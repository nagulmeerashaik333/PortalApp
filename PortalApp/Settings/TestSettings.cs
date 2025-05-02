using AutomationPortal.Constants;
using AutomationPortal.Utils;
using Microsoft.Playwright;


namespace AutomationPortal.Settings
{
    public static class TestSettings
    {
        // Cached values to avoid repeated access
        private static readonly bool _headless = GetHeadlessMode();
        private static readonly string _browserChannel = GetBrowserChannel();
        private static readonly string _videoRecordingDir = GetVideoRecordingDir();

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

        public static BrowserNewContextOptions BrowserNewContextOptions()
        {
            Console.WriteLine($"[Info] Creating new browser context. Video directory: {_videoRecordingDir}");

            return new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
                RecordVideoDir = _videoRecordingDir
            };
        }

        private static bool GetHeadlessMode()
        {
            var value = TestContextUtil.GetParameter(Property.HeadlessMode);

            if (bool.TryParse(value, out var result))
                return result;

            Console.WriteLine($"[Warning] Invalid 'HeadlessMode' value: '{value}'. Defaulting to 'true'.");
            return true;
        }

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

        private static string GetVideoRecordingDir()
        {
            var dir = TestContextUtil.GetVideoRecordingDir();

            if (string.IsNullOrWhiteSpace(dir))
            {
                Console.WriteLine("[Warning] Video recording directory is not set. Test runs will not be recorded.");
            }

            return dir;
        }
    }
}