
namespace AutomationPortal.Utils
{
    public static class DateUtil
    {

        public static string GetTimeStamp(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
