using Squirrel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppSquirrelTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UpdateManager manager;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/BouRHooD/WpfAppSquirrelTest");
                CurrentVersionTextBox.Text = manager.CurrentlyInstalledVersion().ToString();
            }
            catch
            {

            }
        }

        private async void CheckForUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (manager == null)
                {
                    manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/BouRHooD/WpfAppSquirrelTest");
                    CurrentVersionTextBox.Text = manager.CurrentlyInstalledVersion().ToString();
                }

                if (string.IsNullOrEmpty(CurrentVersionTextBox.Text))
                {
                    if (manager == null)
                    {
                        manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/BouRHooD/WpfAppSquirrelTest");
                        CurrentVersionTextBox.Text = manager.CurrentlyInstalledVersion().ToString();
                    }
                    else
                    {
                        manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/BouRHooD/WpfAppSquirrelTest");
                        CurrentVersionTextBox.Text = manager.CurrentlyInstalledVersion().ToString();
                    }
                }

                var updateInfo = await manager.CheckForUpdate();

                if (updateInfo.ReleasesToApply.Count > 0)
                {
                    UpdateButton.IsEnabled = true;
                }
                else
                {
                    UpdateButton.IsEnabled = false;
                }
            }
            catch
            {

            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await manager.UpdateApp();

                MessageBox.Show("Updated succesfuly!");
            }
            catch
            {

            }
        }
    }
}
