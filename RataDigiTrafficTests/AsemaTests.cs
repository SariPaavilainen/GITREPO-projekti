using Microsoft.VisualStudio.TestTools.UnitTesting;
using RataDigiTraffic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RataDigiTraffic.Model;

namespace RataDigiTraffic.Tests
{
    //Testasivat Sari ja Olli
    [TestClass()]
    public class AsemaTests
    {
        //

        [TestMethod()]
        public void IsotJaPienetKirjaimetTest()
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            string nimi = "lApUA";
            string expected = "LPA";
            nimi = Asema.Trimmeri(nimi);
            string actual = Asema.EtsiAsema(rata.Liikennepaikat(), nimi);
            Assert.AreEqual(expected, actual, "Isot ja pienet kirjaimet pielessä!");
        }

        [TestMethod()]
        public void OlematonKaupunginNimi()
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            string nimi = "Virtanen";
            string expected = null;
            string actual = Asema.EtsiAsema(rata.Liikennepaikat(), nimi);
            Assert.AreEqual(expected, actual, "Ei ole kaupunki!");
        }

        [TestMethod()]
        public void YlimääräisetMerkit()
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            string nimi = "..lApUa???";
            string expected = "LPA";
            string actual = Asema.EtsiAsema(rata.Liikennepaikat(), Asema.Trimmeri(nimi));
            Assert.AreEqual(expected, actual, "Ylimääräisiä merkkejä alussa ja lopussa!");
        }
        [TestMethod()]
        public void NumeroitaNimessä()
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            string nimi = "12312lApUa";
            string expected = "LPA";
            string actual = Asema.EtsiAsema(rata.Liikennepaikat(), Asema.Trimmeri(nimi));
            Assert.AreEqual(expected, actual, "Ylimääräisiä merkkejä alussa ja lopussa!");
        }

        [TestMethod()]
        public void EtsiAsemaNumeroInput()
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            string nimi = "45";
            string expected = null;
            string actual = Asema.EtsiAsema(rata.Liikennepaikat(), nimi);
            Assert.AreEqual(expected, actual, "Tyhjää inputtia ei osata käsitellä!");
        }

        [TestMethod()]
        public void SmashTheKeyboardNumeroInput()
        {
            RataDigiTraffic.APIUtil rata = new RataDigiTraffic.APIUtil();
            string nimi = "45";
            string expected = "Asemaa ei löydy!";
            string actual = Asema.SmashTheKeyboard(rata.Liikennepaikat(), nimi);
            Assert.AreEqual(expected, actual, "Tyhjää inputtia ei osata käsitellä!");
        }


    }
}