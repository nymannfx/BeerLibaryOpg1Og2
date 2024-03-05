using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibary
{
    public interface IBeerRepository
    {
        public IEnumerable<Beer> Get(double? abvFilterMin = null, double? abvFilterMax = null, string? charInName = null, string? orderBy = null);
        public Beer? GetById(int id);
        public Beer Add(Beer beer);
        public Beer? Remove(int id);
        public Beer? Update(int id, Beer beer);


    }
}
