using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatooineModel;

namespace TatooineRepository
{
   public interface ITattoineCitizensRepository
    {
        Citizens GetCitizen(string id);
        List<Citizens> GetAllCitizens();
        long AddCitizen(Citizens Citizen);
        bool UpdateCitizen(Citizens Citizen);
        bool DeleteCitizen(string Id);
        List<Statuses> GeStatus();
        List<Citizens> CitizensInRole(string Id);
    }
}
