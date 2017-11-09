using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticManagement.BLL;
using DiagnosticManagement.Model;

namespace DiagnosticManagement
{
    public partial class TestTypeUI : System.Web.UI.Page
    {
        TestManager aTestManager=new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetallTypesName();
        }

        private void GetallTypesName()
        {
            List<Test> tests = aTestManager.GetallTestType();

            testTypeGridView.DataSource = tests;
            testTypeGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Test aTest=new Test();
            aTest.TestType = typeTextBox.Text;
            messageLabel.Text = aTestManager.SaveTestType(aTest);
            GetallTypesName();
        }

        protected void testTypeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}