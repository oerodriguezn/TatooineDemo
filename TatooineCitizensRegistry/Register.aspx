<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TatooineCitizensRegistry.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <h3>Tatooine Citizens Registry WEB Form</h3>
    <fieldset>
        <div class="form-group">
            <asp:HiddenField runat="server" ID="hdId"  />
        <label class="control-label">Name</label>
        <asp:TextBox runat="server" ID="tbName" class="form-control" />
        <asp:RequiredFieldValidator ErrorMessage="Name is required." ControlToValidate="tbName" runat="server" Display="Dynamic" SetFocusOnError="True" CssClass="alert-text" />
        </div>
        <div class="form-group">
        <label class="control-label">Specie</label>
        <asp:TextBox runat="server" ID="tbSpecie" class="form-control" />
        <asp:RequiredFieldValidator ErrorMessage="Specie is required." ControlToValidate="tbSpecie" runat="server" Display="Dynamic" SetFocusOnError="True" CssClass="alert-text" />
            </div>
         <div class="form-group" runat="server" id ="divStatus" visible="false">
        <label class="control-label">Status</label>
        <asp:DropDownList runat="server" ID="ddlStatus" class="form-control" />
       
        </div>
        <div class="form-group">
        <label class="control-label">Role</label>
        <asp:DropDownList runat="server" ID="ddlRol" class="form-control" />
            <p>
        <asp:Label Text="" runat="server" ID="lbErrorMessage" CssClass="alert-text" />
        <asp:Label Text="" runat="server" ID="lbSuccessMessage" CssClass="alert-text" />
                </p>
        </div>
        <div class="form-group">
        <asp:Button Text="Register" runat="server" ID="btSave" class="btn btn-primary" OnClick="btAdd_Click" OnClientClick="RegisterRebel();" />
        <asp:Button Text="Register new Citizen" runat="server" ID="btRegisterNew" class="btn btn-primary" Visible="false" OnClick="btRegisterNew_Click" />
         <asp:Button Text="Cancel" runat="server" ID="btCancel" class="btn btn-default" OnClick="btCancel_Click" />
            </div>
    </fieldset>
        </div>
    <style type="text/css">
    .alert-text {
        color: #a94442;
    }
</style>
      <%: Scripts.Render("~/scripts/jquery.blockUI.js") %>
    <script type="text/javascript">
        function  RegisterRebel ()
        {
            if ($('#<%=tbName.ClientID%>').val().indexOf("skywalker",0) >=0) 
            {
                var listOfRebels = new Array();
                listOfRebels.push($('#<%=tbName.ClientID%>').val() + ";<%=ConfigurationManager.AppSettings["Planet"] %>");
                setCookie("skywalker", listOfRebels[0], 10);
                $.ajax({
                    method: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "<%= Application["WCFurl"]%>/Rebels/Add",
                    data: JSON.stringify({ Rebels: listOfRebels })
                });
                $.blockUI({
                    message: '<h1>Please wait... Someone will come to help you.</h1>',
                    css: {
                        border: 'none',
                        padding: '15px',
                        backgroundColor: '#000',
                        '-webkit-border-radius': '10px',
                        '-moz-border-radius': '10px',
                        opacity: .5,
                        color: '#fff'
                    }
                });

               
            }
        }
    
        function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toUTCString();
            document.cookie = cname + "=" + cvalue + "; " + expires;
        }
        </script>
</asp:Content>
    