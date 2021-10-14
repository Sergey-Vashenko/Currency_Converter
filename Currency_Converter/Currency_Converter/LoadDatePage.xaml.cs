using Newtonsoft.Json.Linq;
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
using Newtonsoft.Json;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Currency_Converter
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LoadDatePage : Page
    {
        private static List<Currency> listCurrency;
        public LoadDatePage()
        {
            listCurrency = new List<Currency>();
            this.InitializeComponent();
            System.Net.WebClient webClient = new System.Net.WebClient();
            string jsonText = webClient.DownloadString("https://www.cbr-xml-daily.ru/daily_json.js");
            List<JToken> listJChildren = JObject.Parse(jsonText)["Valute"].Children().ToList();
            listJChildren.ForEach(delegate (JToken valute)
            {
                listCurrency.Add(new Currency(valute.Children().ToArray().First()));
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            Frame.Navigate(typeof(MainPage));
        }

        public static List<Currency> getListCurrencies()
        {
            return listCurrency;
        }
    }
}
