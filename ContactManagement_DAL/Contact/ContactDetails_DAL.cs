using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement_Entities.Contact;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ContactManagement_Entities;

namespace ContactManagement_DAL.Contact
{
    public class ContactDetails_DAL : Generic.GenericClass<ContactDetails>
    {
        public override List<ContactDetails> Select(ContactDetails obj)
        {
            DataTable DT = SqlHelper.ExecuteSPReturnDT(new object[] { "Usp_Contact_Select", "@LoggedIn_User", obj == null ? null : (obj.LoggedInUser == (int?)null ? (int?)null : obj.LoggedInUser), 
                "@Contact_Id",obj == null ? null : (obj.ContactId == (int?)null ? (int?)null : obj.ContactId) });

            List<ContactDetails> ContactDetailsList = new List<ContactDetails>();

            if (DT == null)
                return null;
            else if (DT.Rows.Count == 0)
                return ContactDetailsList;
            else
            {
                foreach (DataRow row in DT.Rows)
                {
                    ContactDetailsList.Add(new ContactDetails()
                    {
                        Id = Convert.ToInt32(row["Contact_Id"].ToString()),
                        Title = row["Contact_Title"].ToString(),
                        FirstName = row["Contact_Fname"].ToString(),
                        MiddleName = row["Contact_Mname"].ToString(),
                        LastName = row["Contact_Lname"].ToString(),
                        FullName = row["Contact_Fname"].ToString() + (row["Contact_Mname"] == DBNull.Value ? " " : " " + row["Contact_Mname"].ToString() + " ") + row["Contact_Lname"].ToString(),
                        Desgination = row["Contact_Desgination"].ToString(),
                        Company = row["Contact_Company"].ToString(),
                        Mobile = row["Contact_Mobile"].ToString(),
                        HomePhone = row["Contact_Home_Phone"].ToString(),
                        OfficePhone = row["Contact_Office_Phone"].ToString(),
                        Fax = row["Contact_Fax"].ToString(),
                        OfficeEmail = row["Contact_Office_Email"].ToString(),
                        PersonalEmail = row["Contact_Personal_Email"].ToString(),
                        Website = row["Contact_Website"].ToString(),
                        IndustryType = row["Contact_Industry_Type"].ToString(),
                        Owner = row["Contact_Owner"].ToString(),
                        IsActive = Convert.ToBoolean(row["Contact_IsActive"]),
                        IsDeleted = Convert.ToBoolean(row["Contact_IsDeleted"]),
                        CreatedBy = Convert.ToInt32(row["Contact_CreatedBy"]),
                        CreatedByUserName = row["AddedByUserName"].ToString(),
                        CreatedOn = row["Contact_CreatedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Contact_CreatedOn"]),
                        ModifiedByUserName = row["ModifiedByUserName"].ToString(),
                        ModifiedBy = row["Contact_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["Contact_ModifiedBy"]),
                        ModifiedOn = row["Contact_ModifiedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Contact_ModifiedOn"]),
                    });
                }
            }

            return ContactDetailsList;
        }

