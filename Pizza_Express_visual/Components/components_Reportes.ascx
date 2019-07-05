<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Reportes.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Reportes" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">


   <style>
        .ocultarCol {
        display:none;
        }
    </style>


<div class="container"> 

    <div class="row">

        <div class="col-md-6">

                  <%--ALERTA DE MENSAJE--%>
                    <asp:Panel runat="server" ID="alerta" Visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <asp:Label  ID="mensaje3" runat="server"></asp:Label>
                    </asp:Panel>
                            
                        <br />  


            <div class="input-group mb-2">
                <h4 class="text-dark">Desde:</h4>
                <asp:TextBox runat="server" ID="tfechaini"
                    CssClass="form-control" placeholder="Fecha inicial"></asp:TextBox>
                
                <h4 class="text-dark">Hasta:</h4>
                <asp:TextBox runat="server" ID="tfechafin"
                    CssClass="form-control" placeholder="Fecha final"></asp:TextBox>
                
                <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bBuscarNombre" OnClick="bBuscarNombre_Click">
                       <i class="fas fa-plus"></i> Buscar
                </asp:LinkButton>
            </div>
        </div>
        <%--CIERRE COLUMNA--%>









                              
        <div class="col-md-6">
                      <asp:LinkButton runat="server" CssClass="btn btn-success" ID="bGenerarPdf" OnClick="bGenerarPdf_Click">
                       <i class="fas fa-plus"></i> Generar PDF
                                </asp:LinkButton>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div> <%--CIERRE COLUMNA--%>
        </div>


    <div class="row">
        <div class="col align-content-center">
                            <asp:GridView runat="server" ID="idTabla" CssClass="table table-bordered table-center " AutoGenerateColumns="false" >
                                
                                <HeaderStyle CssClass="btn-success" ForeColor="White" Font-Bold="true"   />

                                <Columns>

                                    <asp:BoundField DataField="codigo_producto" HeaderText="Código" />
                                    <asp:BoundField DataField="nombre_producto" HeaderText="Nombre Producto" />
                                    <asp:BoundField DataField="rut_proveedor" HeaderText="Rut Proveedor" />
                                    <asp:BoundField DataField="fecha_ingreso_producto" HeaderText="Fecha ingreso" />
                                    <asp:BoundField DataField="cantidad_producto" HeaderText="Cantidad Producto" />

                                </Columns>
                            </asp:GridView>


                            

    </div>

</div>