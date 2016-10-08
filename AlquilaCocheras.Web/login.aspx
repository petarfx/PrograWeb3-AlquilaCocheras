<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Anonimo.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AlquilaCocheras.Web.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">
    <%--        <div class="row">
            <div class=" col s12 m6 offset-m3 input-field">
                <input id="txtEmail" type="email" class="validate">
                <label for="txtEmail">Email</label>
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6 offset-m3 input-field">
                <input id="txtContrasenia" type="password" class="validate">
                <label for="txtContrasenia">Password</label>
            </div>
        </div>--%>
    <div class="row">
        <div class="col s12 m6 offset-m3">
            <div class="z-depth-4 card-panel">
                <div class="row">
                    <div class="input-field col s12 center">
                        <h4>Login</h4>
                        <p class="center">Ingrese sus datos para continuar</p>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m10 offset-m1 input-field">
                        <asp:Label ID="label3" runat="server" Text="Email: "></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe ingresar un Email" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Formato de Email Incorrecto" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">*</asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m10 offset-m1 input-field">
                        <asp:Label ID="label2" runat="server" Text="Contraseña: "></asp:Label>
                        <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="Debe ingresar la contraseña" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 center-align input-field">
                        <asp:Label ID="lblResultado" runat="server"></asp:Label>
                    </div>

                </div>
                <div class="row">
                    <div class=" col s12 center-align">
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 center-align input-field">
                        <a href="/registracion.aspx">Registrarse como nuevo usuario.</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m12 center-align input-field">
                        <asp:Button ID="btnLogin" CssClass="btn cyan waves-effect waves-light" runat="server" Text="Ingresar" OnClick="btnLogin_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
