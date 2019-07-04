<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="Pizza_Express_visual.Components.WebUserControl1" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<style>
    .ocultarCol {
        display: none;
    }
</style>

<div class="row">

    <asp:UpdatePanel runat="server" ID="uContenedorUsuario" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="col-md-4">
                <div class="d-flex flex-row mt-2">
                    <ul class="nav nav-tabs nav-tabs--vertical nav-tabs--left" role="navigation">
                        <li class="nav-item">
                            <a href="#tabpizza" class="nav-link active" data-toggle="tab" role="tab" aria-controls="lorem">PIZZAS</a>
                        </li>
                        <li class="nav-item">
                            <a href="#tabTabla" class="nav-link" data-toggle="tab" role="tab" aria-controls="ipsum">TABLAS</a>
                        </li>
                        <li class="nav-item">
                            <a href="#tabSandiwch" class="nav-link" data-toggle="tab" role="tab" aria-controls="dolor">SÁNDIWCH</a>
                        </li>
                        <li class="nav-item">
                            <a href="#tabPicadillo" class="nav-link" data-toggle="tab" role="tab" aria-controls="sit-amet">PICADILLO</a>
                        </li>
                        <li class="nav-item">
                            <a href="#tabPlatos" class="nav-link" data-toggle="tab" role="tab" aria-controls="sit-amet">PLATOS</a>
                        </li>
                        <li class="nav-item">
                            <a href="#tabBebestible" class="nav-link" data-toggle="tab" role="tab" aria-controls="sit-amet">BEBESTIBLE</a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade show active" id="tabpizza" role="tabpanel">

                            <div class="btn-group" role="group">

                                <asp:LinkButton ID="tabfamiliar" CssClass=" btn btn-success" runat="server" Text="FAMILIAR"></asp:LinkButton>
                                <asp:LinkButton ID="tabmediana" CssClass="btn btn-success" runat="server" Text="MEDIANA"></asp:LinkButton>
                                <%--OnClick="tabmediana_Click--%>
                                <asp:LinkButton ID="tabindividual" CssClass="btn btn-success" runat="server" Text="INDIVIDUAL"></asp:LinkButton>
                                <%--OnClick="tabindividual_Click" --%>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabTabla" role="tabpanel">
                            <div class="btn-group" role="group">

                                <asp:LinkButton ID="idTablas" CssClass=" btn btn-success" runat="server" Text="TABLAS"></asp:LinkButton>

                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabSandiwch" role="tabpanel">
                            <div class="btn-group-vertical" role="group">
                                <asp:LinkButton ID="idsandiwch" CssClass=" btn btn-success" runat="server" Text="CHURRASCOS"></asp:LinkButton>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabPicadillo" role="tabpanel">
                            <div class="btn-group" role="group">
                                <asp:LinkButton ID="idPapas" CssClass=" btn btn-success" runat="server" Text="PAPASFRITAS"></asp:LinkButton>
                                <asp:LinkButton ID="idsalsa" CssClass=" btn btn-success" runat="server" Text="SALSAS"></asp:LinkButton>
                                <asp:LinkButton ID="idQueso" CssClass=" btn btn-success" runat="server" Text="QUESO "></asp:LinkButton>

                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabPlatos" role="tabpanel">
                            <div class="btn-group" role="group">
                                <asp:LinkButton ID="idPlato" CssClass=" btn btn-success" runat="server" Text="PLATO_CARTA"></asp:LinkButton>
                                <asp:LinkButton ID="idAgregado" CssClass=" btn btn-success" runat="server" Text="AGREGADO"></asp:LinkButton>
                                <asp:LinkButton ID="idEnsalda" CssClass=" btn btn-success" runat="server" Text="ENSALDA "></asp:LinkButton>

                            </div>
                        </div>

                        <div class="tab-pane fade" id="tabBebestible" role="tabpanel">
                            <div class="btn-group" role="group">
                                <asp:LinkButton ID="idVinos" CssClass=" btn btn-success" runat="server" Text="VINOS"></asp:LinkButton>
                                <asp:LinkButton ID="idBebidas" CssClass=" btn btn-success" runat="server" Text="BEBIDAS"></asp:LinkButton>
                                <asp:LinkButton ID="idJugos" CssClass=" btn btn-success" runat="server" Text="JUGOS "></asp:LinkButton>

                            </div>
                        </div>

                    </div>
                    <%--FIN TAB CONTENT--%>
                </div>
                <%--FIN D-FELX--%>
            </div>
            <%--FIN COLUMNA--%>

            <div class=" col-md-8">

                <div class="col align-content-center">
                    <asp:GridView runat="server" ID="idMostrarMenu" CssClass="table table-bordered table-center " AutoGenerateColumns="false">
                        <HeaderStyle CssClass="btn-dark" />

                        <Columns>
                            <asp:BoundField DataField="codigo_menu" HeaderText="Código" />
                            <asp:BoundField DataField="nombre_menu" HeaderText="Nombre" />
                            <asp:BoundField DataField="precio_menu" HeaderText="Precio" DataFormatString="${0:N0}" />
                            <asp:BoundField DataField="ingredientes_menu" HeaderText="Ingredientes" />

                            <asp:ButtonField ButtonType="Link" CommandName="idselected" ControlStyle-CssClass="btn btn-danger bt-sm" Text=" + " />

                        </Columns>
                    </asp:GridView>
                    <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2; AllowPaging="true;OnRowCommand="idMostrarMenu_RowCommand"--%>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">

                    <h6 class="section-title h3 text-center text-dark">TABLA DETALLE PAGO</h6>
                    <asp:Label runat="server" ID="ltotal"></asp:Label>
                    <div class="container offset-3">
                        <asp:Button runat="server" ID="btnenviarC" Text="Enviar Comanda" CssClass="btn btn-warning" />
                        <asp:Button runat="server" ID="btnpago" Text="Pagar" CssClass="btn btn-info" />
                        <asp:Button runat="server" ID="btnAnular" Text="Anular" CssClass="btn btn-danger" />
                    </div>
                </div>
                <div class="col-md-8">
                    <h6 class="section-title h3 text-center text-dark">TABLA DETALLE ELECCION DE COMIDA</h6>
                    <%--TABLA GRIDVIEW--%>
                    <div class="col align-content-center">
                        <asp:GridView runat="server" ID="idCargarSeleccion" CssClass="table table-bordered table-center " AutoGenerateColumns="false">
                            <HeaderStyle CssClass="btn-dark" />

                            <Columns>
                                <asp:BoundField DataField="codigo_M" HeaderText="Codigo" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="nombre_M" HeaderText="Nombre" />
                                <asp:BoundField DataField="precio_M" HeaderText="Precio" />
                                <asp:BoundField DataField="ingre_M" HeaderText="Detalle" />

                                <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-danger" Text="-" />

                            </Columns>
                        </asp:GridView>
                        <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2; AllowPaging="true;OnRowCommand="idCargarSeleccion_RowCommand"--%>
                    </div>
                </div>

            </div>
            <%--FIN ROW--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
