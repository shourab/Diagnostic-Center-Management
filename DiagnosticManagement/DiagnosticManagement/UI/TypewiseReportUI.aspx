<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypewiseReportUI.aspx.cs" Inherits="DiagnosticManagement.UI.TypewiseReportUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Type Wise</title>
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="background: lightblue; width: 960px; margin: 0 auto;">
        <div style="width: 400px; margin: 0 auto;">
            <h1 style="color: green;">Type Wise Report</h1>
    <table >
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="FROM DATE"></asp:Label></td>
            <td>
                <asp:TextBox ID="fromTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="TO DATE"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="toTextBox" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" /></td>
                 </tr>
       
          </table> 
            </div> 
        <div style="width: 400px; margin: 0 auto;">
           <span style="color: red; font-size: 30px;"> <asp:Label ID="messageLabel" runat="server"></asp:Label>  </span>
            <br />
         <asp:GridView ID="resultGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
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
                 <asp:TemplateField HeaderText="Total Test">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TotalTest") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Total Amount">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TotalFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 
                 </Columns>
             <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
             <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
             <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#0000A9" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#000065" />
         </asp:GridView>
        <table>
        <tr>
           
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;
                <asp:Button ID="pdfButton" runat="server" Text="PDF" Visible="False" OnClick="pdfButton_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="totalLabel" runat="server" Text="Total" Visible="False"></asp:Label>
            </td>
            <td>
                <br />
                <asp:TextBox ID="totalTextBox" runat="server" Visible="False" Width="103px"></asp:TextBox></td>
        </tr>
    </table>
         </div>  
    </div>
        <
        <br/><br/>
          <div style="width: 960px; margin: 0 auto;">
         <a href="IndexUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px; ">Back To Start page</a>
         
         <a href="TestwiseReportUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background:green;color: white; display: inline-block; text-align: center;font-size: 40px;">Search Test  wise Report</a>
         <a href="UnpaidBillInfoUI.aspx"style="border-radius: 35px; text-decoration: none;width: 300px;height: 100px;background: green;color: white; display: inline-block; text-align: center;font-size: 40px;">Search Unpaid List</a>
    </div>
    </form>
    
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.min.js"></script>
<script>
    $(document).ready(function () {
        $("#fromTextBox").datepicker({
            changeMonth: true,
            changeYear: true
        });
        $("#toTextBox").datepicker({
            changeMonth: true,
            changeYear: true
        });
    })


</script>
</body>
</html>
