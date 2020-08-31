using EntitiesCore.Models;
using System;
using System.Collections.Generic;

namespace BLLCore.Repository
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int pieId);

            
    }
}
