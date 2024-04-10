using CountdownForExam.Views;
using Prism.Events;
using Prism.Ioc;
using System.ComponentModel;
using System.Windows;

namespace CountdownForExam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<SettingWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IEventAggregator, EventAggregator>();

        }
    }
}
