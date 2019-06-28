<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Inventario.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Inventario" %>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<!-- Tabs -->
<section id="tabs">
    <div class="container">
             <h6 class="section-title h3 text-center text-dark">Menú</h6>
        <div class="row">
            <div class="col-xs-12">
                <nav>
                    <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link text-warning" id="tab-pizza" data-toggle="tab" href="#nav-pizza" role="tab" aria-controls="nav-pizza" aria-selected="true">PIZZAS</a>
                        <a class="nav-item nav-link text-warning" id="tab-tabla" data-toggle="tab" href="#nav-tabla" role="tab" aria-controls="nav-tabla" aria-selected="false">TABLAS</a>
                        <a class="nav-item nav-link text-warning" id="tab-sandiwch" data-toggle="tab" href="#nav-contact" role="tab" aria-controls="nav-contact" aria-selected="false">SANDIWCH</a>
                        <a class="nav-item nav-link text-warning" id="tab-platos" data-toggle="tab" href="#nav-about" role="tab" aria-controls="nav-about" aria-selected="false">PLATOS</a>
                        <a class="nav-item nav-link text-warning" id="tab-ensalada" data-toggle="tab" href="#nav-about" role="tab" aria-controls="nav-about" aria-selected="false">ENSALADAS</a>
                        <a class="nav-item nav-link text-warning" id="tab-bebestible" data-toggle="tab" href="#nav-about" role="tab" aria-controls="nav-about" aria-selected="false">BEBESTIBLES</a>
                    </div>
                </nav>
                <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                    <div class="tab-pane fade show active" id="nav-pizza" role="tabpanel" aria-labelledby="nav-pizza">
                        <div class="btn-group-vertical" role="group">
                            <a href="#" class="list-group">

                                <asp:Button ID="tabfamiliar" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="FAMILIAR" />
                                <asp:Button ID="tabmediana" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="MEDIANA" />
                                <asp:Button ID="tabindividual" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="INDIVIDUAL" />

                            </a>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="nav-tabla" role="tabpanel" aria-labelledby="nav-tabla">
                        <%--BOTONES--%>
                        <div class="btn-group-vertical" role="group">
                            <a href="#" class="list-group">

                                <asp:Button ID="tabTExpress" CssClass=" btn btn-success  btn-lg btn-block" runat="server" Text="TABLA EXPRESS" />
                                <asp:Button ID="tabTDos" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="TALA PARA DOS" />
                                <asp:Button ID="tabTcar" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="TABLA DE CARNE" />
                                <asp:Button ID="tabTVege" CssClass="btn btn-success  btn-lg  btn-block" runat="server" Text="TABLA DE VEGETARIANA" />

                            </a>
                        </div>
                        <%--FIN BOTONES--%>
                    </div>
                    <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                        Et et consectetur ipsum labore excepteur est proident excepteur ad velit occaecat qui minim occaecat veniam. Fugiat veniam incididunt anim aliqua enim pariatur veniam sunt est aute sit dolor anim. Velit non irure adipisicing aliqua ullamco irure incididunt irure non esse consectetur nostrud minim non minim occaecat. Amet duis do nisi duis veniam non est eiusmod tempor incididunt tempor dolor ipsum in qui sit. Exercitation mollit sit culpa nisi culpa non adipisicing reprehenderit do dolore. Duis reprehenderit occaecat anim ullamco ad duis occaecat ex.
				
                    </div>
                    <div class="tab-pane fade" id="nav-about" role="tabpanel" aria-labelledby="nav-about-tab">
                        Et et consectetur ipsum labore excepteur est proident excepteur ad velit occaecat qui minim occaecat veniam. Fugiat veniam incididunt anim aliqua enim pariatur veniam sunt est aute sit dolor anim. Velit non irure adipisicing aliqua ullamco irure incididunt irure non esse consectetur nostrud minim non minim occaecat. Amet duis do nisi duis veniam non est eiusmod tempor incididunt tempor dolor ipsum in qui sit. Exercitation mollit sit culpa nisi culpa non adipisicing reprehenderit do dolore. Duis reprehenderit occaecat anim ullamco ad duis occaecat ex.
				
                    </div>
                </div>

            </div>
        </div>
    </div>
</section>
<!-- ./Tabs -->
