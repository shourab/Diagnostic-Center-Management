using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.Gateway
{
    public class PatientGatewaysrb:Gateway
    {
        public List<Patient> GetallUnpainPatient(DateTime fromDate, DateTime toDate)
        {
           
            List<Patient> patients=new List<Patient>();
            Query = "SELECT * FROM Patient WHERE Status='N' AND DateofIssue BETWEEN '"+fromDate+"' AND '"+toDate+"'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                 Patient aPatient=new Patient();
                aPatient.PatientId = (int) reader["PatientId"];
                aPatient.PatientName = reader["PatientName"].ToString();
                aPatient.MobileNo = reader["MobileNo"].ToString();
                aPatient.TotalFee = Convert.ToDouble(reader["TotalFee"]);
                aPatient.DateofIssue = reader["DateofIssue"].ToString();
                aPatient.BillNo = reader["BillNo"].ToString();
                patients.Add(aPatient);
            }
            Connection.Close();
            reader.Close();
            return patients;

        }

        public double GetTotalDue(DateTime fromDate, DateTime toDate)
        {
            double TotalFee = 0;
            Query = "SELECT * FROM Patient WHERE Status='N' AND DateofIssue BETWEEN '" + fromDate + "' AND '" + toDate + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
               
                TotalFee =TotalFee+ Convert.ToDouble(reader["TotalFee"]);    
            }
            Connection.Close();
            reader.Close();
            return TotalFee;
           
        }
    }
}