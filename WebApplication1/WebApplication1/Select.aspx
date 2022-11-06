﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="kensaku">
            <div class="jyoken">検索条件</div>
            <table class="jyokenable" id="table1">
                <tr>
                    <td class="name1">Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" class="className" runat="server"></asp:TextBox>
                    </td>
                    <td class="name1">ID:</td>
                    <td>
                        <asp:TextBox ID="txtId" class="classId" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" Text="検索" OnClick="button1_Click" />
            <asp:Panel ID="Panel1" runat="server">
                <div class="itiran">■検索一覧</div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowDeleting="GridView_RowDeleting" OnRowUpdating="GridView_RowUpdating" OnRowEditing="GridVew_RowEditing" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="姓名" DataField="name">
                            <HeaderStyle VerticalAlign="Middle" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="年齢" DataField="age">
                            <HeaderStyle VerticalAlign="Middle" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="性別" DataField="gender">
                            <HeaderStyle VerticalAlign="Middle" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" width="106px" Text='<%# Bind("id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" width="106px" Text='<%# Bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:BoundField HeaderText="給料" DataField="salary">
                            <HeaderStyle VerticalAlign="Middle" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="職種" DataField="work">
                            <HeaderStyle VerticalAlign="Middle" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="期日" DataField="date1">
                            <HeaderStyle VerticalAlign="Middle" Width="106px" />
                            <ItemStyle HorizontalAlign="Left" Width="106px" Wrap="false" />
                        </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:CommandField ShowEditButton="True" />                        
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>        
    </form>
</body>
</html>
