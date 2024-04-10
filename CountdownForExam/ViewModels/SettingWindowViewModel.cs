using CountdownForExam.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CountdownForExam.ViewModels
{
    public class SettingWindowViewModel : BindableBase
    {

        private readonly IEventAggregator _eventAggregator ;
        private string _ItemDescription;
        public string ItemDescription
        {
            get { return _ItemDescription; }
            set { SetProperty(ref _ItemDescription, value); }
        }

        private DateTime? _SelectedDate;
        public DateTime? SelectedDate
        {
            get { return _SelectedDate; }
            set { SetProperty(ref _SelectedDate, value); }
        }

        private DelegateCommand _SettingCommand;
        public DelegateCommand SettingCommand =>
            _SettingCommand ?? (_SettingCommand = new DelegateCommand(ExecuteSettingCommand));

        void ExecuteSettingCommand()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(ItemDescription,(DateTime)SelectedDate);
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
            _eventAggregator.GetEvent<CloseViewEvent>().Publish();
        }



        public SettingWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            var data = Base.Read();
            if (data == null)
            {
                SelectedDate=DateTime.Now.AddDays(1);
            }
            else
            {
                ItemDescription = data.Description;
                SelectedDate = data.DateTime;
            }
        }
    }

    public class CloseViewEvent : PubSubEvent
    { }
}
