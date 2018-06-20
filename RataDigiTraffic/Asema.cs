using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RataDigiTraffic
{
    public class Asema
    {


        //Koodasivat Sari ja Tatu, muokkasivat Sari ja Olli
        public static string EtsiAsema(List<Liikennepaikka> lista, string nimi)
        {
         
            //Etsitään käyttäjän syöte listasta
            foreach (var item in lista)
            {
                if (item.stationName == nimi) { return item.stationShortCode; }
                else { continue; }
            }

            return null;


        }

        //Koodasivat Sari ja Olli
        public static string SmashTheKeyboard(List<Liikennepaikka> lista, string typo)
        {
            //Muokataan käyttäjän inputista 
            List<string> samanlaiset = new List<string>();
            foreach (var item in lista)
            {
              
                    string nimi = item.stationName;


                    if (nimi.Substring(0, 1) == typo.Substring(0, 1) && nimi.Substring(nimi.Length - 1, 1) == typo.Substring(typo.Length - 1, 1))

                    {
                        samanlaiset.Add(nimi);
                    }
                    else
                    {
                        continue;
                    }
                
            }
            var oikea = VaihtoehtoKäsittelijä(samanlaiset);
            return oikea;
        }
        // Koodasivat Olli ja Sari
        public static void Konduktööri(out string lähtöAsema, out string kohdeAsema)
        {
            annalähtöasema:
            Console.WriteLine("Anna lähtöasema:");
           
            string syöte= Console.ReadLine();
            string lähtö = Asema.Trimmeri(syöte);
            AsemaLyhenteet pekka = new AsemaLyhenteet();
            lähtöAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: lähtö);

            if (lähtöAsema == null)
            {
                string uusiLähtö = SmashTheKeyboard(pekka.TekeeLyhenteet(), lähtö);
                lähtöAsema = EtsiAsema(pekka.TekeeLyhenteet(), uusiLähtö);
                lähtö = uusiLähtö;
                if (lähtöAsema == null)
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annalähtöasema;
                }
            }
            annakohdeasema:
            Console.WriteLine("Anna asema, jonne haluat matkustaa asemalta " + lähtö + ": ");
            syöte = Console.ReadLine();
            string kohde = Asema.Trimmeri(syöte);
            kohdeAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: kohde);
            if (kohdeAsema == null)
            {
                string uusiKohde = SmashTheKeyboard(pekka.TekeeLyhenteet(), kohde);
                kohdeAsema = Asema.EtsiAsema(pekka.TekeeLyhenteet(), uusiKohde);
                kohde = uusiKohde;
                if (kohdeAsema == null)
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annakohdeasema;
                }
            }
            Console.WriteLine($"Valittu matka: {lähtö}({lähtöAsema})  - { kohde}({kohdeAsema})");


        }
        //Koodasivat Sari ja Olli, muokkasi omaksi metodikseen Sari
        public static string VaihtoehtoKäsittelijä(List<string> lista)
        {
            foreach (var vaihtoehto in lista)
            {


                Console.WriteLine("Tarkoititko " + vaihtoehto + "? (k/e)");
                var response = Console.ReadLine();
                switch (response)
                {
                    case "k":

                        return vaihtoehto;

                    case "e":
                        break;

                    default:
                        Console.WriteLine("Anna vastaus (k/e)");
                        response = Console.ReadLine().Substring(0, 1).ToString();
                        break;
                }

            }
            return "Asemaa ei löydy!";
        }
        //Koodasivat ja metodiksi pilkkoivat Olli ja Sari
        public static string Trimmeri(string syöte)
        {
            char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@', '\'' };
            syöte = syöte.Trim(charsToTrim);
            if (syöte.Length == 0) { return "Asemaa ei löydy!"; }
            else
            {
                string alkukirjain = syöte.Substring(0, 1).ToUpper();
                string loppunimi = syöte.Substring(1, (syöte.Length - 1)).ToLower();
                syöte = alkukirjain + loppunimi;
                return syöte;
            }
        }
    }
}
