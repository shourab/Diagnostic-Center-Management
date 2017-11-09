using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticManagement.Gateway;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.BLL
{
    public class PatientManagersrb
    {
        public List<Patient> GetallUnpaidPatients(DateTime fromDate,DateTime toDate)
        {
            PatientGatewaysrb aPatientGatewaysrb=new PatientGatewaysrb();
            List<Patient> patients= aPatientGatewaysrb.GetallUnpainPatient(fromDate,toDate);
            if (patients.Count == 0)
            {
                Patient aPatient=new Patient();
                aPatient.BillNo = "N/A";
                aPatient.MobileNo = "N/A";
                aPatient.PatientName = "N/A";
                aPatient.TotalFee = 0;
                patients.Add(aPatient);
                return patients;
            }
            else
            {
                return patients;
            }
        }

        public double GetTotalDue(DateTime fromDate, DateTime toDate)
        {
             PatientGatewaysrb aPatientGatewaysrb=new PatientGatewaysrb();
            return aPatientGatewaysrb.GetTotalDue(fromDate, toDate);
        }
    }
}