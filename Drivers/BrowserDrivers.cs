using Microsoft.Playwright;

namespace TflAutomation.Drivers
{
    public class BrowserDrivers
    {
        private IPlaywright? playwright;
        private IBrowser? browser;

        public async Task<IPage> CreatePageAsync()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new[] { "--window-size=1512,894", "--window-position=0,33" }
            });
           
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });
         //   var context = await browser.NewContextAsync();
            return await context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            if(browser != null)
            {
                await browser.CloseAsync();
            }
            playwright?.Dispose();
        }
    }
}