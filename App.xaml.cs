using System.Windows;
using XNote.ViewModel;

namespace XNote
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            }.Show();
            
            base.OnStartup(e);
        }
    }
}
