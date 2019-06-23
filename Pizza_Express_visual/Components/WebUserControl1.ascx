<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="Pizza_Express_visual.Components.WebUserControl1" %>

<asp:UpdatePanel runat="server" ID="uContenedorTest" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <br />
        <asp:Button  runat="server" ID="btnOpenModal" OnClick="btnBarra_Click" Text="OPEN"/>
        <asp:Label runat="server" ID="ms"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>


<div class="modal" id="myModalUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg bg-light" role="document">
        <asp:UpdatePanel runat="server" ID="uModalTest" UpdateMode="Conditional" ChildrenAsTriggers="true">
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
                          <%--    <asp:RequiredFieldValidator runat="server"
                                ForeColor="Red"
                                ErrorMessage="*"
                                Display="Dynamic"
                                ControlToValidate="t1"
                             
                                ></asp:RequiredFieldValidator>
                            <br />--%>
                            <asp:TextBox runat="server" ID="t1" CssClass="form-control"></asp:TextBox>
                        
                             <asp:Label runat="server" ID="error" ForeColor="Red"></asp:Label>
                            </div>

                           <div class="modal-footer">
                            <asp:Button  runat="server" ID="idtest" Text="Test" CssClass="btn btn-success float-right" OnClick="idtest_Click"/>
                            <asp:Button runat="server" ID="ideditar" Text="Actualizar" CssClass="btn btn-success float-right" />                     
                            <asp:Button runat="server" ID="idregistrar" Text="Registrar" CssClass="btn btn-success float-right" />
                        </div>
                         </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
