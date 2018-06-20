using Microsoft.VisualStudio.TestTools.UnitTesting;
using RataDigiTraffic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RataDigiTraffic.Tests
{
    [TestClass()]
    public class JunanumerollaTests
    {
        [TestMethod()] // Koodannut H-M ja Tatu
        public void OikeaJunanNumero()
        {
            RataDigiTraffic.Junanumerolla j = new RataDigiTraffic.Junanumerolla();
            string junanNumero = "42";
            string expected = "";
            string actual = Junanumerolla.EtsiJuna(junanNumero);
            Assert.AreEqual(expected, actual, "Joku on pielessä, pitäisi olla oikea junan numero!");
        }

        [TestMethod()]
        public void JunanNumeroonnolla()
        {
            RataDigiTraffic.Junanumerolla j = new RataDigiTraffic.Junanumerolla();
            string junanNumero = "0";
            string expected = "Junan numero voi olla välillä 1-99999";
            string actual = Junanumerolla.EtsiJuna(junanNumero);
            Assert.AreEqual(expected, actual, "Joku on pielessä, junan numero ei voi olla 0!");
        }

        [TestMethod()]
        public void Liianpitkänumero()
        {
            RataDigiTraffic.Junanumerolla j = new RataDigiTraffic.Junanumerolla();
            string junanNumero = "467859";
            string expected = "Junan numero voi olla välillä 1-99999";
            string actual = Junanumerolla.EtsiJuna(junanNumero);
            Assert.AreEqual(expected, actual, "Liian pitkä numero!");
        }
        [TestMethod()]
        public void Kirjaimianumerossa()
        {
            RataDigiTraffic.Junanumerolla j = new RataDigiTraffic.Junanumerolla();
            string junanNumero = "4kh36c";
            string expected = "Et syöttänyt numeroa!";
            string actual = Junanumerolla.EtsiJuna(junanNumero);
            Assert.AreEqual(expected, actual, "Syötä numero!");
        }

        [TestMethod()]
        public void Junantyyppilisänä()
        {
            RataDigiTraffic.Junanumerolla j = new RataDigiTraffic.Junanumerolla();
            string junanNumero = "IC160";
            string expected = "";
            string actual = Junanumerolla.EtsiJuna(junanNumero);
            Assert.AreEqual(expected, actual, "Joku on pielessä, pitäisi olla oikea junan numero!");
        }
    }
    } // tähän asti
