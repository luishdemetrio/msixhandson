using CustomerList.WPF.ViewModels;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using Windows.UI.Xaml.Controls;

namespace CustomerList.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public CustomerListPageViewModel ViewModel { get; set; } = new CustomerListPageViewModel();

        public MainWindow()
        {
            InitializeComponent();
           

            DataContext = ViewModel;
            DG1.Items.Refresh();

            if (ViewModel.CheckForUpdates ==false)
                menuAutoUpdate.Visibility = System.Windows.Visibility.Collapsed;
        }

      

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void AppBarUpdateButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

      
        private void menuItemClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
