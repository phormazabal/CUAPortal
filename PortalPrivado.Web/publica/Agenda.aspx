<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="PortalPrivado.Web.publica.Agenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Clínica UA</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta name="viewport" content="width=device-width,initial-scale=1"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"
        async>
    <link rel="stylesheet" href="css/fonts.css" type="text/css"/>
    <link rel="stylesheet" href="css/bootstrap-grid.min.css" type="text/css"/>
    <link rel="stylesheet" href="css/tiny-slider.css" type="text/css"/>
    <link rel="stylesheet" href="css/animate.css" type="text/css"/>
    <link rel="stylesheet" href="css/select2.min.css" type="text/css"/>
    <link rel="stylesheet" href="css/normalize.css" type="text/css"/>
    <link rel="stylesheet" href="css/estilos.css" type="text/css"/>
    <script language="javascript" type="text/javascript"> 
        function fireServerButtonEvent(){ 
            document.getElementById("btnSubmit").click(); 
        } 
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        
            <h4 class="border-bottom"><i class="far fa-clock"></i>RESERVA DE HORA</h4>
            <asp:HiddenField ID="hdtest" runat="server" />
            <div class="form-group mb-1">
                <label class="hora-clasif">Búsqueda por médico o especialidad:</label>
                <div class="busqueda-radio flex-between mt-1">
                    <label class="radio-inline">
                        <input type="radio" name="optradio" checked class="radio-hr-med">Hora Médica</label>
                    <label class="radio-inline"><a target="_blank" href="https://6c03d479ec55ad2eb218a2aba471ee8cfc457a3e.agenda.softwaredentalink.com/agendas/agendamiento"class="link-hora-dent"><i class="fas fa-chevron-right"></i>Hora Dental <i class="fas fa-external-link-alt"></i></a></label>
               </div>
            </div>
            <div class="form-group select-reserva mb-1">
                <asp:DropDownList ID="dpBusqueda" CssClass="chosen-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpBusqueda_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group mb-3">
                <a id="buscar" target="_parent" runat="server"><label class="btn btn-amarillo btn-full btn-reserva">Buscar Hora</label></a>
            </div>
            <a id="aAnular" runat="server" target="_parent"><i class="fas fa-chevron-right"></i>Modificar y/o Anular hora</a>
    </form>
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/tiny-slider.js" defer></script>
    <script src="js/lazyload.js" defer></script>
    <script type="text/javascript" src="js/slowNumber.js"></script>
    <script src="js/accordion.js" defer></script>
    <script src="js/wow.js" defer></script>
    <script src="js/select2.min.js" defer></script>
    <script type="text/javascript" src="js/funciones.js" defer></script>
    <script src="js/funciones-widget.js" defer></script>
</body>
</html>
