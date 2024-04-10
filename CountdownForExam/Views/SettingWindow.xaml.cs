using CountdownForExam.ViewModels;
using MahApps.Metro.Controls;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CountdownForExam.Views
{
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : MetroWindow
    {
        private readonly IEventAggregator _eventAggregator;
        public SettingWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<CloseViewEvent>().Subscribe(CloseView);
        }
        private void CloseView()
        {
            this.Close();
        }
    }
}
