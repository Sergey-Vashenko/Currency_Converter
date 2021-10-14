using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Currency_Converter
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int idSelectCur;
        Converter convert;
        public MainPage()
        {
            this.InitializeComponent();
            convert = new Converter();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            convert.setCurrency1(LoadDatePage.getListCurrencies().First());
            convert.setCurrency2(LoadDatePage.getListCurrencies().First());
            lCurrency1.Text = LoadDatePage.getListCurrencies().First().getCharCode();
            lCurrency2.Text = LoadDatePage.getListCurrencies().First().getCharCode();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
                return;
            if (Frame.BackStack.Last().SourcePageType == typeof(ListCurrencies))
                if (idSelectCur == 1)
                {
                    convert.setCurrency1((Currency)e.Parameter);
                    lCurrency1.Text = ((Currency)e.Parameter).getCharCode();
                    lValueCur1.Text = convert.calcValue(float.Parse(lValueCur2.Text), idSelectCur + 1).ToString();
                }
                else if (idSelectCur == 2)
                {
                    convert.setCurrency2((Currency)e.Parameter);
                    lCurrency2.Text = ((Currency)e.Parameter).getCharCode();
                    lValueCur2.Text = convert.calcValue(float.Parse(lValueCur1.Text), idSelectCur - 1).ToString();
                }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idSelectCur = Convert.ToInt32(((Button)sender).Tag);
            this.Frame.Navigate(typeof(ListCurrencies), idSelectCur);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int idChangCur = Convert.ToInt32(((TextBox)sender).Tag);
            try
            {

                if (idChangCur == 1)
                    lValueCur2.Text = convert.calcValue(float.Parse(lValueCur1.Text), idChangCur).ToString();
                else if (idChangCur == 2)
                    lValueCur1.Text = convert.calcValue(float.Parse(lValueCur2.Text), idChangCur).ToString();
            }
            catch (Exception) 
            {
                var message = new MessageDialog("Неверное выражение");
                message.ShowAsync();
                return;
            }
        }
    }
}
