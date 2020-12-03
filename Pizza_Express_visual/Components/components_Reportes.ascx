<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Reportes.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Reportes" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous" />


<style>
    .ocultarCol {
        display: none;
    }
</style>

<asp:UpdatePanel runat="server" ID="uConteReport">
    <ContentTemplate>

        <ul id="tabIndice" class="nav nav-tabs">
            <li class="nav-item">
                <asp:LinkButton runat="server" ID="venta" OnClick="venta_Click" CssClass="nav-link small text-uppercase">Reporte Ventas</asp:LinkButton></li>
            <li class="nav-item">
                <asp:LinkButton runat="server" ID="producto" OnClick="producto_Click" CssClass="nav-link small text-uppercase">Reporte Productos</asp:LinkButton></li>
        </ul>
        <br />
        <div class="tab-content" id="nav-tabContent">
            <asp:MultiView runat="server" ID="mcontenedor">

                <%--VENTAS--%>
                <asp:View runat="server" ID="vVenta">

                    <div class="container col-12 offset-2">
                        <div class="row">

                            <asp:Panel runat="server" ID="Panel1" Visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </asp:Panel>


                            <div class="col-md-2">

                                <div class="input-group mb-4">
                                    <h4 class="text-dark">Desde :</h4>
                                    <asp:TextBox runat="server" ID="tfechaI" CssClass="form-control" TextMode="Date" placeholder="Fecha inicial"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="input-group mb-4">
                                    <h5 class="text-dark">Hasta :</h5>
                                    <asp:TextBox runat="server" ID="tfechaF" CssClass="form-control" TextMode="Date" placeholder="Fecha final"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="input-group mb-2">
                                    <asp:LinkButton runat="server" CssClass="btn btn-success" ID="buscarVentas" OnClick="buscarVentas_Click">
                       <i class="fas fa-plus"></i> Buscar
                                    </asp:LinkButton>
                                </div>
                            </div>


                            <div class="col-md-2">
                                <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bPDFVentas" OnClick="bPDFVentas_Click">
                         Generar PDF
                                </asp:LinkButton>
                                <br />

                            </div>

                        </div>
                    </div>
                    
                    <%--TOTAL VENTAS DE UN RANGO DE FECHA--%>
                    <div class="container col-8">
                        <h5 class="text-dark text-md-left">
                                                <asp:Label runat="server" ID="ltotalRangoFecha"  Text="Total Ventas $0"></asp:Label></h5>
                    </div>


                    <%--GRIDVIEW--%>
                    <div class="container col-10">
                       <div class="row">
                            <div class=" col-md-12">
                                <div class="col align-content-center">
                                    <asp:GridView runat="server" ID="idVentaSelect" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                        OnRowCommand="idVentaSelect_RowCommand">

                                        <HeaderStyle CssClass="btn-dark" ForeColor="White" Font-Bold="true" />
                                        <Columns>

                                            <asp:BoundField DataField="codigo_comanda" HeaderText="Código"
                                                HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol" />
                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                                            <asp:BoundField DataField="nombre_menu" HeaderText="Nombre Menú" />
                                            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="precio_menu" HeaderText="Precio" DataFormatString="${0:N0}" />

                                            <asp:ButtonField ButtonType="Link" CommandName="idseleccionar" ControlStyle-CssClass="btn btn-danger" Text="+" />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />


                                <h3 class="text-center text-body">Detalle de Ventas</h3>
                                <br />

                                <div class="container col-10 ">
                                    <div class="row">
                                        <div class=" col-md-8">
                                            <%--TOTAL SELECCION FECHA--%>
                                            <h5 class="text-dark text-md-left">
                                                <asp:Label runat="server" ID="ltotalRangoFechaSelección" Text="Total ventas seleccionadas $0"></asp:Label></h5>
                                        </div>

                                        <div class=" col-md-2">
                                            <%--BOTON LIMPIAR--%>
                                            <asp:LinkButton runat="server" CssClass="btn btn-success" ID="LinkButtonlimpiarseleccionventa" OnClick="LinkButtonlimpiarseleccionventa_Click">Limpiar</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            <br />
                            <div class="col align-content-center">
                                <asp:GridView runat="server" ID="CargarVentasReporte" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                    OnRowCommand="CargarVentasReporte_RowCommand">
                                    <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                                    <Columns>
                                        <asp:BoundField DataField="codigo_C" HeaderText="Código"
                                            HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol" />
                                        <asp:BoundField DataField="cantidad_V" HeaderText="cantidad" />
                                        <asp:BoundField DataField="nombre_V" HeaderText="Nombre Menú" />
                                        <asp:BoundField DataField="fecha_V" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="precio_V" HeaderText="Precio" />

                                        <asp:ButtonField ButtonType="Link" CommandName="ideditar" Visible="false" ControlStyle-CssClass="btn btn-danger" Text="-" />

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
        </div>
        </asp:View>

                <%--REPORTES--%>
        <asp:View runat="server" ID="vProducto">

            <div class="container col-12 offset-2">
                <div class="row">

                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>


                    <div class="col-md-2">

                        <div class="input-group mb-4">
                            <h4 class="text-dark">Desde :</h4>
                            <asp:TextBox runat="server" ID="tfechaini" CssClass="form-control" TextMode="Date" placeholder="Fecha inicial"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="input-group mb-4">
                            <h5 class="text-dark">Hasta :</h5>
                            <asp:TextBox runat="server" ID="tfechafin" CssClass="form-control" TextMode="Date" placeholder="Fecha final"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="input-group mb-2">
                            <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bBuscarNombre" OnClick="bBuscarNombre_Click">
                       <i class="fas fa-plus"></i> Buscar
                            </asp:LinkButton>
                        </div>
                    </div>


                    <div class="col-md-2">
                        <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bGenerarPdf" OnClick="bGenerarPdf_Click">
                         Generar PDF
                        </asp:LinkButton>
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>

                </div>
            </div>
            <div class="container col-10">

                <div class="row">
                    <div class=" col-md-12">
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idTablaEnvio" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                OnRowCommand="idTablaEnvio_RowCommand">

                                <HeaderStyle CssClass="btn-dark" ForeColor="White" Font-Bold="true" />

                                <Columns>

                                    <asp:BoundField DataField="codigo_producto" HeaderText="Código"
                                        HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol" />
                                    <asp:BoundField DataField="nombre_producto" HeaderText="Nombre Producto" />
                                    <asp:BoundField DataField="rut_proveedor" HeaderText="Rut Proveedor" />
                                    <asp:BoundField DataField="fecha_ingreso_producto" HeaderText="Fecha ingreso" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="cantidad_producto" HeaderText="Cantidad Producto" />

                                    <asp:ButtonField ButtonType="Link" CommandName="idseleccionar" ControlStyle-CssClass="btn btn-danger" Text="+" />

                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                        <h3 class="text-center text-body">Detalle Productos</h3>
                        <br />

                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="cargaReporte" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                OnRowCommand="cargaReporte_RowCommand">
                                <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                                <Columns>
                                    <asp:BoundField DataField="codigo_P" HeaderText="Código"
                                        HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol" />
                                    <asp:BoundField DataField="nombre_P" HeaderText="Nombre Producto" />
                                    <asp:BoundField DataField="rut_P" HeaderText="Rut Proveedor" />
                                    <asp:BoundField DataField="fecha_I" HeaderText="Fecha ingreso" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="cantidad_P" HeaderText="Cantidad Producto" />

                                    <asp:ButtonField ButtonType="Link" CommandName="ideditar" Visible="false" ControlStyle-CssClass="btn btn-danger" Text="-" />

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        </asp:MultiView>
        </div>
    </ContentTemplate>

    <Triggers>
        <asp:PostBackTrigger ControlID="bGenerarPdf" />
        <asp:PostBackTrigger ControlID="bPDFVentas" />
    </Triggers>
</asp:UpdatePanel>
