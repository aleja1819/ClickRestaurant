<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_CartaMenu.ascx.cs" Inherits="Pizza_Express_visual.Components.components_CartaMenu" %>

<style>
    .ocultarCol {
        display: none;
    }
</style>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous" />

<div class="container">
    <div class="row">

        <div class="col-md-12">

            <asp:UpdatePanel runat="server" ID="uContenedorMenu" UpdateMode="Conditional" ChildrenAsTriggers="true">
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

                    <%--PRIMERA COLUMNA--%>
                    <div class="row">
                        <div class="col-md-6">

                            <div class="input-group mb-2">
                                <asp:TextBox runat="server" ID="tdatoBuscar"
                                    CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                <div class="input-group-prepend">
                                    <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">

                                        <asp:ListItem Value="0" Text="Nombre Menu"></asp:ListItem>

                                    </asp:DropDownList>

                                    <asp:Button runat="server" ID="idBuscarMenu" OnClick="idBuscarMenu_Click" Text="buscar" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarMenu_Click" ID="bRegistrarMenu">
                       <i class="fas fa-plus"></i> Registrar Menú
                            </asp:LinkButton>
                            <br />
                            <br />
                            <br />
                            <br />

                        </div>

                     <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnVolver_Click" ID="btnVolver">
                       <i class="fas fa-home"></i>
                            </asp:LinkButton>      
                    </div>

                        <%--SEGUNDA COLUMNA--%>
                    <div class="col align-content-center">
                        <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                            OnRowCommand="idTabla_RowCommand" OnPageIndexChanging="idTabla_PageIndexChanging" PageSize="5" AllowPaging="true">
                            <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                            <Columns>
                                <asp:BoundField DataField="codigo_menu" HeaderText="codigo" 
                                     HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol"/>
                                <asp:BoundField DataField="nombre_menu" HeaderText="Nombre Menú" />
                                <asp:BoundField DataField="precio_menu" DataFormatString="${0:N0}" HeaderText="Precio Menú" />
                                <asp:BoundField DataField="ingredientes_menu" HeaderText="Ingredientes" />
                                <asp:BoundField DataField="nombre_tamanoP" HeaderText="Tamaño" />
                                <asp:BoundField DataField="nombre_categoria" HeaderText="Categoria" />

                                <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-dark" Text="Editar" />
                                <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                            </Columns>
                        </asp:GridView>
                        <%--  --%>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg bg-light" role="document">

                <asp:UpdatePanel ID="uModalMenu" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">CARTA MENÚ</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">

                                <div class="form-group">
                                    <label for="tnombre">Nombre Menú (*)</label>
                                    <div class="input-group mb-2">
                          
                                        <div class="input-group-prepend">
                                                <div class="input-group-text text-info"><i class="fas fa-map fa-1x"></i></div>
                                            </div>
                                           <asp:TextBox runat="server" placeholder="Nombre" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tnombre" CssClass="invalid-feedback" Text="Complete campos vacios, Ingrese Nombre"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="tprecio">Precio Menú (*)</label>
                                    <div class="input-group mb-2">
                          
                                        <div class="input-group-prepend">
                                                <div class="input-group-text text-info"><i class="fas fa-dollar-sign"></i></div>
                                            </div>
                                    <asp:TextBox runat="server" DataFormatString="${0:N0}" placeholder="Precio" ID="tprecio" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="valida_tprecio" CssClass="invalid-feedback" Text="Complete campos vacios, Ingrese Precio"></asp:Label>
                                </div>
                                    </div>

                                <div class="form-group">
                                    <label for="tingredientes">Ingredientes (*)</label>
                                         <div class="input-group mb-2">                      
                                        <div class="input-group-prepend">
                                         <div class="input-group-text text-info"><i class="fas fa-hamburger"></i></div>
                                        </div>
                                    <asp:TextBox runat="server" placeholder="Ingredientes" ID="tingredientes" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="valida_tingrediente" CssClass="invalid-feedback" Text="Complete campos vacios, Ingrese Ingredientes"></asp:Label>
                                </div>
                                    </div>

                                <div class="form-group">
                                    <label for="ftamano">Tamaño (*)</label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ftamano" CssClass="form-control"
                                        DataTextField="nombre_tamanoP" DataValueField="codigo_tamanoP">
                                    </asp:DropDownList>
                                </div>


                                <div class="form-group">
                                    <label for="fcategoria">Categoria (*)</label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="fcategoria" CssClass="form-control"
                                        DataTextField="nombre_categoria" DataValueField="codigo_categoria">
                                    </asp:DropDownList>
                                </div>

                            </div>

                            <div class="modal-footer">
                                <asp:Label runat="server" ID="cod_orginal" CssClass="ocultarCol"></asp:Label>
                                <asp:Button runat="server" ID="ideditarMenuBoton" Visible="false" OnClick="ideditarMenuBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                <asp:Button runat="server" ID="idregistrarMenu" Visible="false" OnClick="idregistrarMenu_Click" Text="Registrar" CssClass="btn btn-success float-right" />
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>

