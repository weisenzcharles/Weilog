using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weilog.Web.Framework.UI
{
    public class ParseMaster
    {
        // used to determine nesting levels  
        Regex GROUPS = new Regex("\\("),
            SUB_REPLACE = new Regex("\\$"),
            INDEXED = new Regex("^\\$\\d+$"),
            ESCAPE = new Regex("\\\\."),
            QUOTE = new Regex("'"),
            DELETED = new Regex("\\x01[^\\x01]*\\x01");

        /// <summary>
        /// Delegate to call when a regular expression is found.  
        /// Use match.Groups[offset + <group number=""/>].Value to get  
        /// the correct subexpression 
        /// </summary>
        /// <param name="match"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public delegate string MatchGroupEvaluator(Match match, int offset);

        private string DELETE(Match match, int offset)
        {
            return "\x01" + match.Groups[offset].Value + "\x01";
        }

        private bool ignoreCase;
        private char escapeChar = '\0';

        ///   
        /// Ignore Case?  
        ///   
        public bool IgnoreCase
        {
            get { return ignoreCase; }
            set { ignoreCase = value; }
        }

        ///   
        /// Escape Character to use  
        ///   
        public char EscapeChar
        {
            get { return escapeChar; }
            set { escapeChar = value; }
        }

        ///   
        /// Add an expression to be deleted  
        ///   
        /// Regular Expression String  
        public void Add(string expression)
        {
            Add(expression, string.Empty);
        }

        ///   
        /// Add an expression to be replaced with the replacement string  
        ///   
        /// Regular Expression String  
        /// Replacement String. Use $1, $2, etc. for groups  
        public void Add(string expression, string replacement)
        {
            if (replacement == string.Empty)
                Add(expression, (object)new MatchGroupEvaluator(DELETE));

            Add(expression, (object)replacement);
        }

        ///   
        /// Add an expression to be replaced using a callback function  
        ///   
        /// Regular expression string  
        /// Callback function  
        public void Add(string expression, MatchGroupEvaluator replacement)
        {
            Add(expression, (object)replacement);
        }

        ///   
        /// Executes the parser  
        ///   
        /// input string  
        /// parsed string  
        public string Exec(string input)
        {
            return DELETED.Replace(Unescape(GetPatterns().Replace(Escape(input), Replacement)), string.Empty);
            //long way for debugging  
            /*input = escape(input); 
            Regex patterns = getPatterns(); 
            input = patterns.Replace(input, new MatchEvaluator(replacement)); 
            input = DELETED.Replace(input, string.Empty); 
            return input;*/
        }

        ArrayList patterns = new ArrayList();
        private void Add(string expression, object replacement)
        {
            Pattern pattern = new Pattern();
            pattern.expression = expression;
            pattern.replacement = replacement;
            //count the number of sub-expressions  
            // - add 1 because each group is itself a sub-expression  
            pattern.length = GROUPS.Matches(InternalEscape(expression)).Count + 1;

            //does the pattern deal with sup-expressions?  
            if (replacement is string && SUB_REPLACE.IsMatch((string)replacement))
            {
                string sreplacement = (string)replacement;
                // a simple lookup (e.g. $2)  
                if (INDEXED.IsMatch(sreplacement))
                {
                    pattern.replacement = int.Parse(sreplacement.Substring(1)) - 1;
                }
            }

            patterns.Add(pattern);
        }

        ///   
        /// builds the patterns into a single regular expression  
        ///   
        ///   
        private Regex GetPatterns()
        {
            StringBuilder rtrn = new StringBuilder(string.Empty);
            foreach (object pattern in patterns)
            {
                rtrn.Append(((Pattern)pattern) + "|");
            }
            rtrn.Remove(rtrn.Length - 1, 1);
            return new Regex(rtrn.ToString(), ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        ///   
        /// Global replacement function. Called once for each match found  
        ///   
        /// Match found  
        private string Replacement(Match match)
        {
            int i = 1, j = 0;
            Pattern pattern;
            //loop through the patterns  
            while (!((pattern = (Pattern)patterns[j++]) == null))
            {
                //do we have a result?  
                if (match.Groups[i].Value != string.Empty)
                {
                    object replacement = pattern.replacement;
                    if (replacement is MatchGroupEvaluator)
                    {
                        return ((MatchGroupEvaluator)replacement)(match, i);
                    }
                    else if (replacement is int)
                    {
                        return match.Groups[(int)replacement + i].Value;
                    }
                    else
                    {
                        //string, send to interpreter  
                        return ReplacementString(match, i, (string)replacement, pattern.length);
                    }
                }
                else //skip over references to sub-expressions  
                    i += pattern.length;
            }
            return match.Value; //should never be hit, but you never know  
        }

        ///   
        /// Replacement function for complicated lookups (e.g. Hello $3 $2)  
        ///   
        private string ReplacementString(Match match, int offset, string replacement, int length)
        {
            while (length > 0)
            {
                replacement = replacement.Replace("$" + length--, match.Groups[offset + length].Value);
            }
            return replacement;
        }

        private StringCollection escaped = new StringCollection();

        //encode escaped characters  
        private string Escape(string str)
        {
            if (escapeChar == '\0')
                return str;
            Regex escaping = new Regex("\\\\(.)");
            return escaping.Replace(str, EscapeMatch);
        }

        private string EscapeMatch(Match match)
        {
            escaped.Add(match.Groups[1].Value);
            return "\\";
        }

        //decode escaped characters  
        private int unescapeIndex;
        private string Unescape(string str)
        {
            if (escapeChar == '\0')
                return str;
            Regex unescaping = new Regex("\\" + escapeChar);
            return unescaping.Replace(str, UnescapeMatch);
        }

        private string UnescapeMatch(Match match)
        {
            return "\\" + escaped[unescapeIndex++];
        }

        private string InternalEscape(string str)
        {
            return ESCAPE.Replace(str, "");
        }

        //subclass for each pattern  
        private class Pattern
        {
            public string expression;
            public object replacement;
            public int length;

            public override string ToString()
            {
                return "(" + expression + ")";
            }
        }
    }
}
