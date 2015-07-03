<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CitizenList.aspx.cs" Inherits="TatooineCitizensRegistry.CitizenList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%: Scripts.Render("~/scripts/jquery.dataTables.js") %>
     <%: Styles.Render("~/Content/jquery.dataTables.css") %>
    <div class="row">
    <h3>Tatooine Citizens List</h3>
    <table id="example" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Specie</th>
                <th>Role</th>
                <th>Status</th>
               
            </tr>
        </thead>
 
        <tfoot>
            <tr>
                <th>Id</th>
                 <th>Name</th>
                <th>Specie</th>
                <th>Role</th>
                <th>Status</th>
            </tr>
        </tfoot>
    </table>
        </div>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#example').dataTable({
                "ajax": {
                    "url": "<%= Application["WCFurl"]%>/GetAllCitizens",
                    "dataSrc": ""
                },
                "columns": [
                    { "data": "Id" },
                    { "data": "Name" },
                    { "data": "Specie" },
                    { "data": "Roles.RoleName" },
                    { "data": "Status.Status" }
                ]
            });
       
        $('#example tbody').on('click', 'tr', function () {
            var id = $('td', this).eq(0).text();
            location = "Register.aspx?Id=" + id;
        });

        });
        </script>
</asp:Content>
