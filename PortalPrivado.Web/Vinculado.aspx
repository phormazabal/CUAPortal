<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Vinculado.aspx.cs" Inherits="PortalPrivado.Web.Vinculado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="img-login">
        <figure>
            <img src="images/img-priv2.jpg" alt="">
        </figure>
        <div class="texto-banner-login">
            <h5>Sesión</h5>
            <h2>
                <asp:Label ID="lbVinculado" runat="server" Text="Label"></asp:Label></h2>
            <h3></h3>
            <h4><span>Cuenta principal</span><asp:Literal ID="Literal1" runat="server"></asp:Literal></h4>
        </div>
    </div>  
</asp:Content>
