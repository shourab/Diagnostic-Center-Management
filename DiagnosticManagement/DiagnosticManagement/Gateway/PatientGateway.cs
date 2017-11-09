using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.Gateway
{[Serializable]
    public class PatientGateway:Gateway
    {
        public List<Patient> GetallTests()
        {
            List<Patient> Patients = new List<Patient>();

            Query = "SELECT * FROM Test";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
              Patient aPatient=new Patient();

                aPatient.TestName = reader["TestName"].ToString();
                aPatient.TestId = Convert.ToInt32(reader["TestId"]);

                Patients.Add(aPatient);
            }
            Connection.Close();
            reader.Close();
            return Patients;
        }

        public Patient GetFeeAndTestNameCorrespondingtoTestId(int testId)
        {
            Query = "SELECT Fee,TestName FROM Test WHERE TestId='"+testId+"'";
           
            Command = new SqlCommand(Query, Connection);
            
            Connection.Open();
           
            Reader = Command.ExecuteReader();

            Patient aPatient = new Patient();
            
            while (Reader.Read())
            {
               
                   aPatient.Fee = Convert.ToDouble(Reader["Fee"]);

                   aPatient.TestName = Reader["TestName"].ToString();
            }
            Connection.Close();
            Reader.Close();
            return aPatient;
        }


        public Patient GetPatientId (string billNo)
        {
            Query = "SELECT PatientId FROM Patient WHERE BillNo='" + billNo + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            Patient aPatient = new Patient();

            while (Reader.Read())
            {

                aPatient.PatientId = (int) Reader["PatientId"];
            }
            Connection.Close();
            Reader.Close();
            return aPatient;
        }


           

        public int SavePatient(Patient aPatient)
        {

            Query = "INSERT INTO Patient VALUES(@patientName,@mobileNo,@dateOfBirth,@totalFee,@dateOfIssue,@billNo,@status)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("patientName", SqlDbType.VarChar);
            Command.Parameters["patientName"].Value = aPatient.PatientName;


            Command.Parameters.Add("mobileNo", SqlDbType.VarChar);
            Command.Parameters["mobileNo"].Value = aPatient.MobileNo;


            Command.Parameters.Add("dateOfBirth", SqlDbType.Date);
            Command.Parameters["dateOfBirth"].Value = aPatient.DateofBirth;


            Command.Parameters.Add("totalFee", SqlDbType.Decimal);
            Command.Parameters["totalFee"].Value = aPatient.TotalFee;


            Command.Parameters.Add("dateOfIssue", SqlDbType.Date);
            Command.Parameters["dateOfIssue"].Value = aPatient.DateofIssue;

            Command.Parameters.Add("billNo", SqlDbType.VarChar);
            Command.Parameters["billNo"].Value = aPatient.BillNo;

            Command.Parameters.Add("status", SqlDbType.VarChar);
            Command.Parameters["status"].Value = aPatient.Status;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }





    public int InsertTestRequest(List<Patient> myPatient1, int patientId)
    {

        int rowAffected = 0;

        if (patientId != 0)
        {
            foreach (Patient aPatient in myPatient1)
            {
                Query = "INSERT INTO TestRequest VALUES(@patientId,@testId)";

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();


                Command.Parameters.Add("patientId", SqlDbType.Int);
                Command.Parameters["patientId"].Value = patientId;


                Command.Parameters.Add("testId", SqlDbType.Int);
                Command.Parameters["testId"].Value = aPatient.TestId;


                Connection.Open();

                int row = Command.ExecuteNonQuery();
                rowAffected = rowAffected + row;

                Connection.Close();

            }

        }

        else
        {
            rowAffected = -9999;
        }

        

        return rowAffected;
    }


    public bool IsMobileNoExists(Patient aPatient)
    {


        Query = "SELECT MobileNo FROM Patient WHERE MobileNo=@mobileNo";

        Command = new SqlCommand(Query, Connection);
        Command.Parameters.Clear();
        Command.Parameters.Add("mobileNo", SqlDbType.VarChar);
        Command.Parameters["mobileNo"].Value = aPatient.MobileNo;
        Connection.Open();

        Reader = Command.ExecuteReader();

        bool mobileNoExists= Reader.HasRows;

        Reader.Close();
        Connection.Close();

        return mobileNoExists;



    }


    }
}