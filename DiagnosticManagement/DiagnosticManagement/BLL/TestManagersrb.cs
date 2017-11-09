using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticManagement.Gateway;
using DiagnosticManagement.Model;
using iTextSharp.text;

namespace DiagnosticManagement.BLL
{
    public class TestManagersrb
    {
        TestGatewaysrb _atestGatewaysrb=new TestGatewaysrb();
        public string SaveTestType(Test aTest)
        {
            int rowAffected = _atestGatewaysrb.SaveTestType(aTest);
            if (rowAffected>0)
            {
                return "Successfully Saved";
            }
            else
            {
                return "Not SuccessFully Saved";
            }
        }
        //end of save test type
        public string SaveTest(Test aTest)
        {
            if (_atestGatewaysrb.IsUniqueTest(aTest.TestName))
            {
                return "Test NAme is Already Exist";
            }
            else
            {
                int rowAffected = _atestGatewaysrb.SaveTest(aTest);
                return "Save SuccessFully";
            }
           
           
        }
        public List<Test> GetallTestType()
        {
            return _atestGatewaysrb.GetallTestType();
        }

        public List<Test> GetallTest()
        {
            return _atestGatewaysrb.GetallTest();
        }
        //end of get all test

        public List<Test> GetallTests()
        {
            List<Test> tests = _atestGatewaysrb.GetallTestsType();
            return tests;
        }

        //code for story 5
        public List<Testsearch> SearchallTest(DateTime fromDate,DateTime toDate)
        {
            List<Testsearch> tests= _atestGatewaysrb.SearchallTest(fromDate, toDate);
            if (tests.Count == 0)
            {
                Testsearch aTestsearch = new Testsearch();
                aTestsearch.TestName = "0";
                aTestsearch.TotalTest = 0;
                aTestsearch.TotalFee = 0;
                tests.Add(aTestsearch);
                return tests;
            }
            else
            {
                return tests;
            }
        }

        public double GetTotalinStory5(DateTime fromDate, DateTime toDate)
        {
            return _atestGatewaysrb.GetToatalinStory5(fromDate, toDate);
        }
        //code for story 6
        public List<Testsearch> SearchallTestType(DateTime fromDate, DateTime toDate)
        {
            List<Testsearch> testtypes= _atestGatewaysrb.SearchallTestType(fromDate, toDate);
            if (testtypes.Count==0)
            {
                Testsearch aTestsearch=new Testsearch();
                aTestsearch.TestType = "0";
                aTestsearch.TotalTest = 0;
                aTestsearch.TotalFee = 0;
                testtypes.Add(aTestsearch);
                return testtypes;
            }
            else
            {
                return testtypes;
            }
        }
        public double GetTotalinStory6(DateTime fromDate, DateTime toDate)
        {
            return _atestGatewaysrb.GetToatalinStory6(fromDate, toDate);
        }
    }
}