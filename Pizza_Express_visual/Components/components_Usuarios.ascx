<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Usuarios.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Usuarios" %>

<div class="container">
    <div class="row">

        <%--PRIMERA COLUMNA--%>
        <div class="col-md-6">
            <br />
            <br />

            <div class="input-group mb-2">
                <asp:TextBox runat="server" ID="tdatoBuscar"
                    CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                <div class="input-group-prepend">
                    <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">
                        <%--ES UN CONBOBOX--%>

                        <asp:ListItem Value="0" Text="Rut" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Nombre Usuario"></asp:ListItem>
                        <%--LO QUE DENTRO--%>
                    </asp:DropDownList>

                    <asp:Button runat="server" ID="idBuscarUsuario" Text="buscar" CssClass="btn btn-success" />
                </div>
            </div>
        </div>

        <%--SEGUNDA COLUMNA--%>
        <div class="col-md-6">
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarUsuario_Click" ID="bRegistrarUsuario">
                       <i class="fas fa-plus"></i> Registrar Usuarios
            </asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
        </div>

        <%--TABLA GRIDVIEW--%>
        <div class="col align-content-center">
            <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false" AllowPaging="true"
                OnRowCommand="idTabla_RowCommand">
                <HeaderStyle CssClass="btn-dark" />

                <Columns>
                    <asp:BoundField DataField="rut_usuario" HeaderText="Rut" />
                    <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre Usuario" />
                    <asp:BoundField DataField="email_usuario" HeaderText="Email" />
                    <asp:BoundField DataField="contraseña_usuario" HeaderText="Contraseña" />
                    <asp:BoundField DataField="nombre_tipoUsuario" HeaderText="Tipo Usuario" />

                    <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-light" Text="Editar" />
                    <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                </Columns>
            </asp:GridView>
            <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2--%>
        </div>
    </div>


    <%--ESTETICA DEL MODAL--%>
    <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg bg-light" role="document">

            <asp:UpdatePanel ID="uModalUsuario" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">

                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">Registrar Usuarios</span></h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <%--TEXTOS INPUTS--%>
                        <div class="modal-body">

                            <%--RUT USUARIO--%>
                            <div class="form-group">
                                <label for="trut">Rut Usuario</label>
                                <asp:TextBox runat="server" placeholder="Rut usuario" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Rut Obligatorio"
                                    ControlToValidate="trut"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>

                            </div>
                            <%--NOMBRE USUARIO--%>
                            <div class="form-group">
                                <label for="tnombre">Nombre Usuario</label>
                                <asp:TextBox runat="server" placeholder="Nombre Usuario" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Nombre Usuario Obligatorio"
                                    ControlToValidate="tnombre"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                            </div>

                            <%--EMAIL USUARIO--%>
                            <div class="form-group">
                                <label for="temail">Email Usuario</label>
                                <asp:TextBox runat="server" placeholder="Email Usuario" ID="temail" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Nombre Usuario Obligatorio"
                                    ControlToValidate="temail"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                            </div>

                            <%--CONTRASEÑA USUARIO--%>
                            <div class="form-group">
                                 <label for="tclave">Contraseña</label>
                                <asp:TextBox runat="server" ID="tclave" TextMode="Password" placeholder="Contraseña" CssClass="form-control bg-secondary"></asp:TextBox>

                                <%--VALIDADOR DE CAMPOS REQUERIDOS--%>
                                <asp:RequiredFieldValidator runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ErrorMessage="Contraseña Obligatoria"
                                    ControlToValidate="tclave"
                                    ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                            </div>

                            <%--TIPO USUARIO--%>
                            <label for="fTipoUsuario">Tipo Usuario  </label><br />
                            <asp:DropDownList runat="server" ID="fTipoUsuario" CssClass="btn btn-secondary">
            
                                <asp:ListItem Value="0" Text="Administrador de venta" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Administrador de inventario"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="Garzón"></asp:ListItem>
                                 <asp:ListItem Value="3" Text="Cajero"></asp:ListItem>
                               
                            </asp:DropDownList>

                            <asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>

                        </div>

                        <div class="modal-footer btn-align-content-center">
                            <asp:Button runat="server" ValidationGroup="grupo1" ID="beditar" Text="Actualizar" CssClass="btn btn-success float-right" />
                            <asp:Button runat="server" ValidationGroup="grupo1" ID="bregistrar" Text="Registrar" CssClass="btn btn-success float-right" />     
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
