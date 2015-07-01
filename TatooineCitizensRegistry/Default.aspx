<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TatooineCitizensRegistry._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Tatooine Citizens Register Web Site</h1>
        <p class="lead">Please use this web site to register new Tatooine Citizens</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Register new Citizen &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>List Citizens</h2>
            <p>
                You can review register citizens to update or delete the registry information.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">List &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Manage Roles</h2>
            <p>
                The web site allows you to add, update and delete Tatooine roles used in the Citizen register process.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Roles &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Register Rebels</h2>
            <p>
                You can easily register rebels with this special page.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Register Rebel &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
