using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using ContactManagement_UI.Models;
using ContactManagement_Entities.Masters;
using System.Text;
using ContactManagement_Entities.Contact;
using ContactManagement_BAL.Contact;

namespace ContactManagement_UI.Generic
{
    public class UploadService
    {
        //ExcelFailureRepository failureRepository = new ExcelFailureRepository();

        public string SaveFileDetails(FileUploadViewModel model)
        {
            //Code to save file detail
            Guid id = Guid.NewGuid();

            //file = new UploadedExcel();
            //file.Id = id;
            //file.FileName = model.File.FileName;
            //file.FileBytes = ConvertToBytes(model.File);
            //file.UserId = 1;
            //file.UploadedDate = DateTime.Now;
            //file.IsProcessed = false;
            //dataContext.UploadedExcel.AddObject(file);
            //dataContext.SaveChanges();
            //return file.Id.ToString();
            return "";
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(Image.InputStream);
            imageBytes = reader.ReadBytes((int)Image.ContentLength);
            return imageBytes;
        }

        public Tuple<int, int, int> ValidateExcelFileData(DataTable dataTable, out DataTable _dataToUpload)
        {
            dataTable.Columns.Add("Remarks", typeof(string));

            DataTable _tempDT = dataTable.Clone();

            List<ContactDetails> usersCurrentContactList = (new ContactDetails_BAL()).Select(new ContactDetails() { LoggedInUser = Convert.ToInt32(HttpContext.Current.Session["UserId"]) });

            int _noOfSuccess = 0, _noOfFailure = 0, _noOfDuplicates = 0;

            StringBuilder _errorSummary;

            //Remarks - To add error details for each row
            //_tempDT.Columns.Add("Remarks", typeof(string));

            foreach (DataRow _currentRow in dataTable.Rows)
            {
                //...
                //x[10] - Office email index in uploaded excel
                // Checking duplicate records in uploaded excel sheet
                bool isExist = _tempDT.Select().ToList().Exists(x => x[10].ToString().ToLower() == _currentRow["OfficeEmail"].ToString().ToLower());

                if (!isExist)
                {

                    _errorSummary = new StringBuilder();

                    if (usersCurrentContactList.Exists(x => x.OfficeEmail.ToLower() == _currentRow["OfficeEmail"].ToString().ToLower()))
                    {
                        _currentRow["Remarks"] = "Record already exists with same office email";
                        _noOfDuplicates++;
                        continue;
                    }

                    string outputMessage = string.Empty;

                    #region Contact Info Validation Block
                    if (string.IsNullOrEmpty(_currentRow["Title"].ToString()))
                        _errorSummary.Append("Title can not be empty, ");

                    if (string.IsNullOrEmpty(_currentRow["FirstName"].ToString()))
                        _errorSummary.Append("First name can not be empty, ");

                    if (string.IsNullOrEmpty(_currentRow["LastName"].ToString()))
                        _errorSummary.Append("Last name can not be empty, ");

                    if (string.IsNullOrEmpty(_currentRow["OfficeEmail"].ToString()))
                        _errorSummary.Append("Office email can not be empty, ");

                    if (string.IsNullOrEmpty(_currentRow["Company"].ToString()))
                        _errorSummary.Append("Company name can not be empty, ");

                    if (string.IsNullOrEmpty(_currentRow["Mobile"].ToString()))
                        _errorSummary.Append("Mobile can not be empty, ");
                    else if (!UIHelper.IsValidPhoneNumber(_currentRow["Mobile"].ToString(), out outputMessage))
                        _errorSummary.Append(string.IsNullOrEmpty(outputMessage) ? "Invalid mobile number, " : outputMessage);

                    if (!string.IsNullOrEmpty(_currentRow["HomePhone"].ToString()))
                    {
                        if (!UIHelper.IsValidPhoneNumber(_currentRow["HomePhone"].ToString(), out outputMessage))
                            _errorSummary.Append(string.IsNullOrEmpty(outputMessage) ? "Invalid phone number, " : outputMessage);
                    }

                    if (!string.IsNullOrEmpty(_currentRow["OfficePhone"].ToString()))
                    {
                        if (!UIHelper.IsValidPhoneNumber(_currentRow["OfficePhone"].ToString(), out outputMessage))
                            _errorSummary.Append(string.IsNullOrEmpty(outputMessage) ? "Invalid office phone number, " : outputMessage);
                    }

                    if (string.IsNullOrEmpty(_currentRow["OfficeEmail"].ToString()))
                        _errorSummary.Append("Office email address can not be empty, ");
                    else if (!UIHelper.IsEmail(_currentRow["OfficeEmail"].ToString()))
                        _errorSummary.Append("Invalid email address format, ");

                    if (!string.IsNullOrEmpty(_currentRow["PersonalEmail"].ToString()))
                    {
                        if (!UIHelper.IsEmail(_currentRow["PersonalEmail"].ToString()))
                            _errorSummary.Append("Invalid email address format, ");
                    }

                    if (!string.IsNullOrEmpty(_currentRow["Website"].ToString()))
                    {
                        if (!UIHelper.IsValidURL(_currentRow["Website"].ToString()))
                            _errorSummary.Append("Invalid url, ");
                    }
                    #endregion

                    #region Address 1 Validation Block
                    if (string.IsNullOrEmpty(_currentRow["Address_1_Line_1"].ToString()))
                        _errorSummary.Append("Address 1 line 1 can not be empty, ");
                    else if (_currentRow["Address_1_Line_1"].ToString().Trim().Length > 200)
                        _errorSummary.Append("Address 1 line 1 length can not be more than 200, ");

                    if (string.IsNullOrEmpty(_currentRow["Address_1_Line_2"].ToString()))
                        _errorSummary.Append("Address 1 line 2 can not be empty, ");
                    else if (_currentRow["Address_1_Line_2"].ToString().Trim().Length > 200)
                        _errorSummary.Append("Address 1 line 2 length can not be more than 200, ");

                    if (_currentRow["Address_1_Line_3"].ToString().Trim().Length > 200)
                        _errorSummary.Append("Address 1 line 3 length can not be more than 200, ");

                    #region Country
                    int address1_countryId = 0;
                    if (string.IsNullOrEmpty(_currentRow["Address_1_Country_Name"].ToString()))
                        _errorSummary.Append("Country name in address 1 can not be empty, ");
                    else if (!UIHelper.IsValidCountry(_currentRow["Address_1_Country_Name"].ToString(), out address1_countryId))
                        _errorSummary.Append("Invalid country name in address 1, ");
                    #endregion

                    #region State
                    int address1_stateId = 0;
                    if (string.IsNullOrEmpty(_currentRow["Address_1_Country_Name"].ToString()) || string.IsNullOrEmpty(_currentRow["Address_1_State_Name"].ToString()))
                        _errorSummary.Append("State name in address 1 can not be empty, ");
                    else if (address1_countryId > 0) //If Country is valid then go for state
                    {
                        if (!UIHelper.IsValidState(address1_countryId, _currentRow["Address_1_State_Name"].ToString(), out address1_stateId))
                            _errorSummary.Append("Invalid state name in address 1, ");
                    }
                    #endregion

                    #region City
                    int address1_cityId = 0;
                    if (string.IsNullOrEmpty(_currentRow["Address_1_State_Name"].ToString()) || string.IsNullOrEmpty(_currentRow["Address_1_City_Name"].ToString()))
                        _errorSummary.Append("City name in address 1 can not be empty, ");
                    else if (address1_stateId > 0)
                    {
                        if (!UIHelper.IsValidCity(address1_stateId, _currentRow["Address_1_City_Name"].ToString(), out address1_cityId))
                            _errorSummary.Append("Invalid city name in address 1, ");
                    }
                    #endregion

                    if (string.IsNullOrEmpty(_currentRow["Address_1_PinCode"].ToString()))
                        _errorSummary.Append("Address 1 pincode can not be empty, ");
                    else if (!UIHelper.IsValidPincode(_currentRow["Address_1_PinCode"].ToString()))
                        _errorSummary.Append("Invalid address 1 pincode, ");
                    #endregion

                    #region Address 2 Validation Block
                    if (_currentRow["Address_2_Line_1"].ToString().Trim().Length > 200)
                        _errorSummary.Append("Address 2 line 1 length can not be more than 200, ");

                    if (_currentRow["Address_2_Line_2"].ToString().Trim().Length > 200)
                        _errorSummary.Append("Address 2 line 2 length can not be more than 200, ");

                    if (_currentRow["Address_2_Line_3"].ToString().Trim().Length > 200)
                        _errorSummary.Append("Address 2 line 3 length can not be more than 200, ");

                    int address2_countryId = 0;
                    if (!string.IsNullOrEmpty(_currentRow["Address_2_Country_Name"].ToString()))
                    {
                        if (!UIHelper.IsValidCountry(_currentRow["Address_2_Country_Name"].ToString(), out address2_countryId))
                            _errorSummary.Append("Invalid country name in address 2, ");
                    }

                    int address2_stateId = 0;
                    if (address2_countryId > 0 && !string.IsNullOrEmpty(_currentRow["Address_2_Country_Name"].ToString()) && !string.IsNullOrEmpty(_currentRow["Address_2_State_Name"].ToString()))
                    {
                        if (!UIHelper.IsValidState(address2_countryId, _currentRow["Address_2_State_Name"].ToString(), out address2_stateId))
                            _errorSummary.Append("Invalid state name in address 2, ");
                    }

                    int address2_cityId = 0;
                    if (address2_stateId > 0 && !string.IsNullOrEmpty(_currentRow["Address_2_State_Name"].ToString()) && !string.IsNullOrEmpty(_currentRow["Address_2_City_Name"].ToString()))
                    {
                        if (!UIHelper.IsValidCity(address2_stateId, _currentRow["Address_2_City_Name"].ToString(), out address2_cityId))
                            _errorSummary.Append("Invalid city name in address 2, ");
                    }

                    if (!string.IsNullOrEmpty(_currentRow["Address_2_PinCode"].ToString()) && !UIHelper.IsValidPincode(_currentRow["Address_2_PinCode"].ToString()))
                        _errorSummary.Append("Invalid address 2 pincode, ");
                    #endregion

                    DataRow drtemp = _tempDT.NewRow();

                    drtemp.ItemArray = _currentRow.ItemArray;


                    #region Assign Id's for Country, State & City
                    if (address1_countryId > 0) drtemp["Address_1_Country_Name"] = address1_countryId;
                    if (address1_stateId > 0) drtemp["Address_1_State_Name"] = address1_stateId;
                    if (address1_cityId > 0) drtemp["Address_1_City_Name"] = address1_cityId;

                    if (address2_countryId > 0) drtemp["Address_2_Country_Name"] = address2_countryId;
                    if (address2_stateId > 0) drtemp["Address_2_State_Name"] = address2_stateId;
                    if (address2_cityId > 0) drtemp["Address_2_City_Name"] = address2_cityId;
                    #endregion

                    //If record is valid, insert to temp table for insertion in database
                    if (string.IsNullOrEmpty(_errorSummary.ToString()))
                    {
                        _noOfSuccess++;
                        _tempDT.Rows.Add(drtemp);
                        // dataTable.Rows.Remove(_currentRow);
                    }
                    else
                    {
                        _noOfFailure++;
                        _currentRow["Remarks"] = _errorSummary.ToString().Trim(',');
                    }

                    _errorSummary = null;
                }
                else
                {
                    _noOfDuplicates++;
                    _currentRow["Remarks"] = "Duplicate records in uploaded excel";
                }
            }

            _dataToUpload = _tempDT.Copy();

            return new Tuple<int, int, int>(_noOfSuccess, _noOfFailure, _noOfDuplicates);
        }

        public void UpdateExcelStatus(Guid excelID, bool processed, string failureReason)
        {
            //using (BulkUploadEntities dataContext = new BulkUploadEntities())
            //{
            //    UploadedExcel excelFile = new UploadedExcel();
            //    excelFile = dataContext.UploadedExcel.Where(q => q.Id == excelID).SingleOrDefault();
            //    excelFile.IsProcessed = processed;
            //    excelFile.ProcessingStatus = (failureReason == string.Empty) ? "Success" : "Failure";
            //    excelFile.FailureReason = (failureReason != string.Empty) ? GetFailureReason() : null;
            //    dataContext.SaveChanges();
            //}
        }

        public string GetFailureReason()
        {
            string failureReason = string.Empty;
            //if (failureRepository.FailureReasonList.Count > 0)
            //{
            //    foreach (string reason in failureRepository.FailureReasonList)
            //    {
            //        failureReason = failureReason + reason;
            //    }
            //}
            //else
            //{
            //    failureReason = "Failure";
            //}
            return failureReason;
        }
    }
}