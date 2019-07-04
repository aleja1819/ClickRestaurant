<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Inventario.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Inventario" %>

<style>
    .ocultarCol {
        display: none;
    }
</style>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<style>
    .ocultarCol {
        display: none;
    }
</style>



<div class="container">
    <div class="row">

        <div class="col-md-12">
            <asp:UpdatePanel runat="server" ID="uContenedorProducto" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <br />
                    <%--ALERTA DE MENSAJE--%>
                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>

                    <br />
                    <br />
                    <br />
                    <%--PRIMERA COLUMNA--%>
                    <div class="row">
                        <div class="col-md-8 offset-2 ">

                            <div class="input-group mb-2">
                                <asp:TextBox runat="server" ID="tdatoBuscarProducto"
                                    CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                <div class="input-group-prepend">
                                    <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">
                                        <%--ES UN CONBOBOX--%>

                                        <asp:ListItem Value="0" Text="Nombre Producto"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Código Producto"></asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:Button runat="server" ID="bBuscarProducto" OnClick="bBuscarProducto_Click" Text="buscar" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>
                        <%--CIERRE COLUMNA--%>

                        <br />
                        <br />
                        <br />
                        <br />
                       
              

                        <%--SEGUNDA COLUMNA--%>

                        <%--TABLA GRIDVIEW--%>
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idTablaInven" CssClass="table table-bordered table-center" AutoGenerateColumns="false"
                                OnRowCommand="idTabla_RowCommand" OnPageIndexChanging="idTablaInven_PageIndexChanging" PageSize="4" AllowPaging="true">

                                <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                                <Columns>
                                    <asp:BoundField DataField="codigo_producto" HeaderText="Código" />
                                    <asp:BoundField DataField="nombre_producto" HeaderText="Nombre Producto" />
                                    <asp:BoundField DataField="rut_proveedor" HeaderText="Rut Proveedor" />
                                    <asp:BoundField DataField="fecha_ingreso_producto" HeaderText="Fecha ingreso" />
                                    <asp:BoundField DataField="cantidad_producto" HeaderText="Cantidad Producto" />

                                    <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-dark" Text="Editar" />

                                </Columns>
                            </asp:GridView>

                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <%--ESTETICA DEL MODAL--%>
        <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg bg-light" role="document">

                <asp:UpdatePanel ID="uModalProducto" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">Productos</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <%--TEXTOS INPUTS--%>
                            <div class="modal-body">

                                <%--NOMBRE PRODUCTO--%>
                                <div class="form-group">

                                    <asp:TextBox runat="server" placeholder="Nombre Producto" Visible="false" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>

                                    <asp:TextBox runat="server" placeholder="Rut Proveedor" Visible="false" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>

                                    <asp:TextBox runat="server" placeholder="Fecha" ID="tfecha" Visible="false" TextMode="Date" CssClass="form-control bg-secondary"></asp:TextBox>

                                    <%--CANTIDAD--%>
                                    <div class="form-group">
                                        <label for="tcantidad">Cantidad Productos</label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <div class="input-group-text text-info"><i class="fas fa-coins"></i></div>
                                            </div>
                                            <asp:TextBox runat="server" placeholder="Cantidad Productos" ID="tcantidad" CssClass="form-control bg-secondary"></asp:TextBox>
                                            <asp:Label runat="server" ID="valida_tcantidad" CssClass="invalid-feedback" Text="Ingrese Cantidad"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <asp:Label runat="server" ID="cod_orginal" CssClass="ocultarCol"></asp:Label>
                                    <asp:Label runat="server" ID="cod_OriProve" CssClass="ocultarCol"></asp:Label>
                                    <asp:Button runat="server" ID="beditarProveedorBoton" OnClick="beditarProductorBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
