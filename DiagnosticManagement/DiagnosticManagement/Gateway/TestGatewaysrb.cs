using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.Gateway
{
    public class TestGatewaysrb:Gateway
    {
       
        public int SaveTestType(Test aTest)
        {

            Query = "INSERT INTO TestType VALUES(@name)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aTest.TestType;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
        //end of save test Type
        public int SaveTest(Test aTest)
        {
            
            Query = "INSERT INTO Test VALUES ('"+aTest.TestName+"','"+aTest.TestTypeId+"','"+aTest.Fee+"')";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            
           
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }
        //end of save Test
        public List<Test> GetallTestType()
        {
            Query = "SELECT* FROM TestType";
            List<Test> tests=new List<Test>();
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
               Test aTest=new Test();
                aTest.TestTypeId =(int) reader["TestTypeId"];
                aTest.TestType = reader["TestTypeName"].ToString();
                tests.Add(aTest);

            }
            reader.Close();
            Connection.Close();
            return tests;
            

        }

       
        //end of get all test type
        public List<Test> GetallTest()
        {
            Query = "SELECT * FROM Test INNER JOIN TestType ON Test.TestTypeId=TestType.TestTypeId Order by Test.TestName ";
            List<Test> tests=new List<Test>();
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Test aTest=new Test();
                aTest.TestName = reader["TestName"].ToString();
                aTest.Fee = Convert.ToDouble(reader["Fee"]);
                aTest.TestType = reader["TestTypeName"].ToString();
                tests.Add(aTest);
            }
            Connection.Close();
            reader.Close();
            return tests;
        }
        //end of Get all Test
        //public string GetrequiredType(int typeId)
        //{
        //    Query = "SELECT* FROM TestType WHERE TestTypeId='" + typeId + "'";
        //    Command=new SqlCommand(Query,Connection);
        //     Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    string typeName = reader["TestTypeName"].ToString();
        //    Connection.Close();
        //    reader.Close();
        //    return typeName;
        //}

        public List<Test> GetallTestsType()
        {
            List<Test> tests=new List<Test>();
            
            Query = "SELECT * FROM TestType";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Test test=new Test();
                test.TestType= reader["TestTypeName"].ToString();
                tests.Add(test);
            }
            Connection.Close();
            reader.Close();
            return tests;
        } 
        //EndEventHandler of get all tests
        public bool IsUniqueTest(string name)
        {
            Query = "SELECT* FROM Test WHERE TestName='" + name + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                Connection.Close();
                reader.Close();
                return true;
            }
            else
            {
                Connection.Close();
                reader.Close();
                return false;
            }

        }
        
       //code for story 5
        public List<Testsearch> SearchallTest(DateTime fromDate,DateTime toDate)
        {
            Query = "SELECT SUM(Fee) AS Total,COUNT(*) AS TotalTest,TestName  FROM TestWithPatient WHERE  DateofIssue BETWEEN '"+fromDate+"' AND '"+toDate+"'  GROUP BY TestName";
            Command=new SqlCommand(Query,Connection);
            List<Testsearch> testSearch =new List<Testsearch>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
               Testsearch aTestsearch=new Testsearch();
                aTestsearch.TestName = reader["TestName"].ToString();
                aTestsearch.TotalTest = (int) reader["TotalTest"];
                aTestsearch.TotalFee = Convert.ToDouble(reader["Total"]);
                testSearch.Add(aTestsearch);
            }
            Connection.Close();
            reader.Close();
            return testSearch;
        } 
        //end of search by test Name
        public double GetToatalinStory5(DateTime fromDate, DateTime toDate)
        {
            double Total = 0;
            Query = "SELECT SUM(Fee) AS Total,COUNT(*) AS TotalTest,TestName  FROM TestWithPatient WHERE  DateofIssue BETWEEN '" + fromDate + "' AND '" + toDate + "'  GROUP BY TestName";
            Command = new SqlCommand(Query, Connection);
            
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Total = Total + Convert.ToDouble(reader["Total"]);
            }
            Connection.Close();
            reader.Close();
            return Total;
        }
        //code for story 6
        public List<Testsearch> SearchallTestType(DateTime fromDate, DateTime toDate)
        {
            Query = "SELECT SUM(Fee) AS Total,COUNT(*) AS TotalTest,TestTypeName  FROM TESTwithPatientandType WHERE  DateofIssue BETWEEN '"+fromDate+"' AND '"+toDate+"'  GROUP BY TestTypeName";
            Command = new SqlCommand(Query, Connection);
            List<Testsearch> testSearch = new List<Testsearch>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Testsearch aTestsearch = new Testsearch();
             
                aTestsearch.TestType = reader["TestTypeName"].ToString();
                if (reader["TotalTest"] == null)
                {
                    aTestsearch.TotalTest = 0;
                }
                else
                {
                    aTestsearch.TotalTest = (int)reader["TotalTest"];
                }
                
                aTestsearch.TotalFee = Convert.ToDouble(reader["Total"]);
                testSearch.Add(aTestsearch);
            }
            Connection.Close();
            reader.Close();
            return testSearch;
        }

        public double GetToatalinStory6(DateTime fromDate, DateTime toDate)
        {
            double Total = 0;
            Query = Query = "SELECT SUM(Fee) AS Total,COUNT(*) AS TotalTest,TestTypeName  FROM TESTwithPatientandType WHERE  DateofIssue BETWEEN '" + fromDate + "' AND '" + toDate + "'  GROUP BY TestTypeName";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Total = Total + Convert.ToDouble(reader["Total"]);
            }
            Connection.Close();
            reader.Close();
            return Total;
        }
    }
}