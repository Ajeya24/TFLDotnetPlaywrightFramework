using TflAutomation.Configuration;
using Microsoft.Playwright;
using Polly;

namespace TflAutomation.Pages
{
    public class JourneyResultsPage
    {
        private readonly IPage _page;
        private readonly TestConfig _config;
        
        
        public JourneyResultsPage(IPage page, TestConfig config)
        {
            _page = page;
            _config = config;
        }

        private ILocator JourneyResultsLabel => _page.GetByRole(AriaRole.Heading, new() { Name = "Walking and cycling" });
        private ILocator EditPreferencesLink => _page.GetByRole(AriaRole.Button, new() { Name = "Edit preferences" });
        private ILocator RouteWithLeastWalkingOption => _page.Locator("//*[contains(text(),'Routes with least walking')]");
        private ILocator UpdateJourneyButton => _page.GetByRole(AriaRole.Button, new() { Name = "Update journey" });
        private ILocator ViewDetailsButton => _page.Locator("(//*[contains(text(),'View details')])[1]");
        
        private ILocator UpStairsAccessInformationIcon => _page.GetByRole(AriaRole.Link, new() { Name = "Up stairs" });
        
        private ILocator UpStairsAccessInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Up stairs" });
        
        private ILocator UpLiftsAccessInformationIcon => _page.GetByRole(AriaRole.Link, new() { Name = "Up lift" });
        private ILocator UpLiftsAccessInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Up lift" });
        
        private ILocator LevelWalkwayAccessInformationIcon => _page.GetByRole(AriaRole.Link, new() { Name = "Level walkway" });
        
        private ILocator LevelWalkwayAccessInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Level walkway" });
        
        private ILocator FieldValidationErrorMessage => _page.Locator("(//*[contains(text(),'We found more than one location matching ')])[1]");
        
        // Method to verify that the journey results page is displayed
        public async Task DisplayJourneyResultsPage()
        {
            await Assertions.Expect(JourneyResultsLabel).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(JourneyResultsLabel).ToHaveTextAsync("Walking and cycling", new() { Timeout = 5000 });
        }

        public async Task ClickOnEditPreferencesLinkAsync()
        {
            await EditPreferencesLink.ClickAsync(new() { Timeout = 5000 });
        }
        
        public async Task SelectRouteWithLeastWalkingOptionAsync()
        {
           await RouteWithLeastWalkingOption.ClickAsync(new() { Timeout = 5000 });
        }

        public async Task ClickOnUpdateJourneyButtonAsync()
        {
            await UpdateJourneyButton.ClickAsync(new() { Timeout = 5000 });
        }
        //Method to verify the view details button is displayed on the journey results page
        //with the text "View details"
        public async Task IsViewDetailsButtonDisplayedAsync()
        {
            await Assertions.Expect(ViewDetailsButton).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(ViewDetailsButton).ToHaveTextAsync("View details", new() { Timeout = 5000 });
        }

        public async Task ClickOnViewDetailsButtonAsync()
        {
            await ViewDetailsButton.ClickAsync(new() { Timeout = 5000 });
        }
        
        // Method to verify complete access information at Covent Garden Station
        public async Task VerifyCompleteAccessInformationAtCoventGardenStationAsync()
        {
            await UpStairsAccessInformationIcon.ClickAsync();
            await Assertions.Expect(UpStairsAccessInformation).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(UpStairsAccessInformation).ToHaveTextAsync("Up stairs", new() { Timeout = 5000 });
          
            await UpLiftsAccessInformationIcon.ClickAsync();
            await Assertions.Expect(UpLiftsAccessInformation).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(UpLiftsAccessInformation).ToHaveTextAsync("Up lift", new() { Timeout = 5000 });
            
            await LevelWalkwayAccessInformationIcon.ClickAsync();
            await Assertions.Expect(LevelWalkwayAccessInformation).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(LevelWalkwayAccessInformation).ToHaveTextAsync("Level walkway", new() { Timeout = 5000 });
            
        }
        //Method to validate that Walking and Running Details are not displayed on the journey results page when user enters invalid locations
        public async Task ValidateErrorMessageIsDisplayedAsync()
        {
          await Assertions.Expect(JourneyResultsLabel).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }
        
    }
}
