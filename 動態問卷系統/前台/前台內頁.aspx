<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="前台內頁.aspx.cs" Inherits="動態問卷系統.前台.前台內頁" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>   <%--標題--%>
            <asp:Repeater ID="reHeading" runat="server">
                <ItemTemplate>
                    <h2>
                        <%#Eval("Heading") %>
                    </h2>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div>   <%--內容--%>
            <asp:Repeater ID="reContent" runat="server">
                <ItemTemplate>
                    <p>
                        <%#Eval("Content") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Label ID="lblName" runat="server" Text="姓名："></asp:Label>
            <asp:TextBox ID="txtbName" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblPhone" runat="server" Text="手機："></asp:Label>
            <asp:TextBox ID="txtbPhone" runat="server" TextMode="Phone"></asp:TextBox><br /><br />
            <asp:Label ID="lblEmail" runat="server" Text="Email："></asp:Label>
            <asp:TextBox ID="txtbEmail" runat="server" TextMode="Email"></asp:TextBox><br /><br />
            <asp:Label ID="lblAge" runat="server" Text="年齡："></asp:Label>
            <asp:TextBox ID="txtbAge" runat="server"></asp:TextBox>
        </div>
        <div>  <%--題目--%>

        </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSent" runat="server" Text="送出" OnClick="btnSent_Click" />
        </div>
    </form>
</body>
</html>
