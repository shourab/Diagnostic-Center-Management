using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticManagement.Gateway;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.BLL
{[Serializable]
    public class PatientManager
    {
        private PatientGateway aPatientGateway = new PatientGateway();

        public List<Patient> GetallTestName()
        {
            List<Patient> patient = aPatientGateway.GetallTests();
            return patient;
        }

        public double GetFeeCorrespondingtoTest(int testId)
        {
            Patient aPatient = aPatientGateway.GetFeeAndTestNameCorrespondingtoTestId(testId);
            return aPatient.Fee;
        }

        public string GetTestNameCorrespondingtoTest(int testId)
        {
            Patient aPatient = aPatientGateway.GetFeeAndTestNameCorrespondingtoTestId(testId);
            return aPatient.TestName;
        }


        public int GetPatientId(string billNo)
        {
            Patient aPatient = aPatientGateway.GetPatientId(billNo);
            return aPatient.PatientId;
        }

        
        public string SavePatient(Patient aPatient)
        {
            bool mobileNoExists = aPatientGateway.IsMobileNoExists(aPatient);


            if (mobileNoExists == true)
            {
                return "Mobile No Already Exists.Try It With a New One";
            }

            else
            {
                int rowAffected = aPatientGateway.SavePatient(aPatient);

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

        

    public string InsertTestRequest(List<Patient> myPatient1, int patientId)
    {
       
       
        
            string message = "Data insertion Failed";

            int rowAffected = aPatientGateway.InsertTestRequest(myPatient1, patientId);

            if (rowAffected > 0)
            {
                message = rowAffected + " Row Affected Successfully";
            }

            else if (rowAffected == -9999)
            {
                message = "Mobile Number Already Exist.Try It With a New One";
            }

            return message;
        }
      
    }
    }




