<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Clientes.Master" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="AlquilaCocheras.Web.clientes.reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <%--    LISTADO DE RESERVAS (gridview, repeater o datalist)
        
            fecha inicio.
            fecha fin
            horario
            precio total.
            puntuación 
        
    --%>
    <table class="highlight light-blue">
        <thead>
            <tr>
                <th data-field="fechaInicio">fecha inicio</th>
                <th data-field="fechaFin">fecha fin</th>
                <th data-field="hora">horario</th>
                <th data-field="precioTotal">precio total</th>
                <th data-field="puntuacion">puntuacion</th>
                <th data-field="Select"></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>10/05/2016</td>
                <td>20/05/2016</td>
                <td>9</td>
                <td>$1800.00</td>
                <td>4</td>
                <td><asp:HyperLink ID="aConfirmar" runat="server" ClientIDMode="Static" NavigateUrl="/clientes/confirmar-reserva.aspx?idcochera=123">Reservar</asp:HyperLink></td>
            </tr>
        </tbody>
    </table>


    


    <!-- Modal -->
    <div id="miModal" class="modal">
        <!-- Contenido Modal -->
        <div class="modal-content">
            <span class="close">x</span>
            <div>
                <%--hidden donde se guarda el id de la reserva elegida para que desde el codebehind se pueda identificar--%>
                <input type="hidden" id="hdIdReserva" />
                <asp:DropDownList runat="server" ID="ddlPuntuacion" ClientIDMode="Static">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                </asp:DropDownList>

                <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" ClientIDMode="Static" />
                <button class="cerrar">Cerrar</button>
            </div>
        </div>
    </div>
</asp:Content>
