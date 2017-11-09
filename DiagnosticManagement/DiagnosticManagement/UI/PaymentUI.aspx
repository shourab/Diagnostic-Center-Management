<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticManagement.UI.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    
</head>
<body >
<div style="width: 500px; margin: 0 auto; background: lightblue;">
    <h1 style="color: green;text-align: center">Payment</h1>
    <form id="form1" runat="server">
    <div >
         <table>
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label1" runat="server" Text="Payment"></asp:Label>
                 </td>
                 <td class="auto-style1"></td>

             </tr>
             <tr>
                 <td class="auto-style2"></td>
             </tr>
             <tr>
                 <td class="auto-style2"></td>
             </tr>  
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label2" runat="server" Text="Bill No"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="billNoTextBox" runat="server" Width="200px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
             <td class="auto-style2">
                 <asp:Label ID="Label3" runat="server" Text="MobileNo"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="mobileNoTextBox" runat="server" Width="200px"></asp:TextBox>
             </td>
                 
                 <td>
                     <asp:Button ID="searchButton" runat="server" Text="Search" Width="75px" OnClick="searchButton_Click" />
                 </td>    
             </tr>
             
             <tr>
                 <td></td>
             </tr>

             <tr>
                 <td class="auto-style2">
                     <asp:HiddenField ID="idHiddenField" runat="server" />
                 </td>
             </tr>
             <tr>
                 <td>..............................</td>
                 <td>....................................................</td>
             </tr>
             
             <tr>
                 <td></td>
             </tr>

             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="amountTextBox" runat="server" Width="200px"></asp:TextBox>
                 </td>
                 <td>
                     
                     <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
                     
                 </td>
             </tr>  

             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label5" runat="server" Text="Due Date"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="dueDateTextBox" runat="server" Width="200px"></asp:TextBox>
                 </td>
                 
                 <td>
                     <asp:Button ID="payButton" runat="server" Text="Pay" Width="75px" OnClick="payButton_Click" />
                 </td>
             </tr>
             
             
             
               
         </table>

        <br/>
        
        <asp:Label ID="messageLabel" runat="server" Text="......."></asp:Label>

    </div>
    </form>
    </div>
    <div style="width: 320px;margin: 0 auto"><br/>
        <a href="IndexUI.aspx"style="border-radius: 35px; text-decoration: none; width: 300px; height: 100px; background: green; color: white; display: inline-block; text-align: center; font-size: 40px;" >Back To Start page</a>
            
        
    </div>
</body>
</html>
