using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RataDigiTraffic
{
    public class AsemaLyhenteet
    {
        public List<Liikennepaikka> TekeeLyhenteet()
        //Koodasivat: Sari ja Tatu
        {
            Liikennepaikka l1 = new Liikennepaikka("Helsinki", "HKI");
            List<Liikennepaikka> Lyhenteet = new List<Liikennepaikka>();
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tampere", "TPE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Turku", "TKU");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lahti", "LH");
            Lyhenteet.Add(l1);
            return Lyhenteet;
        }
    }
}
