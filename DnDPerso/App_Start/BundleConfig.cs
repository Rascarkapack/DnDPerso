using System.Web;
using System.Web.Optimization;

namespace DnDPerso
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Common functions
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Views").Include("~/Scripts/Views/Common.js", "~/Scripts/Views/DnDAutoComplete.js"));

            //Login
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Views/Login").Include("~/Scripts/Views/Login/Login.js"));

            // Home
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Views/Home").Include("~/Scripts/Views/Home/Home.js"));

            // Pouvoir
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Views/Pouvoir").Include("~/Scripts/Views/Pouvoir/Pouvoir.js"));
        }
    }
}
