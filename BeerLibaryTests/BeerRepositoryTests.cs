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
    public class BeerRepositoryTests
    {
        private IBeerRepository _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new BeerRepositoryList(); 

            _repo.Add(new Beer() { Id = 1, Name = "Corona", Abv = 6.4 });
            _repo.Add(new Beer() { Id = 2, Name = "Carlsberg", Abv = 4.6 });
            _repo.Add(new Beer() { Id = 3, Name = "Tuborg Classic", Abv = 4.6 });
            _repo.Add(new Beer() { Id = 4, Name = "Carsberg Nordic", Abv = 0.5 });
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Beer> beers = _repo.Get();
            Assert.AreEqual(4, beers.Count());
            Assert.AreEqual(beers.First().Name, "Corona");
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(100));
        }

        [TestMethod()]
        public void AddTest()
        {
            Beer b = new() { Name = "Mads' Hjemmebryg", Abv = 25.9 };
            Assert.AreEqual(5, _repo.Add(b).Id);
            Assert.AreEqual(5, _repo.Get().Count());
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.IsNull(_repo.Remove(100));
            Assert.AreEqual(1, _repo.Remove(1)?.Id);
            Assert.AreEqual(3, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(4, _repo.Get().Count());
            Beer b = new() { Name = "Test", Abv = 24.5 };
            Assert.IsNull(_repo.Update(100, b));
            Assert.AreEqual(1, _repo.Update(1, b)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());
        }
    }
}