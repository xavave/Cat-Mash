<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cat Mash</h1>
        <p class="lead">Quel est le plus beau chat ?</p>
        <p><%:  nbVotes %> vote(s)</p>
    </div>

    <div class="row">
        <div class="col-md-6 parent">
            <h2>Celui-ci</h2>
            <asp:ImageButton runat="server" ID="btnLeftCat" CssClass="parent img" OnClick="leftCat_Click" />
            <asp:HiddenField runat="server" ID="leftCatId" />
        </div>
        <div class="col-md-6 parent">
            <h2>Celui-là</h2>
            <asp:ImageButton runat="server" ID="btnRightCat" CssClass="parent img" OnClick="rightCat_Click" />
            <asp:HiddenField runat="server" ID="rightCatId" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button runat="server" Text="Ni l'un, ni l'autre" ID="nextCats" OnClick="nextCats_Click" />
        </div>
    </div>

</asp:Content>
