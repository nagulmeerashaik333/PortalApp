using AutomationPortal.Constants;
using NUnit.Framework;
using System.Reflection;


namespace AutomationPortal.Utils
{
    public static class TestContextUtil
    {
        public static string GetProjectRootDir()
        {
            string executingPath = Assembly.GetExecutingAssembly().Location;
            var rootDir = Directory.GetParent(executingPath)?.Parent?.Parent?.FullName;

            if (rootDir == null)
            {
                throw new InvalidOperationException("Failed to find project root directory.");
            }

            return rootDir;
        }

        public static string GetVideoRecordingDir()
        {
            string givenPath = GetParameter(Property.RecordingVideosDir);
            if (string.IsNullOrWhiteSpace(givenPath))
            {
                return string.Empty;
            }

            return Path.Combine(GetProjectRootDir(), givenPath);
        }

        public static string GetParameter(string parameter)
        {
            string value = TestContext.Parameters[parameter];
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        public static string GetBrowser()
        {
            string? browserName = TestContext.CurrentContext.Test.Properties.Get("browser") as string;

            if (string.IsNullOrWhiteSpace(browserName))
            {
                browserName = GetParameter(Property.BrowserType);
            }

            return string.IsNullOrWhiteSpace(browserName) ? "chrome" : browserName; //default
        }
    }
}
