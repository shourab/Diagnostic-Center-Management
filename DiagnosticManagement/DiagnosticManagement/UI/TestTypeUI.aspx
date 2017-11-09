<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeUI.aspx.cs" Inherits="DiagnosticManagement.TestTypeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type</title>
    <link href="indexStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 0 auto; width: 960px; background: lightblue; padding: 10px;">
        <h1 style="color: green; text-align: center;">Test Type Setup</h1>
        <div style="width: 400px; margin: 0 auto; padding-left: 200px; ">
    
        <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
        <asp:TextBox ID="typeTextBox" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" Width="48px" />
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server" style="color: red; " ></asp:Label>
        <br />
        <asp:GridView ID="testTypeGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="testTypeGridView_SelectedIndexChanged" BorderStyle="None" GridLines="Vertical">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
             <asp:TemplateField HeaderText="Sr No" >
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle CssClass="table_04" HorizontalAlign="Left"></HeaderStyle>
            <ItemStyle CssClass="table_02" HorizontalAlign="Left"></ItemStyle>
        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Test Type">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TestType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
        
        </asp:GridView>
    </div>
    </div>
        </form>
        <div style="width: 960px;margin: 0 auto"><br/>
        <a href="IndexUI.aspx"style="border-radius: 35px; text-decoration: none; width: 300px; height: 100px; background: green; color: white; display: inline-block; text-align: center; font-size: 40px;" >Back To Start page</a>
            
             <a href="TestSetuoUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px">TEST SETUP MENU</a>
         <a href="TypewiseReportUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px;">Search Test Type wise Report</a>
        
    </div>
</body>
</html>
