<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Mesas.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Mesas" %>


<h1 class="text-center">Presentación de Mesas</h1>
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
                                        <asp:BoundField DataField="codigo_menu" HeaderText="Código" />
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



                        <div class="col-md-4">
                            <hr />

                            <h6 class="section-title h6 text-center text-dark">TABLA DETALLE PAGO</h6>

                            <br />

                            <h3 class="text-dark text-center">
                                <asp:Label runat="server" ID="ltotal" Text="Total a pagar $0"></asp:Label></h3>
                            <br />

                            <div class="container offset-3">
                                <asp:LinkButton ID="btnGenerarPDF" OnClick="btnGenerarPDF_Click" runat="server" CssClass="btn btn-warning">Enviar Comanda</asp:LinkButton>
                                <%--<asp:Button runat="server" ID="btnGenerarPDF" OnClick="btnGenerarPDF_Click" Text="Enviar Comanda" CssClass="btn btn-warning" />--%>
                                <%-- <asp:Button runat="server" ID="btnpagos" OnClick="btnpagos_Click" Text="Pagar" CssClass="btn btn-danger" />--%>
                                <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClick="PagarModal_Click" ID="PagarModal" Text="Emitir Pago">
                                </asp:LinkButton>
                                <asp:Button runat="server" ID="btnNuevo" OnClick="btnNuevo_Click" Text="Resetear" CssClass="btn btn-info" />



                            </div>

                        </div>
                        <div class="col-md-8">
                            <hr />
                            <h6 class="section-title h6 text-center text-dark">TABLA DETALLE ELECCION DE COMIDA</h6>
                            <%--TABLA GRIDVIEW--%>
                            <div class="col align-content-center">
                                <asp:GridView runat="server" ID="idCargarSeleccion" CssClass="table table-bordered table-center " AutoGenerateColumns="false" OnRowCommand="idCargarSeleccion_RowCommand">
                                    <HeaderStyle CssClass="btn-dark" />

                                    <Columns>
                                        <asp:BoundField DataField="codigo_M" HeaderText="Código" />
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

            <%--Vista Mesas--%>

            <asp:View runat="server" ID="vMesas">
                <div class="container">

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

                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa13" OnClick="bMesa13_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 15px"><strong>Mesa 13</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa14" OnClick="bMesa14_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 15px"><strong>Mesa 14</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa15" OnClick="bMesa15_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 15px"><strong>Mesa 15</strong></span>             
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa16" OnClick="bMesa16_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 16</strong></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa17" OnClick="bMesa17_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 17</strong></span>      
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="bMesa18" OnClick="bMesa18_Click" runat="server" CssClass="btn btn-success">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
                            <span style="font-size: 14px"><strong>Mesa 18</strong></span>
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
                            <asp:Label runat="server" ID="LTotalCancelar"></asp:Label></h3>
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

                        <%--Propina--%>
                        <div class="form-group">
                            <label for="tpropina">Propina (*)</label>
                            <div class="input-group mb-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text text-info"><i class="fa fa-usd"></i></div>
                                </div>
                                <asp:TextBox runat="server" OnTextChanged="TextBox1_TextChanged" placeholder="$" ID="tpropina"
                                    AutoPostBack="true" CssClass="form-control bg-secondary"></asp:TextBox>
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
                                <asp:TextBox runat="server" placeholder="$" ID="tdescuento" CssClass="form-control bg-secondary"
                                    OnTextChanged="tdescuento_TextChanged" AutoPostBack="true"></asp:TextBox>
                                 <asp:Label runat="server" ID="validar_tdescuento" CssClass="invalid-feedback" Text="Complete campos, Ingrese descuento"></asp:Label>
                            </div>
                        </div>


                        <div class="modal-footer">

                            <asp:Label runat="server" ID="codigo_orginal" CssClass="ocultarCol"></asp:Label>
                            <asp:Button runat="server" ID="idregistrarPago" Visible="true" OnClick="idregistrarPago_Click" Text="Pagar" CssClass="btn btn-success float-right" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tpropina" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="tdescuento" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
