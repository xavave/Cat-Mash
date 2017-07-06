<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Scores.aspx.cs" Inherits="Scores" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Les scores en détails</h3><asp:CheckBox runat="server" ID="chkAll" Checked="false" AutoPostBack="true"/>Afficher les chats dont le score est nul
   <asp:Repeater runat="server" ID="rptCats" DataMember="CatImage" OnItemDataBound="rptCats_ItemDataBound">
       <HeaderTemplate>
           <div><ul>
       </HeaderTemplate>
       <ItemTemplate>
         <li><asp:Image runat="server" Width="70px" ID="imgCat" /><asp:Label runat="server" ID="lblCatScore"></asp:Label></li>  
       </ItemTemplate>
       <FooterTemplate>
           </ul></div>
       </FooterTemplate>
   </asp:Repeater>
</asp:Content>
