using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class TypewiseReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadResultGridview()
        {
            DateTime fromdate = DateTime.ParseExact(fromTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(toTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            TestManagersrb _aTestManagersrb = new TestManagersrb();
            List<Testsearch> allTests = _aTestManagersrb.SearchallTestType(fromdate, toDate);
            resultGridView.DataSource = allTests;
            resultGridView.DataBind();
            messageLabel.Text = "TYPE WISE Report FROM "+fromTextBox.Text+" TO "+toTextBox.Text+"";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
          
          
            if (fromTextBox.Text==""||toTextBox.Text=="")
            {
                messageLabel.Text = "You have to input The Dates";
            }
            else
            {
                totalTextBox.Visible = true;
                pdfButton.Visible = true;
                totalLabel.Visible = true;
                DateTime fromdate = DateTime.ParseExact(fromTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(toTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                TestManagersrb _aTestManagersrb = new TestManagersrb();
                List<Testsearch> allTests = _aTestManagersrb.SearchallTestType(fromdate, toDate);
                resultGridView.DataSource = allTests;
                resultGridView.DataBind();
                totalTextBox.Text = _aTestManagersrb.GetTotalinStory6(fromdate, toDate).ToString();
            }
           
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter swr = new StringWriter();
            HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
            resultGridView.AllowPaging = false;
            LoadResultGridview();
            messageLabel.RenderControl(htmlwr);
            resultGridView.RenderControl(htmlwr);
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