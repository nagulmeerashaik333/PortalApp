using AutomationPortal.GlobalConstants;
using AutomationPortal.Utils;
using Microsoft.Playwright;


namespace AutomationPortal.Settings
{
    /// <summary>
    /// Provides browser and context configuration settings for Playwright-based automation.
    /// </summary>
    public static class TestSettings
    {
        // Cached values to avoid repeated access
        private static readonly bool _headless = GetHeadlessMode();
        private static readonly string _browserChannel = GetBrowserChannel();
        private static readonly string _videoRecordingDir = GetVideoRecordingDir();

        /// <summary>
        /// Returns browser launch options including headless mode, browser channel, and startup args.
        /// </summary>
        public static BrowserTypeLaunchOptions BrowserTypeLaunchOptions()
        {
            Console.WriteLine($"[Info] Launching browser with Headless = {_headless}, Channel = {_browserChannel}");

            return new BrowserTypeLaunchOptions
            {
                Headless = _headless,
                Channel = _browserChannel,
                Args = new List<string>
                {
                    "--start-maximized",
                    "--incognito",
                    "--auth-server-whitelist=\"_\""
                }
            };
        }

        /// <summary>
        /// Returns browser context options including viewport size and video recording directory.
        /// </summary>
        public static BrowserNewContextOptions BrowserNewContextOptions()
        {
            Console.WriteLine($"[Info] Creating new browser context. Video directory: {_videoRecordingDir}");

            return new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
                RecordVideoDir = _videoRecordingDir
            };
        }


        /// <summary>
        /// Parses and returns the HeadlessMode setting from test context.
        /// Defaults to true if not set or invalid.
        /// </summary>
        private static bool GetHeadlessMode()
        {
            var value = TestContextUtil.GetParameter(Property.HeadlessMode);

            if (bool.TryParse(value, out var result))
                return result;

            Console.WriteLine($"[Warning] Invalid 'HeadlessMode' value: '{value}'. Defaulting to 'true'.");
            return true;
        }

        /// <summary>
        /// Validates and returns the browser channel (e.g., chrome, msedge, firefox).
        /// Throws exception if unsupported.
        /// </summary>
        private static string GetBrowserChannel()
        {
            var browser = TestContextUtil.GetBrowser();
            var validBrowsers = new[] { "chrome", "msedge", "firefox" };

            if (validBrowsers.Contains(browser?.ToLower()))
                return browser;

            throw new ArgumentException(
                $"[Error] Unsupported browser specified: '{browser}'. " +
                $"Valid options: {string.Join(", ", validBrowsers)}");
        }

        /// <summary>
        /// Gets the video recording directory. Warns if not provided.
        /// </summary>
        private static string GetVideoRecordingDir()
        {
            var dir = TestContextUtil.GetVideoRecordingDir();

            if (string.IsNullOrWhiteSpace(dir))
            {
                Console.WriteLine("[Warning] Video recording directory is not set. Test runs will not be recorded.");
            }

            return dir;
        }

        //public static string GetEnvironment()
        //{

        //}
    }
}


//using System.Reflection.Metadata.Ecma335;
//using System.Runtime;