using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibary
{
    public class BeerRepositoryList : IBeerRepository
    {
        private int _nextId = 1;
        private readonly List<Beer> _beers = new();

        public BeerRepositoryList() 
        {
            //_beers.Add(new Beer() { Id = _nextId++, Name = "Corona", Abv = 5.6 });
            //_beers.Add(new Beer() { Id = _nextId++, Name = "Carlsberg", Abv = 4.6 });
        }

        public IEnumerable<Beer> Get(double? abvFilterMin = null, double? abvFilterMax = null, string? charInName = null,  string? orderBy = null)
        {
            if (abvFilterMin != null)
            {
                if (abvFilterMax != null)
                {
                    return _beers.Where(b => b.Abv <= abvFilterMax);
                }

                return _beers.Where(b => b.Abv <= abvFilterMin);

            }
            if (charInName != null)
            {
                return _beers.Where(b => b.Name.Contains(charInName));
            }
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "Name":
                        _beers.OrderBy(b => b.Name);
                        break;
                    case "name_desc":
                        _beers.OrderByDescending(b => b.Name); 
                        break;
                    case "abv":
                        _beers.OrderBy(b => b.Abv);
                        break;
                    case "abv_desc":
                        _beers.OrderByDescending(b => b.Abv);
                        break;
                    default:
                        break; 
                }
            }
            return _beers;
        }
        public Beer? GetById(int id)
        {
            return _beers.Find(b => b.Id == id);
        }
        public Beer Add(Beer beer)
        {
            beer.Validate();
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }
        public Beer? Remove(int id)
        {
            Beer? beer = GetById(id);
            if (beer == null)
            {
                return null;
            }
            _beers.Remove(beer);
            return beer;
        }

        public Beer? Update(int id, Beer beer)
        {
            beer.Validate();
            Beer? existingBeer = GetById(id);
            if (existingBeer == null)
            {
                return null;
            }
            existingBeer.Name = beer.Name;
            existingBeer.Abv = beer.Abv;
            return existingBeer;
        }
    }
}
