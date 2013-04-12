namespace StudioDonder.HelloGeneticAlgorithm.Website.Helpers
{
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;

    public static class LocalizationHelpers
    {
        public static IHtmlString MetaAcceptLanguage(this HtmlHelper html)
        {
            var acceptLanguage = HttpUtility.HtmlAttributeEncode(Thread.CurrentThread.CurrentUICulture.ToString());
            return new HtmlString(string.Format("<meta name=\"accept-language\" content=\"{0}\">", acceptLanguage));
        }
    }
}