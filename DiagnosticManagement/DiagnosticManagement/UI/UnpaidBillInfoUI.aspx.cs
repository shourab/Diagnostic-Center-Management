using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticManagement.BLL;
using DiagnosticManagement.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using iTextSharp.text.html;

namespace DiagnosticManagement.UI
{
    public partial class UnpaidBillInfoUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    GetGridview();
            //}
        }

        private void GetGridview()
        {


            DateTime fromDate = DateTime.ParseExact(fromDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(toDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            PatientManagersrb aPatientManagersrb = new PatientManagersrb();
            
            List<Patient> patients = aPatientManagersrb.GetallUnpaidPatients(fromDate,toDate);
            unpaidGridView.DataSource = patients;
            unpaidGridView.DataBind();
            messageLabel.Text = "LIST OF UN PAID PATIENT";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
          
            if (fromDateTextBox.Text == "" || toDateTextBox.Text == "")
            {
                messageLabel.Text = "You Have to Select the Dates";
            }
            else
            {
                pdfButton.Visible = true;
                Label2.Visible = true;
                totalTextBox.Visible = true;
                   DateTime fromDate = DateTime.ParseExact(fromDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(toDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            PatientManagersrb aPatientManagersrb=new PatientManagersrb();
            List<Patient> patients = aPatientManagersrb.GetallUnpaidPatients(fromDate,toDate);
            unpaidGridView.DataSource = patients;
            unpaidGridView.DataBind();
            double total = Convert.ToDouble(aPatientManagersrb.GetTotalDue(fromDate, toDate));
            totalTextBox.Text = total.ToString();
            }
         
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter swr = new StringWriter();
            HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
            unpaidGridView.AllowPaging = false;
            GetGridview();
           messageLabel.RenderControl(htmlwr);
            
            unpaidGridView.RenderControl(htmlwr);
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