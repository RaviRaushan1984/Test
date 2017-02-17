using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ContactManagement_Entities.Contact;
using ContactManagement_BAL.Contact;
using System.Net.Mail;
using System.Configuration;

namespace ContactManagement_UI
{
    public partial class contactList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Generic.UserProfile.IsSessionValid())
                return;

            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                List<ContactDetails> contactList = (new ContactDetails_BAL()).Select(new ContactDetails() { LoggedInUser = Convert.ToInt32(Session["UserId"]) });
                g1.DataSource = contactList;
                g1.DataBind();
            }

        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)g1.HeaderRow.FindControl("chkboxSelectAll");
            foreach (GridViewRow row in g1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkEmp");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void btnsendmail_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            List<string> invalidEmailList = new List<string>();

            foreach (GridViewRow row in g1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkEmp") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string lblID = (row.Cells[2].FindControl("lblID") as Label).Text;
                        string lblName = (row.Cells[2].FindControl("lblName") as Label).Text;
                        string lblOfficeEmail = "arvind.mishra@dionglobal.com";//(row.Cells[2].FindControl("lblOfficeEmail") as Label).Text;
                        string strfrom = "vicky.gupta@dionglobal.com";
                        string strAttachmentFile = "textattachment";
                        string strSubject = "Request to update contact details";

                        string strFullBody = "";

                        string uid = Generic.UIHelper.Encrypt(Session["UserId"].ToString(), Generic.UIHelper.Key);
                        string cid = Generic.UIHelper.Encrypt(lblID, Generic.UIHelper.Key);

                        string url = "http://" + Request["HTTP_HOST"] + "/contactLandingPage.aspx?uid=" + uid + "&cid=" + cid + "&";
                        strFullBody = "Dear " + lblName + "," +
                                        "<br /><br />Please update your contact details by clicking on below mentioned link. </br> URL:</br> " + url + "<br /><br /><b>Regards,</b>" +
                                        "<br /><b>" + Session["UserName"].ToString().Replace('.', ' ') + "</b>" + "";
                        bool result = false;

                        if (Generic.UIHelper.IsEmail(lblOfficeEmail))
                            result = Generic.UIHelper.MailFunction(lblOfficeEmail, strfrom, strSubject, strAttachmentFile, HttpUtility.HtmlEncode(strFullBody));
                        else
                            invalidEmailList.Add(lblOfficeEmail);
                    }
                }
            }

            if (invalidEmailList.Count > 0)
            {
                errorMessageDiv.InnerText = "Invalid email(s):" + string.Join(",", invalidEmailList.ToArray());
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Email has sent successfully, below are invalid emails.');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Email has sent successfully!');", true);
        }
    }
}