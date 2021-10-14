using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    public class Converter
    {
        private Currency currency1;
        private Currency currency2;

        public void setCurrency1(Currency value)
        {
            currency1 = value;
        }

        public void setCurrency2(Currency value)
        {
            currency2 = value;
        }
        public float calcValue(float val, int idCur)
        {
            if (currency1 == null || currency2 == null)
                return -1;
            if (idCur == 1)
            {
                float subResult = val * currency1.getValue() / currency1.getNominal();
                return subResult / currency2.getValue() * currency2.getNominal();
            }
            else if (idCur == 2)
            {
                float subResult = val * currency2.getValue() / currency2.getNominal();
                return subResult / currency1.getValue() * currency1.getNominal();
            }
            else
                return -1;
        }
    }
}
