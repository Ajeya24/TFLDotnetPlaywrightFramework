using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using TflAutomation.Drivers;


namespace TflAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private BrowserDrivers? browserDriver;

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            this.scenarioContext = scenarioContext;
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            browserDriver = new BrowserDrivers();
            var page = await browserDriver.CreatePageAsync();
            scenarioContext.Set(page);
            objectContainer.RegisterInstanceAs<IPage>(page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (browserDriver != null)
            {
                await browserDriver.DisposeAsync();
            }
        }
    }
}