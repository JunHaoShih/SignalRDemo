using Autofac;
using SignalRClient.Presenter;
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

            var mainPresenter = CompositionRoot().Resolve<IMainPresenter>();

            Application.Run(mainPresenter.GetForm());
        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainForm>().As<IMainForm>();
            builder.RegisterType<MainPresenter>().As<IMainPresenter>();
            builder.RegisterType<SignalRClientHandlerBuilder>();

            return builder.Build();
        }
    }
}
