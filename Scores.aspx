<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Scores.aspx.cs" Inherits="Scores" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Les scores en détails :&nbsp;<asp:Label runat="server" ID="lblNbVotesTotal"></asp:Label></h3><asp:CheckBox runat="server" ID="chkAll" Checked="false" AutoPostBack="true"/>Afficher les chats dont le score est nul ou inférieur à 0
   <asp:Repeater runat="server" ID="rptCats" DataMember="Cat" OnItemDataBound="rptCats_ItemDataBound">
       <HeaderTemplate>
           <div><ul>
       </HeaderTemplate>
       <ItemTemplate>
         <li><asp:Image runat="server" Width="70px" ID="imgCat" />
             <span>&nbsp;Score Elo :&nbsp;</span><asp:Label runat="server" ID="lblCatScore"></asp:Label>
             <span>&nbsp;nb de votes gagnants :&nbsp;</span><asp:Label runat="server" ID="lblnbVotes"></asp:Label>

         </li>  
       </ItemTemplate>
       <FooterTemplate>
           </ul></div>
       </FooterTemplate>
   </asp:Repeater>
</asp:Content>
