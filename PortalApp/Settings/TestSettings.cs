using AutomationPortal.Constants;
using AutomationPortal.Utils;
using Microsoft.Playwright;

namespace AutomationPortal.Settings
{
    public static class TestSettings
    {

        public static BrowserTypeLaunchOptions BrowserTypeLaunchOptions()
        {
            return new BrowserTypeLaunchOptions
            {
                Headless = bool.Parse(TestContextUtil.GetParameter(Property.HeadlessMode)),
                Channel = TestContextUtil.GetBrowser(),
                Args = new List<string> { "--start-maximized" }
            };
        }

        public static BrowserNewContextOptions BrowserNewContextOptions()
        {
            return new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
                RecordVideoDir = TestContextUtil.GetVideoRecordingDir()
            };
        }
    }
}
