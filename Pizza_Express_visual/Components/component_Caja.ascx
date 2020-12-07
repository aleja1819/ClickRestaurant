<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="component_Caja.ascx.cs" Inherits="Pizza_Express_visual.Components.component_Caja" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous" />
<link href="../Content/animate.min.css" rel="stylesheet" />

<style>
    .ocultarCol {
        display: none;
    }
</style>




<div class="container">
    <div class="row">

        <div class="modal-body">

            <asp:UpdatePanel runat="server" ID="uContenedorCajaA" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>

                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>

                    <br />

                    <h4>APERTURA DE CAJA</h4>
                    <div class="form-group">
                                    <label for="tmonto">Monto de apertura</label>
                                    <div class="input-group col-md-4">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-user"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Monto de apertura" ID="tmonto" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_tmonto" CssClass="invalid-feedback" Text="I"></asp:Label>
                                    </div>
                                </div>
                    

                    <div class="form-group col-md-2">
                                    <label for="fcaja">N° Caja</label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="fcaja" CssClass="form-control"
                                        DataTextField="numero_caja" DataValueField="numero_caja" >
                                        
                                    </asp:DropDownList>
                                </div>

                    <br />
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="bregistrarmonto_Click" ID="bregistrarmonto">
                       <i class="fas fa-plus"></i> Registrar Monto
                            </asp:LinkButton>

                        <br />
                        <br />
                        
                    <div class="col align-content-center">
                        <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false"
                           OnPageIndexChanging="idTabla_PageIndexChanging" OnRowCommand="idTabla_RowCommand" PageSize="4" AllowPaging="true">
                            <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true" />

                            <Columns>
                                <asp:BoundField DataField="id_DetalleCaja" HeaderText="ID"/>
                                <asp:BoundField DataField="monto_apertura" HeaderText="Monto" />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="hora" HeaderText="Hora" DataFormatString="{0:T}"/>
                                <asp:BoundField DataField="numero_caja" HeaderText="N° Caja"/>
                                <asp:BoundField DataField="nombre_usuario" HeaderText="Usuario"/>

                                <asp:ButtonField ButtonType="Link" CommandName="ideditar" ControlStyle-CssClass="btn btn-dark" Text="Editar"/>
                                <asp:ButtonField ButtonType="Link" CommandName="ideliminar" ControlStyle-CssClass="btn btn-dark" Text="Eliminar"/>

                            </Columns>
                        </asp:GridView>                       
                    </div>



                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <div class="modal" id="myModalCaja" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg bg-light" role="document">

                <asp:UpdatePanel ID="uModalCaja" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"><span class="badge badge-pill badge-info badge-center">Modificar Caja</span></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">
                                
                        <div class="form-group">
                                    <label for="emonto">Monto de apertura</label>
                                    <div class="input-group col-md-4">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text text-info"><i class="fas fa-user"></i></div>
                                        </div>
                                        <asp:TextBox runat="server" placeholder="Monto de apertura" ID="emonto" CssClass="form-control bg-secondary"></asp:TextBox>
                                        <asp:Label runat="server" ID="valida_emonto" CssClass="invalid-feedback" Text="I"></asp:Label>
                                    </div>
                                </div>
                    

                    <div class="form-group col-md-2">
                                    <label for="fcaja">N° Caja</label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-control"
                                        DataTextField="numero_caja" DataValueField="numero_caja" >
                                        
                                    </asp:DropDownList>
                                </div>

                            </div>

                            <div class="modal-footer">
                                <asp:Label runat="server" ID="cod_orginal" CssClass="ocultarCol"></asp:Label>
                                <asp:Button runat="server" ID="ideditarCajaBoton" Visible="false" OnClick="ideditarCajaBoton_Click" Text="Actualizar" CssClass="btn btn-success float-right" />
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>




    </div>
</div>
