<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Anonimo.Master" AutoEventWireup="true" CodeBehind="registracion.aspx.cs" Inherits="AlquilaCocheras.Web.registracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <%--    <asp:Label ID="label1" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label2" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label3" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label4" runat="server" Text="Contraseña: "></asp:Label>
    <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label5" runat="server" Text="Confirme Contraseña: "></asp:Label>
    <asp:TextBox ID="txtConfContrasenia" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>

    <asp:RadioButtonList ID="rblPerfil" runat="server" ClientIDMode="Static">
        <asp:ListItem Text="Cliente" Value="1" />
        <asp:ListItem Text="Propietario" Value="2" />
    </asp:RadioButtonList>

    <asp:Label ID="lblResultado" runat="server"></asp:Label>
    <asp:Button ID="btnRegistrarUsuario" runat="server" Text="Registrar usuario" ClientIDMode="Static" />--%>

    <div class="row">
        <div class="col s12 m10 offset-m1">
            <div class="z-depth-4 card-panel">

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label1" runat="server" Text="Nombre: "></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un Nombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label2" runat="server" Text="Apellido: "></asp:Label>
                        <asp:TextBox ID="txtApellido" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar un Apellido" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label3" runat="server" Text="Email: "></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe ingresar un Email" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Formato de Email Incorrecto" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">*</asp:RegularExpressionValidator>
                    </div>

                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label6" runat="server" Text="Perfil: "></asp:Label>
                        <asp:RadioButtonList ID="rblPerfil" runat="server" ClientIDMode="Static">
                            <asp:ListItem Text="Cliente" Value="1" />
                            <asp:ListItem Text="Propietario" Value="2" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvPerfil" runat="server" ControlToValidate="rblPerfil" ErrorMessage="Debe seleccionar un Perfil" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label4" runat="server" Text="Contraseña: "></asp:Label>
                        <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="Debe ingresar una Contraseña" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revContrasenia" ControlToValidate="txtContrasenia" runat="server" ErrorMessage="La contraseña debe empezar con mayúscula y contener al menos 1 número" ValidationExpression="^[A-Z]{1,}(([a-zA-Z0-9]+[0-9]{1,}[a-zA-Z0-9]+)|([0-9]{1,}[a-zA-Z0-9]+)|([a-zA-Z0-9]+[0-9]{1,}))$" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revContrasenia8" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="La contraseña debe tener al menos 8 caracteres" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]{8,}">*</asp:RegularExpressionValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label5" runat="server" Text="Confirme Contraseña: "></asp:Label>
                        <asp:TextBox ID="txtConfContrasenia" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfContrasenia" runat="server" ControlToValidate="txtConfContrasenia" ErrorMessage="Debe reingresar la Contaseña" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvContraseñas" runat="server" ControlToCompare="txtContrasenia" ControlToValidate="txtConfContrasenia" ErrorMessage="Las Contraseñas no coinciden" ForeColor="Red" ValueToCompare="=">*</asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="revConfContrasenia" ControlToValidate="txtConfContrasenia" runat="server" ErrorMessage="La contraseña debe empezar con mayúscula y contener al menos 1 número" ValidationExpression="^[A-Z]{1,}(([a-zA-Z0-9]+[0-9]{1,}[a-zA-Z0-9]+)|([0-9]{1,}[a-zA-Z0-9]+)|([a-zA-Z0-9]+[0-9]{1,}))$" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revConfContrasenia8" runat="server" ControlToValidate="txtConfContrasenia" ErrorMessage="La contraseña debe tener al menos 8 caracteres" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]{8,}">*</asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Button ID="btnRegistrarUsuario" runat="server" Text="Registrar usuario" CssClass="btn cyan waves-effect waves-light" ClientIDMode="Static" OnClick="btnRegistrarUsuario_Click" />
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
