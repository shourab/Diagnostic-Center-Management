using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticManagement.Gateway;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.BLL
{[Serializable]
    public class TestManager
    {
        TestGateway atestGateway=new TestGateway();
        public string SaveTestType(Test aTest)
        {
            bool typeExists = atestGateway.IsTestTypeExists(aTest);

            if (typeExists == true)
            {
                return "Test Type Already Exists.Try It With a New One";
            }

            else
            {
                int rowAffected = atestGateway.SaveTestType(aTest);
                if (rowAffected > 0)
                {
                    return "Successfully Saved";
                }
                else
                {
                    return "Not SuccessFully Saved";
                } 
            }
                }


        public string SaveTest(Test aTest)
        {
            bool typeExists = atestGateway.IsTestExists(aTest);

            if (typeExists == true)
            {
                return "Test Name Already Exists.Try It With a New One";
            }

            else
            {
                int rowAffected = atestGateway.SaveTest(aTest);

                if (rowAffected > 0)
                {
                    return "Successfully Saved";
                }
                else
                {
                    return "Not SuccessFully Saved";
                }
            }
        }





        public List<Test> GetallTestType()
        {
            List<Test> tests = atestGateway.GetallTests();
            return tests;
        }


        public List<Test> GetGridViewListForTest()

        {
            List<Test> tests = atestGateway.GetGridViewListForTest();
            return tests;
        }







    }
}