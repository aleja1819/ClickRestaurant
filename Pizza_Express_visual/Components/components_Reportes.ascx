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

                <%--///////////////////REPORTES DE VENTAS//////////////////////--%>

                  

                <asp:View runat="server" ID="vVenta">

                     <div class="container">
                        <asp:Panel runat="server" ID="AVenta" Visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <asp:Label ID="MVenta" runat="server"></asp:Label>
                        </asp:Panel>
                    </div>


                    <div class="container col-8 offset-3">
                        <div class="row">

                            <div class="col-md-4">

                                <div class="input-group mb-4">
                                    <h5 class="text-dark">Desde : </h5>
                                    <asp:TextBox runat="server" ID="tfechaI" CssClass="form-control" TextMode="Date" placeholder="Fecha inicial"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="input-group mb-4">
                                    <h5 class="text-dark">Hasta : </h5>
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

                        </div>
                    </div>

                 
                    <%--GRIDVIEW--%>
                    <div class="container col-10">
                        <%--TOTAL VENTAS DE UN RANGO DE FECHA--%>
                        <div class="col-md-10">
                            <h5 class="text-dark text-md-left">
                                <asp:Label runat="server" ID="ltotalRangoFecha" Visible="false" class="text-danger" Text="Total Ventas del Periodo $"></asp:Label></h5>
                        </div>

                        <br />
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
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="container col-6 offset-4">
                        <h3 class="text-dark text-md-left">
                            <asp:Label runat="server" Visible="false" ID="ldetalleSeleccion" Style="text-align: center" class="text-primary" Text="Detalle Selección "></asp:Label></h3>
                    </div>
                    <br />

                    <div class=" container col-10">
                        <%--TOTAL PRECIO SELECCION FECHA--%>
                        <div class=" col-md-10">
                            <h5 class="text-dark text-md-left">
                                <asp:Label runat="server" Visible="false" ID="ltotalRangoFechaSelección" class="text-danger" Text="Total ventas seleccionadas $0"></asp:Label></h5>
                        </div>
                    </div>
                    <br />

                    <%--////TABLA SELECCION////--%>
                    <div class="container col-10">
                        <div class="row">
                            <div class="col-md-10">

                                <div class="col align-content-center">
                                    <asp:GridView runat="server" ID="CargarVentasReporte" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                        OnRowCommand="CargarVentasReporte_RowCommand">
                                        <HeaderStyle CssClass="btn-dark" ForeColor="White" Font-Bold="true" />

                                        <Columns>
                                            <asp:BoundField DataField="codigo_C" HeaderText="Código"
                                                HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol" />
                                            <asp:BoundField DataField="cantidad_V" HeaderText="cantidad" />
                                            <asp:BoundField DataField="nombre_V" HeaderText="Nombre Menú" />
                                            <asp:BoundField DataField="fecha_V" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="precio_V" HeaderText="Precio" />

                                            <asp:ButtonField ButtonType="Link" Visible="false" CommandName="idQuitar" ControlStyle-CssClass="btn btn-danger" Text="-" />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                            <%--/////BOTONES IMPRIMIR Y LIMPIAR//////--%>
                            <div class="col-md-2 text-center">
                                <br />
                                <%--GENERAR PDF--%>
                                <asp:LinkButton runat="server" Visible="false" CssClass="btn btn-success" ID="bPDFVentas" OnClick="bPDFVentas_Click"> 
                                         <svg class="w-5 h-5" viewBox="0 0 16 16" class="bi bi-printer-fill" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                            <path d="M5 1a2 2 0 0 0-2 2v1h10V3a2 2 0 0 0-2-2H5z"/>
                                            <path fill-rule="evenodd" d="M11 9H5a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1z"/>
                                            <path fill-rule="evenodd" d="M0 7a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-1v-2a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v2H2a2 2 0 0 1-2-2V7zm2.5 1a.5.5 0 1 0 0-1 .5.5 0 0 0 0 1z"/>
                                                 </svg>
                                           <span style="font-size: 15px">Imprimir</span>                                              
                                </asp:LinkButton>
                                </br> </br>

                             <%--BOTON LIMPIAR--%>
                                <asp:LinkButton runat="server" Visible="false" CssClass="btn btn-info" ID="LinkButtonlimpiarseleccionventa" OnClick="LinkButtonlimpiarseleccionventa_Click">
                                    <svg class="w-5 h-5" viewBox="0 0 16 16" class="bi bi-trash-fill" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                       <path fill-rule="evenodd" d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5a.5.5 0 0 0-1 0v7a.5.5 0 0 0 1 0v-7z"/>
                                    </svg>
                                     <span style="font-size: 15px">Limpiar</span>
                                </asp:LinkButton>

                            </div>
                        </div>
                    </div>

                </asp:View>

                <%--/////////////////REPORTES PRODUCTO////////////////--%>

                <asp:View runat="server" ID="vProducto">

                    <div class="container col-10">
                      <asp:Panel runat="server" ID="AProducto" Visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <asp:Label ID="MProducto" runat="server"></asp:Label>
                    </asp:Panel>
                    </div>

                    <div class="container col-8 offset-3">
                        <div class="row">

                            <div class="col-md-4">
                                <div class="input-group mb-4">
                                    <h5 class="text-dark">Desde : </h5>
                                    <asp:TextBox runat="server" ID="tfechaini" CssClass="form-control" TextMode="Date" placeholder="Fecha inicial"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="input-group mb-4">
                                    <h5 class="text-dark">Hasta : </h5>
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

                            <div class="container">
                                <asp:Panel runat="server" ID="alertaProducto" Visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </asp:Panel>
                            </div>

                        </div>
                    </div>


                    <%--//TABLA GRIDVIEW//--%>
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
                                </div>
                            </div>
                        </div>
                                <br />

                                <div class="container col-6 offset-4">
                                    <h3 class="text-dark text-md-left">
                                        <asp:Label runat="server" Visible="false" ID="ldetalleSeleciónP" Style="text-align: center" class="text-primary" Text="Detalle Selección "></asp:Label></h3>
                                </div>
                                <br />

                                <%-- DESDE AQUIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII--%>
                                <div class="container col-10">
                                    <div class="row">
                                        <div class="col-md-10">

                                            <div class="col align-content-center">
                                                <asp:GridView runat="server" ID="cargaReporte" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                                    OnRowCommand="cargaReporte_RowCommand">
                                                    <HeaderStyle CssClass="btn-dark" ForeColor="White" Font-Bold="true" />

                                                    <Columns>
                                                        <asp:BoundField DataField="codigo_P" HeaderText="Código"
                                                            HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol" />
                                                        <asp:BoundField DataField="nombre_P" HeaderText="Nombre Producto" />
                                                        <asp:BoundField DataField="rut_P" HeaderText="Rut Proveedor" />
                                                        <asp:BoundField DataField="fecha_I" HeaderText="Fecha ingreso" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="cantidad_P" HeaderText="Cantidad Producto" />

                                                        <asp:ButtonField ButtonType="Link" CommandName="IDQuitar" Visible="false" ControlStyle-CssClass="btn btn-danger" Text="-" />

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>


                                        <%--///////////BOTONES///////////////--%>
                                        <div class="col-md-2 text-center">
                                            <br />
                                            <%--GENERAR PDF--%>

                                            <asp:LinkButton runat="server" Visible="false" CssClass="btn btn-success" ID="bGenerarPdf" OnClick="bGenerarPdf_Click">
                                            <svg class="w-5 h-5" viewBox="0 0 16 16" class="bi bi-printer-fill" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                            <path d="M5 1a2 2 0 0 0-2 2v1h10V3a2 2 0 0 0-2-2H5z"/>
                                            <path fill-rule="evenodd" d="M11 9H5a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1z"/>
                                            <path fill-rule="evenodd" d="M0 7a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-1v-2a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v2H2a2 2 0 0 1-2-2V7zm2.5 1a.5.5 0 1 0 0-1 .5.5 0 0 0 0 1z"/>
                                                 </svg>
                                           <span style="font-size: 15px">Imprimir</span>

                                            </asp:LinkButton>
                                            <br /><br />

                                            <%--BOTON LIMPIAR--%>
                                            <asp:LinkButton runat="server" Visible="false" CssClass="btn btn-info" ID="LinkButtonlimpiarseleccionventaPRO" OnClick="LinkButtonlimpiarseleccionventaPRO_Click">
                                            <svg class="w-5 h-5" viewBox="0 0 16 16" class="bi bi-trash-fill" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5a.5.5 0 0 0-1 0v7a.5.5 0 0 0 1 0v-7z"/>
                                            </svg>
                                           <span style="font-size: 15px">Limpiar</span>
                                            </asp:LinkButton>

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
