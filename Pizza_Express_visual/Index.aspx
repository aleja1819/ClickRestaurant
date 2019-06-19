<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Pizza_Express_visual.Index" %>

<%@ Register Src="~/Components/component_Bienvenidos.ascx" TagPrefix="uc1" TagName="component_Bienvenidos" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css" />
</head>
<body class="bg-secondary">
    <form id="form1" runat="server" method="post">

        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <%--ESTO ES UNA LIBRERIA PARA CARGAR EL PANEL--%>
        <asp:UpdatePanel runat="server" ID="uBarraMenu" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <%--Para evitar un panel dentro de otro panel = childreaAsTriggers--%>

            <ContentTemplate>

                <div class="row ">
                    <div class="col">

                        <!-- Barra de navegación -->
                        <nav class="navbar navbar-expand-lg navbar-dark bg-danger">
                            <!-- Brand -->
                            <a class="navbar-brand" href="#">Pizza Express</a><br />
                            <br />

                            <!-- Toggler/collapsibe Button -->
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                                <span class="navbar-toggler-icon"></span>
                            </button>

                    <!-- Navbar links -->
                     <div class="collapse navbar-collapse" id="collapsibleNavbar">
                                <ul class="navbar-nav">

<%--                                    <li class="nav-item">
                                        <%--<asp:LinkButton CssClass="nav-link" runat="server" Visible="false" ID="Menu_cerrar">Cerrar</asp:LinkButton>
                                  <asp:LinkButton CssClass="nav-link" runat="server" ID="Menu_Login">Login</asp:LinkButton>
                                    </li>--%>

                                </ul>
                            </div>

                            <%--HOME--%>
                            <asp:LinkButton runat="server" Visible="false" OnClick="Menu_home_Click" CssClass="navbar-brand" ID="Menu_home">
                                <div class="btn-group-toggle">
                                    <i class="fas fa-home fa-2x"></i> Home

                                </div> 
                            </asp:LinkButton>

                            <%--VENTA--%>
                            <ul class="nav nav-default">
                                <li class="nav-item dropdown show">

                                    <asp:LinkButton Style="color: lightsteelblue"  Class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" ID="Menu_ventas" runat="server"
                                        aria-haspopup="true" aria-expanded="true"> 
                                                <i class="fas fa-dollar-sign fa-2x"></i> Ventas</asp:LinkButton>
                                    <div class="dropdown-menu show" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Monto Inicial</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Reservas</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Número de mesa</asp:LinkButton>
                                    </div>
                                </li>
                            </ul>

                            <%--ADMINISTRACIÓN--%>
                            <ul class="nav nav-default">
                                <li class="nav-item dropdown show">

                                    <asp:LinkButton Style="color: lightsteelblue"  CssClass="nav-link dropdown-toggle" data-toggle="dropdown" href="#" ID="Menu_administracion" runat="server"
                                        aria-haspopup="true" aria-expanded="true">  
                                                <i class="fas fa-users-cog fa-2x"></i> Administración</asp:LinkButton>
                                    <div class="dropdown-menu show" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 38px, 0px);">
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Usuarios</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Proveedores</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Registrar Productos</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Inventario</asp:LinkButton>
                                         <asp:LinkButton runat="server" CssClass="dropdown-item">Carta Menú</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="dropdown-item">Reportes</asp:LinkButton>
                                    </div>
                                </li>
                            </ul>


                            <%--LOGIN--%>
                            <asp:LinkButton Style="color: beige" runat="server" CssClass="nav-link" OnClick="login_Click" ID="login">              
                                         <div class="btn-group-toggle">
                                             <i class="far fa-user fa-2x"></i> Login
                                         </div>
                            </asp:LinkButton>

                            <%--BIENVENIDOS--%>
                            <asp:LinkButton runat="server" Visible="false" CssClass="nav-link " ID="bCerrarSesion">
                             
                                <div class="btn-group-vertical"  style="color:beige">
                                     Bienvenido@<%=Session["userName"] %>
                                           </div>
                            </asp:LinkButton>

                        </nav>

                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="uContenido" ChildrenAsTriggers="true">
            <ContentTemplate>

                <%--VISTAS--%>
                <asp:MultiView runat="server" ID="mcontenedor">

                    <asp:View runat="server" ID="vProducto">
                    </asp:View>
                    <asp:View runat="server" ID="vUsuario">
                    </asp:View>
                    <asp:View runat="server" ID="vAsignarMenu">
                    </asp:View>
                    <asp:View runat="server" ID="vBienvenida">
                        <uc1:component_Bienvenidos runat="server" id="component_Bienvenidos" />
                    </asp:View>
                </asp:MultiView>

            </ContentTemplate>
        </asp:UpdatePanel>

        <%--ESTETICA DEL MODAL--%>
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm bg-light" role="document">

                <asp:UpdatePanel ID="uModal" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info">Login</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="uname1">Usuario</label>
                                    <asp:TextBox runat="server" placeholder="Usuario" ID="tusuario" CssClass="form-control"></asp:TextBox>

                                    <%--VALIDADOR DE CAMPOS REQUERIDOS--%>


                                    <asp:RequiredFieldValidator runat="server"
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        ErrorMessage="Usuario Requerido"
                                        ControlToValidate="tusuario"
                                        ValidationGroup="grupo1"></asp:RequiredFieldValidator>

                                </div>

                                <div class="form-group">
                                    <label>Contraseña</label>
                                    <asp:TextBox runat="server" ID="tclave" TextMode="Password" placeholder="Clave" CssClass="form-control"></asp:TextBox>

                                    <%--VALIDADOR DE CAMPOS REQUERIDOS--%>


                                    <asp:RequiredFieldValidator runat="server"
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        ErrorMessage="Contraseña Obligatoria"
                                        ControlToValidate="tclave"
                                        ValidationGroup="grupo1"></asp:RequiredFieldValidator>




                                </div>
                                <asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary float-right" data-dismiss="modal">Cerrar</button>
                                <asp:Button runat="server" ValidationGroup="grupo1" ID="Mostrar" Text="Ingresar" CssClass="btn btn-info float-right" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>

    <%--LIBRERIAS JAVASCRIPT:--%>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
 <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
