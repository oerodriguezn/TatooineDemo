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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<TatooineModel.Roles> roles = Common.LoadRoles;
                
                if(roles!=null)
                {
                    ddlRol.DataSource = roles;
                    ddlRol.DataTextField = "RoleName";
                    ddlRol.DataValueField = "Id";
                    ddlRol.DataBind();
                }

                List<Statuses> status = null;
                if (Cache["status"] == null)
                {
                    WCFproxy<ITatooineCitizens>.Use(client =>
                    {
                        status = client.GeStatus();
                    });
                    Cache["status"] = status;
                }
                else
                {
                    status = (List<Statuses>)Cache["status"];
                }
                if (status != null)
                {
                    ddlStatus.DataSource = status;
                    ddlStatus.DataValueField = "Id";
                    ddlStatus.DataTextField = "Status";
                    ddlStatus.DataBind();
                    
                }

                if(Request.QueryString["Id"] !=null)
                {
                    try
                    {
                        Citizens cit = null;
                        WCFproxy<ITatooineCitizens>.Use(client =>
                        {
                            cit = client.GetCitizen(Request.QueryString["Id"]);
                        });
                        if (cit != null)
                        {
                            hdId.Value = Request.QueryString["Id"];
                            tbName.Text = cit.Name;
                            tbSpecie.Text = cit.Specie;
                            ddlRol.SelectedValue = cit.IdRole.ToString();
                            ddlStatus.SelectedValue = cit.IdStatus.ToString();
                            btSave.Text = "Update";
                            divStatus.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {

                        LogUtil.Log("Error Page_Load Register.aspx, Id:"+Request.QueryString["Id"] , ex);
                    }
                }
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                long IdCitizen = 0;
                string action = "saved";
                try
                {
                    Citizens cit = new Citizens();
                    cit.Name = tbName.Text;
                    cit.Specie = tbSpecie.Text;
                    cit.IdRole = int.Parse(ddlRol.SelectedValue);
                   
                    if (string.IsNullOrEmpty(hdId.Value))
                    {
                        cit.IdStatus = 1;
                        action = "added";
                        WCFproxy<ITatooineCitizens>.Use(client =>
                        {
                            IdCitizen = client.AddCitizen(cit);
                        });
                    }
                    else
                    {
                        cit.Id = long.Parse(hdId.Value);
                        cit.IdStatus  = int.Parse(ddlStatus.SelectedValue);
                        WCFproxy<ITatooineCitizens>.Use(client =>
                        {
                           var result = client.UpdateCitizen(cit);
                           if (result)
                               IdCitizen = cit.Id;

                        });
                    }
                }
                catch (Exception ex)
                {
                    LogUtil.Log("Error btSave_Click Register.aspx", ex);
                }
                if(IdCitizen>0)
                {
                    BlockUI();
                    lbSuccessMessage.Text = "Citizen " + action + " successfully.";
                    lbErrorMessage.Visible = false;
                    LogUtil.Log("Citizen "+ action+" successfully." + IdCitizen.ToString());
                }
                else
                {
                    lbErrorMessage.Text = "Error saving Citizen. Please try again.";
                }
            }
        }

        private void BlockUI()
        {
            tbSpecie.Enabled = false;
            tbName.Enabled = false;
            ddlRol.Enabled = false;
            btSave.Visible = false;
            btRegisterNew.Visible = true;
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdId.Value))
            {
                Response.Redirect("Default.aspx", false);
            }
            else
                Response.Redirect("CitizenList.aspx", false);
        }

        protected void btRegisterNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx", false);
        }
    }
}