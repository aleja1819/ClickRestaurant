<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Pizza_Express_visual.Index" %>

<style>
    .ocultarCol {
        display: none;
    }
</style>


<%@ Register Src="~/Components/component_Bienvenidos.ascx" TagPrefix="uc1" TagName="component_Bienvenidos" %>
<%@ Register Src="~/Components/components_CartaMenu.ascx" TagPrefix="uc1" TagName="components_CartaMenu" %>
<%@ Register Src="~/Components/components_Inventario.ascx" TagPrefix="uc1" TagName="components_Inventario" %>
<%@ Register Src="~/Components/components_Proveedores.ascx" TagPrefix="uc1" TagName="components_Proveedores" %>
<%@ Register Src="~/Components/components_RegistrarProductos.ascx" TagPrefix="uc1" TagName="components_RegistrarProductos" %>
<%@ Register Src="~/Components/components_Reportes.ascx" TagPrefix="uc1" TagName="components_Reportes" %>
<%@ Register Src="~/Components/components_Usuarios.ascx" TagPrefix="uc1" TagName="components_Usuarios" %>
<%@ Register Src="~/Components/component_Caja.ascx" TagPrefix="uc1" TagName="component_Caja" %>
<%@ Register Src="~/Components/components_Mesas.ascx" TagPrefix="uc1" TagName="components_Mesas" %>






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

        <asp:UpdatePanel runat="server" ID="uBarraMenu" UpdateMode="Conditional" ChildrenAsTriggers="true">
      
            <ContentTemplate>

                <div class="row ">
                    <div class="col">

                        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">

                            <a class="navbar-brand" href="#">
                                <img src="Imagenes/LOGO APP.png" class="img-thumbnail img-rounded shadow-lg" style="width: 4rem" />
                            </a>
                            <br />

                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                                <span class="navbar-toggler-icon"></span>
                            </button>

                            <div class="collapse navbar-collapse" id="collapsibleNavbar">
                                <ul class="navbar-nav">
                                </ul>
                            </div>

                            <asp:LinkButton runat="server" Visible="false" OnClick="Menu_home_Click1" CssClass="navbar-brand" ID="Menu_home">
                                <div class="btn-group-toggle">
                                    <i class="fas fa-home fa-2x"></i> Home

                                </div> 
                            </asp:LinkButton>

                            <%--VENTA--%>
                            <ul class="nav nav-default">
                                <li class="nav-item dropdown">

                                    <asp:LinkButton Style="color: white" Class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" Visible="false" ID="Menu_ventas" runat="server"
                                        aria-haspopup="true" aria-expanded="false"><i class="fas fa-dollar-sign fa-2x"></i> Ventas</asp:LinkButton>
                                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                        <asp:LinkButton runat="server" ID="Menu_Mesas" OnClick="Menu_Mesas_Click" CssClass="dropdown-item">Toma de Pedidos</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Menu_Caja" OnClick="Menu_Caja_Click" CssClass="dropdown-item">Apertura Caja</asp:LinkButton>
                                    </div>
                                </li>
                            </ul>

                            <%--ADMINISTRACIÓN--%>
                            <ul class="nav nav-default">
                                <li class="nav-item dropdown show">

                                    <asp:LinkButton Style="color: white" CssClass="nav-link dropdown-toggle" data-toggle="dropdown" href="#" Visible="false" ID="Menu_administracion" runat="server"
                                        aria-haspopup="true" aria-expanded="true"><i class="fas fa-users-cog fa-2x"></i> Administración</asp:LinkButton>
                                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                        <asp:LinkButton runat="server" ID="Menu_usuarios" OnClick="Menu_usuarios_Click" CssClass="dropdown-item">Usuarios</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Menu_Proveedores" OnClick="Menu_Proveedores_Click" CssClass="dropdown-item">Proveedores</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Menu_RegistrarProductos" OnClick="Menu_RegistrarProductos_Click" CssClass="dropdown-item">Productos</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Menu_Inventario" OnClick="Menu_Inventario_Click" CssClass="dropdown-item">Inventario</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Menu_CartaMenu" OnClick="Menu_CartaMenu_Click" CssClass="dropdown-item">Carta Menú</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="Menu_Reportes" OnClick="Menu_Reportes_Click" CssClass="dropdown-item">Reportes</asp:LinkButton>
                                    </div>
                                </li>
                            </ul>


                            <%--LOGIN--%>
                            <asp:LinkButton Style="color: beige" runat="server" CssClass="nav-link" OnClick="login_Click" ID="login">              
                                         <div class="btn-group-toggle">
                                             <i class="far fa-user fa-2x"></i> Login
                                         </div>
                            </asp:LinkButton>

                            <asp:Panel runat="server" CssClass="btn-group" ID="mostrar_usuario" Visible="false">

                                <asp:LinkButton runat="server" CssClass="nav-link  badge badge-pill badge-success dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="idCerrarSesion">
                             <div class="btn-group-vertical" style="color: ghostwhite">
                                    Bienvenido@<%=Session["name_user"] %>
                                </div>
                                
                                </asp:LinkButton>
                                <div class="dropdown-menu">
                                    <asp:LinkButton runat="server" CssClass="dropdown-item" OnClick="bCerrarSesion_Click" ID="bCerrarSesion">
                                Cerrar Sesión
                                    </asp:LinkButton>
                                    <div class="dropdown-divider"></div>
                                    <asp:LinkButton runat="server" CssClass="dropdown-item">
                               Notificaciones
                                    </asp:LinkButton>
                                </div>

                            </asp:Panel>
                        </nav>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="uContenido" ChildrenAsTriggers="true">
            <ContentTemplate>

                  <%--ALERTA DE MENSAJE--%>
                <div class="container">
                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <br />

                <asp:Panel runat="server" ID="MostrarLogo" Visible="true">
                    <br />
                    <br />

                    <div id="carouselExampleFade" class="carousel slide carousel-fade" data-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="Imagenes/LOGO%20APP.png" class="Responsive image mx-auto d-block" 
                                    style="width: 41rem"/>
                            </div>
                            <div class="carousel-item align-content-center">
                                <img src="Imagenes/1.jpg" class="Responsive image mx-auto d-block" 
                                    style="width: 50rem"/>
                            </div>
                            <div class="carousel-item align-content-center">
                                <img src="Imagenes/2.jpg" class="Responsive image mx-auto d-block"
                                    style="width: 47rem"/>
                            </div>
                            <div class="carousel-item align-content-center">
                                <img src="Imagenes/7.jpg"  class="Responsive image mx-auto d-block"
                                    style="width: 55rem"/>
                            </div>
                            <div class="carousel-item align-content-center">
                                <img src="Imagenes/4.jpg"  class="Responsive image mx-auto d-block" 
                                    style="width: 45rem "/>
                            </div>
                            <div class="carousel-item align-content-center">
                                <img src="Imagenes/6.jpg"  class="Responsive image mx-auto d-block" 
                                    style="width: 50rem"/>
                            </div>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExampleInterval" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExampleInterval" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </asp:Panel>

                <%--VISTAS--%>
                <asp:MultiView runat="server" ID="mcontenedor">

                   <asp:View runat="server" ID="vUsuarios">
                        <uc1:components_Usuarios runat="server" ID="components_Usuarios" />
                    </asp:View>
                    <asp:View runat="server" ID="vProveedores">
                        <uc1:components_Proveedores runat="server" ID="components_Proveedores" />
                    </asp:View>
                    <asp:View runat="server" ID="vRegistrar_producto">
                        <uc1:components_RegistrarProductos runat="server" ID="components_RegistrarProductos" />
                    </asp:View>
                    <asp:View runat="server" ID="vInventario">
                        <uc1:components_Inventario runat="server" ID="components_Inventario" />
                    </asp:View>
                    <asp:View runat="server" ID="vCarta_menu">
                        <uc1:components_CartaMenu runat="server" ID="components_CartaMenu" />
                    </asp:View>
                    <asp:View runat="server" ID="vReportes">
                        <uc1:components_Reportes runat="server" ID="components_Reportes" />
                    </asp:View>
                    <asp:View runat="server" ID="vBienvenida">
                        <uc1:component_Bienvenidos runat="server" ID="component_Bienvenidos" />
                    </asp:View>
                    <asp:View runat="server" ID="vCaja">
                        <uc1:component_Caja runat="server" ID="component_Caja" />
                    </asp:View>
                    <asp:View runat="server" ID="vMesas">
                        <uc1:components_Mesas runat="server" id="components_Mesas" />
                    </asp:View>

                </asp:MultiView>

            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm bg-light" role="document">

                <asp:UpdatePanel ID="uModal" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info">Inicio Sesión</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            
                            <div class="modal-body">

                                <div class="form-group">
                                    <label for="tnombre">Nombre Usuario (*)</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-user"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="nombre usuario" ID="tnombres" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <asp:RequiredFieldValidator runat="server"
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        ErrorMessage="Usuario Requerido"
                                        ControlToValidate="tnombres"
                                        ValidationGroup="grupo1"></asp:RequiredFieldValidator>

                                </div>

                                <div class="form-group">
                                    <label>Contraseña (*)</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-key"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" ID="tclave" TextMode="Password" placeholder="Clave" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <asp:RequiredFieldValidator runat="server"
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        ErrorMessage="Contraseña Obligatoria"
                                        ControlToValidate="tclave"
                                        ValidationGroup="grupo1"></asp:RequiredFieldValidator>

                                </div>

                                <asp:Label runat="server" ID="ErrorInicioSesion" Text="Mensaje" Visible="false"></asp:Label>
                                
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary float-right" data-dismiss="modal">Cerrar</button>
                                <asp:Button runat="server" ValidationGroup="grupo1" OnClick="bingresar_login_Click" ID="bingresar_login" Text="Ingresar" CssClass="btn btn-info float-right" />
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

</body>
</html>
