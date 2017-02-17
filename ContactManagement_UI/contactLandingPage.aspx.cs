using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContactManagement_Entities.Contact;
using ContactManagement_BAL.Contact;
using ContactManagement_BAL.Masters;
using ContactManagement_Entities.Common;
using System.Data;

namespace ContactManagement_UI
{
    public partial class contactLandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Request.QueryString["uid"]) || string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                errMsgLbl.Visible = true;
                editContainer.Visible = false;
                errMsgLbl.Text = "Oops! This link has expired or you are entering wrong URL. Please check.";
            }

            if (!IsPostBack)
                ValidateURL();

        }

        public void ValidateURL()
        {
            try
            {
                ContactDetails contDetails = (new ContactDetails_BAL()).SingleSelect(Convert.ToInt32(Generic.UIHelper.Decrypt(Request.QueryString["cid"], Generic.UIHelper.Key)));
                if (contDetails == null)
                {
                    errMsgLbl.Visible = true;
                    editContainer.Visible = false;
                    errMsgLbl.Text = "Oops! This link has expired or you are entering wrong URL. Please check.";
                }
                else
                {
                    editContainer.Visible = true;
                    titleDropDown.SelectedValue = contDetails.Title;
                    fname.Text = contDetails.FirstName;
                    mname.Text = contDetails.MiddleName;
                    lname.Text = contDetails.LastName;
                    desgination.Text = contDetails.Desgination;
                    company.Text = contDetails.Company;
                    mobile.Text = contDetails.Mobile;
                    homePhone.Text = contDetails.HomePhone;
                    officePhone.Text = contDetails.HomePhone;
                    fax.Text = contDetails.Fax;
                    officeEmail.Text = contDetails.OfficeEmail;
                    personalEmail.Text = contDetails.PersonalEmail;
                    website.Text = contDetails.Website;
                    industryType.Text = contDetails.IndustryType;
                    Address1Id.Value = contDetails.AddressId1.ToString();
                    address1_line1.Text = contDetails.Address1_Line1;
                    address1_line2.Text = contDetails.Address1_Line2;
                    address1_line3.Text = contDetails.Address1_Line3;
                    address1_country.DataSource = (new Country_BAL()).Select(null);
                    address1_country.DataBind();
                    address1_country.SelectedValue = contDetails.Address1_Country;

                    if (!string.IsNullOrEmpty(contDetails.Address1_Country))
                        address1_state.DataSource = (new State_BAL()).Select(new ContactManagement_Entities.Masters.State() { CountryId = Convert.ToInt32(contDetails.Address1_Country) });
                    else
                        address1_state.DataSource = (new State_BAL()).Select(null);
                    address1_state.DataBind();
                    address1_state.SelectedValue = contDetails.Address1_State;

                    if (!string.IsNullOrEmpty(contDetails.Address1_State))
                        address1_city.DataSource = (new City_BAL()).Select(new ContactManagement_Entities.Masters.City() { StateId = Convert.ToInt32(contDetails.Address1_State) });
                    else
                        address1_city.DataSource = (new City_BAL()).Select(null);
                    address1_city.DataBind();
                    address1_city.SelectedValue = contDetails.Address1_City;

                    address1_pincode.Text = contDetails.Address1_PinCode;

                    Address2Id.Value = contDetails.AddressId2.ToString();
                    address2_line1.Text = contDetails.Address2_Line1;
                    address2_line2.Text = contDetails.Address2_Line2;
                    address2_line3.Text = contDetails.Address2_Line3;

                    address2_country.DataSource = (new Country_BAL()).Select(null);
                    address2_country.DataBind();
                    address2_country.SelectedValue = contDetails.Address2_Country;

                    if (!string.IsNullOrEmpty(contDetails.Address2_Country))
                        address2_state.DataSource = (new State_BAL()).Select(new ContactManagement_Entities.Masters.State() { CountryId = Convert.ToInt32(contDetails.Address2_Country) });
                    else
                        address2_state.DataSource = (new State_BAL()).Select(null);
                    address2_state.DataBind();
                    address2_state.SelectedValue = contDetails.Address2_State;

                    if (!string.IsNullOrEmpty(contDetails.Address2_State))
                        address2_city.DataSource = (new City_BAL()).Select(new ContactManagement_Entities.Masters.City() { StateId = Convert.ToInt32(contDetails.Address2_State) });
                    else
                        address2_city.DataSource = (new City_BAL()).Select(null);
                    address2_city.DataBind();
                    address2_city.SelectedValue = contDetails.Address2_City;

                    address2_pincode.Text = contDetails.Address2_PinCode;
                    activeStatusRadio.Checked = contDetails.IsActive;
                    inactiveStatusRadio.Checked = !activeStatusRadio.Checked;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            ContactDetails contactDetailsObj = new ContactDetails()
            {
                ContactId = string.IsNullOrEmpty(Request.QueryString["cid"]) ? 0 : Convert.ToInt32(Generic.UIHelper.Decrypt(Request.QueryString["cid"], Generic.UIHelper.Key)),
                LoggedInUser = Convert.ToInt32(Generic.UIHelper.Decrypt(Request.QueryString["uid"], Generic.UIHelper.Key)),
                Title = titleDropDown.SelectedValue,
                FirstName = fname.Text,
                MiddleName = mname.Text,
                LastName = lname.Text,
                Desgination = desgination.Text,
                Company = company.Text,
                Mobile = mobile.Text,
                HomePhone = homePhone.Text,
                OfficePhone = officePhone.Text,
                Fax = fax.Text,
                OfficeEmail = officeEmail.Text,
                Owner = Generic.UIHelper.Decrypt(Request.QueryString["uid"], Generic.UIHelper.Key),
                PersonalEmail = personalEmail.Text,
                Website = website.Text,
                IndustryType = industryType.Text,
                IsActive = activeStatusRadio.Checked,
                ModifiedBy = Convert.ToInt32(Generic.UIHelper.Decrypt(Request.QueryString["uid"], Generic.UIHelper.Key)),
            };
            DataRow drRow1 = contactDetailsObj.AddressTypeTable.NewRow();

            if (!string.IsNullOrEmpty(Address1Id.Value))
                drRow1["Address_Id"] = Address1Id.Value;
            else
                drRow1["Address_Id"] = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                drRow1["Contact_Id"] = Generic.UIHelper.Decrypt(Request.QueryString["cid"], Generic.UIHelper.Key);
            else
                drRow1["Contact_Id"] = 0;

            drRow1["Address_Line_1"] = address1_line1.Text;
            drRow1["Address_Line_2"] = address1_line2.Text;
            drRow1["Address_Line_3"] = address1_line3.Text;
            drRow1["Country_Id"] = address1_country.SelectedItem.Value;
            drRow1["State_Id"] = address1_state.SelectedItem.Value;
            drRow1["City_Id"] = address1_city.SelectedItem.Value;
            drRow1["PinCode"] = address1_pincode.Text;
            drRow1["Address_IsPrimary"] = true;

            DataRow drRow2 = contactDetailsObj.AddressTypeTable.NewRow();

            if (!string.IsNullOrEmpty(Address2Id.Value))
                drRow2["Address_Id"] = Address2Id.Value;
            else
                drRow2["Address_Id"] = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                drRow2["Contact_Id"] = Generic.UIHelper.Decrypt(Request.QueryString["cid"], Generic.UIHelper.Key);
            else
                drRow2["Contact_Id"] = 0;

            drRow2["Address_Line_1"] = address2_line1.Text;
            drRow2["Address_Line_2"] = address2_line2.Text;
            drRow2["Address_Line_3"] = address2_line3.Text;
            drRow2["Country_Id"] = address2_country.Text;
            drRow2["State_Id"] = address2_state.Text;
            drRow2["City_Id"] = address2_city.Text;
            drRow2["PinCode"] = address2_pincode.Text;
            drRow2["Address_IsPrimary"] = false;


            contactDetailsObj.AddressTypeTable.Rows.Add(drRow1);
            contactDetailsObj.AddressTypeTable.Rows.Add(drRow2);

            MethodResponse responseObj = (new ContactDetails_BAL()).Update(ref contactDetailsObj);

            if (responseObj.ResponseStatus)
            {
                editContainer.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Sc", "alert('" + responseObj.ResponseMessage + "');", true);
            }
            else
            {
                errMsgLbl.Visible = true;
                errMsgLbl.Text = "For security reason, Please close this tab.";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Sc", "alert('" + responseObj.ResponseMessage + "');", true);
            }
        }
    }
}