<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_CartaMenu.ascx.cs" Inherits="Pizza_Express_visual.Components.components_CartaMenu" %>



<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<div class="container">
    <div class="row">   
            
         <div class="col-md-12">

                <asp:UpdatePanel runat="server" ID="uContenedorMenu" UpdateMode="Conditional" ChildrenAsTriggers="true">
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

                                            <asp:ListItem Value="0" Text="Nombre Menu"></asp:ListItem>
                                            
                                        </asp:DropDownList>

                                        <asp:Button runat="server" ID="idBuscarMenu" Text="buscar" CssClass="btn btn-success" />
                                    </div>
                                </div>                     
                             </div> <%--CIERRE COLUMNA--%>
                        
                        <%--SEGUNDA COLUMNA--%>
                        
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarMenu_Click"  ID="bRegistrarMenu">
                       <i class="fas fa-plus"></i> Registrar Menú
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
                                >
                                <HeaderStyle CssClass="btn-dark" />

                                <Columns>
                                    <asp:BoundField DataField="codigo_menu" HeaderText="codigo"/>
                                    <asp:BoundField DataField="nombre_menu" HeaderText="Nombre Menú" />
                                    <asp:BoundField DataField="precio_menu" HeaderText="Precio Menú" />
                                    <asp:BoundField DataField="ingredientes_menu" HeaderText="Ingredientes" />
                                    <asp:BoundField DataField="nombre_categoria" HeaderText="Categoria" />

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

                    <asp:UpdatePanel ID="uModalMenu" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
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

                                    <%--NOMBRE MENU--%>
                                    <div class="form-group">
                                        <label for="tnombreM">Nombre Menú</label>
                                        <asp:TextBox runat="server" placeholder="Rut usuario" ID="trut" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--NOMBRE USUARIO--%>
                                    <div class="form-group">
                                        <label for="tprecio">Precio Menú</label>
                                        <asp:TextBox runat="server" placeholder="Nombre Usuario" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--EMAIL USUARIO--%>
                                    <div class="form-group">
                                        <label for="tingredientes">Ingredientes</label>
                                        <asp:TextBox runat="server" placeholder="Email Usuario" ID="temail" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--TAMAÑO PIZZA--%>
                                    <div class="form-group">
                                        <label for="ftamaño">Tamaño Pizza</label>
                                        <br />
                                        <asp:DropDownList runat="server" ID="ftamaño" CssClass="form-control"
                                            DataTextField="nombre_tamanoP" DataValueField="codigo_tamanoP">
                                        </asp:DropDownList>
                                    </div>

                                    <%--CATEGORIA--%>
                                    <div class="form-group">
                                        <label for="fcategoria">Categoria</label>
                                        <br />
                                        <asp:DropDownList runat="server" ID="fcategoria" CssClass="form-control"
                                            DataTextField="nombre_categoria" DataValueField="codigo_categoria">
                                        </asp:DropDownList>
                                    </div>

                                    <%--<asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>--%>

                                </div>

                                <div class="modal-footer">
                                   <%-- <asp:Button runat="server" ID="idtest" OnClick="idtest_Click" />--%>
                                    <asp:Button runat="server" ID="ideditarMenuBoton"  Text="Actualizar" CssClass="btn btn-success float-right" />
                                    <asp:Button runat="server" ID="idregistrarMenu"  Text="Registrar" CssClass="btn btn-success float-right" />
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

