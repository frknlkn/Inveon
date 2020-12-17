using System.Configuration; 

namespace Inveon.WEB.Helpers
{
    public static class ReadSettingsHelper
    {
        public static string ImagePath()
        {
            var value = ConfigurationManager.AppSettings["ImagePath"];
            return value ?? string.Empty;
        }
    }
}