using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticManagement.BLL;
using DiagnosticManagement.Gateway;
using DiagnosticManagement.Model;

namespace DiagnosticManagement.UI
{
    public partial class TestSetuoUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TestManagersrb _aTestManagersrb = new TestManagersrb();
                List<Test> teststype = _aTestManagersrb.GetallTestType();
                typeDropDownList.DataSource = teststype;
                typeDropDownList.DataTextField = "TestType";
                typeDropDownList.DataValueField = "TestTypeId";
                typeDropDownList.DataBind();
                List<Test> tests = _aTestManagersrb.GetallTest();
                setupGridView.DataSource = tests;
                setupGridView.DataBind();

            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestManagersrb _aTestManagersrb = new TestManagersrb();
            Test aTest=new Test();
            aTest.TestName=testNameTextBox.Text;
            aTest.Fee = Convert.ToDouble(feeTextBox.Text);
            aTest.TestTypeId = Convert.ToInt32(typeDropDownList.SelectedValue);
            messageLabel.Text = _aTestManagersrb.SaveTest(aTest);

           

            List<Test> tests = _aTestManagersrb.GetallTest();
            setupGridView.DataSource = tests;
            setupGridView.DataBind();
            testNameTextBox.Text=String.Empty;
            feeTextBox.Text=String.Empty;
        }
    }
}