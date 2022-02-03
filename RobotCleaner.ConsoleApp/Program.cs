using Microsoft.Extensions.DependencyInjection;
using RobotCleaner.ConsoleApp.Helpers;
using RobotCleaner.ConsoleApp.Helpers.Interfaces;
using RobotCleaner.ConsoleApp.Implementations;
using RobotCleaner.Domain.Implementations;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.ServiceLibrary.Implementations;
using RobotCleaner.ServiceLibrary.Interfaces;

namespace RobotCleaner.ConsoleApp

{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            services
                .AddSingleton<InputConsole, InputConsole>()
                .BuildServiceProvider()
                .GetService<InputConsole>()
                .StartRobotCleanerAppAsync();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IUserLibrary, UserLibrary>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<IRobotLibrary, RobotLibrary>()
                .AddSingleton<IRobotService, RobotService>()
                .AddSingleton<IConsole, ConsoleWrapper>();
        }
    }
}
