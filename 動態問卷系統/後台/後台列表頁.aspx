<%@ Page Title="" Language="C#" MasterPageFile="~/Models/Main.Master" AutoEventWireup="true" CodeBehind="後台列表頁.aspx.cs" Inherits="動態問卷系統.後台.後台列表頁" %>

<%@ Register Src="~/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style1" style="border: thin solid #000000">
            <asp:Label ID="lblTitle" runat="server" Text="問卷標題："></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" TextMode="Search"></asp:TextBox><br />
            <asp:Label ID="lblStart" runat="server" Text="開始時間："></asp:Label>
            <asp:TextBox ID="txtStart" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;
            <asp:Label ID="lblEnd" runat="server" Text="結束時間："></asp:Label>
            <asp:TextBox ID="txtEnd" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFind" runat="server" Text="搜尋" OnClick="btnFind_Click" />
        </div>
    <br />
        <div>
            <asp:ImageButton ID="ImgbtnBin" runat="server" Height="29px" ImageUrl="~/Images/bin.png" Width="34px" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="ImgbtnAdd" runat="server" ImageUrl="~/Images/add.png" Height="29px" Width="33px" />
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:CheckBoxField />
            <asp:BoundField HeaderText="#" />
            <asp:HyperLinkField HeaderText="問卷" />
            <asp:BoundField HeaderText="狀態" />
            <asp:BoundField HeaderText="開始時間" />
            <asp:BoundField HeaderText="結束時間" />
            <asp:TemplateField HeaderText="觀看統計">
                <ItemTemplate>
                    <a href="前台統計頁.aspx?Number=<%# Eval("Number") %>">前往</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <uc1:ucPager runat="server" ID="ucPager" />
</asp:Content>
