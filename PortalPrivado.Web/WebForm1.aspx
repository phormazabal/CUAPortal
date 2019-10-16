﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PortalPrivado.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Clínica UA</title>

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width,initial-scale=1">
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"
        async />
<link rel="stylesheet" href="css/fonts.css" type="text/css">
<link rel="stylesheet" href="css/bootstrap-grid.min.css" type="text/css" />
<link rel="stylesheet" href="css/tiny-slider.css" type="text/css" />
<link rel="stylesheet" href="css/select2.min.css" type="text/css" />
<link rel="stylesheet" href="css/animate.css" type="text/css" />
<link rel="stylesheet" href="css/normalize.css" type="text/css" />
<link rel="stylesheet" href="css/estilos.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">      
    <header>
        <div class="wrap flex-between-top">
          <a href="#" class="logo">
            <img src="images/logo.svg" alt="Clínica Universidad de Los Andes">
          </a>
          <div class="head">
            <div class="head-top flex-right">
              <div class="nav-top">
                <a href="#">Quiénes Somos</a>
                <a href="#">Docencia e Investigación</a>
                <a href="#">Responsabilidad Social</a>
                <a href="#">Noticias</a>
              </div>
              <div class="tamano-letra">
                <a href="#">A</a>
                <a href="#">A</a>
                <a href="#">A</a>
              </div>
              <div class="buscador" id="buscador">
                <input type="text" placeholder="Ingrese su búsqueda">
                <button type="submit"><i class="fas fa-search"></i></button>
              </div>
              <a href="#" class="lupa" id="lupa"><i class="fas fa-search"></i></a>
              <a href="#" class="correo"><i class="far fa-envelope"></i></a>
            </div>
            <div class="head-bottom flex-center">
              <div class="datos-head flex-center">
                <div class="dato-head mesa-central flex-center">
                  <img src="images/icon_mobile.svg" alt="">
                  <div>
                    <p>Mesa Central</p>
                    <h5><a href="tel:56226183000">(56) 22 618 3000</a></h5>
                  </div>
                </div>
                <div class="dato-head rescate flex-center">
                  <img src="images/icon_rescate.svg" alt="">
                  <div>
                    <p>Rescate</p>
                    <h5><a href="tel:56228261111">(56) 22 826 1111</a></h5>
                  </div>
                </div>
                <a href="#" class="btn btn-amarillo">RESERVA DE HORA</a>
              </div>
              <div class="box-login logeado">
                <img src="images/ic-user.svg" alt="">
                <h5>Bienvenida</h5>
                <h4>Juanita Perez Cotapos</h4>
                <i class="fas fa-chevron-down"></i>
                <div class="menu-usuario">
                  <ul>
                    <li><a href="#">Mi Perfil</a></li>
                    <li class="m-dropdown close"><a href="#">Personas vinculadas <i class="fas fa-chevron-right"></i></a>
                      <ul class="submenu">
                        <li><a href="#">Baltazar Eskenazi Perez</a></li>
                        <li class="activo"><a href="#">Maximiliano Eskenazi Perez
                          </a></li>
                        <li><a href="#">Maria Jose Riquelme Perez</a></li>
                        <li><a href="#">Miguel Eskenazi Torres</a></li>
                      </ul>
                    </li>
                    <li><a href="#">Reserva de horas</a></li>
                    <li><a href="#">Reserva de horas dental</a></li>
                    <li><a href="#">Mis Reservas de horas activas</a></li>
                    <li><a href="#">Mi historial de horas médicas</a></li>
                    <li><a href="#">Mis profesionales favoritos</a></li>
                    <li><a href="#">Resultados de exámenes <i class="fas fa-chevron-right"></i></a></li>
                    <li><a href="#">Seguro y convenios</a></li>
                    <li><a href="#">Pago de cuentas</a></li>
                  </ul>
                  <div class="cerrar-sesion-user">
                    <i class="fas fa-times"></i> Cerrar sesión
                  </div>
                </div>
              </div>
            </div>
            <div class="head-movil">
              <div class="buscar-movil">
                <img src="images/ic-lupa.svg" alt="">
              </div>
              <div class="rescate-movil">
                <img src="images/ic-celular.svg" alt="">
              </div>
              <div class="login-movil">
                <img src="images/ic-user.svg" alt="">
              </div>
              <div class="btn-menu close" id="btn-menu">
                <span></span>
                <span></span>
                <span></span>
              </div>
              <div class="buscador-movil">
                <input type="text" placeholder="Ingrese su búsqueda">
                <button type="submit" class="btn btn-verde btn-full">BUSCADOR</button>
              </div>
              <div class="box-rescate-movil">
                <a href="tel:56226183000">
                  <img src="images/icon_mobile2.svg" alt="">
                  <span>Mesa Central</span>
                  (56) 22 618 3000
                  <i class="fas fa-chevron-right"></i>
                </a>
                <a href="tel:56226183000">
                  <img src="images/icon_rescate2.svg" alt="">
                  <span>Mesa Central</span>
                  (56) 22 618 3000
                  <i class="fas fa-chevron-right"></i>
                </a>
              </div>
              <div class="box-login-movil">
                <div class="menu-usuario">
                  <ul>
                    <li><a href="#">Mi Perfil</a></li>
                    <li class="m-dropdown close"><a href="#">Personas vinculadas <i class="fas fa-chevron-right"></i></a>
                      <ul class="submenu">
                        <li><a href="#">Baltazar Eskenazi Perez</a></li>
                        <li class="activo"><a href="#">Maximiliano Eskenazi Perez
                          </a></li>
                        <li><a href="#">Maria Jose Riquelme Perez</a></li>
                        <li><a href="#">Miguel Eskenazi Torres</a></li>
                      </ul>
                    </li>
                    <li><a href="#">Reserva de horas</a></li>
                    <li><a href="#">Reserva de horas dental</a></li>
                    <li><a href="#">Mis Reservas de horas activas</a></li>
                    <li><a href="#">Mi historial de horas médicas</a></li>
                    <li><a href="#">Mis profesionales favoritos</a></li>
                    <li><a href="#">Resultados de exámenes <i class="fas fa-chevron-right"></i></a></li>
                    <li><a href="#">Seguro y convenios</a></li>
                    <li><a href="#">Pago de cuentas</a></li>
                  </ul>
                  <div class="cerrar-sesion-user">
                    <i class="fas fa-times"></i> Cerrar sesión
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <nav id="navHead">

          <div class="wrap">
            <ul>
              <li><a href="#">Médicos y Especialidades</a> <i class="fas fa-chevron-down"></i>
                <ul class="submenu">
                  <li><a href="#">Buscador de médicos</a></li>
                  <li><a href="#">Especialidades</a></li>
                  <li><a href="#">Otros profesionales de la salud</a></li>
                  <li><a href="#">Glosario médico</a></li>
                </ul>
              </li>
              <li><a href="#">Centros y Programas</a> <i class="fas fa-chevron-down"></i></li>
              <li><a href="#">Servicios y Unidades</a> <i class="fas fa-chevron-down"></i></li>
              <li><a href="#">Seguros y Convenios</a> <i class="fas fa-chevron-down"></i></li>
              <li><a href="#">Actividades de Extensión</a> <i class="fas fa-chevron-down"></i></li>
              <li><a href="#">SERVICIOS EN LINEA</a> <i class="fas fa-chevron-down"></i>
                <ul class="submenu">
                  <li><a href="#">Reserva de hora</a></li>
                  <li><a href="#">Reserva hora dental</a></li>
                  <li><a href="#">Buscador de médicos</a></li>
                  <li><a href="#">Solicitud de documentos</a></li>
                  <li><a href="#">Presupuestos</a></li>
                  <li><a href="#">Saludos a pacientes</a></li>
                  <li><a href="#">Admisión</a></li>
                  <li><a href="#">Pago de cuentas</a></li>
                  <li><a href="#">Fotos de recién nacido</a></li>
                </ul>
              </li>
            </ul>
            <ul class="m2-movil">
              <li><a href="#">Noticias</a></li>
              <li><a href="#">Responsabilidad Social</a></li>
              <li><a href="#">Docencia e Investigación</a></li>
              <li><a href="#">Quienes Somos</a></li>
              <li><a href="#">Contacto</a></li>
            </ul>
          </div>
        </nav>
      </header>
        <header class="sticky" id="head-sticky">
          <div class="wrap flex-between-top">
            <a href="#" class="logo">
              <img src="images/logo-blanco.svg" alt="Clínica Universidad de Los Andes">
            </a>
            <div class="head">
              <div class="head-top flex-right">
                <div class="nav-top">
                  <a href="#">Quiénes Somos</a>
                  <a href="#">Docencia e Investigación</a>
                  <a href="#">Responsabilidad Social</a>
                  <a href="#">Noticias</a>
                </div>
                <div class="tamano-letra">
                  <a href="#">A</a>
                  <a href="#">A</a>
                  <a href="#">A</a>
                </div>
                <div class="buscador" id="buscador2">
                  <input type="text" placeholder="Ingrese su búsqueda">
                  <button type="submit"><i class="fas fa-search"></i></button>
                </div>
                <a href="#" class="lupa" id="lupa2"><i class="fas fa-search"></i></a>
                <div class="fonos flex-center" id="fonos">
                  <span><img src="images/icon_mobile2.svg" alt=""> <a href="tel:56226183000">(56) 22 618 3000</a></span>
                  <span><img src="images/icon_rescate2.svg" alt=""> <a href="tel:56228261111">(56) 22 826 1111</a></span>
                  <div class="cerrar-fonos" id="cerrar-fonos"><i class="far fa-times-circle"></i></div>
                </div>
                <a href="#" class="fono" id="verFono"><i class="fas fa-phone"></i></a>
                <a href="#" class="correo"><i class="far fa-envelope"></i></a>
              </div>
              <div class="head-bottom flex-right">
                <nav id="navHead">
                  <ul>
                    <li><a href="#">Médicos y<br> Especialidades</a> <i class="fas fa-chevron-down"></i>
                      <ul class="submenu">
                        <li><a href="#">Buscador de médicos</a></li>
                        <li><a href="#">Especialidades</a></li>
                        <li><a href="#">Otros profesionales de la salud</a></li>
                        <li><a href="#">Glosario médico</a></li>
                      </ul>
                    </li>
                    <li><a href="#">Centros y<br> Programas</a> <i class="fas fa-chevron-down"></i></li>
                    <li><a href="#">Servicios y<br> Unidades</a> <i class="fas fa-chevron-down"></i></li>
                    <li><a href="#">Seguros y<br> Convenios</a> <i class="fas fa-chevron-down"></i></li>
                    <li><a href="#">Actividades de<br> Extensión</a> <i class="fas fa-chevron-down"></i></li>
                  </ul>
                </nav>
                <div class="botones-head flex-between">
                  <a href="#" class="btn btn-verde-dark">Servicios en línea</a>
                  <a href="#" class="btn btn-amarillo">Reserva de hora</a>
                </div>
              </div>
              <div class="btn-menu close" id="btn-menu">
                <span></span>
                <span></span>
                <span></span>
              </div>
            </div>
          </div>
        </header>

        <div class="sticky-movil">
          <div class="menu-servicios">
            <ul>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Reserva de hora</a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Reserva de hora dental</a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Buscador de médicos</a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Presupuestos</a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Admisión</a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Pago de cuentas</a></li>
            </ul>
          </div>
          <a href="#" class="m-servicios">SERVICIOS EN LÍNEA <i class="fas fa-chevron-up"></i></a>
          <div class="chat">
            <img src="images/ic-chat.svg" alt="">
          </div>
        </div>

