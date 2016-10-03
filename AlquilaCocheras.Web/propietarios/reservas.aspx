﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Propietarios.Master" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="AlquilaCocheras.Web.propietarios.reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <div class="row">
        <div class="col s12 m10 offset-m1">
            <div class="z-depth-4 card-panel">

                <div class="row">
                    <div class=" col s12 m12 input-field">
                        <asp:Label ID="label1" runat="server" Text="Período Disponible: "></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m12 input-field">
                        <%--<asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" ClientIDMode="Static" />--%>
                        <asp:LinkButton ID="btnFiltrar" CssClass="btn cyan waves-effect waves-light" ClientIDMode="Static" runat="server" Text="Filtrar" ></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>