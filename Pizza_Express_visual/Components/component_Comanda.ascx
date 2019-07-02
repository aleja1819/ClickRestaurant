<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="component_Comanda.ascx.cs" Inherits="Pizza_Express_visual.Components.component_Comanda" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

   <style>
        .ocultarCol {
        display:none;
        }
    </style>


<%--<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">--%>
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!------ Include the above in your HEAD tag ---------->


<div class="row">

    <div class="col-md-12">

        <asp:UpdatePanel runat="server" ID="uContenedorUsuario" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>

                <%--PRIMERA COLUMNA--%>
                <div class="row">
                    <div class="col-md-6">
                        <h6 class="section-title h3 text-center text-dark">CARGA DE LOS MENUS</h6>
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idMostrarMenu" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                OnRowCommand="idMostrarMenu_RowCommand">
                                <HeaderStyle CssClass="btn-dark" />

                                <Columns>
                                    <asp:BoundField DataField="codigo_menu" HeaderText="Código" />
                                    <asp:BoundField DataField="nombre_menu" HeaderText="Nombre" />
                                    <asp:BoundField DataField="precio_menu" HeaderText="Precio" />
                                    <asp:BoundField DataField="ingredientes_menu" HeaderText="Ingredientes" />
                                    <asp:BoundField DataField="nombre_tamanoP" HeaderText="Tamaño" />
                                    <asp:BoundField DataField="nombre_categoria" HeaderText="Categoria" />

                                    <asp:ButtonField ButtonType="Link" CommandName="idselected" ControlStyle-CssClass="btn btn-danger" Text="Seleccione" />

                                </Columns>
                            </asp:GridView>
                            <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2; AllowPaging="true;--%>
                        </div>

                    </div>
                    <%--CIERRE COLUMNA--%>


                    <%--SEGUNDA COLUMNA--%>
                    <div class="col-md-6">

                        <!-- Tabs -->
                        <section id="tabs">
                            <div class="container">
                                <h6 class="section-title h3 text-center text-dark">Menú</h6>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <nav>
                                            <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                                                <a class="nav-item nav-link text-warning" id="tab-pizza" data-toggle="tab" href="#nav-pizza" role="tab" aria-controls="nav-pizza" aria-selected="true">PIZZAS</a>
                                                <a class="nav-item nav-link text-warning" id="tab-tabla" data-toggle="tab" href="#nav-tabla" role="tab" aria-controls="nav-tabla" aria-selected="false">TABLAS</a>
                                                <a class="nav-item nav-link text-warning" id="tab-sandiwch" data-toggle="tab" href="#nav-sandiwch" role="tab" aria-controls="nav-sandiwch" aria-selected="false">SANDIWCH</a>
                                                <a class="nav-item nav-link text-warning" id="tab-platos" data-toggle="tab" href="#nav-plato" role="tab" aria-controls="nav-plato" aria-selected="false">PLATOS</a>
                                                <a class="nav-item nav-link text-warning" id="tab-bebestible" data-toggle="tab" href="#nav-bebestible" role="tab" aria-controls="nav-bebestible" aria-selected="false">BEBESTIBLES</a>
                                                <a class="nav-item nav-link text-warning" id="tab-Picadillo" data-toggle="tab" href="#nav-Picadillo" role="tab" aria-controls="nav-Picaddillo" aria-selected="false">Para Picar</a>
                                            </div>
                                        </nav>
                                        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                                            <div class="tab-pane fade show active" id="nav-pizza" role="tabpanel" aria-labelledby="tab-pizza">
                                                <div class="btn-group-vertical" role="group">
                                                    <a href="#" class="list-group">

                                                        
                                                            <asp:DropDownList runat="server"  ID="idOpciones" CssClass="btn btn-secondary">
                                                                <%--ES UN CONBOBOX--%>

                                                                <asp:ListItem Value="0" Text="Grande"  Selected="True"></asp:ListItem>
                                                                
                                                            </asp:DropDownList>


                                                            <asp:Button ID="tabfamiliar" OnClick="tabGrande_Click" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="FAMILIAR" />
                                                            <%--<asp:Button ID="tabmediana" CssClass="btn btn-success btn-lg  btn-block" runat="server" Text="MEDIANA" />
                                                            <asp:Button ID="tabindividual" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="INDIVIDUAL" />--%>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="nav-tabla" role="tabpanel" aria-labelledby="tab-tabla">
                                                <%--BOTONES--%>
                                                <div class="btn-group-vertical" role="group">
                                                    <a href="#" class="list-group">

                                                        <asp:Button ID="tabTablas" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="TABLAS" />
                                                        <asp:Button ID="taAgregadoT" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="AGREGADO" />

                                                    </a>
                                                </div>
                                                <%--FIN BOTONES--%>
                                            </div>
                                            <div class="tab-pane fade" id="nav-sandiwch" role="tabpanel" aria-labelledby="tab-sandiwch">
                                                <%--BOTONES--%>
                                                <div class="btn-group-vertical" role="group">
                                                    <a href="#" class="list-group">

                                                        <asp:Button ID="btnChurrasco" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="CHURRASCOS" />
                                                        <asp:Button ID="btnAgregadoC" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="AGREGADO" />

                                                    </a>
                                                </div>
                                                <%--FIN BOTONES--%>
                                            </div>
                                            <div class="tab-pane fade" id="nav-plato" role="tabpanel" aria-labelledby="tab-platos">
                                                <%--BOTONES--%>
                                                <div class="btn-group-vertical" role="group">
                                                    <a href="#" class="list-group">

                                                        <asp:Button ID="btnPlatos" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="PLATOS" />
                                                        <asp:Button ID="btnAgregadoP" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="AGREGADO DE PLATO" />
                                                        <asp:Button ID="btnEnsaladaP" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="ENSALDA" />
                                                        <asp:Button ID="btnPostreP" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="POSTRES" />

                                                    </a>
                                                </div>
                                                <%--FIN BOTONES--%>
                                            </div>
                                            <div class="tab-pane fade" id="nav-bebestible" role="tabpanel" aria-labelledby="tab-bebestible">
                                                <%--BOTONES--%>
                                                <div class="btn-group-vertical" role="group">
                                                    <a href="#" class="list-group">

                                                        <asp:Button ID="btnVinos" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="VINOS" />
                                                        <asp:Button ID="btnTragos" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="TRAGOS" />
                                                        <asp:Button ID="btnCervezas" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="CERVEZAS" />
                                                        <asp:Button ID="btnBebidaE" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="BEBIDA EXPRESS" />
                                                        <asp:Button ID="btnBebidaL" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="BEBIDA LITRO" />
                                                        <asp:Button ID="btnJugo" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="JUGOS" />
                                                    </a>
                                                </div>
                                                <%--FIN BOTONES--%>
                                            </div>
                                            <div class="tab-pane fade" id="nav-Picadillo" role="tabpanel" aria-labelledby="tab-Picadillo">
                                                <%--BOTONES--%>
                                                <div class="btn-group-vertical" role="group">
                                                    <a href="#" class="list-group">

                                                        <asp:Button ID="btnPapas" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="PAPAS FRITAS" />
                                                        <asp:Button ID="btnPicadillo" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="PICADILLO" />
                                                        <asp:Button ID="btnSalsa" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="SALSAS" />
                                                    </a>
                                                </div>
                                                <%--FIN BOTONES--%>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </section>
                        <!-- ./Tabs -->

                    </div>
                    <!-- FIN ./Tabs -->

                </div>
                <%--FIN COLUMNA TAB--%>
                        </div><%--FIN ROW--%>

                <%--CIERRE COLUMNA--%>

                <div class="row">
                    <div class="col-md-6">
                        <%--TABLA CARGA DE MENUS--%>
                        <h6 class="section-title h3 text-center text-dark">TABLA DETALLE PAGO</h6>

                        <div class="container offset-3">
                            <asp:Button runat="server" ID="btnenviarC" Text="Enviar Comanda" CssClass="btn btn-warning" />
                            <asp:Button runat="server" ID="btnpago" Text="Pagar" CssClass="btn btn-info" />
                            <asp:Button runat="server" ID="btnAnular" Text="Anular" CssClass="btn btn-danger" />
                        </div>
                    </div>


                    <%--PRECIO DETALLE--%>
                    <div class="col-md-6">
                        <h6 class="section-title h3 text-center text-dark">TABLA DETALLE ELECCION DE COMIDA</h6>
                        <%--TABLA GRIDVIEW--%>
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idCargarSeleccion" CssClass="table table-bordered table-center " AutoGenerateColumns="false">
                                <HeaderStyle CssClass="btn-dark" />

                                <Columns>
                                    <asp:BoundField DataField="" HeaderText="codigo" />
                                    <asp:BoundField DataField="" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="" HeaderText="detalle" />
                                    <asp:BoundField DataField="" HeaderText="Precio" />

                                    <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-light" Text="Editar" />
                                    <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                                </Columns>
                            </asp:GridView>
                            <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2; AllowPaging="true; OnRowCommand="idTabla_RowCommand--%>
                        </div>
                    </div>
                </div>
                </div>
                 
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</div>



