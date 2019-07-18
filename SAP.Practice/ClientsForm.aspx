
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientsForm.aspx.cs" Inherits="SAP.Practice.ClientsForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Gestión de Clientes</h3>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="false" DataKeyNames="DocumentId" OnSelectedIndexChanged="grdItems_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="true" />
                    <asp:BoundField DataField="DocumentId" HeaderText="DNI" ReadOnly="true" />
                    <asp:BoundField DataField="FirstName" HeaderText="Nombre" ReadOnly="true" />
                    <asp:BoundField DataField="LastName" HeaderText="Apellido" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>DNI</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDocumentId"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFirstName"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <label>Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtLastName"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="btnCreate" runat="server" Text="Crear" OnClick="btnCreate_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="btnDelete_Click" />
        </div>
    </div>

</asp:Content>
