<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Pizza_Express_visual.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div class="form-group">
                                <label for="trut">Rut Usuario</label>
                                <asp:TextBox runat="server" placeholder="Rut usuario" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Rut Obligatorio"
                                    ControlToValidate="trut"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>

                            </div>
           <asp:TextBox runat="server" placeholder="Nombre Usuario" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Nombre Usuario Obligatorio"
                                    ControlToValidate="tnombre"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                         

                            <%--EMAIL USUARIO--%>
                            <div class="form-group">
                                <label for="temail">Email Usuario</label>
                                <asp:TextBox runat="server" placeholder="Email Usuario" ID="temail" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Nombre Usuario Obligatorio"
                                    ControlToValidate="temail"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                            </div>

                            <%--CONTRASEÑA USUARIO--%>
                            <div class="form-group">
                                <label for="tclave">Contraseña</label>
                                <asp:TextBox runat="server" ID="tclave" TextMode="Password" placeholder="Contraseña" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Contraseña Obligatoria"
                                    ControlToValidate="tclave"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                            </div>

        <asp:Button runat="server" ID="btn" OnClick="btn_Click" ValidationGroup="grupo1" Text="test"/>
    </form>
</body>
</html>
