using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using ContactManagement_Entities.Masters;


namespace ContactManagement_Entities.Contact
{
    public class ContactDetails : Common.CommonProperties
    {
        public ContactDetails()
        {
            AddressTypeTable = new DataTable();
            AddressTypeTable.Columns.Add("Address_Id", typeof(int));
            AddressTypeTable.Columns.Add("Contact_Id", typeof(int));
            AddressTypeTable.Columns.Add("Address_Line_1", typeof(string));
            AddressTypeTable.Columns.Add("Address_Line_2", typeof(string));
            AddressTypeTable.Columns.Add("Address_Line_3", typeof(string));
            AddressTypeTable.Columns.Add("Country_Id", typeof(int));
            AddressTypeTable.Columns.Add("State_Id", typeof(int));
            AddressTypeTable.Columns.Add("City_Id", typeof(int));
            AddressTypeTable.Columns.Add("PinCode", typeof(string));
            AddressTypeTable.Columns.Add("Address_IsPrimary", typeof(bool));

            BulkContactUploadTable = new DataTable();
            BulkContactUploadTable.Columns.Add("Contact_Title", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Fname", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Mname", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Lname", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Desgination", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Company", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Mobile", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Home_Phone", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Office_Phone", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Fax", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Office_Email", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Personal_Email", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Website", typeof(string));
            BulkContactUploadTable.Columns.Add("Contact_Industry_Type", typeof(string));

            BulkContactUploadTable.Columns.Add("Address_1_Line_1", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_1_Line_2", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_1_Line_3", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_1_Country_Name", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_1_State_Name", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_1_City_Name", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_1_PinCode", typeof(string));

            BulkContactUploadTable.Columns.Add("Address_2_Line_1", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_2_Line_2", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_2_Line_3", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_2_Country_Name", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_2_State_Name", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_2_City_Name", typeof(string));
            BulkContactUploadTable.Columns.Add("Address_2_PinCode", typeof(string));
            BulkContactUploadTable.Columns.Add("UploadedBy_user", typeof(int));
            BulkContactUploadTable.Columns.Add("UploadedOn", typeof(DateTime));


            Address1_Country = Address2_Country = Address1_State = Address2_State = Address1_City = Address2_City = "0";
        }

        #region Contact Block
        public int Id { get; set; }

        public int? LoggedInUser { get; set; }

        //[Required(ErrorMessage = "Contact is required")]
        //[Display(Name = "Contact")]
        public int? ContactId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter alphabets only")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter alphabets only")]
        public string FirstName { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter alphabets only")]
        public string MiddleName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        [Display(Name = "Middle Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter alphabets only")]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter alphabets only")]
        public string Desgination { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Company is required")]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        [Display(Name = "Mobile")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,12}$", ErrorMessage = "Please enter valid mobile no, digit count should be in between 10 to 12")]
        public virtual string Mobile { get; set; }

        [Display(Name = "Office Phone")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,12}$", ErrorMessage = "Please enter valid number, digit count should be in between 10 to 12")]
        public string HomePhone { get; set; }

        [Display(Name = "Office Home")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,12}$", ErrorMessage = "Please enter valid number, digit count should be in between 10 to 12")]
        public string OfficePhone { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "Office email is required")]
        [Display(Name = "Office Email")]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9]+)*\\.([a-zA-Z]{2,4})$", ErrorMessage = "Invalid email format")]
        public string OfficeEmail { get; set; }

        [Display(Name = "Personal Email")]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9]+)*\\.([a-zA-Z]{2,4})$", ErrorMessage = "Invalid email format")]
        public string PersonalEmail { get; set; }

        [Display(Name = "Website")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Invalid URL, valid format is http://www.test.com")]
        public string Website { get; set; }

        public string IndustryType { get; set; }

        public string Owner { get; set; }
        #endregion

        #region Address Block
        public int AddressId1 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address line 1 is required")]
        [Display(Name = "Address Line 1")]
        public string Address1_Line1 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address line 2 is required")]
        [Display(Name = "Address line 2")]
        public string Address1_Line2 { get; set; }

        public string Address1_Line3 { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public string Address1_Country { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string Address1_State { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string Address1_City { get; set; }

        [Required(ErrorMessage = "Pincode is required, digit count should be in between 6 to 10")]
        [Display(Name = "Pincode")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{6,10}$", ErrorMessage = "Invalid pincode")]
        public string Address1_PinCode { get; set; }

        public bool Address1_IsPrimary { get; set; }

        public int AddressId2 { get; set; }

        public string Address2_Line1 { get; set; }

        public string Address2_Line2 { get; set; }

        public string Address2_Line3 { get; set; }

        public string Address2_Country { get; set; }

        public string Address2_State { get; set; }

        public string Address2_City { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{6,10}$", ErrorMessage = "Invalid pincode, digit count should be in between 6 to 10")]
        public string Address2_PinCode { get; set; }

        public bool Address2_IsPrimary { get; set; }
        #endregion

        public List<AddressDetails> Address { get; set; }

        /// <summary>
        /// Table valued parameter to insert multiple address against a contact
        /// </summary>
        public DataTable AddressTypeTable { get; set; }


        public DataTable BulkContactUploadTable { get; set; }

        public List<Country> CountryList { get; set; }
        public List<State> StateList { get; set; }
        public List<City> CityList { get; set; }
    }
}
