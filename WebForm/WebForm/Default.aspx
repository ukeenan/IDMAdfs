<%@ Page Title="Home Page" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %> 
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">  
    <p>  
        This page displays the claims associated with a Forms authenticated user.          
    </p>  
    <h3>Your Claims</h3>  
    <p>  
        <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">  
            <AlternatingRowStyle BackColor="White" />  
            <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />  
        </asp:GridView>  
    </p>  
</asp:Content>  
