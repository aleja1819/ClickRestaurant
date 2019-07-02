<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Proveedores.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Proveedores" %>

   <style>
        .ocultarCol {
        display:none;
        }
    </style>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<div class="container">
    <div class="row">   
            
         <div class="col-md-12">
                <asp:UpdatePanel runat="server" ID="uContenedorProveedor" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                         <br />
             
                  <%--ALERTA DE MENSAJE--%>
                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label  ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>
                            
                        <br />  
                     
                      <%--PRIMERA COLUMNA--%>
                        <div class="row">
                                <div class="col-md-6">
                                   
                                <div class="input-group mb-2">
                                    <asp:TextBox runat="server" ID="tdatoBuscarProveedor"
                                        CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                    <div class="input-group-prepend">
                                        <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">
                                            <%--ES UN CONBOBOX--%>

                                            <asp:ListItem Value="0" Text="Rut" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Nombre"></asp:ListItem>
                                            <%--LO QUE DENTRO--%>
                                        </asp:DropDownList>

                                        <asp:Button runat="server" ID="idBuscarProveedor" OnClick="idBuscarProveedor_Click"  Text="buscar" CssClass="btn btn-success" />
                                    </div>
                                </div>                     
                             </div> <%--CIERRE COLUMNA--%>
                        
                        <%--SEGUNDA COLUMNA--%>          
                        <div class="col-md-6">
                      <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarProveedorModal_Click" ID="bRegistrarProveedorModal">
                       <i class="fas fa-plus"></i> Registrar Proveedor
                                </asp:LinkButton>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div> <%--CIERRE COLUMNA--%>
                        </div>
                        
                       
                        <%--TABLA GRIDVIEW--%>
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                                OnRowCommand="idTabla_RowCommand">
                                
                                <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true"  />

                                <Columns>

                                    <asp:BoundField DataField="codigo_proveedor" HeaderText="Código" />
                                    <asp:BoundField DataField="rut_proveedor" HeaderText="Rut" />
                                    <asp:BoundField DataField="nombre_proveedor" HeaderText="Nombre Usuario" />
                                    <asp:BoundField DataField="apellido_paterno_proveedor" HeaderText="Apellido Paterno" />
                                    <asp:BoundField DataField="apellido_materno_proveedor" HeaderText="Apellido Materno" />
                                    <asp:BoundField DataField="direccion_proveedor" HeaderText="Dirección" />
                                    <asp:BoundField DataField="nombre_tipoProducto" HeaderText="Tipo Producto" />

                                    <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-light" Text="Editar" />
                                    <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                                </Columns>
                            </asp:GridView>
                            <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2; AllowPaging="true; OnRowCommand="idTabla_RowCommand"--%>
                        </div>      
                 </ContentTemplate>
                </asp:UpdatePanel>      
             </div>
          

            <%--ESTETICA DEL MODAL--%>
            <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg bg-light" role="document">

                    <asp:UpdatePanel ID="uModalProveedor" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>

                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">PROVEEDORES</span></h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>

                                <%--TEXTOS INPUTS--%>
                                <div class="modal-body">

                                    <%--RUT PROVEEDOR--%>
                                    <div class="form-group">
                                        <label for="trut">Rut Proveedor (*)</label>
                                        <asp:TextBox runat="server" placeholder="Rut Proveedor" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>
                                     <asp:Label runat="server" ID="valida_trut" CssClass="invalid-feedback" Text="Ingrese Rut"></asp:Label>
                                    </div>

                                    <%--NOMBRE PROVEEDOR--%>
                                    <div class="form-group">
                                        <label for="tnombre">Nombre Proveedor (*)</label>
                                        <asp:TextBox runat="server" placeholder="Nombre Proveedor" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="validar_tnombre" CssClass="invalid-feedback" Text="Ingrese Nombre"></asp:Label>
                                    </div>

                                    <%--APELLIDO PATERNO--%>
                                    <div class="form-group">
                                        <label for="tapellidoP">Apellido Paterno (*)</label>
                                        <asp:TextBox runat="server" placeholder="Apellido Paterno" ID="tapellidoP" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="validar_tapellidoP" CssClass="invalid-feedback" Text="Ingrese Apellido Paterno"></asp:Label>
                                    </div>

                                    <%--APELLIDO MATERNO--%>
                                    <div class="form-group">
                                        <label for="tapellidoM">Apellido Materno (*)</label>
                                        <asp:TextBox runat="server" placeholder="Apellido Paterno" ID="tapellidoM" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="validar_tapellidoM" CssClass="invalid-feedback" Text="Ingrese Apellido Materno"></asp:Label>
                                    </div>

                                    <%--DIRECCION--%>
                                    <div class="form-group">
                                        <label for="tdireccion">Dirección (*)</label>
                                        <asp:TextBox runat="server" placeholder="Dirección" ID="tdireccion" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="validar_tdireccion" CssClass="invalid-feedback" Text="Ingrese Dirección"></asp:Label>
                                    </div>

                                    <%--TIPO Producto--%>
                                    <div class="form-group">
                                        <label for="fTipoProducto">Tipo Producto (*)</label>
                                        <br />
                                        <asp:DropDownList runat="server" ID="fTipoProducto" CssClass="form-control"
                                            DataTextField="nombre_tipoProducto" DataValueField="codigo_tipoProducto">
                                        </asp:DropDownList>
                                    </div>

                               </div>

                                <div class="modal-footer">
                                    <asp:Label runat="server" ID="codigo_orginal" CssClass="ocultarCol"></asp:Label>
                                    <asp:Button runat="server" ID="ideditarProveedorBoton" OnClick="ideditarProveedorBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                    <asp:Button runat="server" ID="idregistrarProveedor" OnClick="idregistrarProveedor_Click"  Text="Registrar" CssClass="btn btn-success float-right" />
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
</div>
