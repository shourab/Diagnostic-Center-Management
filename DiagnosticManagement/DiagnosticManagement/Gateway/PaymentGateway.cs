using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticManagement.DAL.Model;

namespace DiagnosticManagement.DAL.Gateway
{
    public class PaymentGateway:DiagnosticManagement.Gateway.Gateway
    {
        public Payment SearchWithAmountOrDueDate(string column, string searchWith)
        {
            //string connectionString = "Server=GAMIR; Database=DiagonosicDB;Integrated Security=true";
           
            //SqlConnection connection = new SqlConnection(connectionString);

            Query = "SELECT * FROM Patient WHERE "+column+" = '"+searchWith+"'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Payment aPayment=new Payment();
            while (reader.Read())
            {
                aPayment.BillNo = reader["BillNo"].ToString();
                aPayment.MobileNo = reader["MobileNo"].ToString();
                aPayment.Amount = Convert.ToDouble(reader["TotalFee"]);
                aPayment.DueDate = reader["DateOfIssue"].ToString();
                aPayment.Status = reader["Status"].ToString();
                aPayment.PatientId = (int) reader["PatientId"];
            }

            reader.Close();
            Connection.Close();
            return aPayment;
        }

        public int Pay(int patientId)
        {
            int rowAffected = 0;
            //string connectionString = "Server=GAMIR; Database=DiagonosicDB;Integrated Security=true";
            //SqlConnection connection = new SqlConnection(connectionString);

            Query = "UPDATE Patient SET Status = 'Y' WHERE PatientId = '" + patientId + "'";
            SqlCommand command = new SqlCommand(Query, Connection);
            Connection.Open();

            rowAffected = command.ExecuteNonQuery();
            Connection.Close();
            
            return rowAffected;
        }
    }
}