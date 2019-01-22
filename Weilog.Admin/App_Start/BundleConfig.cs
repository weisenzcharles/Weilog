using System;
using System.Web;
using System.Web.Optimization;
using Weilog.Web.Framework.UI;

namespace Weilog.Admin
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //重新处理bundle忽略资源的规则
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            #region JS

            // 控制面板通用 js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/BaseScripts").Include(
                "~/Content/js/jquery-1.10.2.min.js",
                "~/Content/js/jquery-migrate.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/modernizr.min.js",
                "~/Content/js/jquery.nicescroll.js",
                "~/Content/js/slidebars.min.js",
                "~/Content/js/switchery/switchery.min.js",
                "~/Content/js/switchery/switchery-init.js",
                "~/Content/js/sparkline/jquery.sparkline.js",
                "~/Content/js/sparkline/sparkline-init.js",
                "~/Content/js/jquery.validate.min.js",
                "~/Content/js/json2.js",
                "~/Content/js/scripts.js"));

            bundles.Add(new WeilogScriptBundle("~/Content/JS/Layer/BaseLayer").Include(
                "~/Content/js/layer/layer.js"));

            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/JuCheap").Include(
                "~/Content/js/jucheap.js"));

            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/JuCheapMenu").Include(
                "~/Content/js/jucheap.menu.js"));



            // DataTable
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/DataTable").Include(
                "~/Content/js/data-table/js/jquery.dataTables.min.js",
                "~/Content/js/data-table/js/dataTables.tableTools.min.js",
                "~/Content/js/data-table/js/bootstrap-dataTable.js",
                "~/Content/js/data-table/js/dataTables.colVis.min.js",
                "~/Content/js/data-table/js/dataTables.responsive.min.js",
                "~/Content/js/data-table/js/dataTables.scroller.min.js",
                "~/Content/js/jucheap.tables.js"));

            // DataTable Demo Page
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/DataTableDemo").Include(
                "~/Content/js/data-table/js/jquery.dataTables.min.js",
                "~/Content/js/data-table/js/dataTables.tableTools.min.js",
                "~/Content/js/data-table/js/bootstrap-dataTable.js",
                "~/Content/js/data-table/js/dataTables.colVis.min.js",
                "~/Content/js/data-table/js/dataTables.responsive.min.js",
                "~/Content/js/data-table/js/dataTables.scroller.min.js",
                "~/Content/js/data-table-init.js"));

            // tree
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/Tree").Include(
                "~/Content/js/fuelux/js/tree.min.js"));

            // login page
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/Login").Include(
                "~/Content/js/jquery-1.10.2.min.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/jquery.validate.min.js",
                "~/Content/js/jucheap.login.valid.js"));

            // select2 js
            bundles.Add(new ScriptBundle("~/JS/Admin/jucheap/Select").Include(
                "~/Content/js/select2.js",
                "~/Content/js/select2-init.js"));

            // nesttable js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/Nestable").Include(
                "~/Content/js/nestable/jquery.nestable.js"));

            // tagsinput js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/Tags").Include(
                "~/Content/js/tags-input.js",
                "~/Content/js/tags-input-init.js"));

            // fileinput js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/File").Include(
                "~/Content/js/bootstrap-fileinput-master/js/fileinput.js",
                "~/Content/js/file-input-init.js"));

            // email js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/Email").Include(
                "~/Content/js/bootstrap-wysihtml5/wysihtml5-0.3.0.js",
                "~/Content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Content/js/bootstrap-fileinput-master/js/fileinput.js",
                "~/Content/js/file-input-init.js"));

            // editor js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/Editor").Include(
                "~/Content/js/bootstrap-wysihtml5/wysihtml5-0.3.0.js",
                "~/Content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Content/js/summernote/dist/summernote.min.js"));

            // icheck js
            bundles.Add(new WeilogScriptBundle("~/JS/Admin/jucheap/FormValidate").Include(
                "~/Content/js/jquery.validate.min.js",
                "~/Content/js/form-validation-init.js",
                "~/Content/js/icheck/skins/icheck.min.js"));

            // Advance demo js
            bundles.Add(new ScriptBundle("~/JS/Admin/jucheap/Advance").Include(
                "~/Content/js/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Content/js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                "~/Content/js/bootstrap-daterangepicker/moment.min.js",
                "~/Content/js/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/js/bootstrap-colorpicker/js/bootstrap-colorpicker.js",
                "~/Content/js/bootstrap-timepicker/js/bootstrap-timepicker.js",
                "~/Content/js/picker-init.js",
                "~/Content/js/icheck/skins/icheck.min.js",
                "~/Content/js/icheck-init.js",
                "~/Content/js/tags-input.js",
                "~/Content/js/tags-input-init.js",
                "~/Content/js/touchspin.js",
                "~/Content/js/spinner-init.js",
                "~/Content/js/dropzone.js",
                "~/Content/js/select2.js",
                "~/Content/js/select2-init.js"));

            // flot chart demo
            bundles.Add(new ScriptBundle("~/JS/Admin/jucheap/Chart").Include(
                "~/Content/js/sparkline/jquery.sparkline.js",
                "~/Content/js/sparkline/sparkline-init.js",
                "~/Content/js/flot-chart/jquery.flot.js",
                "~/Content/js/flot-chart/jquery.flot.resize.js",
                "~/Content/js/flot-chart/jquery.flot.tooltip.min.js",
                "~/Content/js/flot-chart/jquery.flot.pie.js",
                "~/Content/js/flot-chart/jquery.flot.selection.js",
                "~/Content/js/flot-chart/jquery.flot.selection.js",
                "~/Content/js/flot-chart/jquery.flot.stack.js",
                "~/Content/js/flot-chart/jquery.flot.crosshair.js",
                "~/Content/js/flot-chart-init.js"));

            // morris chart demo
            bundles.Add(new ScriptBundle("~/JS/Admin/jucheap/ChartMorris").Include(
                "~/Content/js/morris-chart/morris.js",
                "~/Content/js/morris-chart/raphael-min.js",
                "~/Content/js/morris-init.js"));

            // chartjs demo
            bundles.Add(new ScriptBundle("~/JS/Admin/jucheap/ChartJs").Include(
                "~/Content/js/chart-js/chart.js",
                "~/Content/js/chartJs-init.js"));

            bundles.Add(new WeilogScriptBundle("~/JS/Front/Web/Home").Include(
                "~/Content/front/web/js/jquery.js",
                "~/Content/front/web/js/bootstrap.min.js",
                "~/Content/front/web/js/jquery.prettyPhoto.js",
                "~/Content/front/web/js/jquery.isotope.min.js",
                "~/Content/front/web/js/main.js",
                "~/Content/front/web/js/wow.min.js"));

            #endregion

            #region CSS

            // Base Styles
            bundles.Add(new StyleBundle("~/Content/Css/BaseStyles").Include(
                "~/Content/css/style.css",
                "~/Content/css/style-responsive.css"));

            // Data Table
            bundles.Add(new StyleBundle("~/Content/Css/DataTable").Include(
                "~/Content/js/data-table/css/jquery.dataTables.css",
                "~/Content/js/data-table/css/dataTables.tableTools.css",
                "~/Content/js/data-table/css/dataTables.colVis.min.css",
                "~/Content/js/data-table/css/dataTables.responsive.css",
                "~/Content/js/data-table/css/dataTables.scroller.css"));

            // tree
            bundles.Add(new StyleBundle("~/Content/Css/TreeStyle").Include(
                "~/Content/js/fuelux/css/tree-style.css"));

            // select2
            bundles.Add(new StyleBundle("~/Content/Css/SelectStyle").Include(
                "~/Content/css/select2.css",
                "~/Content/css/select2-bootstrap.css"));

            // Nestable
            bundles.Add(new StyleBundle("~/Content/Css/Nestable").Include(
                "~/Content/js/nestable/jquery.nestable.css"));
            // Tagsinput
            bundles.Add(new StyleBundle("~/Content/Css/Tags").Include(
                "~/Content/css/tagsinput.css"));

            // FileInput
            bundles.Add(new StyleBundle("~/Content/Css/File").Include(
                "~/Content/js/bootstrap-fileinput-master/css/fileinput.css"));

            // Email
            bundles.Add(new StyleBundle("~/Content/Css/Email").Include(
                "~/Content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.css",
                "~/Content/js/bootstrap-fileinput-master/css/fileinput.css"));

            // Editor
            bundles.Add(new StyleBundle("~/Content/Css/Editor").Include(
                "~/Content/js/summernote/dist/summernote.css",
                "~/Content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.css"));

            // icheck Demo
            bundles.Add(new StyleBundle("~/Content/Css/FormValidate").Include(
                "~/Content/js/icheck/skins/all.css"));

            // morris chart Demo
            bundles.Add(new StyleBundle("~/Content/Css/ChartMorris").Include(
                "~/Content/js/morris-chart/morris.css"));

            // Advance Demo
            bundles.Add(new StyleBundle("~/Content/Css/Advance").Include(
                "~/Content/js/icheck/skins/all.css",
                "~/Content/css/tagsinput.css",
                //"~/Content/css/dropzone.css",
                "~/Content/css/select2.css",
                "~/Content/css/select2-bootstrap.css",
                "~/Content/css/bootstrap-touchspin.css",
                "~/Content/js/bootstrap-datepicker/css/datepicker.css",
                "~/Content/js/bootstrap-timepicker/compiled/timepicker.css",
                "~/Content/js/bootstrap-colorpicker/css/colorpicker.css",
                "~/Content/js/bootstrap-daterangepicker/daterangepicker-bs3.css",
                "~/Content/js/bootstrap-datetimepicker/css/datetimepicker.css"));

            // front web/index
            bundles.Add(new StyleBundle("~/css/front/web/home").Include(
                "~/Content/front/web/css/bootstrap.min.css",
                "~/Content/front/web/css/font-awesome.min.css",
                "~/Content/front/web/css/animate.min.css",
                "~/Content/front/web/css/prettyPhoto.css",
                "~/Content/front/web/css/main.css",
                "~/Content/front/web/css/responsive.css"));

            #endregion

            // BundleTable.EnableOptimizations = true;强制启用压缩
        }
        /// <summary>
        /// 添加 bundle 需要忽略的表达式的资源。
        /// </summary>
        /// <param name="ignoreList">忽略的资源列表。</param>
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException(nameof(ignoreList));

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            // ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            // ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}
