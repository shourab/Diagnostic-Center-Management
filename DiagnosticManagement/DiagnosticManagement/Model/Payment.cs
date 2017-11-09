using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticManagement.DAL.Model
{
    public class Payment
    {
        public string BillNo { get; set; }
        public string MobileNo { get; set; }

        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public string DueDate { get; set; }

        public string Status { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }

        public double Fee { get; set; }
        public int TotalTest { get; set; }
    }
}