using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TatooineModel;
using TatooineServices;
using Utils;

namespace TatooineCitizensRegistry
{
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
           
        }

       

        public List<TatooineModel.Roles> gvRoles_GetData()
        {
           
            return Common.LoadRoles;
        }

       
        public void gvRoles_UpdateItem(int id)
        {
            TatooineModel.Roles item = null;
            WCFproxy<ITatooineRoles>.Use(client =>
            {
                item = client.GetRol(id.ToString());


            });
            if (item == null)
            {
               
                ModelState.AddModelError("", String.Format("Item no found. {0}", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                WCFproxy<ITatooineRoles>.Use(client =>
                {
                     client.UpdateRole(item);

                });
                Common.LoadRoles = null;
 
            }
        }

     
        public void gvRoles_DeleteItem(int id)
        {
            WCFproxy<ITatooineRoles>.Use(client =>
            {
                client.DeleteRole(id.ToString());

            });
            Common.LoadRoles = null;
           
        }

        protected void btAddRole_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TatooineModel.Roles role = new TatooineModel.Roles();
                role.RoleName = tbNewRoleName.Text;
                WCFproxy<ITatooineRoles>.Use(client =>
                {
                    client.AddRole(role);

                });
                Common.LoadRoles = null;
                gvRoles.DataBind();
            }

        }

     
        protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "List":
                     int RolId = (int)gvRoles.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                     string RolName = Common.LoadRoles.Where(p => p.Id == RolId).Select(p=>p.RoleName).FirstOrDefault();
                     BindUserList(RolId, RolName);
                    break;
                default:
                    break;
            }
        }

        private void BindUserList(int RolId, string RolName)
        {
            List<Citizens> citizens = null;
            WCFproxy<ITatooineCitizens>.Use(client =>
                {
                     citizens = client.CitizensInRole(RolId.ToString());

                });
            lbRol.Text = "Citizens in role " + RolName;
            lbRol.Visible = true;
            if (citizens.Count() > 0)
            {
                gvUsers.DataSource = citizens;
                gvUsers.DataBind();
                gvUsers.Visible = true;
                gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
                lbNoCitizens.Visible = false;
            }
            else
            {
                gvUsers.Visible = false;
                lbNoCitizens.Visible = true;
            }
        }

        protected void gvRoles_DataBound(object sender, EventArgs e)
        {
            gvRoles.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}