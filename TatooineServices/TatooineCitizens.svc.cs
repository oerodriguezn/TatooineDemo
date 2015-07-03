using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TatooineDataAccess;
using TatooineModel;
using Utils;

namespace TatooineServices
{
   
    public class TatooineCitizens : ITatooineCitizens
    {

        public Citizens GetCitizen(string CitizenID)
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    long Id = long.Parse( CitizenID);
                    return db.Citizens.SingleOrDefault(p => p.Id == Id);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("GetCitizen", ex);
                throw new FaultException(ex.Message);
            }
        }

        public List<Citizens> GetAllCitizens()
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    return db.Citizens.Include("Roles").Include("Status").ToList();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("GetAllCitizens", ex);
                throw new FaultException(ex.Message);
            }
        }

      

        public long AddCitizen(Citizens Citizen)
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    db.Citizens.Add(Citizen);
                    db.SaveChanges();
                    return Citizen.Id;
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("AddCitizen", ex);
                throw new FaultException(ex.Message);
            }
        }

        public bool UpdateCitizen(Citizens Citizen)
        {
            try
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
            catch (Exception ex)
            {
                LogUtil.Log("UpdateCitizen", ex);
                throw new FaultException(ex.Message);
            }
        }

        public bool DeleteCitizen(string CitizenID)
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    var Citizen = db.Citizens.SingleOrDefault(p => p.Id == long.Parse(CitizenID));
                    db.Citizens.Remove(Citizen);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("DeleteCitizen", ex);
                throw new FaultException(ex.Message);
            }
        }

        public bool RegisterRebels(string[] Rebels)
        {
            try
            {
                if (Rebels != null)
                {
                    string RebelsPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Rebels");
                    if (Directory.Exists(RebelsPath))
                    {
                        string FileName = Path.Combine(RebelsPath, DateTime.Now.ToString("yyyyMMdd") + ".txt");
                        var lines = Rebels.Where(p => p.IndexOf(";") > 0).Select(p => string.Format("rebeld {0} on {1} at {2}", p.Split(';')[0], p.Split(';')[1], DateTime.Now.ToString("yyyy-MM-dd")));
                        File.AppendAllLines(FileName, lines);
                    }
                    else
                        throw new FaultException(string.Format("Directory {0} no found", RebelsPath));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogUtil.Log("RegisterRebels", ex);
                throw new FaultException(ex.Message);
            }
        }

        public List<Statuses> GeStatus()
        {
            try
            {
                using (var db = new TatooineCitizensRegistryEntities())
                {
                    return db.Status.ToList();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log("GeStatus", ex);
                throw new FaultException(ex.Message);
            }
        }

      
    }
}
