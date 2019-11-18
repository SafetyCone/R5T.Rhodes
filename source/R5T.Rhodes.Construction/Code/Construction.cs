using System;
using System.IO;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace R5T.Rhodes.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            Construction.SearchGoogle();
        }

        private static void SearchGoogle()
        {
            Construction.AddChromeDriverExeToPath();

            var url = "http://www.github.com";

            var driver = new ChromeDriver
            {
                Url = url
            };
            // If chromedriver.exe is not added to the PATH, then you get: OpenQA.Selenium.DriverServiceNotFoundException: Message = The chromedriver.exe file does not exist in the current directory or in a directory on the PATH environment variable. The driver can be downloaded at http://chromedriver.storage.googleapis.com/index.html.

            driver.Quit();
        }

        private static void AddChromeDriverExeToPath()
        {
            var chromeDriverExeDirectoryPath = Construction.GetChromeDriverExeDirectoryPath();

            var path = Environment.GetEnvironmentVariable("PATH");

            var newPath = path + Path.PathSeparator + chromeDriverExeDirectoryPath;

            Environment.SetEnvironmentVariable("PATH", newPath);
        }

        private static string GetChromeDriverExeDirectoryPath()
        {
            var directoryPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Downloads/chromedriver_win32";
            return directoryPath;
        }
    }
}
