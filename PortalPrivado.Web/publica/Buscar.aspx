<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="PortalPrivado.Web.publica.Buscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Clínica UA</title>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width,initial-scale=1">
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"
        async>
<link rel="stylesheet" href="../css/fonts.css" type="text/css">
<link rel="stylesheet" href="../css/bootstrap-grid.min.css" type="text/css">
<link rel="stylesheet" href="../css/tiny-slider.css" type="text/css">
<link rel="stylesheet" href="../css/animate.css" type="text/css">
<link rel="stylesheet" href="../css/select2.min.css" type="text/css">
<link rel="stylesheet" href="../css/normalize.css" type="text/css">
<link rel="stylesheet" href="../css/estilos.css" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
         <script>
        function IAmSelected(source, eventArgs) {
            alert(eventArgs.get_value());
            document.getElementById("contentPlaceHolder_hdRut").value = eventArgs.get_value();
        }
    </script>
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
         <section class="pb-2 home-priv"><div class="wrap">
    <div class="box-perfil" id="form-perfil">
    <div class="pasos-reserva">
        <div class="paso activo">
            <div class="num-paso">
                <span>1</span>
            </div>
            <p>Búsqueda</p>
        </div>
        <div class="paso">
            <div class="num-paso">
                <span>2</span>
            </div>
            <p>Profesional</p>
        </div>
        <div class="paso">
            <div class="num-paso">
                <span>3</span>
            </div>
            <p>Hora</p>
        </div>
        <div class="paso">
            <div class="num-paso">
                <span>4</span>
            </div>
            <p>Reserva</p>
        </div>
    </div>
    <div class="box-busqueda">
        <div class="w-form full">
            <div class="form-group">
                <label>Ingrese la especialidad o nombre del profesional</label>
                <asp:DropDownList ID="dpBusqueda" CssClass="chosen-select" runat="server" OnSelectedIndexChanged="dpBusqueda_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="w-form full">
                <div class="form-group text-right mb-0">
                   
                </div>
                  <div class="form-group text-right mb-0">
                      <asp:LinkButton ID="btnaceptarSimple" CssClass="btn btn-amarillo" OnClick="btnAceptar_Click" Visible="false" runat="server">BUSCAR</asp:LinkButton>
                      <%-- <asp:Button ID="btnaceptarSimple" CssClass="btn btn-amarillo" runat="server" Text="Buscar" OnClick="btnAceptar_Click" Visible="false" />--%>
                  </div>
            </div>
            <div class="w-form full">
                <div class="form-group">
                    <label>
                        <asp:Label ID="lbEspejo" runat="server" Text="Ingrese la especialidad" Visible="false"></asp:Label></label>
                    <asp:DropDownList ID="dpEspejo" CssClass="chosen-select" runat="server" Visible="false" TabIndex="1"></asp:DropDownList>
                </div>
                <div class="form-group text-right mb-0">
                    
                    <asp:LinkButton ID="btnAceptar" CssClass="btn btn-amarillo" OnClick="btnAceptar_Click" Visible="false" runat="server">BUSCAR</asp:LinkButton>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="dpBusqueda" EventName="SelectedIndexChanged" />
                <%--<asp:AsyncPostBackTrigger ControlID="btnaceptarSimple" EventName="Click" />--%>
                <asp:PostBackTrigger ControlID="btnaceptarSimple" />
            <asp:PostBackTrigger ControlID="btnAceptar" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
        </div></div></section>
    </form>
    <script type="text/javascript" src="../js/iframeResizer.contentWindow.min.js" defer></script> 
    <script src="../js/select2.min.js" defer></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/tiny-slider.js" defer></script>
    <script src="../js/lazyload.js" defer></script>
    <script type="text/javascript" src="../js/slowNumber.js"></script>
    <script src="../js/accordion.js" defer></script>
    <script src="../js/wow.js" defer></script>
    <script src='../js/moment.min.js'></script>
    <script src='../js/fullcalendar.min.js'></script>
    <script src='../js/es.js'></script>
    <script type="text/javascript" src="../js/funciones.js" defer></script>
    <script type="text/javascript" src="../js/funciones-privado.js" defer></script>
    <script src="../js/funciones-widget.js" defer></script>
</body>
</html>
