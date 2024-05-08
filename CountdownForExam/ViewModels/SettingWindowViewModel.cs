using CountdownForExam.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotification.Base;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

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


        private string _ReminderDescription;
        public string ReminderDescription
        {
            get { return _ReminderDescription; }
            set { SetProperty(ref _ReminderDescription, value); }
        }

        private DateTime? _SelectedTime;
        public DateTime? SelectedTime
        {
            get { return _SelectedTime; }
            set { SetProperty(ref _SelectedTime, value); }
        }
        void ExecuteSettingCommand()
        {
            //item
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(ItemDescription,(DateTime)SelectedDate);
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();


            //reminder
            if (SelectedTime != null && !string.IsNullOrEmpty(ReminderDescription))
            {
                Task.Factory.StartNew(() =>
                {
                    DateTime now = DateTime.Now;

                    while (true)
                    {
                        if ((DateTime.Now - now).TotalSeconds > new TimeSpan(SelectedTime.Value.Hour, SelectedTime.Value.Minute, SelectedTime.Value.Second).TotalSeconds)
                        {
                            mainWindow.Dispatcher.Invoke(() =>
                            {
                                Notifier.ShowInfo("Reminder", ReminderDescription, false);
                            });
                            now = DateTime.Now;

                        }
                        Thread.Sleep(10 * 1000);
                    }
                });
            }






            _eventAggregator.GetEvent<CloseViewEvent>().Publish();
        }



        public SettingWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            var data = Base.Read();
            if (data == null)
            {
                SelectedDate=DateTime.Now.AddDays(1);
                SelectedTime = null;
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
