using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticManagement.Model;
using DiagnosticManagement.UI;

namespace DiagnosticManagement.Gateway
{[Serializable]
    public class TestGateway:Gateway
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


        public int SaveTest(Test aTest)
        {

            Query = "INSERT INTO Test (TestName,Fee,TestTypeId) VALUES('"+aTest.TestName+"','"+aTest.Fee+"','"+aTest.TestTypeId+"')";

            Command = new SqlCommand(Query, Connection);



            //Command.Parameters.Clear();
            //Command.Parameters.Add("testName", SqlDbType.VarChar);
            //Command.Parameters["testName"].Value = aTest.TestName;
            //Command.Parameters.Add("fee", SqlDbType.Decimal);
            //Command.Parameters["fee"].Value = aTest.Fee;
            //Command.Parameters.Add("testTypeId", SqlDbType.Int);
            //Command.Parameters["testTypeId"].Value = aTest.TestTypeId;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }



        public List<Test> GetallTests()
        {
            List<Test> tests=new List<Test>();
            
            Query = "SELECT * FROM TestType ORDER BY TestTypeName ";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Test test=new Test();
                test.TestType = reader["TestTypeName"].ToString();
                test.TestTypeId = (int) reader["TestTypeId"];
                tests.Add(test);
            }
            Connection.Close();
            reader.Close();
            return tests;
        }


        public List<Test>GetGridViewListForTest()
        {
            List<Test> tests = new List<Test>();

            Query = "SELECT TestName,Fee,TestTypeName FROM TEST INNER JOIN TestType ON Test.TestTypeId=TestType.TestTypeId ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Test test = new Test();
                
                test.TestName = reader["TestName"].ToString();
                test.Fee =Convert.ToDouble(reader["Fee"]);
                test.TestType = reader["TestTypeName"].ToString();
                tests.Add(test);
            }
            Connection.Close();
            reader.Close();
            return tests;
        }





        public bool IsTestTypeExists(Test aTest)
        {
            

            Query = "SELECT TestTypeName FROM TestType WHERE TestTypeName=@testTypeName";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("testTypeName", SqlDbType.VarChar);
            Command.Parameters["testTypeName"].Value =aTest.TestType ;
            Connection.Open();

            Reader = Command.ExecuteReader();

            bool testTypeExists = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return testTypeExists;



        }

        public bool IsTestExists(Test aTest)
        {


            Query = "SELECT TestName FROM Test WHERE TestName=@testName";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("testName", SqlDbType.VarChar);
            Command.Parameters["testName"].Value = aTest.TestName;
            Connection.Open();

            Reader = Command.ExecuteReader();

            bool testTypeExists = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return testTypeExists;



        }


        public Test GetAllTestType()
        {
           

            Query = "SELECT TestTypeName FROM TestType ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Test test = new Test();
            while (reader.Read())
            {
                
                test.TestType = reader["TestTypeName"].ToString();


                
            }
            Connection.Close();
            reader.Close();
            return test;
        }


       




    }
}