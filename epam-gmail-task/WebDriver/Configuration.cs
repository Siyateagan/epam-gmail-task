using System.Configuration;


namespace epam_gmail_task.WebDriver
{
    public class Configuration
    {
        public static string GetEnviromentVar(string var, string defautlValue) =>
            ConfigurationManager.AppSettings[var] ?? defautlValue;

        public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "30");

        public static string Browser => GetEnviromentVar("Browser", "Chrome");

        public static string StartUrl => GetEnviromentVar("StartUrl", "https://www.google.com/intl/ru/gmail/about/");
    }
}