<section class="bread">
    <div class="wrap">
      <a href="#">Home</a> > Mi Clínica UANDES > Reserva de hora
    </div>
</section>

<section class="pb-2 home-priv">
  <div class="wrap">
    <div class="flex-stretch">
      <div class="panel-usuario">
        <div class="header">
          <img src="images/ic-user.svg" alt="">
          <h4>BIENVENID@</h4>
          <h5>JUANITA PEREZ COTAPOS</h5>
        </div>
        <ul>
          <li><a href="#">Mi Perfil</a></li>
          <li class="m-dropdown close"><a>Personas vinculadas <i class="fas fa-chevron-down"></i></a>
            <ul class="submenu">
              <li><a href="#"><i class="fas fa-chevron-right"></i> Baltazar Eskenazi Perez</a></li>
              <li class="activo"><a href="#"><i class="fas fa-chevron-right"></i> Maximiliano Eskenazi Perez
                </a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Maria Jose Riquelme Perez</a></li>
              <li><a href="#"><i class="fas fa-chevron-right"></i> Miguel Eskenazi Torres</a></li>
            </ul>
          </li>
          <li class="activo"><a href="#">Reserva de horas</a></li>
          <li><a href="#">Reserva de horas dental</a></li>
          <li><a href="#">Mis Reservas de horas activas</a></li>
          <li><a href="#">Mi historial de horas médicas</a></li>
          <li><a href="#">Mis profesionales favoritos</a></li>
          <li><a href="#">Resultados de exámenes <i class="fas fa-chevron-right"></i></a></li>
          <li><a href="#">Seguros y convenios</a></li>
          <li><a href="#">Pago de cuentas</a></li>
        </ul>
      </div>
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
          <label>Ingrese la especialidad o nombre del profesional</label>
          <div class="w-form">
            
       <select name="ctl00$contentPlaceHolder$dpBusqueda" id="contentPlaceHolder_dpBusqueda" class="chosen-select">
		<option value="CIRUGÍA GENERAL">CIRUG&#205;A GENERAL</option>
		<option value="MEDICINA INTERNA">MEDICINA INTERNA</option>
		<option value="CIRUGÍA DIGESTIVA">CIRUG&#205;A DIGESTIVA</option>
		<option value="CARDIOLOGÍA">CARDIOLOG&#205;A</option>
		<option value="NICOLAS VEAS">NICOLAS VEAS</option>
		<option value="JORGE LEON">JORGE LEON</option>
		<option value="PABLO VALDES">PABLO VALDES</option>
		<option value="CATALINA DI GIUSSEPE">CATALINA DI GIUSSEPE</option>

	</select><asp:Button ID="Button1" CssClass="btn btn-amarillo" runat="server" Text="Button" />
            <%--<button class="btn btn-amarillo">BUSCAR </button>--%>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

