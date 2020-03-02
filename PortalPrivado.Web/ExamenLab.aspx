<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="ExamenLab.aspx.cs" Inherits="PortalPrivado.Web.ExamenLab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
      <script type="text/javascript">      
        function ActivarPostClickAceptar() {

            /*oculto el mensage que contiene el modalPopUp para evitar que se presione durante la ejecución*/
            div = document.getElementById('divdesv');
            div.style.display = 'none';

        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box-perfil sin-padding b-con-tabla">
        <asp:UpdatePanel ID="UpdatePanel1" class="box-res tabla-prof mt-0" runat="server">
            <ContentTemplate>
                 <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesv"  TargetControlID="Label1" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>--%>
       
                <div class="tabla-resultados tabla-prof box-res">

                    <table class="table-responsive">
                        <thead>
                            <tr>
                                <th>Tipo de estudio</th>
                                <th>Área</th>
                                <th>Médico responsable</th>
                                <th>Fecha</th>
                                <th>Estado</th>
                                <th class="col-accion col-btn">Compartir</th>
                                <th class="col-accion col-btn">Visualizar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="grdExam" runat="server" DataKeyNames="accession_number" OnPagePropertiesChanging="grdHistorico_PagePropertiesChanging" OnItemCommand="grdExam_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbPrestacion" runat="server" Text='<%# Eval("prestacion") %>'></asp:Label>
                                            <asp:HiddenField ID="hdcompartir" runat="server" Value='<%# Eval("compartir_estudio") %>' />
                                        </td>
                                        <td>Laboratorio</td>
                                        <td>
                                            <asp:Label ID="lbProfesional" runat="server" Text='<%# Eval("informante") %>'></asp:Label>
                                        </td>
                                        <td><%# Eval("fecha_estudio") %></td>
                                        <td><%# Eval("estado_publicacion").Equals("4") ?
                                                        "En<br>progreso</td>":Eval("estado_publicacion").Equals("6") ? "Disponible<br>para retiro</td>": "Disponible</td>"
                                        %>
                                        <td class="col-accion col-btn">
                                                <asp:CheckBox ID='chkCompartir' CommandName='C' Checked='<%# Convert.ToBoolean(Eval("compartir"))%>' runat='server' />
      
                                        </td>
                                        <td class="col-accion col-btn">
                                            <asp:LinkButton ID="LinkButton1" CausesValidation="false" CommandName="A" runat="server">
                                        <img src="images/ic-1b.png" alt=""></asp:LinkButton></td>
                                        <%-- <a href='<%# Eval("pdf") %>' target="_blank">--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>              
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="DataPager1" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="d-flex-descargar">
            <asp:LinkButton ID="lnkCompartir" CssClass="btn btn-amarillo" CausesValidation="false"  runat="server" OnClick="lnkCompartir_Click">COMPARTIR SELECCIONADOS</asp:LinkButton>

            <div class="paginador">
                <a href="#" class="pag-nav"><i class="fas fa-chevron-left"></i></a>
                <asp:DataPager ID="DataPager1" PagedControlID="grdExam" PageSize="6" runat="server">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
                <a href="#" class="pag-nav"><i class="fas fa-chevron-right"></i></a>
            </div>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div id="divdesv">
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
