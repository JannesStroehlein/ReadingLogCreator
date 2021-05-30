using HandyControl.Data;
using HandyControl.Tools;
using System;
using System.IO;
using System.Windows;

namespace ReadingLogCreator.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string SaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ReadingLogCreator";
            if (!Directory.Exists(SaveDirectory))
                Directory.CreateDirectory(SaveDirectory);

            base.OnStartup(e);

            MainWindow window = new MainWindow();

            // Create the ViewModel to which 
            // the main window binds.
            var viewModel = new MainWindowViewModel();

            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            window.DataContext = viewModel;

            ConfigHelper.Instance.SetLang("en");
            this.UpdateSkin(SkinType.Dark);

            window.Show();
        }
        internal void UpdateSkin(SkinType skin)
        {
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/HandyControl;component/Themes/Skin{skin.ToString()}.xaml")
            });
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });
        }
    }
}
