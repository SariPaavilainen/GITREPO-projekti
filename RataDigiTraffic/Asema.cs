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
            // Etsitään liikennepaikkojen listasta syötteen ensimmäisen ja viimeisen kirjaimen perusteella
            // mahdolliset oikeat vaihtoehdot ja tarjotaan niitä käyttäjälle yksi kerrallaan.
            List<string> samanlaiset = new List<string>();
            foreach (var item in lista)
            {
              
                  string nimi = item.stationName;
                
                if (nimi.Substring(0, 2) == typo.Substring(0, 2)) 

                    {if (nimi.Substring(0, 3) == typo.Substring(0, 3))
                    {
                       
                            samanlaiset.Add(nimi);
                        

                    }
                    if (nimi.Substring(nimi.Length - 1, 1) == typo.Substring(typo.Length - 1, 1))
                    {
                    samanlaiset.Add(nimi);
                    }


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
            //Selvittää asiakkaan syötteen perusteella halutun reitin lähtö- ja kohdeasemat
            annalähtöasema:
            Console.WriteLine("Anna lähtöasema:");
           
            string syöte= Console.ReadLine();
            string lähtö = Asema.Trimmeri(syöte);
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            lähtöAsema = Asema.EtsiAsema(lista: rata.Liikennepaikat(), nimi: lähtö);

            if (lähtöAsema == null)
            { 
                //Jos syötteen perusteella ei suoraan löydy asemaa, etsitään syötettä lähinnä vastaavat 
                //asemat ja kysytään niitä käyttäjältä 
                string uusiLähtö = SmashTheKeyboard(rata.Liikennepaikat(), lähtö);
                lähtöAsema = EtsiAsema(rata.Liikennepaikat(), uusiLähtö);
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
            kohdeAsema = Asema.EtsiAsema(lista: rata.Liikennepaikat(), nimi: kohde);
            if (kohdeAsema == null)
            {
                string uusiKohde = SmashTheKeyboard(rata.Liikennepaikat(), kohde);
                kohdeAsema = Asema.EtsiAsema(rata.Liikennepaikat(), uusiKohde);
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
            // Käydään läpi Smash the keyboard() -metodin antamat lähinnä syötettä vastaavat
            // aseman nimet ja kysytään käyttäjältä, oliko joku niistä käyttäjän tarkoittama asema
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
            //Muotoillaan käyttäjän syötteestä standardimuotoinen ilmaus ja poistetaan ylimääräiset merkit.
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
