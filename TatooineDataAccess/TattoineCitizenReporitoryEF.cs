using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatooineRepository;

namespace TatooineDataAccess
{
    public class TattoineCitizenReporitoryEF : ITattoineCitizensRepository
    {

        public TatooineModel.Citizens GetCitizen(string CitizenID)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                long Id = long.Parse(CitizenID);
                return db.Citizens.SingleOrDefault(p => p.Id == Id);
            }
        }

        public List<TatooineModel.Citizens> GetAllCitizens()
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                return db.Citizens.Include("Roles").Include("Status").ToList();
            }
        }

        public long AddCitizen(TatooineModel.Citizens Citizen)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                db.Citizens.Add(Citizen);
                db.SaveChanges();
                return Citizen.Id;
            }
        }

        public bool UpdateCitizen(TatooineModel.Citizens Citizen)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                var CitizenDB = db.Citizens.SingleOrDefault(p => p.Id == Citizen.Id);
                CitizenDB.Name = Citizen.Name;
                CitizenDB.Specie = Citizen.Specie;
                CitizenDB.IdRole = Citizen.IdRole;
                CitizenDB.IdStatus = Citizen.IdStatus;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteCitizen(string CitizenID)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                var Citizen = db.Citizens.SingleOrDefault(p => p.Id == long.Parse(CitizenID));
                db.Citizens.Remove(Citizen);
                db.SaveChanges();
                return true;
            }
        }

       

        public List<TatooineModel.Statuses> GeStatus()
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                return db.Status.ToList();
            }
        }

        public List<TatooineModel.Citizens> CitizensInRole(string Id)
        {
            using (var db = new TatooineCitizensRegistryEntities())
            {
                int id = int.Parse(Id);
                return db.Citizens.Where(p => p.IdRole == id).ToList();
            }
        }
    }
}
