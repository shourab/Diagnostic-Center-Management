<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetuoUI.aspx.cs" Inherits="DiagnosticManagement.UI.TestSetuoUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%;">
   
       <div style="width: 960px; margin: 0 auto; background: lightblue; border: 1px solid black">
           <h1 style="text-align: center; color: green;">TEST SETUP</h1>
           <div style="width: 300px; margin: 0 auto;">
           
               <br />
           
        <asp:Label ID="Label1" runat="server" Text="TEST NAME"></asp:Label>

          
        
    &nbsp;<asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
           <br />
        <br />
       
           
        <asp:Label ID="Label2" runat="server" Text="FEE"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
               
          
        <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox>
           <br />
        <br />
               
      
        <asp:Label ID="Label3" runat="server" Text="TEST TYPE"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="typeDropDownList" runat="server" Height="31px" Width="101px" ForeColor="Blue">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" Height="30px" Width="53px" />
        <br />
       </div>
           <div style="width: 940px; margin: 0 auto;">
        <asp:GridView ID="setupGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle CssClass="table_04" HorizontalAlign="Left"></HeaderStyle>
            <ItemStyle CssClass="table_02" HorizontalAlign="Left"></ItemStyle>
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TestName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEE">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Type Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TestType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
               </div>
          
    </div>
        <div style="width: 1260px; margin: 0 auto;">
            <br/><br/>
         <a href="IndexUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px; ">Back To Start page</a>
         <a href="TestwiseReportUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px;">Search Test Wise Report</a>
         <a href="TypewiseReportUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px;">Search Test Type wise Report</a>
         <a href="UnpaidBillInfoUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px;">Search Unpaid List</a>
    </div>
        </div>
    </form>
</body>
</html>
