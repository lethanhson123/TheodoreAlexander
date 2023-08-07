<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
           <h3>Code create Model</h3>
        </div>        
    </div>
    <div class="row">
        <div class="col-sm-2">
            Connection String:
        </div>
        <div class="col-sm-8">

            <asp:TextBox runat="server" ID="txtConnectionString" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button runat="server" ID="tbnGetTable" class="btn btn-success" OnClick="tbnGetTable_OnClick" Text="Get Tables" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
              <div class="row">
                <div class="col-sm-4">
                    InitialCatalog:
                </div>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="txtInitialCatalog" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    Tables:
                </div>
                <div class="col-sm-8">
                    <asp:DropDownList ID="ddlTable" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlTable_OnSelectedIndexChanged_"></asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-4">
                    Choose Key:
                </div>
                <div class="col-sm-8">
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-4">
                    Name Space:
                </div>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="txtNameSpace" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    Class:
                </div>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="txtNameClass" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-5">           
        </div>

    </div>
    <div class="row text-center">
        <asp:Button runat="server" ID="btnCreateCode" Text="Create Code" OnClick="btnCreateCode_OnClick" class="btn btn-success btn-lg" />
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </div>

</asp:Content>
