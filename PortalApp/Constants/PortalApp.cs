using AutomationPortal.PageObjects;
using Microsoft.Playwright;

namespace AutomationPortal.Constants
{
    public class Portal
    {
        private readonly IPage _page;

        public Portal(IPage page)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
        }

        public LoginPage LoginPage => GetPage<LoginPage>();

        public T GetPage<T>() where T : class
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T), _page)
                    ?? throw new InvalidOperationException($"Could not create an instance of {typeof(T).Name}.");
            }
            catch (MissingMethodException)
            {
                throw new InvalidOperationException(
                    $"{typeof(T).Name} must have a constructor that accepts an IPage.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Failed to create an instance of {typeof(T).Name}.", ex);
            }
        }
    }

}

