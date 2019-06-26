<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Reservas.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Reservas" %>


<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<div class="container">
    <div class="row">   
            
         <div class="col-md-12">
                <asp:UpdatePanel runat="server" ID="uContenedorReservas" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                         <br />
                         <br />  
                     
                      <%--PRIMERA COLUMNA--%>
                        <div class="row">
                                <div class="col-md-6">
                                   
                                <div class="input-group mb-2">
                                    <asp:TextBox runat="server" ID="tdatoBuscarReservas"
                                        CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                    <div class="input-group-prepend">
                                        <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">
                                            <%--ES UN CONBOBOX--%>

                                            <asp:ListItem Value="0" Text="Número de mesa" Selected="True"></asp:ListItem>
                                            
                                        </asp:DropDownList>

                                        <asp:Button runat="server" ID="idBuscarMesa"  Text="buscar" CssClass="btn btn-success" />
                                    </div>
                                </div>                     
                             </div> <%--CIERRE COLUMNA--%>
                        
                        <%--SEGUNDA COLUMNA--%>          
                        <div class="col-md-6">
                      <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarReservarModal_Click" ID="bRegistrarReservarModal">
                       <i class="fas fa-plus"></i> Registrar Reservas
                                </asp:LinkButton>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div> <%--CIERRE COLUMNA--%>
                        </div>
                        
                       
                        <%--TABLA GRIDVIEW--%>
                        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false">
                                
                                <HeaderStyle CssClass="btn-dark" />

                                <Columns>

                                    <asp:BoundField DataField="codigo_reserva" HeaderText="Código Reserva" />
                                    <asp:BoundField DataField="numero_mesa" HeaderText="Número de mesa" />
                                    <asp:BoundField DataField="nombre_reserva" HeaderText="Nombre Cliente" />
                                    <asp:BoundField DataField="fecha_reserva" HeaderText="Fecha" />
                                    <asp:BoundField DataField="hora_reserva" HeaderText="Hora" />


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

                    <asp:UpdatePanel ID="uModalReserva" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>

                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">Registrar Reservas</span></h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>

                                <%--TEXTOS INPUTS--%>
                                <div class="modal-body">

                                    <%--NUMERO DE MESA--%>
                                    <div class="form-group">
                                        <label for="tnMesa">Número Mesa</label>
                                        <asp:TextBox runat="server" placeholder="Número mesa" ID="tnMesa" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--NOMBRE RESERVA--%>
                                    <div class="form-group">
                                        <label for="tnombre">Nombre Cliente</label>
                                        <asp:TextBox runat="server" placeholder="Nombre Cliente" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <%--FECHA--%>
                                    <div class="form-group">
                                        <label for="tfecha">Fecha</label>
                                        <asp:TextBox  runat="server" ID="tfecha" TextMode="Date" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>
                                                               

                                    <%--HORA--%>
                                    <div class="form-group">
                                        <label for="thora">Hora</label>
                                        <asp:TextBox runat="server"  ID="thora" TextMode="Time" CssClass="form-control bg-secondary"></asp:TextBox>
                                    </div>

                                    <asp:Label runat="server" ID="mensaje" Text="Mensaje" Visible="false"></asp:Label>

                                </div>

                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="ideditarProveedorBoton" Text="Actualizar" CssClass="btn btn-success float-right" />
                                    <asp:Button runat="server" ID="idregistrarReservas" OnClick="idregistrarReservas_Click" Text="Registrar" CssClass="btn btn-success float-right" />
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
