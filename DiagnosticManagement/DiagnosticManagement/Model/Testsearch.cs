using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticManagement.Model
{
    public class Testsearch
    {
        public string TestName { get; set; }
        public int TotalTest { get; set; }
        public string TestType { get; set; }
        public double TotalFee { get; set; }
    }
}