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
            //Muotoillaan käyttäjän inputista oikeanmuotoinen syöte listaan verrattavaksi
            char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@', '\'' };
            nimi = nimi.Trim(charsToTrim);
            if (nimi.Length == 0) { return null; }
            else
            {
                string alkukirjain = nimi.Substring(0, 1).ToUpper();
                string loppunimi = nimi.Substring(1, (nimi.Length - 1)).ToLower();
                nimi = alkukirjain + loppunimi;
                //Etsitään käyttäjän syöte listasta
                foreach (var item in lista)
                {
                    if (item.stationName == nimi) { return item.stationShortCode; }
                    else { continue; }
                }

                return null; 
            }
          
        }

        //Koodasivat Sari ja Olli
        public static string SmashTheKeyboard(List<Liikennepaikka> lista, string typo)
        {
            //Muokataan käyttäjän inputista 
            List<string> samanlaiset = new List<string>();
            foreach (var item in lista)
            {
                char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@', '\'' };
                typo = typo.Trim(charsToTrim);
                if (typo.Length == 0)
                {
                    return  "Asemaa ei löydy!";
                    
                }
                else
                {
                    string alkukirjain = typo.Substring(0, 1).ToUpper();
                    string loppunimi = typo.Substring(1, (typo.Length - 1)).ToLower();
                    typo = alkukirjain + loppunimi;
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
            }
            var oikea = VaihtoehtoKäsittelijä(samanlaiset);
            return oikea;
        }
        // Koodasivat Olli ja Sari
        public static void Konduktööri(out string lähtöAsema, out string kohdeAsema)
        {
                annalähtöasema:
                Console.WriteLine("Anna lähtöasema:");
                string lähtö = Console.ReadLine();
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
                string kohde = Console.ReadLine();
            
            kohdeAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: kohde);
            if (kohdeAsema == null)
            {
                string uusiKohde = SmashTheKeyboard(pekka.TekeeLyhenteet(), kohde);
                kohdeAsema = Asema.EtsiAsema(pekka.TekeeLyhenteet(), uusiKohde);
                kohde = uusiKohde;
                if ( kohdeAsema == null)
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annakohdeasema;
                }
            
            }

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
    }
}
