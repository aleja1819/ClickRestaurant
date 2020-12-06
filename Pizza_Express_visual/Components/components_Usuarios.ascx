<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Usuarios.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Usuarios" %>

<style>
    .ocultarCol {
        display: none;
    }
</style>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">
<link href="../Content/animate.min.css" rel="stylesheet" />

<div class="container">
    <div class="row">

        <div class="col-md-12">

            <asp:UpdatePanel runat="server" ID="uContenedorUsuario" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>

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
                                <asp:TextBox runat="server" ID="tdatoBuscar"
                                    CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                <div class="input-group-prepend">
                                    <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">

                                        <asp:ListItem Value="0" Text="Rut" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Nombre Usuario"></asp:ListItem>

                                    </asp:DropDownList>

                                    <asp:Button runat="server" ID="idBuscarUsuario" OnClick="idBuscarUsuario_Click" Text="buscar" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                        <%--SEGUNDA COLUMNA--%>
                        <div class="col-md-3">

                            <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarUsuarioModal_Click" ID="bRegistrarUsuario">
                       <i class="fas fa-plus"></i> Registrar Usuarios
                            </asp:LinkButton>
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>

                        <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnVolverU_Click" ID="btnVolverU">
                       <i class="fas fa-home"></i>
                            </asp:LinkButton>      
                    </div>

                    </div>

                    <div class="col align-content-center">
                        <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                            OnRowCommand="idTabla_RowCommand" OnPageIndexChanging="idTabla_PageIndexChanging" PageSize="4" AllowPaging="true">
                            <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                            <Columns>
                                <asp:BoundField DataField="codigo_usuario" HeaderText="codigo"
                                    HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol"/>
                                <asp:BoundField DataField="rut_usuario" HeaderText="Rut" />
                                <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre Usuario" />
                                <asp:BoundField DataField="email_usuario" HeaderText="Email" />
                                <asp:BoundField DataField="contraseña_usuario" HeaderText="Contraseña" Visible="true" />
                                <asp:BoundField DataField="nombre_tipoUsuario" HeaderText="Tipo Usuario" />
                                <asp:BoundField DataField="nombre_estado" HeaderText="Estado Usuario" />

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

                <asp:UpdatePanel ID="uModalUsuario" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">USUARIOS</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">

                                <div class="form-group">
                                    <label for="trut">Rut Usuario (*)</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-user"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Rut usuario" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_trut" CssClass="invalid-feedback" Text="Ingrese Rut"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="tnombre">Nombre Usuario (*)</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-file-signature"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Nombre Usuario" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tnombre" CssClass="invalid-feedback" Text="Ingrese Nombre"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="temail">Email Usuario(*)</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-envelope-open-text"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Email Usuario" ID="temail" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_temail" CssClass="invalid-feedback" Text="Ingrese Email"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="tclave">Contraseña(*)</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-key"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" ID="tclave"  placeholder="Contraseña" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tclave" CssClass="invalid-feedback" Text="Ingrese Contraseña"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="fTipoUsuario">Tipo Usuario(*)</label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="fTipoUsuario" CssClass="form-control"
                                        DataTextField="nombre_tipoUsuario" DataValueField="codigo_tipoUsuario">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label for="fEstado">Estado(*)</label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="fEstado" CssClass="form-control"
                                        DataTextField="nombre_estado" DataValueField="codigo_estado">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <asp:Label runat="server" ID="cod_orginal" CssClass="ocultarCol"></asp:Label>
                                <asp:Button runat="server" ID="ideditarUsuarioBoton" Visible="false" OnClick="ideditarUsuarioBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                <asp:Button runat="server" ID="idregistrar" Visible="false" OnClick="idregistrarUsuario_Click" Text="Registrar"  CssClass="btn btn-success float-right" />
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
