using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticManagement.BLL;
using DiagnosticManagement.DAL.Model;

namespace DiagnosticManagement.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Payment aPayment=new Payment();

            aPayment.BillNo = billNoTextBox.Text;
            aPayment.MobileNo = mobileNoTextBox.Text;

            string column = "";
            string searchWith = "";

            PaymentManager aPaymentManager=new PaymentManager();

            payButton.Enabled = false;
            messageLabel.Text = "";
            if (!string.IsNullOrWhiteSpace(billNoTextBox.Text))
            {
                column = "BillNo";
                searchWith = aPayment.BillNo;
                aPayment = aPaymentManager.SearchWithAmountOrDueDate(column, searchWith);    
                
                PaymentClearance(aPayment);
                
            }
                
            else if (!string.IsNullOrWhiteSpace(mobileNoTextBox.Text))
            {
                column = "MobileNO";
                searchWith = aPayment.MobileNo;
                aPayment = aPaymentManager.SearchWithAmountOrDueDate(column, searchWith);

                PaymentClearance(aPayment);
                
            }

            else
            {
                messageLabel.Text = "Enter DueDate or Mobile No....";
            }
        }

        private void PaymentClearance(Payment aPayment)
        {
            billNoTextBox.Text = aPayment.BillNo;
            mobileNoTextBox.Text = aPayment.MobileNo;
            amountTextBox.Text = aPayment.Amount.ToString();
            dueDateTextBox.Text = aPayment.DueDate;
            idHiddenField.Value = aPayment.PatientId.ToString();

            if (aPayment.Status == "Y")
            {
                statusLabel.Text = "Paid";
                payButton.Enabled = false;
            }

            else if (aPayment.Status == "N")
            {
                statusLabel.Text = "Unpaid";
                payButton.Enabled = true;
            }
            else
            {
                statusLabel.Text = "";
                payButton.Enabled = false;
            }


            if (aPayment.BillNo == null)
            {
                messageLabel.Text = "No similiar data in database";
                payButton.Enabled = false;
            }
        }



        protected void payButton_Click(object sender, EventArgs e)
        {
            PaymentManager aPaymentManager=new PaymentManager();
            messageLabel.Text = "";
            if (statusLabel.Text == "Unpaid")
            {
                messageLabel.Text = aPaymentManager.Pay(Convert.ToInt32(idHiddenField.Value));
                statusLabel.Text = "Paid";
                payButton.Enabled = false;
            }

            else if (idHiddenField.Value == "0")
            {
                messageLabel.Text = "Ki Dustomi Cholce";
                payButton.Enabled = false;
            }
            else
            {
                messageLabel.Text = "Customer Already Paid The Cash";
            }
        }
    }
}