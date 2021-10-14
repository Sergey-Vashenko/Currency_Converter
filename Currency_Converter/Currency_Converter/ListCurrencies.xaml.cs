using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Currency_Converter
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ListCurrencies: Page
    {
        public ListCurrencies()
        {
            this.InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
                Windows.UI.Core.AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            NavigationCacheMode = NavigationCacheMode.Enabled;
            List<Currency> listCurrency = LoadDatePage.getListCurrencies();
            listCur.ItemsSource = listCurrency;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
            this.Frame.Navigate(typeof(MainPage), listCur.SelectedItem);
        }
        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true; 
            }
        }
    }
}
