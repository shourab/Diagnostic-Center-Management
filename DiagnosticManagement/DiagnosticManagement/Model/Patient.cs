using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticManagement.Model
{
    [Serializable]
    public class Patient:Test
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public  string DateofBirth { get; set; }
        public  double TotalFee { get; set; }
        public  string DateofIssue { get; set; }
        public  string BillNo { get; set; }
        public  string Status { get; set; }


        

    }
}