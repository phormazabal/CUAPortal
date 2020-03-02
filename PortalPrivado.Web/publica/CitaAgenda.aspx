<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CitaAgenda.aspx.cs" Inherits="PortalPrivado.Web.publica.CitaAgenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Clínica UA</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta name="viewport" content="width=device-width,initial-scale=1" />
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"
        async />
<link rel="stylesheet" href="../css/fonts.css" type="text/css"/>
<link rel="stylesheet" href="../css/bootstrap-grid.min.css" type="text/css"/>
<link href='../css/fullcalendar.min.css' rel='stylesheet' />
<link rel="stylesheet" href="../css/tiny-slider.css" type="text/css"/>
<link rel="stylesheet" href="../css/animate.css" type="text/css"/>
<link rel="stylesheet" href="../css/normalize.css" type="text/css"/>
<link rel="stylesheet" href="../css/estilos.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <section class="p-2 home-priv">
  <div class="wrap">
    <div class="row">
      <div class="col-lg-9">
        <div class="box-perfil w-busqueda pb-0">

          <div class="pasos-reserva">
            <div class="paso activo">
              <div class="num-paso">
                <span>1</span>
              </div>
              <p>Búsqueda</p>
            </div>
            <div class="paso activo">
              <div class="num-paso">
                <span>2</span>
              </div>
              <p>Profesional</p>
            </div>
            <div class="paso activo">
              <div class="num-paso">
                <span>3</span>
              </div>
              <p>Hora</p>
            </div>
            <div class="paso activo">
              <div class="num-paso">
                <span>4</span>
              </div>
              <p>Reserva</p>
            </div>
          </div>
          <div class="ficha-id">
            <div class="reserva-exito">
              <div class="check">
                <i class="far fa-check-circle"></i>
              </div>
              <div class="texto">
                <h4>Su hora médica ha sido reservada exitosamente</h4>
                <ul>
                  <li><b>Profesional:</b> <asp:Label ID="lbNombreMed" runat="server" Text=""></asp:Label></li>
                  <li><b>Fecha:</b> <asp:Label ID="lbFecha" runat="server" Text=""></asp:Label></li>
                  <li><b>Hora:</b> <asp:Label ID="lbHora" runat="server" Text=""></asp:Label></li>
                  <li><b>Especialidad:</b> <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label></li>
                  <%--<li><b>Subespecialidad:</b> Tobillo y pie</li>
                  <li><b>Ubicación de consulta:</b> Edificio Centro Médico (amarillo) piso 6.</li>--%>
                </ul>
                <br>
                <h4>Hemos enviado un correo electrónico de confirmación de su reserva</h4>
              </div>
            </div>
            <div class="text-right">
              <a id="aHome" target="_parent" runat="server" class="btn btn-verde">HOME MI CLINICA UANDES</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
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
