<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_NumeroMesa.ascx.cs" Inherits="Pizza_Express_visual.Components.components_NumeroMesa" %>

<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/cerulean/bootstrap.min.css" rel="stylesheet" integrity="sha384-C++cugH8+Uf86JbNOnQoBweHHAe/wVKN/mb0lTybu/NZ9sEYbd+BbbYtNpWYAsNP" crossorigin="anonymous">

<style type="text/css">
    .boton {
        font-size: 20px;
        font-family: Verdana,'Comic Sans MS';
        font-weight: bold;
        color: white;
        background: #44bf20;
        border: 0px;
        width: 100px;
        height: 100px;
    }
</style>


<div class="container">
    <div class="row">



        <div class="row">
            <div class="col-md-6">
                <asp:LinkButton runat="server" CssClass="boton">1</asp:LinkButton>
            </div>
             
            <div class="col-md-6">
                <asp:LinkButton runat="server" CssClass="boton">2</asp:LinkButton>
            </div>
       </div>

</div>
</div>
