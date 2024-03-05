using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibary.Tests
{
    [TestClass()]
    public class BeerTests
    {
        private Beer beerNormal = new() {Id = 1, Name = "Carlsberg", Abv = 4 };
        private Beer beerNullName = new() { Id = 2, Name = null, Abv = 4 };
        private Beer beerName2Char = new() { Id = 3, Name = "PO", Abv = 4 };
        private Beer beerLowAbv = new() { Id = 4, Name = "Carlsberg", Abv = 0 };
        private Beer beerHighAbv = new() { Id = 5, Name = "Carlsberg", Abv = 68 };

        [TestMethod()]
        public void ToStringTest()
        {
            string str = beerNormal.ToString();
            Assert.AreEqual("1 Carlsberg 4", str);
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => beerNullName.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerName2Char.ValidateName());
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerLowAbv.ValidateAbv());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerHighAbv.ValidateAbv());
        }
    }
}