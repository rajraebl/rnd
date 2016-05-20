<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Localization._Default" culture="auto" uiculture="auto" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
           <asp:Label runat="server" meta:resourcekey="LabelResource1"></asp:Label>
        </li>
        <li class="two">
           <asp:Label runat="server" meta:resourcekey="LabelResource2"></asp:Label>
        </li>
        <li class="two">
           
               <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </li>
    </ol>
</asp:Content>
