using System.Configuration;
using System.IO;

namespace Inveon.ADMIN.Helpers
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