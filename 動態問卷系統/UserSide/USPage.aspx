﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Models/Main.Master" AutoEventWireup="true" CodeBehind="USPage.aspx.cs" Inherits="動態問卷系統.後台.後台內頁1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
        <style>
            body {font-family: Arial;}

            .tab {
              overflow: hidden;
              border: 1px solid #ccc;
              background-color: #f1f1f1;
            }

            .tab button {
              background-color: inherit;
              float: left;
              border: none;
              outline: none;
              cursor: pointer;
              padding: 14px 16px;
              transition: 0.3s;
              font-size: 17px;
            }

            .tab button:hover {
              background-color: #ddd;
            }

            .tab button.active {
              background-color: #ccc;
            }

            .tabcontent {
              display: none;
              padding: 6px 12px;
              border: 1px solid #ccc;
              border-top: none;
            }
        </style>

        <script>
            function openQuestionnaire(evt, idName) {

                var i, tabcontent, tablinks;
                tabcontent = document.getElementsByClassName("tabcontent");
                for (i = 0; i < tabcontent.length; i++) {
                    tabcontent[i].style.display = "none";
                }

                tablinks = document.getElementsByClassName("tablinks");
                for (i = 0; i < tablinks.length; i++) {
                    tablinks[i].className = tablinks[i].className.replace(" active", "");
                }

                document.getElementById(idName).style.display = "block";
                evt.currentTarget.className += " active";
            }

            document.getElementById("defaultOpen").click();
        </script>

        <div class="tab">
          <button type="button" class="tablinks" onclick="openQuestionnaire(event, 'Questionnaire')" id="defaultOpen">問卷</button>
          <button type="button" class="tablinks" onclick="openQuestionnaire(event, 'Question')">問題</button>
          <button type="button" class="tablinks" onclick="openQuestionnaire(event, 'WriteInformation')">填寫資料</button>
          <button type="button" class="tablinks" onclick="openQuestionnaire(event, 'Statistics')">統計</button>
        </div>

        <div id="Questionnaire" class="tabcontent">  <%--問卷--%>
            <asp:Label ID="lblQuestaireName" runat="server" Text="問卷名稱"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtQuestaireName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblContent" runat="server" Text="描述內容"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Label ID="lblStartT" runat="server" Text="開始時間"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtStartT" runat="server" TextMode="Date" ></asp:TextBox>
            <br />
            <asp:Label ID="lblEndT" runat="server" Text="結束時間"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtEndT" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:CheckBox ID="ckbActivated" runat="server" Checked="True" /><asp:Label ID="lblActivated" runat="server" Text="已啟用"></asp:Label>
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" ></asp:Label>
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSent" runat="server" Text="送出" OnClick="btnSent_Click" />
        </div>

        <div id="Question" class="tabcontent">  <%--問題--%>
            <asp:Label ID="lblType" runat="server" Text="種類"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Value="0">自訂問題</asp:ListItem>
                <asp:ListItem Value="1">常用問題1</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblQuestion" runat="server" Text="問題"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlChoose" runat="server">
                <asp:ListItem Value="0">單選方塊</asp:ListItem>
                <asp:ListItem Value="1">複選方塊</asp:ListItem>
                <asp:ListItem Value="2">文字</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
            <asp:CheckBox ID="ckbRequired" runat="server" /><asp:Label ID="lblRequired" runat="server" Text="必填"></asp:Label>
            <br />
            <asp:Label ID="lblOptions" runat="server" Text="回答"></asp:Label>
            <asp:TextBox ID="txtOptions" runat="server"></asp:TextBox><p>(多個答案以；分隔)</p>&nbsp;&nbsp;
            <asp:Button ID="btnAddIn" runat="server" Text="加入" OnClick="btnAddIn_Click" />
            <br />
            <asp:ImageButton ID="ImgbtnBin" runat="server" ImageUrl="~/Images/bin.png" Height="29px" Width="34px" OnClick="ImgbtnBin_Click"/>&nbsp;&nbsp;<asp:Label ID="lblAddMessage" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="givQuestion" runat="server" AutoGenerateColumns="False" OnRowCommand="givQuestion_RowCommand">
                <Columns>
                    <asp:CheckBoxField />
                    <asp:BoundField HeaderText="#"  />
                    <asp:BoundField HeaderText="問題"  />
                    <asp:BoundField HeaderText="種類"  />
                    <asp:CheckBoxField HeaderText="必填" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="ID=<%# Eval("TopicNum") %>">編輯</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div>
                <asp:Button ID="btngivCancel" runat="server" Text="取消" OnClick="btngivCancel_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btngivSent" runat="server" Text="送出" OnClick="btngivSent_Click"/>
            </div>

        </div>

        <div id="WriteInformation" class="tabcontent">  <%--填寫資料--%>
            <asp:Button ID="btnExport" runat="server" Text="匯出" />
            <asp:GridView ID="givExport" runat="server"></asp:GridView>
            <%--分頁--%>

            <asp:PlaceHolder ID="PlaceHolderDetail" runat="server">
                <div>
                    <asp:Label ID="plblName" runat="server" Text="姓名"></asp:Label><asp:Literal ID="pltlName" runat="server"></asp:Literal>
                    <asp:Label ID="plblPhone" runat="server" Text="手機"></asp:Label><asp:Literal ID="pltlPhone" runat="server"></asp:Literal>
                    <asp:Label ID="plblEmail" runat="server" Text="Email"></asp:Label><asp:Literal ID="pltlEmail" runat="server"></asp:Literal>
                    <asp:Label ID="plblAge" runat="server" Text="年齡"></asp:Label><asp:Literal ID="pltlAge" runat="server"></asp:Literal>

                    <asp:Label ID="lblWriteT" runat="server" Text="填寫時間：<%# %>"></asp:Label>  <%--連結時間--%>
                </div>
                <div>
                    <%--跳出填答問卷--%>
                </div>
            </asp:PlaceHolder>

        </div>

        <div id="Statistics" class="tabcontent">  <%--統計--%>
          <h3>統計</h3>
        </div>

</asp:Content>

