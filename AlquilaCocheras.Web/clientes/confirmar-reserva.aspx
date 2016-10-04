<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Clientes.Master" AutoEventWireup="true" CodeBehind="confirmar-reserva.aspx.cs" Inherits="AlquilaCocheras.Web.clientes.confirmar_reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <%--    <asp:Label ID="label2" runat="server" Text="Fecha Inicio: "></asp:Label>
    <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:Label ID="label4" runat="server" Text="Fecha Fin: "></asp:Label>
    <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label3" runat="server" Text="Hora de Entrada: "></asp:Label>
    <asp:TextBox ID="txtHorarioInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:Label ID="label1" runat="server" Text="Hora de Salida: "></asp:Label>
    <asp:TextBox ID="txtHorarioFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="lblUbicacion" ClientIDMode="Static" runat="server"></asp:Label>
    <asp:Image ID="imgFoto" ClientIDMode="Static" runat="server" />
    <asp:Label ID="lblPrecioHora" ClientIDMode="Static" runat="server"></asp:Label>
    <asp:Label ID="lblPrecioTotal" ClientIDMode="Static" runat="server"></asp:Label>

    <asp:Label ID="lblResultado" runat="server"></asp:Label>
    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Reserva" ClientIDMode="Static"/>   
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" ClientIDMode="Static" />--%>


    <div class="row">
        <div class="col s12 m10 offset-m1">
            <div class="z-depth-4 card-panel">

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label2" runat="server" Text="Fecha Inicio: "></asp:Label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label4" runat="server" Text="Fecha Fin: "></asp:Label>
                        <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label1" runat="server" Text="Hora de Entrada: "></asp:Label>
                        <asp:TextBox ID="txtHorarioInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label3" runat="server" Text="Hora de Salida: "></asp:Label>
                        <asp:TextBox ID="txtHorarioFin" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label5" runat="server" Text="Precio Hora: "></asp:Label>
                        <asp:Label ID="lblPrecioHora" ClientIDMode="Static" runat="server"></asp:Label>
    
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label6" runat="server" Text="Precio Total: "></asp:Label>
                        <asp:Label ID="lblPrecioTotal" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label7" runat="server" Text="Ubicacion: "></asp:Label>
                        <asp:Label ID="lblUbicacion" ClientIDMode="Static" runat="server"></asp:Label>
    
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label9" runat="server" Text="Precio Total: "></asp:Label>
                        <asp:Image ID="imgFoto" ClientIDMode="Static" runat="server" />
                    </div>
                </div> 
                               
                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:LinkButton ID="btnConfirmar" CssClass="btn cyan waves-effect waves-light" ClientIDMode="Static" runat="server" Text="Confirmar Reserva"></asp:LinkButton>
                        <asp:LinkButton ID="btnCancelar" CssClass="btn cyan waves-effect waves-light" ClientIDMode="Static" runat="server" Text="Cancelar"></asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Label ID="lblResultado" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 center-align">
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
