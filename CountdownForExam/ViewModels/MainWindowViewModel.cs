using CountdownForExam.Views;
using Prism.Mvvm;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CountdownForExam.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { SetProperty(ref _Text, value); }
        }

        public MainWindowViewModel()
        {
            var target = new DateTime(2024, 5, 24);
            Text = (target - DateTime.Now).TotalDays.ToString();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000 /** 60 * 60*/);
                    Text = (target - DateTime.Now).TotalDays.ToString();
                }
            });
        }
    }
}
