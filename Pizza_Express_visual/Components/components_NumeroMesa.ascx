<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_NumeroMesa.ascx.cs" Inherits="Pizza_Express_visual.Components.components_NumeroMesa" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous" />

<style>
    .ocultarCol {
        display: none;
    }
</style>

<asp:UpdatePanel runat="server" ID="uConteReport">
    <ContentTemplate>

        <nav>
            <div class="nav nav-tabs" id="nav-tab" role="tablist">
                <a class="nav-item nav-link active" id="nav-venta-tab" data-toggle="tab" href="#nav-venta" role="tab" aria-controls="nav-home" aria-selected="true">REPORTE DE VENTA</a>
                <a class="nav-item nav-link" id="nav-producto-tab" data-toggle="tab" href="#nav-producto" role="tab" aria-controls="nav-profile" aria-selected="false">REPORTE DE PRODUCTO</a>
            </div>
        </nav>
        <br />
        <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade show active" id="nav-venta" role="tabpanel" aria-labelledby="nav-venta-tab">
           
            </div>
            <div class="tab-pane fade" id="nav-producto" role="tabpanel" aria-labelledby="nav-producto-tab">
               
          <div class="container col-12 offset-2">
           
            <div class="row">

                <%--ALERTA DE MENSAJE--%>
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
                        <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bBuscarNombre"><%--OnClick="bBuscarNombre_Click"--%>
                       <i class="fas fa-plus"></i> Buscar
                        </asp:LinkButton>
                    </div>
                </div>

                <%--CIERRE COLUMNA--%>

                <div class="col-md-2">
                    <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bGenerarPdf"><%--OnClick="bGenerarPdf_Click"--%>
             Generar PDF
                    </asp:LinkButton>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
                <%--CIERRE COLUMNA--%>
            </div>
            </div>
            <div class="container col-10">

                <div class="row">
                    <div class=" col-md-12">
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idTablaEnvio" CssClass="table table-bordered table-center " AutoGenerateColumns="false">

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
                            <%--OnRowCommand="idTablaEnvio_RowCommand"--%>
                        </div>
                        <br />
                        <h3 class="text-center text-body">Detalle Generar Reporte</h3>
                        <br />

                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="cargaReporte" CssClass="table table-bordered table-center " AutoGenerateColumns="false">
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
                            <%--OnRowCommand="cargaReporte_RowCommand"--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
