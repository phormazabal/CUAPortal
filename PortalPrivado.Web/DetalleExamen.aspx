<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="DetalleExamen.aspx.cs" Inherits="PortalPrivado.Web.DetalleExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
   <%-- <script type="text/javascript">
        function ActivarPostClickAceptar() {
            div = document.getElementById('divdesv');
            div.style.display = 'none';
        }
        function ActivarPostClickAceptar1() {
            div = document.getElementById('divdesv1');
            div.style.display = 'none';
        }
    </script>    --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel class="box-perfil vista-examen" ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<div class="box-perfil vista-examen">--%>
        <div class="col-lg-12">
            <asp:LinkButton ID="LinkButton2" CssClass="volver" runat="server" CausesValidation="false" OnClick="lkVOlver_Click"><img src="images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>
        </div>
        <div class="header-examen">

            <div class="titulo">
                <h4>
                    <asp:Label ID="lbNombreEstudio" runat="server" Text=""></asp:Label></h4>
                <p>
                    <b>Médico responsable:</b>
                    <asp:Label ID="lbNombreMed" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <b>Fecha:</b>
                    <asp:Label ID="lbFechaEstudio" runat="server" Text=""></asp:Label>
                </p>
            </div>
            <div class="acciones">
                <asp:Panel ID="pnImg" runat="server" Visible="false">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><img src="images/ic-imagenes.png" alt=""><br>
                        Imágenes</asp:LinkButton>
                </asp:Panel>
                <asp:LinkButton ID="lkCompartir" runat="server" OnClick="lkCompartir_Click1"><img src="images/ic-compartir.svg" alt=""><br>
                    Compartir</asp:LinkButton>
                </a></div>
        </div>
        <div class="cont-examen">
            <iframe id="iFrameExam" runat="server" width="100%" height="467px" alt=""></iframe>
        </div>   
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID ="LinkButton1" />
            <asp:PostBackTrigger ControlID ="lkCompartir" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="pnExamen" runat="server" Visible="false">
                <div id="divdesv">
                    <div class="popup visible">
                        <div class="w-pop">
                            <asp:LinkButton ID="lkCerraImgrSession" CssClass="cerrar-pop" OnClick="lkCerraImgrSession_Click" runat="server"><i class="fas fa-times"></i></asp:LinkButton>
                            <iframe id="iFrameXero" runat="server" width="100%" height="467px" alt=""></iframe>
                        </div>
                    </div>
                </div>
            </asp:Panel>
    <asp:Panel ID="pnCompartir" runat="server" Visible="false">
            <div id="divComp">
            <div class="popup visible">
                <div class="w-pop">
                    <h3>Compartir resultado de examen por correo electrónico</h3>
                    <div class="form-group">
                        <label>Ingrese el e-mail de quien recibirá los resultados de este examen</label>
                        <asp:TextBox ID="txtCompartir" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic"
                                        ControlToValidate="txtCompartir" ForeColor="Red" ErrorMessage="Falta Ingreso de Email"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtCompartir"
                                        ErrorMessage="Formato de correo no valido" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                          </div>
                    <div class="botones">
                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-borde-gris" CausesValidation="false" runat="server" OnClick="LinkButton3_Click">CANCELAR</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton4_Click">ENVIAR</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        </asp:Panel>
</asp:Content>
