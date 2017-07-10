<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Scores.aspx.cs" Inherits="Scores" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Les scores en détails :&nbsp;<asp:Label runat="server" ID="lblNbVotesTotal"></asp:Label></h3>
    <asp:CheckBox runat="server" ID="chkAll" Checked="false" AutoPostBack="true"/>Afficher les chats qui n'ont pas eu de votes
   <asp:Repeater runat="server" ID="rptCats" DataMember="Cat" OnItemDataBound="rptCats_ItemDataBound">
       <HeaderTemplate>
           <div><ul>
       </HeaderTemplate>
       <ItemTemplate>
          <li class="liRpt">
             <strong>&nbsp; <%# Container.ItemIndex + 1 %>&nbsp;</strong>
              <asp:Image runat="server" Width="70px" ID="imgCat" />
            <span class="spR">&nbsp;Score Elo&nbsp;<asp:Label runat="server" Font-Bold="true" ID="lblCatScore"></asp:Label></span>
             <span  class="spR">&nbsp;nb de votes gagnants&nbsp;<asp:Label runat="server" Font-Bold="true" ID="lblnbVotesGagnants"></asp:Label></span>
             <span  class="spR">&nbsp;nb de votes perdants&nbsp;<asp:Label runat="server" ID="lblnbVotesPerdants" Font-Bold="true"></asp:Label></span>
             <span  class="spR">&nbsp;nb de votes nuls&nbsp;<asp:Label runat="server" ID="lblnbMatchsNuls" Font-Bold="true"></asp:Label></span>

         </li>  
       </ItemTemplate>
       <FooterTemplate>
           </ul></div>
       </FooterTemplate>
   </asp:Repeater>
</asp:Content>
