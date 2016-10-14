<%@ Assembly Name="WF_Chapter10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=1f9c6d3a81157ab6" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, 
                   PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" 
             Namespace="Microsoft.SharePoint.WebControls" 
             Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, 
                       PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" 
             Namespace="Microsoft.SharePoint.Utilities" 
             Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, 
                       PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" 
             Namespace="System.Web.UI" 
             Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, 
                       PublicKeyToken=31bf3856ad364e35" %>

<%@ Page Language="C#" 
    DynamicMasterPageFile="~masterurl/default.master" 
    AutoEventWireup="true" 
    Inherits="WF_Chapter10.Workflow1.Chapter10Initiation" 
    CodeBehind="Chapter10Initiation.aspx.cs" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <!-- Add your custom content here -->
    <asp:Label ID="Label1" runat="server" 
               Text="Invitees (separate names with a semi-colon)"></asp:Label>
    <br />
    <asp:TextBox ID="txtInvitees" Width="300px" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Event Description"></asp:Label>
    <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Menu URL"></asp:Label>
    <asp:TextBox ID="txtMenuUrl" runat="server"></asp:TextBox>
    <br />
    <!-- End of custom content -->
    <asp:Button ID="StartWorkflow" runat="server" OnClick="StartWorkflow_Click" 
                Text="Start Workflow" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancel" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" 
             runat="server">
    Workflow Initiation Form
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" runat="server" 
             ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea">
    Workflow Initiation Form
</asp:Content>
