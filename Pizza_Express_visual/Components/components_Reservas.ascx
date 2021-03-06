﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Reservas.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Reservas" %>


<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<style>
    .ocultarCol {
        display: none;
    }
</style>

<div class="container">
    <div class="row">

        <div class="col-md-12">
            <asp:UpdatePanel runat="server" ID="uContenedorReservas" UpdateMode="Conditional" ChildrenAsTriggers="true">
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
                                <asp:TextBox runat="server" ID="tdatoBuscarReservas"
                                    CssClass="form-control" placeholder="Ingrese datos"></asp:TextBox>

                                <div class="input-group-prepend">
                                    <asp:DropDownList runat="server" ID="idOpciones" CssClass="btn btn-secondary">

                                        <asp:ListItem Value="0" Text="Número de mesa" Selected="True"></asp:ListItem>

                                    </asp:DropDownList>

                                    <asp:Button runat="server" ID="idBuscarMesa" OnClick="idBuscarMesa_Click" Text="buscar" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                        <%--SEGUNDA COLUMNA--%>
                        <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bRegistrarReservarModal_Click" ID="bRegistrarReservarModal">
                       <i class="fas fa-plus"></i> Registrar Reservas
                            </asp:LinkButton>
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>

                          <div class="col-md-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnVolverR_Click" ID="btnVolverR">
                       <i class="fas fa-home"></i>
                            </asp:LinkButton>      
                    </div>
                    </div>

                    <div class="col align-content-center">
                        <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                            OnRowCommand="idTabla_RowCommand" OnPageIndexChanging="idTabla_PageIndexChanging" PageSize="4" AllowPaging="true">

                            <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                            <Columns>

                                <asp:BoundField DataField="codigo_reserva" HeaderText="Código" 
                                    HeaderStyle-CssClass="ocultarCol" ItemStyle-CssClass="ocultarCol"/>
                                <asp:BoundField DataField="numeroMesa" HeaderText="Número de mesa" />
                                <asp:BoundField DataField="nombre_reserva" HeaderText="Nombre Cliente" />
                                <asp:BoundField DataField="fecha_reser" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="hora_reser" HeaderText="Hora" DataFormatString="{0:t}" />

                                <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-dark" Text="Editar" />
                                <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />

                            </Columns>
                        </asp:GridView>
                        <%-- --%>
                     </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg bg-light" role="document">

                <asp:UpdatePanel ID="uModalReserva" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">RESERVAS</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">

                                <div class="form-group">
                                    <label for="tnMesa">Número Mesa</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-edit"></i></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Número mesa" ID="tnMesa" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tnMesa" CssClass="invalid-feedback" Text="Complete campos vacios, Ingrese Número Mesa"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="tnombre">Nombre Cliente</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-file-signature"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Nombre Cliente" ID="tnombre" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tnombre" CssClass="invalid-feedback" Text="Complete campos vacios, Ingrese Nombre Cliente"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="tfecha">Fecha</label>
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="far fa-calendar-alt"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" ID="tfecha" TextMode="Date" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tfecha" CssClass="invalid-feedback" Text="Complete campos vacios, Ingrese Fecha"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                        <label for="thora">Hora</label>
                                        <asp:TextBox  runat="server" ID="thora" TextMode="Time" CssClass="form-control bg-secondary"></asp:TextBox>
                                    <asp:Label runat="server" ID="valida_thora" CssClass="invalid-feedback" Text="Ingrese Hora"></asp:Label>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <asp:Label runat="server" ID="c_orginal" CssClass="ocultarCol"></asp:Label>
                                <asp:Button runat="server" ID="ideditarReservaBoton" Visible="false" OnClick="ideditarReservaBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                                <asp:Button runat="server" ID="idregistrarReservas" Visible="false" OnClick="idregistrarReservas_Click" Text="Registrar" CssClass="btn btn-success float-right" />
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
