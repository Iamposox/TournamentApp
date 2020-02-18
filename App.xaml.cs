using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Tournaments.WPF
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceContainer;
        public App()
        {
            IServiceCollection col = new ServiceCollection();
            ConfigService(col);
            ServiceContainer = col.BuildServiceProvider();
        }

        private void ConfigService(IServiceCollection _services)
        {
            _services.AddSingleton<Manager.StateManager>();
        }
    }
}
