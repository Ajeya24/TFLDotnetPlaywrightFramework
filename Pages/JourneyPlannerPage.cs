using TflAutomation.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Polly;
using TflAutomation.Pages;

namespace TflAutomation.Pages
{

    public class JourneyPlannerPage
    {
        private readonly IPage _page;
        private readonly TestConfig _config;
        private readonly JourneyResultsPage _journeyResultsPage;
        

        public JourneyPlannerPage(IPage page, TestConfig config, JourneyResultsPage journeyResultsPage)
        {
            _page = page;
            _config = config;
            _journeyResultsPage = journeyResultsPage;
        }

        public async Task NavigateToJourneyPlannerURLAsync()
        {
            var baseUrl = _config.GetBaseUrl();
            await _page.GotoAsync(baseUrl);
            
        }

        private ILocator AcceptCookiesButton => _page.GetByRole(AriaRole.Button, new() {Name = "Accept all cookies"});
        private ILocator FromLocationInput => _page.GetByPlaceholder("From");
        private ILocator ToLocationInput => _page.Locator("[placeholder='To']");
        private ILocator SelectFromLocation => _page.Locator("[data-id ='940GZZLULSQ']");
        private ILocator SelectToLocation => _page.Locator("[data-id ='940GZZLUCGN']");
        
        private ILocator InvalidSelectFromLocation => _page.Locator("[data-id ='ChIJLQCJCbJydkgRpyf7PuFFSYE']");
        
        private ILocator InvalidSelectToLocation => _page.Locator("[data-id ='ChIJkXynszghj0gRhkgKycP2GB4']");
        
        private ILocator PlanMyJourneyButton => _page.GetByRole(AriaRole.Button, new() { Name = "Plan my journey" });

        private ILocator FromFieldErrorMessage => _page.GetByText("The From field is required.");
        
        private ILocator ToFieldErrorMessage => _page.GetByText("The To field is required.");
        
        
        public async Task AcceptCookieAsync()
        {
            await AcceptCookiesButton.ClickAsync(new() { Timeout = 5000 });
        }
        [Retry(3)]
        public async Task PlanAJourneyAsync(string fromLocation, string toLocation)
        {   
            await FromLocationInput.FillAsync(fromLocation);
            await SelectFromLocation.ClickAsync(new() { Timeout = 5000 });
            await ToLocationInput.FillAsync(toLocation,new() { Timeout = 5000 });
            await SelectToLocation.ClickAsync(new() { Timeout = 5000 });
            await PlanMyJourneyButton.ClickAsync();
            
        }
        [Retry(3)]
        public async Task PlanAnInvalidJourneyAsync(string fromLocation, string toLocation)
        {
            await FromLocationInput.FillAsync(fromLocation);
            await InvalidSelectFromLocation.ClickAsync(new() { Timeout = 5000 });
            await ToLocationInput.FillAsync(toLocation,new() { Timeout = 5000 });
            await PlanMyJourneyButton.ClickAsync();
            
        }
        
        public async Task NoJourneyAsync()
        {
            await PlanMyJourneyButton.ClickAsync();
        }
        //Method to validate the appropriate error message is displayed when the user does not enter any locations in the From and To fields
        public async Task ValidateApprpriateErrorMessageAsync()
        {
            await Assertions.Expect(FromFieldErrorMessage).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(FromFieldErrorMessage).ToHaveTextAsync("The From field is required.", new() { Timeout = 5000 });
            await Assertions.Expect(ToFieldErrorMessage).ToBeVisibleAsync(new() { Timeout = 5000 });
            await Assertions.Expect(ToFieldErrorMessage).ToHaveTextAsync("The To field is required.", new() { Timeout = 5000 });
        }
        
    }
}
    