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
            l1 = new Liikennepaikka("Pasila", "PSL");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Tikkurila", "TKL");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Riihimäki", "RI");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Hämeenlinna", "HL");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Toijala", "TL");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lempäälä", "LPÄ");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Kerava", "KE");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Haarajoki", "HAA");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Mäntsälä", "MLÄ");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Henna", "HNN");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Leppävaara", "LPV");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Karjaa", "KR");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Ervelä", "ERV");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Salo", "SLO");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Inkoo", "IKO");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Paimio", "PO");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Kupittaa", "KUT");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Kouvola", "KV");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Lappeenranta", "LR");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Joutseno", "JTS");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Imatra", "IMR");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Simpele", "SPL");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Parikkala", "PAR");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Kesälahti", "KTI");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Kitee", "KIT");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Joensuu", "JNS");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Hanko", "HNK");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Parkano", "PKO");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Ylivalli", "YLV");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Seinäjoki", "SK");
            Lyhenteet.Add(l1);
            l1 = new Liikennepaikka("Pasila", "PSL");
            Lyhenteet.Add(l1);

            return Lyhenteet;
        }
    }
}
