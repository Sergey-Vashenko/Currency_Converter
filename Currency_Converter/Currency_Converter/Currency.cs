using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    public class Currency
    {
        private string id;
        private int numCod;
        public string charCode;
        private int nominal;
        public string name;
        private float value;
        private float previous;

        public Currency(JToken data)
        {
            id = data["ID"].ToString();
            numCod = Convert.ToInt32(data["NumCode"]);
            charCode = data["CharCode"].ToString();
            nominal = Convert.ToInt32(data["Nominal"]);
            name = data["Name"].ToString();
            value = data["Value"].ToObject<float>();
            previous = data["Previous"].ToObject<float>();
        }
        public string getCharCode()
        {
            return charCode;
        }

        public float getValue()
        {
            return value;
        }

        public int getNominal()
        {
            return nominal;
        }
    }
}
