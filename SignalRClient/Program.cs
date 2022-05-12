using Autofac;
using SignalRClient.Service;
using SignalRClient.SignalR;
using SignalRClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRClient
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(CompositionRoot().Resolve<MainForm>());
        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainForm>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<SignalRService>().As<ISignalRService>().InstancePerLifetimeScope();
            builder.RegisterType<SignalRClientHandlerBuilder>();

            return builder.Build();
        }
    }
}
