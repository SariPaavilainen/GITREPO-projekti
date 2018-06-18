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


        //Koodasivat Sari ja Tatu
        public static string EtsiAsema(List<Liikennepaikka> lista, string nimi)
        {
            char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@' };
            nimi = nimi.Trim(charsToTrim);
            string alkukirjain = nimi.Substring(0, 1).ToUpper();
            string loppunimi = nimi.Substring(1, (nimi.Length - 1)).ToLower();
            nimi = alkukirjain + loppunimi;
            foreach (var item in lista)
            {
                if (item.stationName == nimi) { return item.stationShortCode; }
                else { continue; }
            }
            SmashTheKeyboard(lista, nimi);
            return "Asemaa ei löydy!";
        }

        public static string SmashTheKeyboard(List<Liikennepaikka> lista, string typo)
        {
            foreach (var item in lista)
            {
                char[] charsToTrim = { ' ', ',', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '@' };
                typo = typo.Trim(charsToTrim);
                string alkukirjain = typo.Substring(0, 1).ToUpper();
                string loppunimi = typo.Substring(1, (typo.Length - 1)).ToLower();
                typo = alkukirjain + loppunimi;
                string nimi = item.stationName;
                if (nimi.Substring(0,1) == typo.Substring(0,1))
                {
                    return "Tarkoititko " + item.stationName + "?";
                }
                else { continue; }
                
            }
            return "Asemaa ei löydy!";
        }

    }
}
