package org.charles.weilog.constant;

public class Constants {

    public static final String POST_TITLE  = "title"; // 标题
    public static final String POST_KEYWORDS = "keywords"; // 关键字
    public static final String POST_DESCRIPTION = "description"; // 描述
    public enum PostType {

        POST(1, "POST"),

        PAGE(2, "PAGE");

        PostType(int code, String description) {
            this.code = code;
            this.description = description;
        }

        private final String description;
        private final int code;
    }
}