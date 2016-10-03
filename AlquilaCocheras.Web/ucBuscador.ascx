<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBuscador.ascx.cs" Inherits="AlquilaCocheras.Web.ucBuscador" %>

<div class="row">
    <div class="col s12 m6 offset-m3">
        <div class="z-depth-4 card-panel">
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <asp:Label ID="label1" runat="server" Text="Ubicacion: "></asp:Label>
                    <asp:TextBox ID="txtUbicacion" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <asp:Label ID="label2" runat="server" Text="Período Disponible: "></asp:Label><i class="mdi mdi-bell"></i>
                    <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <%--<div class=" col s12 m10 offset-m1 input-field">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" ClientIDMode="Static" />
                </div>--%>
                <div class="col s12 m12 center-align input-field">
                    <asp:LinkButton ID="btnFiltrar" CssClass="btn cyan waves-effect waves-light" runat="server" Text="Buscar"></asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <%--si no se encuentran resultados mostrar mensaje "No se encontraron resultados"--%>
                    <asp:Label ID="lblResultado" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>
