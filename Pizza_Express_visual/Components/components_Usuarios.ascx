<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Usuarios.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Usuarios" %>


<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<div class="container">
    <div class="row">   
            
         <div class="col-md-12">

                <asp:UpdatePanel runat="server" ID="uContenedorUsuario" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                         <br />
                         <br />  
                                         
                                 <%--PRIMERA COLUMNA--%>
                        <div class="row">
                                <div class="col-md-6">
                                   
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

                                        <asp:Button runat="server" ID="idBuscarUsuario" OnClick="idBuscarUsuario_Click" Text="buscar" CssClass="btn btn-success" />
                                    </div>
                                </div>                     
                             </div> <%--CIERRE COLUMNA--%>
                        
                        <%--SEGUNDA COLUMNA--%>
                        
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarUsuarioModal_Click" ID="bRegistrarUsuario">
                       <i class="fas fa-plus"></i> Registrar Usuarios
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
                                <HeaderStyle CssClass="btn-dark" />

                                <Columns>
                                    <asp:BoundField DataField="codigo_usuario" HeaderText="codigo"/>
                                    <asp:BoundField DataField="rut_usuario" HeaderText="Rut" />
                                    <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre Usuario" />
                                    <asp:BoundField DataField="email_usuario" HeaderText="Email" />
                                    <asp:BoundField DataField="contraseña_usuario" HeaderText="Contraseña" />
                                    <asp:BoundField DataField="nombre_tipoUsuario" HeaderText="Tipo Usuario" />

                                    <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-light" Text="Editar" />
                                    <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                                </Columns>
                            </asp:GridView>
                            <%-- OnPageIndexChanging="idTabla_PageIndexChanging";PageSize="2; AllowPaging="true--%>
                        </div>
                                
                  
                    </ContentTemplate>
                </asp:UpdatePanel>
            
             </div>
          

            <%--ESTETICA DEL MODAL--%>
            <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg bg-light" role="document">

                    <asp:UpdatePanel ID="uModalUsuario" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
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
                                    </div>

                                    <%--NOMBRE USUARIO--%>
                                    <div class="form-group">
                                        <label for="tnombre">Nombre Usuario</label>
                                        <asp:TextBox runat="server" placeholder="Nombre Usuario" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--EMAIL USUARIO--%>
                                    <div class="form-group">
                                        <label for="temail">Email Usuario</label>
                                        <asp:TextBox runat="server" placeholder="Email Usuario" ID="temail" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--CONTRASEÑA USUARIO--%>
                                    <div class="form-group">
                                        <label for="tclave">Contraseña</label>
                                        <asp:TextBox runat="server" ID="tclave" TextMode="Password" placeholder="Contraseña" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--TIPO USUARIO--%>
                                    <div class="form-group">
                                        <label for="fTipoUsuario">Tipo Usuario</label>
                                        <br />
                                        <asp:DropDownList runat="server" ID="fTipoUsuario" CssClass="form-control"
                                            DataTextField="nombre_tipoUsuario" DataValueField="codigo_tipoUsuario">
                                        </asp:DropDownList>
                                    </div>

                                    <%--<asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>--%>

                                </div>

                                <div class="modal-footer">
                                   <%-- <asp:Button runat="server" ID="idtest" OnClick="idtest_Click" />--%>
                                    <asp:Button runat="server" ID="ideditarUsuarioBoton" OnClick="ideditarUsuarioBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                    <asp:Button runat="server" ID="idregistrar" OnClick="idregistrarUsuario_Click" Text="Registrar" CssClass="btn btn-success float-right" />
                                </div>

                                <%--ALERTA DE MENSAJE--%>
                                <asp:Panel runat="server" ID="alerta" Visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="alert-heading">Mensaje del sistema</h4>
                                    <asp:Label ID="mensaje2" runat="server"></asp:Label>
                                    <hr />
                                    <%=DateTime.Now %>
                                </asp:Panel>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
</div>
