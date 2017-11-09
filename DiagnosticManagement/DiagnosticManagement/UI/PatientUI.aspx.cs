using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticManagement.BLL;
using DiagnosticManagement.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace DiagnosticManagement.UI
{
    [Serializable]
    public partial class PatientUI : System.Web.UI.Page
    {

        PatientManager aPatientManager = new PatientManager();

        Patient aPatient = new Patient();


        protected void Page_Load(object sender, EventArgs e)
        {

            List<Patient> aPatients = aPatientManager.GetallTestName();

            if (!IsPostBack)
            {
                testNameDropDownList.DataSource = aPatients;
                testNameDropDownList.DataTextField = "TestName";
                testNameDropDownList.DataValueField = "TestId";
                testNameDropDownList.DataBind();

               aPatient.TestId = Convert.ToInt32(testNameDropDownList.SelectedValue);
               aPatient.Fee = (aPatientManager.GetFeeCorrespondingtoTest(aPatient.TestId));
                feeTextBox.Text = aPatient.Fee.ToString();

            }


            if (IsPostBack)
            {
               aPatient.TestId = Convert.ToInt32(testNameDropDownList.SelectedValue);
                aPatient.Fee = (aPatientManager.GetFeeCorrespondingtoTest(aPatient.TestId));
                feeTextBox.Text = aPatient.Fee.ToString();
            }

            //______________________________________________________
            //string date = System.DateTime.Today.ToString("ddmmyy");
            //ShowGridViewForPatient();
            //_______________________________________________________

        }


        private void ShowGridViewForPatient1()
        {
            List<Patient> myPatient = GetGridViewListForPatient();
            patientGridView.DataSource = myPatient;
            patientGridView.DataBind();

            //double tempFee = 0;
            //ViewState["TotalFee"] = tempFee;



            //foreach (Patient feePatient in myPatient)
            //{
            //    tempFee = tempFee + feePatient.Fee;
            //}

            //totalFeeTextBox.Text = tempFee.ToString();




        }



        private void ShowGridViewForPatient()
        {
            List<Patient> myPatient = GetGridViewListForPatient();
            patientGridView.DataSource = myPatient;
            patientGridView.DataBind();

            double tempFee = 0;
            ViewState["TotalFee"] = tempFee;

            

            foreach (Patient feePatient in myPatient)
            {
                tempFee = tempFee + feePatient.Fee;
            }

            totalFeeTextBox.Text = tempFee.ToString();




        }




        protected void patientAddButton_Click(object sender, EventArgs e)
        {


            aPatient.TestId = Convert.ToInt32(testNameDropDownList.SelectedValue);
            aPatient.Fee = (aPatientManager.GetFeeCorrespondingtoTest(aPatient.TestId));
            


            
            aPatient.TestName = aPatientManager.GetTestNameCorrespondingtoTest(aPatient.TestId);

            ShowGridViewForPatient();
        }



        protected void testNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
         


        }

        public List<Patient> GetGridViewListForPatient()
        {
            if (ViewState["List"] == null)
            {
                List<Patient> myPatient = new List<Patient>();
                myPatient.Add(aPatient);
                ViewState["List"] = myPatient;
            }
            else
            {
                List<Patient> myPatient = (List<Patient>)ViewState["List"];
                myPatient.Add(aPatient);
                ViewState["List"] = myPatient;

            }

            List<Patient> myPatient1 = (List<Patient>)ViewState["List"];

            return myPatient1;
        }


        public List<Patient> GetGridViewListForPatient1()
        {
            List<Patient> myPatient = new List<Patient>();

            if (ViewState["List"] == null)
            {
                
                myPatient.Add(aPatient);
                ViewState["List"] = myPatient;
            }
            else
            {
                myPatient = (List<Patient>)ViewState["List"];
                myPatient.Add(aPatient);
                ViewState["List"] = myPatient;

            }

            int count = myPatient.Count-1;
            int i = 0;

            List<Patient> myPatient1=new List<Patient>();
            foreach (Patient p in myPatient)
            {
                if (count != i)
                {
                    myPatient1.Add(p);
                }
                    i++;
            }

           /// List<Patient> myPatient1 = (List<Patient>)ViewState["List"];

            return myPatient1;
        }



        


        protected void patientSaveButton_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;


            aPatient.PatientName = patientNameTextBox.Text;
            aPatient.DateofBirth = dateOfBirthTextBox.Text;
            aPatient.MobileNo = mobileNoTextBox.Text;
            aPatient.BillNo = "Bill No-" + localDate.ToString("yyMMddHHmmss");
            aPatient.TotalFee = Convert.ToDouble(totalFeeTextBox.Text);
            aPatient.DateofIssue = date.ToString("yyyy-MM-dd");
            aPatient.Status = "N";



            patientAddButton.Enabled = false;
            patientSaveButton.Enabled = false;

            timeLabel.Text = aPatientManager.SavePatient(aPatient);

            aPatient.PatientId = aPatientManager.GetPatientId(aPatient.BillNo);

            List<Patient> myPatient1 = (List<Patient>)ViewState["List"];

            timeLabel.Text = aPatientManager.InsertTestRequest(myPatient1, aPatient.PatientId);





            //pdf
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter swr = new StringWriter();
            HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
            patientGridView.AllowPaging = false;
            List<Patient> myPatient = GetGridViewListForPatient1();
            patientGridView.DataSource = myPatient;
            patientGridView.DataBind();



            Label10.Text = " " + aPatient.BillNo + "";
            Label7.Text = "NAME : " + patientNameTextBox.Text + "------";
            Label8.Text = "Date of Birth : " + dateOfBirthTextBox.Text + "------";
            Label9.Text = "Mobile Number : " + mobileNoTextBox.Text + "";

            Label11.Text = "_______________________________________________________________________________";
            Label12.Text = " ...................................................................................................Total Fee :" + totalFeeTextBox.Text + "";
            Label13.Text = "Issued Date: " + aPatient.DateofIssue + "........................................................................................\n";


            Label13.RenderControl(htmlwr);
            Label10.RenderControl(htmlwr);
            Label7.RenderControl(htmlwr);
            Label8.RenderControl(htmlwr);
            Label9.RenderControl(htmlwr);
            

            //ShowGridViewForPatient();
            //timeLabel.RenderControl(htmlwr);

            patientGridView.RenderControl(htmlwr);
            Label11.RenderControl(htmlwr);
            Label12.RenderControl(htmlwr);

            patientSaveButton.Enabled = false;

            StringReader srr = new StringReader(swr.ToString());

            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfdoc);
            PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
            pdfdoc.Open();
            htmlparser.Parse(srr);
            pdfdoc.Close();
            Response.Write(pdfdoc);
            Response.End();  


        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

    }

}