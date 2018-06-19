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

            char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@' };
            nimi = nimi.Trim(charsToTrim);
            if (nimi.Length == 0) { return null; }
            else
            {
                string alkukirjain = nimi.Substring(0, 1).ToUpper();
                string loppunimi = nimi.Substring(1, (nimi.Length - 1)).ToLower();
                nimi = alkukirjain + loppunimi;
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
            foreach (var item in lista)
            {
                char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@' };
                typo = typo.Trim(charsToTrim);
                if (typo.Length == 0)
                {
                    return "Asemaa ei löydy!";
                }
                else
                {
                    string alkukirjain = typo.Substring(0, 1).ToUpper();
                    string loppunimi = typo.Substring(1, (typo.Length - 1)).ToLower();
                    typo = alkukirjain + loppunimi;
                    string nimi = item.stationName;
                    if (nimi.Substring(0, 1) == typo.Substring(0, 1) && nimi.Substring(nimi.Length - 1, 1) == typo.Substring(typo.Length - 1, 1))

                    {
                        return item.stationName.ToString();
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                
            }
            return "Asemaa ei löydy!";
        }
        // Koodasivat Olli ja Sari
        public static void Konduktööri(out string lähtöAsema, out string kohdeAsema)
        {
            Console.WriteLine("Tervetuloa Junajuttuun!");
         
                annalähtöasema:
                Console.WriteLine("Anna lähtöasema:");
                string lähtö = Console.ReadLine();
                AsemaLyhenteet pekka = new AsemaLyhenteet();
                lähtöAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: lähtö);
                if (lähtöAsema == null)
                {

                    string uusiLähtö = SmashTheKeyboard(pekka.TekeeLyhenteet(), lähtö);
                if (uusiLähtö == "Asemaa ei löydy!")
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annalähtöasema;
                }
                    Console.WriteLine("Tarkoititko " + uusiLähtö + "? (k/e)");
                    var response = Console.ReadLine();
                    if (response == "e")
                    {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annalähtöasema;

                    }
                    else { lähtöAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: uusiLähtö); }
                }
                annakohdeasema:
                Console.WriteLine("Anna asema, jonne haluat matkustaa asemalta " + lähtöAsema + ": ");
                string kohde = Console.ReadLine();

                kohdeAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: kohde);
                if (kohdeAsema == null)
                {
                    string uusiKohde = SmashTheKeyboard(pekka.TekeeLyhenteet(), kohde);
                if (uusiKohde == "Asemaa ei löydy!")
                {
                    Console.WriteLine("Asemaa ei löydy!");
                    goto annakohdeasema;
                }
                    Console.WriteLine("Tarkoititko " + kohde + "? (k/e)");
                    var response = Console.ReadLine();
                    if (response == "e")
                    {
                    Console.WriteLine("Asemaa ei löydy!");
                        goto annakohdeasema;

                    }
                    else { kohdeAsema = Asema.EtsiAsema(lista: pekka.TekeeLyhenteet(), nimi: kohde); }
                }

         
           
           

        }
       

    }
}
