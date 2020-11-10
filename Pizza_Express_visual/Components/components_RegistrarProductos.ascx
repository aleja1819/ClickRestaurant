<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_RegistrarProductos.ascx.cs" Inherits="Pizza_Express_visual.Components.components_RegistrarProductos" %>

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

                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>
                    <br />

                    <div class="row">
                        <div class="col-md-6">

                            <div class="input-group mb-2">
                                <asp:TextBox runat="server" ID="tdatoBuscarProducto"
                                    CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                <div class="input-group-prepend">
                                    <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">

                                        <asp:ListItem Value="0" Text="Nombre Producto"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Código Producto"></asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:Button runat="server" ID="bBuscarProducto" OnClick="bBuscarProducto_Click" Text="buscar" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                        <%--SEGUNDA COLUMNA--%>
                        <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarProductoModal_Click" ID="bRegistrarProductoModal">
                       <i class="fas fa-plus"></i> Registrar Producto
                            </asp:LinkButton>
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>

                           <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnVolverPr_Click" ID="btnVolverPr">
                       <i class="fas fa-home"></i>
                            </asp:LinkButton>      
                    </div>

                    </div>

                    <div class="col align-content-center">
                        <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                            OnRowCommand="idTabla_RowCommand" OnPageIndexChanging="idTabla_PageIndexChanging" PageSize="4" AllowPaging="true">

                            <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                            <Columns>

                                <asp:BoundField DataField="codigo_producto" HeaderText="Código" 
                                    HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol"/>
                                <asp:BoundField DataField="nombre_producto" HeaderText="Nombre Producto" />
                                <asp:BoundField DataField="rut_proveedor" HeaderText="Rut Proveedor" />
                                <asp:BoundField DataField="fecha_ingreso_producto" HeaderText="Fecha ingreso" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="cantidad_producto" HeaderText="Cantidad Producto" />

                                <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-dark" Text="Editar" />
                                <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                            </Columns>
                        </asp:GridView>
                        
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg bg-light" role="document">

                <asp:UpdatePanel ID="uModalProducto" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">PRODUCTOS</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>


                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="tnombre">Nombre Producto</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-file-signature"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Nombre Producto" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tnombre" CssClass="invalid-feedback" Text=" Complete Campos, Ingrese Nombre producto"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="trut">Rut Proveedor</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-user"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Rut Proveedor" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_trut" CssClass="invalid-feedback" Text="Complete Campos, Ingrese Rut"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="tfecha">Fecha</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="far fa-calendar-alt"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Fecha" ID="tfecha" TextMode="Date" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tfecha" CssClass="invalid-feedback" Text="Complete Campos, Ingrese Fecha"></asp:Label>
                                    </div>
                                </div>
                            
                                <div class="form-group">
                                    <label for="tcantidad">Cantidad Productos</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-coins"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Cantidad Productos" ID="tcantidad" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tcantidad" CssClass="invalid-feedback" Text="Complete Campos, Ingrese Cantidad"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <asp:Label runat="server" ID="cod_orginal" CssClass="ocultarCol"></asp:Label>
                                <asp:Label runat="server" ID="cod_OriProve" CssClass="ocultarCol"></asp:Label>
                                <asp:Button runat="server" ID="beditarProductoBoton" Visible="false" OnClick="beditarProductoBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                <asp:Button runat="server" ID="bregistrarProducto" Visible="false" OnClick="bregistrarProveedor_Click" Text="Registrar" CssClass="btn btn-success float-right" />
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
