using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticManagement.Model
{
    [Serializable]
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int TestTypeId { get; set; }
        public string TestType { get; set; }
        public double Fee { get; set; }

        public string TestTypeName { get; set; }
    }
}