<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsurancesForm.aspx.cs" Inherits="SAP.Practice.InsurancesForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Gestión de Clientes</h3>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="false" DataKeyNames="InsuranceId" OnSelectedIndexChanged="grdItems_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="true" />
                    <asp:BoundField DataField="InsuranceId" HeaderText="Id" ReadOnly="true" />
                    <asp:BoundField DataField="Status" HeaderText="Estado" ReadOnly="true" />
                    <asp:BoundField DataField="Rate" HeaderText="Tasa" ReadOnly="true" />
                    <asp:BoundField DataField="Value" HeaderText="Prima" ReadOnly="true" />
                    <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="true" />
                    <asp:BoundField DataField="ClientName" HeaderText="Cliente" ReadOnly="true" />
                    <asp:BoundField DataField="ClientId" HeaderText="IdCliente" Visible="false" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <div class="form-group">
                <label>Id</label>
                <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control" ID="txtInsuranceId"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label></label>
                <asp:DropDownList runat="server" ID="ddlType">
                    <asp:ListItem Text="De automovil" Value="CAR"></asp:ListItem>
                    <asp:ListItem Text="De barco" Value="BOAT"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        

        <div class="col-md-2">
            <div class="form-group">
                <label>Status</label>
                <asp:DropDownList runat="server" ID="ddlStatus">
                    <asp:ListItem Text="Activa" Value="A"></asp:ListItem>
                    <asp:ListItem Text="Cancelada" Value="C"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-md-2">
            <div class="form-group">
                <label>Prima</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtValue"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label>Cliente</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlClient"></asp:DropDownList>
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

    <asp:RegularExpressionValidator
        runat="server"
        ErrorMessage="La prima debe ser un numero decimal" 
        ID="regValue" 
        ValidationGroup="Insert" 
        ControlToValidate="txtValue" 
        ValidationExpression="^\d+\.\d{0,2}$"
    ></asp:RegularExpressionValidator>

    <asp:ModelErrorMessage runat="server" />

</asp:Content>
