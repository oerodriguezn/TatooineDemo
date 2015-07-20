using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using TatooineServices;
using Utils;

namespace TatooineCitizensRegistry
{
    public class Common 
    {
        public static List<TatooineModel.Roles> LoadRoles
        {
            get
            {
                List<TatooineModel.Roles> roles = null;
                if (HttpContext.Current.Cache["roles"] == null)
                {
                    WCFproxy<ITatooineRoles>.Use(client =>
                    {
                        roles = client.GetRoles();
                    });
                    HttpContext.Current.Cache["roles"] = roles;
                }
                else
                {
                    roles = (List<TatooineModel.Roles>)HttpContext.Current.Cache["roles"];
                }
                return roles;
            }
            set
            {
                HttpContext.Current.Cache.Remove("roles");
            }
        }
    }
}