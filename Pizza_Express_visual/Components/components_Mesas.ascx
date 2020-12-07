<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Mesas.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Mesas" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<h1 class="text-center">Presentación de Mesas y Pedidos</h1>
<br />

<style>
    .ocultarCol {
        display: none;
    }
</style>

<asp:UpdatePanel ID="uContenido" runat="server" UpdateMode="Conditional" ChildrenASTrigger="true">
    <ContentTemplate>
        <asp:MultiView ID="mContenedor" runat="server">

            <%--Vista Menú Comanda--%>
            <asp:View runat="server" ID="vComanda">
                <div class="container col-md-12">
                    <h3><span class="text-warning"><strong>Nuevo Pedido Mesa N° <%=System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]%></strong></span></h3>
                    <br />

                    <%--ALERTA DE MENSAJE--%>
                    <div class="container">
                        <asp:Panel runat="server" ID="alerta" Visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                             <asp:Label ID="mensaje3" runat="server"></asp:Label> 
                        </asp:Panel>
                    </div>

                    <div class="row">
                        <div class="col-md-1">
                            <div class="d-flex flex-row mt-2">
                                <ul class="nav nav-tabs nav-tabs--vertical nav-tabs--left" role="navigation">
                                    <li class="nav-item">
                                        <a href="#tabpizza" class="nav-link active" data-toggle="tab" role="tab" aria-controls="tabpizza">PIZZAS</a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#tabTabla" class="nav-link" data-toggle="tab" role="tab" aria-controls="tabTabla">TABLAS</a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#tabSandiwch" class="nav-link" data-toggle="tab" role="tab" aria-controls="tabSandiwch">SÁNDIWCH</a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#tabPicadillo" class="nav-link" data-toggle="tab" role="tab" aria-controls="tabPicadillo">PICADILLO</a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#tabPlatos" class="nav-link" data-toggle="tab" role="tab" aria-controls="tabPlatos">PLATOS</a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#tabBebestible" class="nav-link" data-toggle="tab" role="tab" aria-controls="tabBebestible">BEBESTIBLE</a>
                                    </li>
                                </ul>
                            </div>
                            <%--FIN D-FELX--%>
                        </div>
                        <%--FIN COLUMNA--%>

                        <div class=" col-md-3 offset-1">
                            <div class="tab-content">
                                <div class="tab-pane fade show active" id="tabpizza" role="tabpanel">
                                    <div class="btn-group-vertical" role="group">
                                        <asp:LinkButton ID="idGrande" OnClick="idGrande_Click" CssClass=" btn btn-success" runat="server" Text="FAMILIAR"></asp:LinkButton><br />
                                        <asp:LinkButton ID="idMediana" OnClick="idMediana_Click" CssClass="btn btn-success" runat="server" Text="MEDIANA"></asp:LinkButton><br />
                                        <asp:LinkButton ID="idIndividual" OnClick="idIndividual_Click" CssClass="btn btn-success" runat="server" Text="INDIVIDUAL"></asp:LinkButton>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabTabla" role="tabpanel">
                                    <div class="btn-group" role="group">

                                        <asp:LinkButton ID="idTablas" OnClick="idTablas_Click" CssClass=" btn btn-success" runat="server" Text="TABLAS"></asp:LinkButton>

                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabSandiwch" role="tabpanel">
                                    <div class="btn-group-vertical" role="group">
                                        <asp:LinkButton ID="idsandiwch" OnClick="idsandiwch_Click" CssClass=" btn btn-success" runat="server" Text="CHURRASCOS"></asp:LinkButton>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabPicadillo" role="tabpanel">
                                    <div class="btn-group-vertical" role="group">
                                        <asp:LinkButton ID="idQueso" OnClick="idQueso_Click" CssClass=" btn btn-success" runat="server" Text="QUESO"></asp:LinkButton>

                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabPlatos" role="tabpanel">
                                    <div class="btn-group-vertical" role="group">
                                        <asp:LinkButton ID="idPlato" CssClass=" btn btn-success" OnClick="idPlato_Click" runat="server" Text="PLATO_CARTA"></asp:LinkButton><br />
                                        <asp:LinkButton ID="idAgregado" CssClass=" btn btn-success" OnClick="idAgregado_Click" runat="server" Text="AGREGADO"></asp:LinkButton><br />
                                        <asp:LinkButton ID="idEnsalda" CssClass=" btn btn-success" runat="server" OnClick="idEnsalda_Click" Text="ENSALDA "></asp:LinkButton>

                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabBebestible" role="tabpanel">
                                    <div class="btn-group-vertical" role="group">
                                        <asp:LinkButton ID="idVinos" OnClick="idVinos_Click" CssClass=" btn btn-success" runat="server" Text="VINOS"></asp:LinkButton><br />
                                        <asp:LinkButton ID="idBebidas" OnClick="idBebidas_Click" CssClass=" btn btn-success" runat="server" Text="BEBIDAS"></asp:LinkButton><br />
                                        <asp:LinkButton ID="idJugos" OnClick="idJugos_Click" CssClass=" btn btn-success" runat="server" Text="JUGOS "></asp:LinkButton><br />
                                        <asp:LinkButton ID="idLicores" OnClick="idLicores_Click" CssClass=" btn btn-success" runat="server" Text="LICORES "></asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                            <%--FIN TAB CONTENT--%>
                        </div>
                        <%--FIN COLO BOTON DETALLE--%>


                        <div class=" col-md-7">
                            <div class="col align-content-center">
                                <asp:GridView runat="server" ID="idMostrarMenu" CssClass="table table-bordered table-center " AutoGenerateColumns="false" OnRowCommand="idMostrarMenu_RowCommand">
                                    <HeaderStyle CssClass="btn-dark" />

                                    <Columns>
                                        <asp:BoundField DataField="codigo_menu" HeaderText="Código Interno" HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol"/>
                                        <asp:BoundField DataField="nombre_menu" HeaderText="Nombre" />
                                        <asp:BoundField DataField="precio_menu" HeaderText="Precio" DataFormatString="${0:N0}" />
                                        <asp:BoundField DataField="ingredientes_menu" HeaderText="Ingredientes" />

                                        <asp:ButtonField ButtonType="Link" CommandName="idselected" ControlStyle-CssClass="btn btn-danger bt-sm" Text=" + " />

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-5">
                            <hr />

                            <h6 class="section-title h6 text-center text-dark">TABLA DETALLE PAGO</h6>

                            <br />

                            <h3 class="text-dark text-center">
                                <asp:Label runat="server" ID="ltotal" Text="Total a pagar $0"></asp:Label></h3>
                            <br />

                            <%-- BOTONES DE COMANDA --%>
                            <div class="container  offset-2">
                                    <asp:LinkButton ID="btnGenerarPDF" CssClass="btn btn-danger" OnClick="btnGenerarPDF_Click" runat="server">
                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-notes" width="40" height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#ffffff" fill="none" stroke-linecap="round" stroke-linejoin="round">
                                          <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                          <rect x="5" y="3" width="14" height="18" rx="2" />
                                          <line x1="9" y1="7" x2="15" y2="7" />
                                          <line x1="9" y1="11" x2="15" y2="11" />
                                          <line x1="9" y1="15" x2="13" y2="15" />
                                        </svg><br />
                                        Generar<br /> Ticket Comanda

                                    </asp:LinkButton>

                                <asp:LinkButton ID="btnLimpiar" CssClass="btn btn-warning" OnClick="btnLimpiar_Click" runat="server">
                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-artboard" width="40" height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#ffffff" fill="none" stroke-linecap="round" stroke-linejoin="round">
                                      <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                      <rect x="8" y="8" width="8" height="8" rx="1" />
                                      <line x1="3" y1="8" x2="4" y2="8" />
                                      <line x1="3" y1="16" x2="4" y2="16" />
                                      <line x1="8" y1="3" x2="8" y2="4" />
                                      <line x1="16" y1="3" x2="16" y2="4" />
                                      <line x1="20" y1="8" x2="21" y2="8" />
                                      <line x1="20" y1="16" x2="21" y2="16" />
                                      <line x1="8" y1="20" x2="8" y2="21" />
                                      <line x1="16" y1="20" x2="16" y2="21" />
                                    </svg><br />
                                    Limpiar<br /> Pedido Actual</asp:LinkButton> 

                                <asp:LinkButton ID="btnCancelar" CssClass="btn btn-info" OnClick="btnCancelar_Click" runat="server" >
                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-square-check" width="40" height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#ffffff" fill="none" stroke-linecap="round" stroke-linejoin="round">
                                      <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                      <rect x="4" y="4" width="16" height="16" rx="2" />
                                      <path d="M9 12l2 2l4 -4" />
                                    </svg><br />
                                    Finalizar <br /> Pedido Actual
                                </asp:LinkButton> 
                            </div>

                        </div>
                        <div class="col-md-7">
                            <hr />
                            <h6 class="section-title h6 text-center text-dark">TABLA DETALLE ELECCION DE COMIDA</h6>
                            <%--TABLA GRIDVIEW--%>
                            <div class="col align-content-center">
                                <asp:GridView runat="server" ID="idCargarSeleccion" CssClass="table table-bordered table-center " AutoGenerateColumns="false" OnRowCommand="idCargarSeleccion_RowCommand">
                                    <HeaderStyle CssClass="btn-dark" />
                                    <Columns>
                                        <asp:BoundField DataField="codigo_M" HeaderText="Código Interno" HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol"/>
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="nombre_M" HeaderText="Nombre" />
                                        <asp:BoundField DataField="precio_M" HeaderText="Precio" />

                                        <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-danger" Text="-" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <%--FIN ROW--%>
                </div>
            </asp:View>


            <%--            ========================== Vista Mesas ===================================--%>
            <asp:View runat="server" ID="vMesas">
                <div class="container">

                    <div class="container">
                        <asp:Panel runat="server" ID="alertaMesas" Visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <asp:Label ID="mensajeMesas" runat="server"></asp:Label>
                        </asp:Panel>
                    </div>


                    <%-- Fila 1 --%>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa1" OnClick="bMesa1_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 1</strong>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa2" OnClick="bMesa2_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 2</strong>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa3" OnClick="bMesa3_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 3</strong>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa4" OnClick="bMesa4_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 4</strong>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa5" OnClick="bMesa5_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 5</strong>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa6" OnClick="bMesa6_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 6</strong>             
                            </asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />

                    <%-- Fila 2 --%>

                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa7" OnClick="bMesa7_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 7</strong>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa8" OnClick="bMesa8_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <strong>Mesa 8</strong>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa9" OnClick="bMesa9_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 16px"><strong>Mesa 9</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa10" OnClick="bMesa10_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 15px"><strong>Mesa 10</strong></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa11" OnClick="bMesa11_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 11</strong></span>      
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa12" OnClick="bMesa12_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 12</strong></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />

                    <%-- Fila 3 --%>

                    <h4 class="text-center"><strong>Sección Pedidos para llevar</span></strong></h4>
                    <br />

                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa13" OnClick="bMesa13_Click" runat="server" CssClass="btn btn-primary">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 13</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa14" OnClick="bMesa14_Click" runat="server" CssClass="btn btn-primary">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 14</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa15" OnClick="bMesa15_Click" runat="server" CssClass="btn btn-primary">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 15</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa16" OnClick="bMesa16_Click" runat="server" CssClass="btn btn-primary">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 16</strong></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa17" OnClick="bMesa17_Click" runat="server" CssClass="btn btn-primary">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 17</strong></span>      
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa18" OnClick="bMesa18_Click" runat="server" CssClass="btn btn-primary">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 18</strong></span>
                            </asp:LinkButton>
                        </div>
                    </div>

                </div>
            </asp:View>
            
            <%-- Vista Pedidos Pendientes --%>
            <asp:View ID="vPendiente" runat="server">
                <div class="container-fluid">  
                    <br />
                    
                    <div class="row">

                        <div class="col-md-10">

                            <%-- GridView para solo un pedido en una mesa --%>
                            <div class="row">
                                <div class="col-md-4 text-center">
                                    <h2><span class="text-danger"><strong>Pedidos Mesa N° <%=System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]%></strong></span></h2>
                                </div>
                            
                                <div class="col-md-8 text-center">                                
                                    <h2><span class="text-danger"><strong> Total a Cancelar: $<%=Session["precioTotal"]%></strong></span></h2>
                                </div>
                            </div><br />
                            <asp:GridView ID="gridUnPedido" runat="server" CssClass="table table-bordered table-center" AutoGenerateColumns="False" OnRowCommand="gridUnPedido_RowCommand">
                                <HeaderStyle CssClass="btn-dark" />
                                <Columns>
                                    <asp:BoundField DataField="codigo_comanda" HeaderText="ID PEDIDO"/>
                                    <asp:BoundField DataField="nombre_menu" HeaderText="Pedido" />
                                    <asp:BoundField DataField="precio_menu" HeaderText="Valor Unitario" />
                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="subtotal" HeaderText="SubTotal" />
                                </Columns>
                            </asp:GridView>

                        </div>
                        <div class="col-md-2 text-center">
                        <br /> <br /> <br />
                            <asp:LinkButton ID="Nuevo_Pedido" OnClick="Nuevo_Pedido_Click" runat="server" CssClass="btn btn-success">
                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                                <span style="font-size: 15px">Nuevo Pedido</span>             
                            </asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton runat="server" CssClass="btn btn-danger " OnClick="PagarModal_Click" ID="PagarModal">
                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path></svg>
                                <span style="font-size: 15px">Realizar Pago</span>
                            </asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="btnVolverMesas" runat="server" CssClass="btn btn-warning" OnClick="btnVolverMesas_Click">
                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 10h10a8 8 0 018 8v2M3 10l6 6m-6-6l6-6"></path></svg>
                                <span style="font-size: 20px">Volver</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:View>

        </asp:MultiView>
    </ContentTemplate>

    <Triggers>
        <asp:PostBackTrigger ControlID="btnGenerarPDF" />
        <%--     <asp:PostBackTrigger ControlID="btnpagos" />--%>
    </Triggers>

