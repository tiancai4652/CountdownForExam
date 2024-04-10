using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System;


namespace CountdownForExam.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon notifyIcon;
        public MainWindow()
        {
            InitializeComponent();

            notifyIcon = new NotifyIcon
            {
                Icon = new Icon("countdown.ico", 32, 32),
                Visible = true,
                Text = "Countdown" 
            };
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, (s, e) => { this.Close(); });
            notifyIcon.ContextMenuStrip = contextMenu;
            this.Closed += (s, e) => { notifyIcon.Visible = false; };
        }
    }
}
