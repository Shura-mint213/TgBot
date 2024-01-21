using Microsoft.Extensions.Configuration;
using Shared.Statics;

namespace ReestrBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            // Берем из настроек режим работы 
            Settings.IsTest = configuration.GetValue<bool>("IsTest");
            // Берем из настроек токе ТГ бота
            string botToken = configuration.GetValue<string>("BotToken");
            Settings.BotName = configuration.GetValue<string>("BotName");
            Settings.BotShortDescription = configuration.GetValue<string>("BotShortDescription");
            Settings.BotDescription = configuration.GetValue<string>("BotDescription");
            Engine engine = new Engine(botToken);
            await engine.Start();
        }
    }
}