</asp:UpdatePanel>

<%-- Modal Pago --%>
<div class="modal" id="myModalComanda" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg bg-light" role="document">

        <asp:UpdatePanel ID="uModalComanda" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>

                <div class="modal-content">

                    <div class="modal-header">
                        <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">PAGO</span></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <br />

                        <h3 class="text-dark text-center">
                            Total a Cancelar $<asp:Label runat="server" ID="LTotalCancelar"></asp:Label>                            
                        </h3>
                        <br />
                        <br />

                        <%--Tipo Pago--%>
                        <div class="form-group">
                            <label for="fTipoProducto">Forma de Pago (*)</label>
                            <br />
                            <asp:DropDownList runat="server" ID="ftipoPago" CssClass="form-control"
                                DataTextField="nombre" DataValueField="codigo_tipoPago">
                            </asp:DropDownList>
                        </div>

                         <%--Transferencia--%>
                        <div class="form-group">
                            <label for="ttransferencia">N° Transferencia (*)</label>
                            <div class="input-group mb-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text text-info"><i class="fa fa-usd"></i></div>
                                </div>
                                <asp:TextBox ID="ttransferencia" runat="server"  placeholder="Ingrese N° transferencia, solo si canceló con tarjeta "  CssClass="form-control bg-secondary"></asp:TextBox>
                                <asp:Label runat="server" ID="validar_ttransferencia" CssClass="invalid-feedback" Text="Verifique Este campo, Medio de Pago Efectivo = Vacío, Medio de Pago Tarjeta = N° Comprobante RedCompra"></asp:Label>
                            </div>
                        </div>

                        <%--Propina--%>
                        <div class="form-group">
                            <label for="tpropina">Propina (*)</label>
                            <div class="input-group mb-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text text-info"><i class="fa fa-usd"></i></div>
                                </div>
                                <asp:TextBox ID="tpropina" runat="server" OnTextChanged="tpropina_TextChanged" placeholder="$" AutoPostBack="true" CssClass="form-control bg-secondary">0</asp:TextBox>
                                <asp:Label runat="server" ID="validar_tpropina" CssClass="invalid-feedback" Text="Complete campos, Ingrese propina"></asp:Label>
                            </div>
                        </div>

                        <%--Descuento--%>
                        <div class="form-group">
                            <label for="tdescuento">Descuento (*)</label>
                            <div class="input-group mb-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text text-info"><i class="fa fa-usd"></i></div>
                                </div>
                                <asp:TextBox ID="tdescuento" runat="server" placeholder="$"  CssClass="form-control bg-secondary"
                                    OnTextChanged="tdescuento_TextChanged" AutoPostBack="true">0</asp:TextBox>
                                 <asp:Label runat="server" ID="validar_tdescuento" CssClass="invalid-feedback" Text="Complete campos, Ingrese descuento"></asp:Label>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <asp:Label runat="server" ID="codigo_orginal" CssClass="ocultarCol"></asp:Label>
                            <asp:LinkButton ID="btnPdfPago" runat="server" Visible="true" OnClick="btnPdfPago_Click" CssClass="btn btn-success float-right">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-notes" width="32" height="32" viewBox="0 0 24 24" stroke-width="1.5" stroke="#ffffff" fill="none" stroke-linecap="round" stroke-linejoin="round">
                                  <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                  <rect x="5" y="3" width="14" height="18" rx="2" />
                                  <line x1="9" y1="7" x2="15" y2="7" />
                                  <line x1="9" y1="11" x2="15" y2="11" />
                                  <line x1="9" y1="15" x2="13" y2="15" />
                                </svg><br />
                                Imprimir Detalle
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnRegistraPago" runat="server" Visible="true" OnClick="btnRegistraPago_Click" CssClass="btn btn-danger float-right">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-coin" width="32" height="32" viewBox="0 0 24 24" stroke-width="1.5" stroke="#ffffff" fill="none" stroke-linecap="round" stroke-linejoin="round">
                                  <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                  <circle cx="12" cy="12" r="9" />
                                  <path d="M14.8 9a2 2 0 0 0 -1.8 -1h-2a2 2 0 0 0 0 4h2a2 2 0 0 1 0 4h-2a2 2 0 0 1 -1.8 -1" />
                                  <path d="M12 6v2m0 8v2" />
                                </svg><br />
                                Realizar Pago
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tpropina" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="tdescuento" EventName="TextChanged" />
                <asp:PostBackTrigger ControlID="btnPdfPago" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
