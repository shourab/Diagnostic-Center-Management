using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticManagement.DAL.Gateway;
using DiagnosticManagement.DAL.Model;

namespace DiagnosticManagement.BLL
{
    public class PaymentManager
    {
        public Payment SearchWithAmountOrDueDate(string column, string searchWith)
        {
            PaymentGateway aPaymentGateway=new PaymentGateway();
            Payment aPayment=new Payment();
            aPayment = aPaymentGateway.SearchWithAmountOrDueDate(column,searchWith);
            

            return aPayment;
        }

        public string Pay(int patientId)
        {
            string message = "Database Update Failed";
            PaymentGateway aPaymentGateway=new PaymentGateway();
            int rowAffected = aPaymentGateway.Pay(patientId);

            if (rowAffected > 0)
            {
                message = "Payment Successful";
            }

            return message;
        }
    }
}