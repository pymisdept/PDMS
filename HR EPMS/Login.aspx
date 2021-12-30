<%@ Page Title="Title" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HR_EPMS.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <dl> <dt>IsAuthenticated</dt> 
        <% var userClaims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity; %>
        <dd><%= HttpContext.Current.User.Identity.IsAuthenticated %></dd>
        <dt>AuthenticationType</dt> 
        <dd><%= HttpContext.Current.User.Identity.AuthenticationType %></dd> 
        <dt>Name</dt> 
        <dd><%=userClaims?.FindFirst("name")?.Value %></dd> 
        <dl>
</asp:Content>
