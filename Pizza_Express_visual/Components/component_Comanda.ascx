<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="component_Comanda.ascx.cs" Inherits="Pizza_Express_visual.Components.component_Comanda" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous" />

<style>
    .ocultarCol {
        display: none;
    }
</style>

<asp:UpdatePanel runat="server" ID="uContenedorUsuario1">
    <ContentTemplate>
        <br />

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

                                <asp:LinkButton ID="idGrande" OnClick="tabGrande_Click" CssClass=" btn btn-success" runat="server" Text="FAMILIAR"></asp:LinkButton><br />
                                <asp:LinkButton ID="idMediana" OnClick="tabmediana_Click" CssClass="btn btn-success" runat="server" Text="MEDIANA"></asp:LinkButton><br />
                                <asp:LinkButton ID="idIndividual" OnClick="tabindividual_Click" CssClass="btn btn-success" runat="server" Text="INDIVIDUAL"></asp:LinkButton>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabTabla" role="tabpanel">
                            <div class="btn-group" role="group">

                                <asp:LinkButton ID="idTablas"  OnClick="idTablas_Click" CssClass=" btn btn-success" runat="server" Text="TABLAS"></asp:LinkButton>

                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabSandiwch" role="tabpanel">
                            <div class="btn-group-vertical" role="group">
                                <asp:LinkButton ID="idsandiwch" OnClick="idsandiwch_Click" CssClass=" btn btn-success" runat="server" Text="CHURRASCOS"></asp:LinkButton>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabPicadillo" role="tabpanel">
                            <div class="btn-group-vertical" role="group">
                                <asp:LinkButton ID="idQueso" OnClick="idPicadillo_Click" CssClass=" btn btn-success" runat="server" Text="PICADILLO"></asp:LinkButton>

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
                                <asp:BoundField DataField="nombre_menu"  HeaderText="Nombre" />
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

                        <asp:Button runat="server" ID="btnGenerarPDF" OnClick="btnGenerarPDF_Click" Text="Enviar Comanda" CssClass="btn btn-warning" />
                        <asp:Button runat="server" ID="btnpagos" OnClick="btnpago_Click" Text="Pagar" CssClass="btn btn-danger" />
                       <%-- <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClick="PagarModal_Click" ID="PagarModal" Text="Pagar">
                            </asp:LinkButton>--%>
                        <asp:Button runat="server" ID="btnNuevo" OnClick="btnNuevo_Click" Text="Nuevo" CssClass="btn btn-info" />
                              
                        
 
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


    </ContentTemplate>

    <Triggers>
        <asp:PostBackTrigger ControlID="btnGenerarPDF" />
        <asp:PostBackTrigger ControlID="btnpagos" />
    </Triggers>

</asp:UpdatePanel>

 <div class="modal" id="myModalComanda" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg bg-light" role="document">

                <asp:UpdatePanel ID="uModalComanda" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">PROVEEDORES</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">

                                <%--<div class="form-group">
                                    <label for="trut">Rut Proveedor (*)</label>
                                      <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-user"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Rut Proveedor" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_trut" CssClass="invalid-feedback" Text="Complete campos, Ingrese Rut"></asp:Label>
                                    </div>
                                </div>--%>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>







