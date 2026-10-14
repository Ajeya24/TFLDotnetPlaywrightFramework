using Microsoft.Extensions.Configuration;


namespace TflAutomation.Configuration
{
    public class TestConfig
    {
        private readonly IConfiguration config;

        public TestConfig()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public string GetBaseUrl()
        {
            return config.GetSection("BaseUrl").Value 
                   ?? throw new InvalidOperationException("BaseUrl is missing form the config file.");
        }
        
    }
}