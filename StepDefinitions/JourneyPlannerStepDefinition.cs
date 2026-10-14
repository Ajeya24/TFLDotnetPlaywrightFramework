using Microsoft.Playwright;
using Reqnroll;
using TflAutomation.Pages;

namespace TflAutomation.StepDefinitions
{
    [Binding]
public class JourneyPlannerStepDefinition
{
    private readonly IPage _page;
    private readonly JourneyPlannerPage _journeyPlannerPage;
    private readonly JourneyResultsPage _journeyResultsPage;
    
    
    
    public JourneyPlannerStepDefinition(IPage page, JourneyPlannerPage journeyPlannerPage, JourneyResultsPage journeyResultsPage)
    {
        _page = page;
        _journeyPlannerPage = journeyPlannerPage;
        _journeyResultsPage = journeyResultsPage;
    }


    [Given("User launches the TFL Journey Planner application")]
    public async Task GivenUserLaunchesTheTflJourneyPlannerApplication()
    {
          await _journeyPlannerPage.NavigateToJourneyPlannerURLAsync();
          await _journeyPlannerPage.AcceptCookieAsync();
          
    }

    [When("User enters the {string} and {string} locations")]
    public async Task WhenUserEntersTheAndLocations(string From, string To)
    {
        await _journeyPlannerPage.PlanAJourneyAsync(From, To);
        
    }

    [Then("validate that journey results page is displayed")]
    public async Task ThenValidateThatJourneyResultsPageIsDisplayed()
    {
        
        await _journeyResultsPage.DisplayJourneyResultsPage();
        
    }

    [When("User clicks on EditPreferences Link")]
    public async Task WhenUserClicksOnEditPreferencesLink()
    {
        await _journeyResultsPage.ClickOnEditPreferencesLinkAsync();
    }

    [When("User selects the route with least walking option")]
    public async Task WhenUserSelectsTheRouteWithLeastWalkingOption()
    {
        await _journeyResultsPage.SelectRouteWithLeastWalkingOptionAsync();
        
    }

    [When("User clicks on Update Journey button")]
    public async Task WhenUserClicksOnUpdateJourneyButton()
    {
       await _journeyResultsPage.ClickOnUpdateJourneyButtonAsync();
      
    }

    [Then("User validates that the journey results page is displayed with least walking route")]
    public async Task ThenUserValidatesThatTheJourneyResultsPageIsDisplayedWithLeastWalkingRoute()
    {
        await _journeyResultsPage.IsViewDetailsButtonDisplayedAsync();
    }

    [When("User clicks on View Details button")]
    public async Task WhenUserClicksOnViewDetailsButton()
    {
        await _journeyResultsPage.ClickOnViewDetailsButtonAsync();
    }

    [Then("User validates complete access information is displayed for Covent Garden Station")]
    public async Task ThenUserValidatesCompleteAccessInformationIsDisplayedForCoventGardenStation()
    {
        await _journeyResultsPage.VerifyCompleteAccessInformationAtCoventGardenStationAsync();
    }

    [Then("validate that an error message is displayed")]
    public async Task ThenValidateThatAnErrorMessageIsDisplayed()
    {
        await _journeyResultsPage.ValidateErrorMessageIsDisplayedAsync();
    }

    [When("User enters invalid {string} and {string} locations")]
    public async Task WhenUserEntersInvalidAndLocations(string From, string To)
    {
       await _journeyPlannerPage.PlanAnInvalidJourneyAsync(From, To);
    }

    [When("User clicks on Plan My Journey button")]
    public async Task WhenUserClicksOnPlanMyJourneyButton()
    {
        await _journeyPlannerPage.NoJourneyAsync();
    }

    [Then("User validates the apprpriate error messages are displayed on the widget")]
    public async Task ThenUserValidatesTheApprpriateErrorMessagesAreDisplayedOnTheWidget()
    {
        await _journeyPlannerPage.ValidateApprpriateErrorMessageAsync();
    }
}

}