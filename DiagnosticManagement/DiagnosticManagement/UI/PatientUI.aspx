<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientUI.aspx.cs" Inherits="DiagnosticManagement.UI.PatientUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Request</title>
    
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
</head>
<body>
<div style="background: lightblue; width: 960px; margin: 0 auto;">
<div style="background: lightblue; width: 500px; margin: 0 auto;">
    <h1 style="color: green;text-align: center">Test Request</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Name of Patient"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="patientNameTextBox" runat="server" Width="189px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="DateOfBirth"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dateOfBirthTextBox" runat="server" Width="189px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Mobile No"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="mobileNoTextBox" runat="server" Width="190px"></asp:TextBox>

        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Select Test"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="testNameDropDownList" runat="server" Height="29px" Width="197px" OnSelectedIndexChanged="testNameDropDownList_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Fee"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="feeTextBox" runat="server" Enabled="False" Width="96px" style="margin-left: 3px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="patientAddButton" runat="server" Text="Add" OnClick="patientAddButton_Click" />
        <br />
        <br />
        <asp:GridView ID="patientGridView" runat="server" AutoGenerateColumns="False" Width="355px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            
             
            
            <AlternatingRowStyle BackColor="#DCDCDC" />
            
             
            
            <Columns>
             <asp:TemplateField HeaderText="Sr No" >
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
                
                    <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
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
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Total"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="totalFeeTextBox" runat="server" Width="69px" Enabled="False"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="patientSaveButton" runat="server" Text="Save" OnClick="patientSaveButton_Click" />
        <br />
        <br />
        <br />
        <br />
    
        <a href="PatientUI.aspx">For New Patient</a>
        <br />
        <asp:Label ID="timeLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
        <br />
    
    </div>
    </form>
    </div>
    </div>
     <div style="width: 640px;margin: 0 auto"><br/>
        <a href="IndexUI.aspx"style="border-radius: 35px; text-decoration: none; width: 300px; height: 100px; background: green; color: white; display: inline-block; text-align: center; font-size: 40px;" >Back To Start page</a>
        <a href="PaymentUI.aspx"style="border-radius: 35px; text-decoration: none; width: 300px; height: 100px; background: green; color: white; display: inline-block; text-align: center; font-size: 40px;" >Go to payment page</a>    
        
    </div>
    
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
    
    
    <script>
        $(document).ready(function () {
            $("#dateOfBirthTextBox").datepicker({
                changeMonth: true,
                changeYear: true
            });
        })

    </script>
</body>
</html>