<footer>
  <div class="wrap">
    <div class="flex-between-top">
      <div class="logos-footer">
        <a href="#"><img src="images/logo2.svg" alt="" class="logo-2"></a>
        <a href="#"><img src="images/logo-acre.svg" alt="" class="logo-acre"></a>
      </div>
      <div class="w-footer">
        <h4>Conócenos</h4>
        <ul>
          <li><a href="#">Tour Virtual</a></li>
          <li><a href="#">Horarios</a></li>
          <li><a href="#">Sala de Prensa</a></li>
          <li><a href="#">Derechos y Deberes del Paciente</a></li>
          <li><a href="#">Trabaja con Nosotros</a></li>
          <li><a href="#">Portal Personas</a></li>
          <li><a href="#">Universidad de los Andes</a></li>
        </ul>
      </div>
      <div class="w-footer">
        <h4>Contacto</h4>
        <p>Avda. Plaza 2501, Las Condes, Santiago. Chile</p>
        <p>Mesa Central (56) 22 618 3000 </p>
        <p>Rescate (56) 22 826 1111</p>
        <p><a href="#">contacto@clinicauandes.cl</a></p>
      </div>
    </div>
    <div class="footer-bottom flex-between-top">
      <div class="newsletter">
        <label>Suscríbete a Nuestro Newsletter</label>
        <div class="form-group">
          <input type="text" placeholder="Ingresa tu Email">
          <button class="btn btn-amarillo">SUSCRÍBETE</button>
        </div>
      </div>
      <div class="links">
        <a href="#"><i class="fas fa-chevron-right"></i> Privacidad y Seguridad</a>
        <a href="#"><i class="fas fa-chevron-right"></i> Términos y Condiciones</a>
      </div>
      <div class="redes-footer">
        <a href="#"><i class="fab fa-facebook-f"></i></a>
        <a href="#"><i class="fab fa-twitter"></i></a>
        <a href="#"><i class="fab fa-instagram"></i></a>
        <a href="#"><i class="fab fa-youtube"></i></a>
      </div>
    </div>
  </div>
</footer>

<script src="js/jquery.min.js"></script>
<script src="js/tiny-slider.js" defer></script>
<script src="js/lazyload.js" defer></script>
<script type="text/javascript" src="js/slowNumber.js"></script>
<script src="js/accordion.js" defer></script>
<script src="js/wow.js" defer></script>
<script src="js/select2.min.js" defer></script>
<script type="text/javascript" src="js/funciones.js" defer></script>
<script type="text/javascript" src="js/funciones-privado.js" defer></script>
<script src="js/funciones-widget.js" defer></script>
    </form>
</body>
</html>