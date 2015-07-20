using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TatooineModel;
using TatooineRepository;
using Utils;

namespace TatooineServices
{
   
    public class TatooineCitizens : ITatooineCitizens
    {
        private readonly ITattoineCitizensRepository repository =  null;

        public TatooineCitizens(ITattoineCitizensRepository ConcreteRepository)
        {
            repository = ConcreteRepository;
        }
        public Citizens GetCitizen(string CitizenID)
        {
            try
            {
               return repository.GetCitizen(CitizenID);
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
                return repository.GetAllCitizens();
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
                return repository.AddCitizen(Citizen);
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
                return repository.UpdateCitizen(Citizen);
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
                return repository.DeleteCitizen(CitizenID);
            }
            catch (Exception ex)
            {
                LogUtil.Log("DeleteCitizen", ex);
                throw new FaultException(ex.Message);
            }
        }

        public List<Citizens> CitizensInRole(string Id)
        {
            try
            {
                return repository.CitizensInRole(Id);
            }
            catch (Exception ex)
            {
                LogUtil.Log("CitizensInRole", ex);
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
                return repository.GeStatus();
            }
            catch (Exception ex)
            {
                LogUtil.Log("GeStatus", ex);
                throw new FaultException(ex.Message);
            }
        }

      
    }
}
