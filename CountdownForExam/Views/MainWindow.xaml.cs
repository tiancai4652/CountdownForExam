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

            // 创建 NotifyIcon
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon("countdown.ico", 32, 32),
                Visible = true,
                Text = "Countdown" // 鼠标悬停时显示的文本
            };

            // 创建右键菜单
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exit", null, (s, e) => { this.Close(); });

            notifyIcon.ContextMenuStrip = contextMenu;

            // 确保在应用程序退出时清理图标
            this.Closed += (s, e) => { notifyIcon.Visible = false; };
        }
    }
}