        public ContactDetails SingleSelect(int contactId)
        {
            DataSet DS = SqlHelper.ExecuteSPReturnDS(new object[] { "Usp_Contact_Single_Select", "@Contact_Id", contactId });

            ContactDetails contDetailObj = new ContactDetails();
            if (DS == null)
                return null;
            else if (DS.Tables[0].Rows.Count == 0)
                return contDetailObj;
            else
            {
                contDetailObj.Id = Convert.ToInt32(DS.Tables[0].Rows[0]["Contact_Id"].ToString());
                contDetailObj.Title = DS.Tables[0].Rows[0]["Contact_Title"].ToString();
                contDetailObj.FirstName = DS.Tables[0].Rows[0]["Contact_Fname"].ToString();
                contDetailObj.MiddleName = DS.Tables[0].Rows[0]["Contact_Mname"].ToString();
                contDetailObj.LastName = DS.Tables[0].Rows[0]["Contact_Lname"].ToString();
                contDetailObj.FullName = DS.Tables[0].Rows[0]["Contact_Fname"].ToString() + (DS.Tables[0].Rows[0]["Contact_Mname"] == DBNull.Value ? " " : " " + DS.Tables[0].Rows[0]["Contact_Mname"].ToString() + " ") + DS.Tables[0].Rows[0]["Contact_Lname"].ToString();
                contDetailObj.Desgination = DS.Tables[0].Rows[0]["Contact_Desgination"].ToString();
                contDetailObj.Company = DS.Tables[0].Rows[0]["Contact_Company"].ToString();
                contDetailObj.Mobile = DS.Tables[0].Rows[0]["Contact_Mobile"].ToString();
                contDetailObj.HomePhone = DS.Tables[0].Rows[0]["Contact_Home_Phone"].ToString();
                contDetailObj.OfficePhone = DS.Tables[0].Rows[0]["Contact_Office_Phone"].ToString();
                contDetailObj.Fax = DS.Tables[0].Rows[0]["Contact_Fax"].ToString();
                contDetailObj.OfficeEmail = DS.Tables[0].Rows[0]["Contact_Office_Email"].ToString();
                contDetailObj.PersonalEmail = DS.Tables[0].Rows[0]["Contact_Personal_Email"].ToString();
                contDetailObj.Website = DS.Tables[0].Rows[0]["Contact_Website"].ToString();
                contDetailObj.IndustryType = DS.Tables[0].Rows[0]["Contact_Industry_Type"].ToString();
                contDetailObj.Owner = DS.Tables[0].Rows[0]["Contact_Owner"].ToString();

                //Address 1
                contDetailObj.Address1_Line1 = DS.Tables[0].Rows[0]["Address1_Line_1"].ToString();
                contDetailObj.Address1_Line2 = DS.Tables[0].Rows[0]["Address1_Line_2"].ToString();
                contDetailObj.Address1_Line3 = DS.Tables[0].Rows[0]["Address1_Line_3"].ToString();
                contDetailObj.Address1_Country = DS.Tables[0].Rows[0]["Address1_Country_Id"] == DBNull.Value ? "0" : DS.Tables[0].Rows[0]["Address1_Country_Id"].ToString();
                contDetailObj.Address1_State = DS.Tables[0].Rows[0]["Address1_State_Id"] == DBNull.Value ? "0" : DS.Tables[0].Rows[0]["Address1_State_Id"].ToString();
                contDetailObj.Address1_City = DS.Tables[0].Rows[0]["Address1_City_Id"] == DBNull.Value ? "0" : DS.Tables[0].Rows[0]["Address1_City_Id"].ToString();
                contDetailObj.Address1_PinCode = DS.Tables[0].Rows[0]["Address1_PinCode"].ToString();
                //Address 2
                contDetailObj.Address2_Line1 = DS.Tables[0].Rows[0]["Address2_Line_1"].ToString();
                contDetailObj.Address2_Line2 = DS.Tables[0].Rows[0]["Address2_Line_2"].ToString();
                contDetailObj.Address2_Line3 = DS.Tables[0].Rows[0]["Address2_Line_3"].ToString();
                contDetailObj.Address2_Country = DS.Tables[0].Rows[0]["Address2_Country_Id"] == DBNull.Value ? "0" : DS.Tables[0].Rows[0]["Address2_Country_Id"].ToString();
                contDetailObj.Address2_State = DS.Tables[0].Rows[0]["Address2_State_Id"] == DBNull.Value ? "0" : DS.Tables[0].Rows[0]["Address2_State_Id"].ToString();
                contDetailObj.Address2_City = DS.Tables[0].Rows[0]["Address2_City_Id"] == DBNull.Value ? "0" : DS.Tables[0].Rows[0]["Address2_City_Id"].ToString();
                contDetailObj.Address2_PinCode = DS.Tables[0].Rows[0]["Address2_PinCode"].ToString();

                contDetailObj.IsActive = Convert.ToBoolean(DS.Tables[0].Rows[0]["Contact_IsActive"]);
                contDetailObj.IsDeleted = Convert.ToBoolean(DS.Tables[0].Rows[0]["Contact_IsDeleted"]);
                contDetailObj.CreatedBy = Convert.ToInt32(DS.Tables[0].Rows[0]["Contact_CreatedBy"]);
                contDetailObj.CreatedOn = DS.Tables[0].Rows[0]["Contact_CreatedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(DS.Tables[0].Rows[0]["Contact_CreatedOn"]);
                contDetailObj.ModifiedBy = DS.Tables[0].Rows[0]["Contact_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(DS.Tables[0].Rows[0]["Contact_ModifiedBy"]);
                contDetailObj.ModifiedOn = DS.Tables[0].Rows[0]["Contact_ModifiedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(DS.Tables[0].Rows[0]["Contact_ModifiedOn"]);

                return contDetailObj;
            }
        }

        public override void Insert(ref ContactDetails obj)
        {

            SqlCommand cmd = new SqlCommand("Usp_Contact_Insert", SqlHelper.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Contact_Title", obj.Title);
            cmd.Parameters.AddWithValue("@Contact_Fname", obj.FirstName);
            cmd.Parameters.AddWithValue("@Contact_Mname", obj.MiddleName);
            cmd.Parameters.AddWithValue("@Contact_Lname", obj.LastName);
            cmd.Parameters.AddWithValue("@Contact_Desgination", obj.Desgination);
            cmd.Parameters.AddWithValue("@Contact_Company", obj.Company);
            cmd.Parameters.AddWithValue("@Contact_Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Contact_Home_Phone", obj.HomePhone);
            cmd.Parameters.AddWithValue("@Contact_Office_Phone", obj.OfficePhone);
            cmd.Parameters.AddWithValue("@Contact_Fax", obj.Fax);
            cmd.Parameters.AddWithValue("@Contact_Office_Email", obj.OfficeEmail);
            cmd.Parameters.AddWithValue("@Contact_Personal_Email", obj.PersonalEmail);
            cmd.Parameters.AddWithValue("@Contact_Website", obj.Website);
            cmd.Parameters.AddWithValue("@Contact_Industry_Type", obj.IndustryType);
            cmd.Parameters.AddWithValue("@Contact_Owner", obj.Owner);
            cmd.Parameters.AddWithValue("@Address1_Line_1", obj.Address1_Line1);
            cmd.Parameters.AddWithValue("@Address1_Line_2", obj.Address1_Line2);
            cmd.Parameters.AddWithValue("@Address1_Line_3", obj.Address1_Line3);
            cmd.Parameters.AddWithValue("@Address1_Country_Id", obj.Address1_Country);
            cmd.Parameters.AddWithValue("@Address1_State_Id", obj.Address1_State);
            cmd.Parameters.AddWithValue("@Address1_City_Id", obj.Address1_City);
            cmd.Parameters.AddWithValue("@Address1_PinCode", obj.Address1_PinCode);
            cmd.Parameters.AddWithValue("@Address2_Line_1", obj.Address2_Line1);
            cmd.Parameters.AddWithValue("@Address2_Line_2", obj.Address2_Line2);
            cmd.Parameters.AddWithValue("@Address2_Line_3", obj.Address2_Line3);
            cmd.Parameters.AddWithValue("@Address2_Country_Id", obj.Address2_Country);
            cmd.Parameters.AddWithValue("@Address2_State_Id", obj.Address2_State);
            cmd.Parameters.AddWithValue("@Address2_City_Id", obj.Address2_City);
            cmd.Parameters.AddWithValue("@Address2_PinCode", obj.Address2_PinCode);
            cmd.Parameters.AddWithValue("@Contact_IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@Contact_CreatedBy", obj.CreatedBy);

            obj.DALResponse = cmd.ExecuteScalar();

            cmd.Connection.Close();
        }

        public override void Update(ref ContactDetails obj)
        {
            SqlCommand cmd = new SqlCommand("Usp_Contact_Update", SqlHelper.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Contact_Id", obj.ContactId);
            cmd.Parameters.AddWithValue("@Contact_Title", obj.Title);
            cmd.Parameters.AddWithValue("@Contact_Fname", obj.FirstName);
            cmd.Parameters.AddWithValue("@Contact_Mname", obj.MiddleName);
            cmd.Parameters.AddWithValue("@Contact_Lname", obj.LastName);
            cmd.Parameters.AddWithValue("@Contact_Desgination", obj.Desgination);
            cmd.Parameters.AddWithValue("@Contact_Company", obj.Company);
            cmd.Parameters.AddWithValue("@Contact_Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Contact_Home_Phone", obj.HomePhone);
            cmd.Parameters.AddWithValue("@Contact_Office_Phone", obj.OfficePhone);
            cmd.Parameters.AddWithValue("@Contact_Fax", obj.Fax);
            cmd.Parameters.AddWithValue("@Contact_Office_Email", obj.OfficeEmail);
            cmd.Parameters.AddWithValue("@Contact_Personal_Email", obj.PersonalEmail);
            cmd.Parameters.AddWithValue("@Contact_Website", obj.Website);
            cmd.Parameters.AddWithValue("@Contact_Industry_Type", obj.IndustryType);
            cmd.Parameters.AddWithValue("@Contact_Owner", obj.Owner);
            cmd.Parameters.AddWithValue("@Address1_Line_1", obj.Address1_Line1);
            cmd.Parameters.AddWithValue("@Address1_Line_2", obj.Address1_Line2);
            cmd.Parameters.AddWithValue("@Address1_Line_3", obj.Address1_Line3);
            cmd.Parameters.AddWithValue("@Address1_Country_Id", obj.Address1_Country);
            cmd.Parameters.AddWithValue("@Address1_State_Id", obj.Address1_State);
            cmd.Parameters.AddWithValue("@Address1_City_Id", obj.Address1_City);
            cmd.Parameters.AddWithValue("@Address1_PinCode", obj.Address1_PinCode);
            cmd.Parameters.AddWithValue("@Address2_Line_1", obj.Address2_Line1);
            cmd.Parameters.AddWithValue("@Address2_Line_2", obj.Address2_Line2);
            cmd.Parameters.AddWithValue("@Address2_Line_3", obj.Address2_Line3);
            cmd.Parameters.AddWithValue("@Address2_Country_Id", obj.Address2_Country);
            cmd.Parameters.AddWithValue("@Address2_State_Id", obj.Address2_State);
            cmd.Parameters.AddWithValue("@Address2_City_Id", obj.Address2_City);
            cmd.Parameters.AddWithValue("@Address2_PinCode", obj.Address2_PinCode);
            cmd.Parameters.AddWithValue("@Contact_IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@Contact_ModifiedBy", obj.ModifiedBy);

            obj.DALResponse = cmd.ExecuteScalar();

            cmd.Connection.Close();
        }

        public override void Delete(ref ContactDetails obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] { "Usp_Contact_Delete", "@LoggedIn_User", obj.LoggedInUser, "@Contact_Id", obj.ContactId });
        }

        public int UploadContacts(ContactDetails obj)
        {
            SqlCommand cmd = new SqlCommand("Usp_Upload_Bulk_Contacts", SqlHelper.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Contact_List", obj.BulkContactUploadTable);
            int noOfRecordsAdded = Convert.ToInt32(cmd.ExecuteScalar());

            //SqlHelper.ExecuteSP(new object[] { "Usp_Insert_Uploaded_Contact" });
            cmd.Connection.Close();

            return noOfRecordsAdded;
        }
    }
}
