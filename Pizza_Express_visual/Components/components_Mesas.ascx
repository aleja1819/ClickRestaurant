<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="components_Mesas.ascx.cs" Inherits="Pizza_Express_visual.Components.components_Mesas" %>
<%@ Register Src="~/Components/component_Comanda.ascx" TagPrefix="uc1" TagName="component_Comanda" %>



<h1 class="text-center">Presentación de Mesas</h1>
<br />

<div class="container">
    <div class="row">
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa1" OnClick="bMesa1_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 1</strong>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa2" OnClick="bMesa2_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 2</strong>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa3" OnClick="bMesa3_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 3</strong>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa4" OnClick="bMesa4_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 4</strong>             
        </asp:LinkButton>
            </div>
        <div class="col-md-2">
            <asp:LinkButton ID="bMesa5" OnClick="bMesa5_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 5</strong>             
        </asp:LinkButton>
            </div>
        <div class="col-md-2">
            <asp:LinkButton ID="bMesa6" OnClick="bMesa6_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 6</strong>             
        </asp:LinkButton>
            </div>
    </div>
    <br />
    <br />
    <br />

    <%-- Fila 2 --%>

    <div class="row">
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa7" OnClick="bMesa7_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 7</strong>
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa8" OnClick="bMesa8_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <strong>Mesa 8</strong>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa9" OnClick="bMesa9_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 16px"><strong>Mesa 9</strong></span>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa10" OnClick="bMesa10_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 15px"><strong>Mesa 10</strong></span>
        </asp:LinkButton>
            </div>
        <div class="col-md-2">
            <asp:LinkButton ID="bMesa11" OnClick="bMesa11_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 14px"><strong>Mesa 11</strong></span>      
            </asp:LinkButton>
            </div>
        <div class="col-md-2">
            <asp:LinkButton ID="bMesa12" OnClick="bMesa12_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 14px"><strong>Mesa 12</strong></span>
        </asp:LinkButton>
            </div>
    </div>
    <br />
    <br />
    <br />

    <%-- Fila 3 --%>


    <div class="row">
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa13" OnClick="bMesa13_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 15px"><strong>Mesa 13</strong></span>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa14" OnClick="bMesa14_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 15px"><strong>Mesa 14</strong></span>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa15" OnClick="bMesa15_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 15px"><strong>Mesa 15</strong></span>             
        </asp:LinkButton>
        </div>
        <div class="col-md-2">
        <asp:LinkButton ID="bMesa16" OnClick="bMesa16_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 14px"><strong>Mesa 16</strong></span>
        </asp:LinkButton>
            </div>
        <div class="col-md-2">
            <asp:LinkButton ID="bMesa17" OnClick="bMesa17_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 14px"><strong>Mesa 17</strong></span>      
            </asp:LinkButton>
            </div>
        <div class="col-md-2">
            <asp:LinkButton ID="bMesa18" OnClick="bMesa18_Click" runat="server" CssClass="btn btn-success">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"></path></svg>
            <span style="font-size: 14px"><strong>Mesa 18</strong></span>
        </asp:LinkButton>
            </div>
    </div>

</div>
<asp:UpdatePanel ID="uContenido" runat="server" UpdateMode="Conditional" ChildrenASTrigger="true">
    <ContentTemplate>
        <asp:MultiView ID="mContenedor" runat="server">
            <asp:View runat="server" ID="vComanda">
                <uc1:component_Comanda runat="server" ID="component_Comanda" />
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
