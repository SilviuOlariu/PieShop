using DALContext;
using EntitiesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLCore.Repository
{
  public class PieRepository : IPieRepository
    {
        private readonly PieShopContext _context;

        public PieRepository(PieShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Pie> GetAllPies()
        {
            return _context.Pies; 
        }

        public Pie GetPieById(int pieId)
        {
            return _context.Pies.FirstOrDefault(a => a.Id == pieId);
        }
    }
}
