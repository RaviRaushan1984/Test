using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using ContactManagement_Entities.Common;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;
using ContactManagement_Entities.Masters;
using ContactManagement_BAL.Masters;
using ContactManagement_BAL;
using System.Data;
//using Excel = Microsoft.Office.Interop.Excel;

namespace ContactManagement_UI.Generic
{
    public static class UIHelper
    {
        // key="DION"

        public static List<Country> _countryList = (new Country_BAL()).Select(null);

        public static List<State> _stateList = (new State_BAL()).Select(null);

        public static List<City> _cityList = (new City_BAL()).Select(null);

        /// <summary>
        /// Regular expression, which is used to validate an E-Mail address.
        /// </summary>
        public const string MatchEmailPattern =
                  @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        public static string Key = "DION";

        private static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

        private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

        public static byte[] MD5Hash(string value)
        {
            return (MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value)));
        }

        public static string Encrypt(string stringToEncrypt, string key)
        {
            DES.Key = UIHelper.MD5Hash(key);
            DES.Mode = CipherMode.ECB;
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);
            return (Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length)));
        }

        public static string Decrypt(string encryptedString, string key)
        {
            try
            {
                DES.Key = UIHelper.MD5Hash(key);
                DES.Mode = CipherMode.ECB;
                byte[] Buffer = Convert.FromBase64String(encryptedString);
                return (ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length)));

            }
            catch (Exception ex)
            {
                //MessageBox.Show("The encryption key specified was not appropriate for decryption.", "Invalid Enryption Key", MessageBoxButtons.OK, MessageBoxIcon.Information)
                return ("");
            }
        }

        public static byte[] GetFileData(this string fileName, string filePath)
        {
            var fullFilePath = string.Format("{0}/{1}", filePath, fileName);
            if (!System.IO.File.Exists(fullFilePath))
                throw new FileNotFoundException("The file does not exist.", fullFilePath);
            return System.IO.File.ReadAllBytes(fullFilePath);
        }

        /// <summary>
        /// Checks whether the given Email-Parameter is a valid E-Mail address.
        /// </summary>
        /// <param name="email">Parameter-string that contains an E-Mail address.</param>
        /// <returns>True, when Parameter-string is not null and 
        /// contains a valid E-Mail address;
        /// otherwise false.</returns>
        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }

        public static bool IsValidURL(string url)
        {
            if (url != null)
            {
                if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                {
                    if (url.Contains(","))
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            else return false;
        }

        public static bool IsValidPhoneNumber(string phoneNumber, out string _outputMessage)
        {
            _outputMessage = string.Empty;

            if (phoneNumber != null)
            {
                if (phoneNumber.Length >= 10 && phoneNumber.Length <= 12)
                {
                    if (Regex.IsMatch(phoneNumber, "^[0-9]*$"))
                    {
                        switch (phoneNumber)
                        {
                            case "0000000": // 7 times
                            case "00000000": // 8 times
                            case "000000000": // 9 times
                            case "0000000000": // 10 times
                            case "00000000000": // 11 times
                            case "000000000000": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "1111111": // 7 times
                            case "11111111": // 8 times
                            case "111111111": // 9 times
                            case "1111111111": // 10 times
                            case "11111111111": // 11 times
                            case "111111111111": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "2222222": // 7 times
                            case "22222222": // 8 times
                            case "222222222": // 9 times
                            case "2222222222": // 10 times
                            case "22222222222": // 11 times
                            case "222222222222": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "3333333": // 7 times
                            case "33333333": // 8 times
                            case "333333333": // 9 times
                            case "3333333333": // 10 times
                            case "33333333333": // 11 times
                            case "333333333333": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "4444444": // 7 times
                            case "44444444": // 8 times
                            case "444444444": // 9 times
                            case "4444444444": // 10 times
                            case "44444444444": // 11 times
                            case "444444444444": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "5555555": // 7 times
                            case "55555555": // 8 times
                            case "555555555": // 9 times
                            case "5555555555": // 10 times
                            case "55555555555": // 11 times
                            case "555555555555": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "6666666": // 7 times
                            case "66666666": // 8 times
                            case "666666666": // 9 times
                            case "6666666666": // 10 times
                            case "66666666666": // 11 times
                            case "666666666666": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "7777777": // 7 times
                            case "77777777": // 8 times
                            case "777777777": // 9 times
                            case "7777777777": // 10 times
                            case "77777777777": // 11 times
                            case "777777777777": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "8888888": // 7 times
                            case "88888888": // 8 times
                            case "888888888": // 9 times
                            case "8888888888": // 10 times
                            case "88888888888": // 11 times
                            case "888888888888": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            case "9999999": // 7 times
                            case "99999999": // 8 times
                            case "999999999": // 9 times
                            case "9999999999": // 10 times
                            case "99999999999": // 11 times
                            case "999999999999": // 12 times
                                {
                                    _outputMessage = phoneNumber + " : is not a valid number.";
                                    return false;
                                }
                            default:
                                return true;
                        }
                    }
                    else
                    {
                        _outputMessage = "Invalid number format. It accept only number, minimum length should be 10 and max should be 12.";
                        return false;
                    }
                }
                else
                {
                    _outputMessage = "Invalid number, minimum length should be 10 and max should be 12.";
                    return false;
                }
            }
            else
                return false;

        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, "^[0-9]*$"))
            {
                switch (phoneNumber)
                {
                    case "0000000": // 7 times
                    case "00000000": // 8 times
                    case "000000000": // 9 times
                    case "0000000000": // 10 times
                    case "00000000000": // 11 times
                    case "000000000000": // 12 times
                        return false;
                    case "1111111": // 7 times
                    case "11111111": // 8 times
                    case "111111111": // 9 times
                    case "1111111111": // 10 times
                    case "11111111111": // 11 times
                    case "111111111111": // 12 times
                        return false;
                    case "2222222": // 7 times
                    case "22222222": // 8 times
                    case "222222222": // 9 times
                    case "2222222222": // 10 times
                    case "22222222222": // 11 times
                    case "222222222222": // 12 times
                        return false;
                    case "3333333": // 7 times
                    case "33333333": // 8 times
                    case "333333333": // 9 times
                    case "3333333333": // 10 times
                    case "33333333333": // 11 times
                    case "333333333333": // 12 times
                        return false;
                    case "4444444": // 7 times
                    case "44444444": // 8 times
                    case "444444444": // 9 times
                    case "4444444444": // 10 times
                    case "44444444444": // 11 times
                    case "444444444444": // 12 times
                        return false;
                    case "5555555": // 7 times
                    case "55555555": // 8 times
                    case "555555555": // 9 times
                    case "5555555555": // 10 times
                    case "55555555555": // 11 times
                    case "555555555555": // 12 times
                        return false;
                    case "6666666": // 7 times
                    case "66666666": // 8 times
                    case "666666666": // 9 times
                    case "6666666666": // 10 times
                    case "66666666666": // 11 times
                    case "666666666666": // 12 times
                        return false;
                    case "7777777": // 7 times
                    case "77777777": // 8 times
                    case "777777777": // 9 times
                    case "7777777777": // 10 times
                    case "77777777777": // 11 times
                    case "777777777777": // 12 times
                        return false;
                    case "8888888": // 7 times
                    case "88888888": // 8 times
                    case "888888888": // 9 times
                    case "8888888888": // 10 times
                    case "88888888888": // 11 times
                    case "888888888888": // 12 times
                        return false;
                    case "9999999": // 7 times
                    case "99999999": // 8 times
                    case "999999999": // 9 times
                    case "9999999999": // 10 times
                    case "99999999999": // 11 times
                    case "999999999999": // 12 times
                        return false;
                    default:
                        return true;
                }
            }
            else
                return false;
        }

        public static bool IsValidCountry(string _countryName, out int countryId)
        {
            countryId = 0;

            if (_countryName != null)
            {
                Country country = _countryList.Find(x => x.CountryName.ToLower() == _countryName.Trim().ToLower());
                if (country != null)
                {
                    countryId = country.Id.Value;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool IsValidState(int _countryId, string _stateName, out int stateId)
        {
            stateId = 0;
            if (_stateName != null)
            {
                Country country = _countryList.Find(x => x.Id.Value == Convert.ToInt32(_countryId));

                if (country == null)
                    return false;
                else
                {
                    List<State> _tempStates = _stateList.FindAll(x => x.CountryId == country.Id);

                    if (_tempStates.Count == 0)
                        return false;
                    else
                    {
                        State state = _tempStates.Find(x => x.Name.ToLower() == _stateName.Trim().ToLower());
                        if (state != null)
                        {
                            stateId = state.Id.Value;
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            else return false;
        }

        public static bool IsValidCity(int _stateId, string _cityName, out int cityId)
        {
            cityId = 0;

            if (_cityName != null)
            {
                State state = _stateList.Find(x => x.Id.Value == _stateId);

                if (state == null)
                    return false;
                else
                {
                    List<City> _tempCity = _cityList.FindAll(x => x.StateId == state.Id);

                    if (_tempCity.Count == 0)
                        return false;
                    else
                    {
                        City city = _cityList.Find(x => x.Name.ToLower() == _cityName.Trim().ToLower());
                        if (city != null)
                        {
                            cityId = city.Id.Value;
                            return true;
                        }
                        else
                            return false;
                    }
                }

            }
            else return false;
        }

        public static bool IsValidPincode(string _pincode)
        {
            if (_pincode != null) return Regex.IsMatch(_pincode, "^[0-9]*$");
            else return false;
        }

        public static bool MailFunction(string mailFrom, string displayName, string mailTo, string mailSubj, string mailAttachment, string mailBody)
        {
            MailMessage msg = new MailMessage();
            SmtpClient client = new SmtpClient();

            try
            {

                string MailHost = ConfigurationManager.AppSettings["MailHost"];
                string MailPort = ConfigurationManager.AppSettings["MailPort"];
                string MailCredentialsUser = ConfigurationManager.AppSettings["MailCredentialsUser"];
                string MailCredentialsPassword = ConfigurationManager.AppSettings["MailCredentialsPassword"];


                msg.From = new MailAddress(mailFrom, displayName);

                msg.To.Add(mailTo);
                msg.Priority = MailPriority.High;
                msg.Subject = mailSubj;
                msg.Body = HttpUtility.HtmlDecode(mailBody);
                msg.IsBodyHtml = true;


                client.Host = MailHost;
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(MailCredentialsUser, MailCredentialsPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
                return true;


            }
            catch (Exception ex)
            {
                (new Exception_BAL()).LogException(HttpContext.Current.Session["UserId"] == null ? (int?)null : Convert.ToInt32(HttpContext.Current.Session["UserId"]), ex);
                return false;
            }
            finally
            {
                msg.Dispose();
                msg = null;
                client.Dispose();
                client = null;
            }

        }

        public static void ExportToExcel(DataTable dt, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            string str = string.Empty;

            foreach (DataColumn dtcol in dt.Columns)
            {
                HttpContext.Current.Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            HttpContext.Current.Response.Write("\n");

            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    HttpContext.Current.Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                HttpContext.Current.Response.Write("\n");
            }
            HttpContext.Current.Response.End();
        }

        public static bool SaveDataTableToExcel(DataTable table, string savePath)
        {
            //open file
            StreamWriter wr = new StreamWriter(savePath, false, Encoding.Unicode);

            try
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    wr.Write(table.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (table.Rows.Count); i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (table.Rows[i][j] != null)
                        {
                            wr.Write("=\"" + Convert.ToString(table.Rows[i][j]) + "\"" + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                (new Exception_BAL()).LogException(HttpContext.Current.Session["UserId"] == null ? (int?)null : Convert.ToInt32(HttpContext.Current.Session["UserId"]), ex);

                return false;
            }

            return true;
        }
    }
}