<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Vincular.aspx.cs" Inherits="PortalPrivado.Web.Vincular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <script type="text/javascript">
        //function openModal() {
        //    $('#divpopup').modal('show');
        //}
        function ActivarPostClickAceptar() {

            /*oculto el mensage que contiene el modalPopUp para evitar que se presione durante la ejecución*/
            div = document.getElementById('divdesv');
            div.style.display = 'none';

        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box-personas" id="form-perfil">
        <div class="texto pb-0">
            <p>Personas vinculadas es un servicio mediante el cual puede acceder a la información de salud de su familia o de otras personas relacionadas. Una vez vinculada una persona, usted podrá ingresar a esa cuenta desde la suya, sin necesidad de registrar nuevamente su clave de acceso. Si la persona que quiere vincular no tiene clave, debe solicitarla presencialmente en la clínica.</p>
        </div>
        <%-- <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesv"  TargetControlID="Label1" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>
        --%>
        <div class="form-vincular">
            <div class="w-vincular">
                <div class="form-group">
                    <label>RUT a vincular</label>
                    <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Contraseña cuenta a vincular</label>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group form-group--button">
                    <asp:LinkButton ID="lkVincular" runat="server" Autopostback="true" CssClass="btn btn-amarillo" OnClick="lkVincular_Click">VINCULAR</asp:LinkButton>
                </div>
            </div>
        </div>
        <h3>Personas Vinculadas</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rpVinculados" runat="server" OnItemCommand="rpVinculados_ItemCommand">
                    <ItemTemplate>
                        <% if (rpVinculados.Items.Count > 0)
                            {%>
                        <div class="item-persona">
                            <p><%#  Eval("Nombre") + " " + Eval("Apellidos") %></p>
                            <asp:HiddenField ID="hdRut" runat="server" Value='<%# Eval("Rut") %>' />
                            <asp:HiddenField ID="hdNombre" runat="server" Value='<%#  Eval("Nombre") + " " + Eval("Apellidos") %>' />
                            <div class="botones-persona">
                                <asp:LinkButton ID="LinkButton2" class="btn btn-amarillo" CommandName="A" runat="server">ACCEDER</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="R" CommandArgument="" CssClass="btn btn-borde-gris">DESVINCULAR</asp:LinkButton>
                            </div>
                        </div>
                        <% } %>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lkVincular" EventName="Click" />
                <%--<asp:AsyncPostBackTrigger ControlID="LinkButton4" EventName="Click" />--%>
            </Triggers>
        </asp:UpdatePanel>
        <h3>Personas que pueden acceder a mi cuenta</h3>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Repeater ID="rpVinculador" runat="server" OnItemCommand="rpVinculador_ItemCommand">
                    <ItemTemplate>
                        <div class="item-persona">
                             <asp:HiddenField ID="hdNombrev" runat="server" Value='<%#  Eval("Nombre") + " " + Eval("Apellidos") %>' />
                            <p><%#  Eval("Nombre") + " " + Eval("Apellidos") %></p>
                            <asp:HiddenField ID="hdNombreVincu" runat="server" Value='<%#  Eval("Nombre") + " " + Eval("Apellidos") %>' />
                            <asp:HiddenField ID="hdRutVincu" runat="server" Value='<%# Eval("Rut") %>' />
                            <asp:LinkButton ID="lnkDesvincular" runat="server" CommandName="R" CssClass="btn btn-borde-gris">DESVINCULAR</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="LinkButton4" />
            </Triggers>
        </asp:UpdatePanel>
          </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <div id="divdesv">
      <div class="popup visible">
          <div class="w-pop">
              <!--div class="cerrar-pop"><i class="fas fa-times"></i></!--div-->
              <h3>Desvinculación de personas</h3>
              <p>¿Está seguro de querer desvincular a <span>
                  <asp:Label ID="lbNombreDes" runat="server" Text=""></asp:Label>?</span></p>
              <div class="botones">
                  <asp:LinkButton ID="LinkButton3" CssClass="btn btn-borde-gris" runat="server" OnClick="LinkButton3_Click">CANCELAR</asp:LinkButton>
                  <asp:LinkButton ID="LinkButton4" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton4_Click">CONFIRMAR</asp:LinkButton>
              </div>
          </div>
      </div>
    </div>
   </asp:Panel>    
</asp:Content>
