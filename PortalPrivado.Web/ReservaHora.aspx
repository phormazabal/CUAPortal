<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="ReservaHora.aspx.cs" Inherits="PortalPrivado.Web.ReservaHora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
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
            <input type="text">
            <button class="btn btn-amarillo">BUSCAR </button>
          </div>
        </div>
      </div>
</asp:Content>
