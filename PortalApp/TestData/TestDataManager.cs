using Microsoft.Playwright;
using Newtonsoft.Json;

namespace AutomationPortal.TestData
{
    public  class TestDataManager
    {
        public static T GetTestData<T>(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException($"Test data file not found at path {fullPath}");
                }
                var jsonData = File.ReadAllText(fullPath);

                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading test data: {ex.Message}");
                throw;
            }
        }

        public class OnboardingPageDetails
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }

        }
        public class Data
        {
            public OnboardingPageDetails OnboardingDetails { get; set; }
        }
    }
}
