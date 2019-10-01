<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="PortalPrivado.Web.Reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <script>
        function IAmSelected(source, eventArgs) {
            alert(eventArgs.get_value());
            document.getElementById("contentPlaceHolder_hdRut").value = eventArgs.get_value();
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtbus" CssClass="texto" runat="server"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender ServiceMethod="getBusqueda" MinimumPrefixLength="1" CompletionInterval="10"
                EnableCaching="false" CompletionSetCount="10" TargetControlID="txtbus" ID="AutoCompleteExtender1"
                runat="server" FirstRowSelected="false" OnClientItemSelected="IAmSelected">
            </ajaxToolkit:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
