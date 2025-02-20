﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSPage.aspx.cs" Inherits="動態問卷系統.前台.前台內頁" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td><h1>前台</h1></td>
                    <td>
                        <%-- 投票中
                                時間顯示--%>
                    </td>
                </tr>
            </table>
        </div>
        <div>   <%--標題--%>
            <asp:Repeater ID="reHeading" runat="server">
                <ItemTemplate>
                     <div style="text-align:center;">
                         <h2>
                            <%#Eval("Heading") %>
                         </h2>
                     </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div>   <%--內容--%>
            <asp:Repeater ID="reContent" runat="server">
                <ItemTemplate>
                    <h3>
                        <%#Eval("Content") %>
                    </h3>
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
            <asp:TextBox ID="txtbAge" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        
        <asp:PlaceHolder ID="plcNoWriteData" runat="server" Visible="false">
            <p style="color: red; background-color:lightgoldenrodyellow">姓名、手機、Email、年齡 皆為必填</p>
        </asp:PlaceHolder>

        <div>  <%--題目、選項--%>
            <asp:Repeater ID="reTopic" runat="server">
                <ItemTemplate>
                    <p>
                        <%#Eval("TopicDescription") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="reOptions" runat="server">
                <ItemTemplate>
                    <p>
                        <%#Eval("OptionsDescription") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSent" runat="server" Text="送出" OnClick="btnSent_Click" />
        </div>
    </form>
</body>
</html>
