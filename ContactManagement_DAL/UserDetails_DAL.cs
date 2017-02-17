using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement_Entities;
using ContactManagement_DAL.Generic;
using System.Data;

namespace ContactManagement_DAL
{
    public class UserDetails_DAL : GenericClass<UserDetails>
    {
        public override List<UserDetails> Select(UserDetails obj)
        {
            DataTable DT = SqlHelper.ExecuteSPReturnDT(new object[] {  "Usp_User_Select",
                                                                    "@User_Id", obj == null? (int?)null : obj.Id
                                                                });

            List<UserDetails> userList = new List<UserDetails>();

            if (DT == null)
                return null;
            else if (DT.Rows.Count == 0) return userList;

            else
            {
                foreach (DataRow row in DT.Rows)
                {
                    userList.Add(new UserDetails()
                    {
                        Id = Convert.ToInt32(row["User_Id"]),
                        UserGroupId = Convert.ToInt32(row["User_Group_Id"]),
                        User_Code = row["User_Code"].ToString(),
                        User_Name = row["User_Name"].ToString(),
                        User_Password = row["User_Password"].ToString(),
                        User_EmailId = row["User_EmailId"].ToString(),
                        IsActive = Convert.ToBoolean(row["User_IsActive"]),
                        IsDeleted = Convert.ToBoolean(row["User_IsDeleted"]),
                        CreatedBy = Convert.ToInt32(row["User_CreatedBy"]),
                        CreatedByUserName = row["CreatedByUserName"].ToString(),
                        CreatedOn = Convert.ToDateTime(row["User_CreatedOn"]),
                        ModifiedBy = row["User_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["User_ModifiedBy"]),
                        ModifiedByUserName = row["ModifiedByUserName"].ToString(),
                        ModifiedOn = row["User_ModifiedBy"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["User_ModifiedOn"])
                    });
                }
            }

            return userList;
        }

        public override void Insert(ref UserDetails obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] { "Usp_User_Insert",
                                                                            "@User_Group_Id",obj.UserGroupId,
                                                                            "@User_Code",obj.User_Code,
                                                                            "@User_Name",obj.User_Name,
                                                                            //"@User_Password",obj.User_Password,
                                                                            "@User_EmailId",obj.User_EmailId,
                                                                            "@User_IsActive",obj.IsActive,
                                                                            "@User_CreatedBy",obj.CreatedBy,
                                                                            });
        }

        public override void Update(ref UserDetails obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] { "Usp_User_Update",
                                                                            "@User_Id",obj.Id,
                                                                            "@User_Group_Id",obj.UserGroupId,
                                                                            "@User_Code",obj.User_Code,
                                                                            "@User_Name",obj.User_Name,
                                                                            //"@User_Password",obj.User_Password,
                                                                            "@User_EmailId",obj.User_EmailId,
                                                                            "@User_IsActive",obj.IsActive,
                                                                            "@User_ModifiedBy",obj.ModifiedBy,
                                                                            });
        }

        public override void Delete(ref UserDetails obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] { "Usp_User_Delete",
                                                                            "@User_Id",obj.Id,
                                                                            "@User_ModifiedBy",obj.ModifiedBy,
                                                                            });
        }

        public UserDetails GetUserDetails(ref UserDetails obj)
        {
            DataTable DT = SqlHelper.ExecuteSPReturnDT(new object[] {  "Usp_Get_User_Details",
                                                                    "@User_Name", obj.User_Name,
                                                                    "@Password", obj.User_Password
                                                                });

            if (DT == null)
                return null;
            else if (DT.Rows.Count == 0) return null;

            else
            {
                return new UserDetails()
                {
                    Id = Convert.ToInt32(DT.Rows[0]["User_Id"]),
                    UserGroupId = Convert.ToInt32(DT.Rows[0]["User_Group_Id"]),
                    User_Code = DT.Rows[0]["User_Code"].ToString(),
                    User_Name = DT.Rows[0]["User_Name"].ToString(),
                    User_Password = DT.Rows[0]["User_Password"].ToString(),
                    User_EmailId = DT.Rows[0]["User_EmailId"].ToString(),
                    IsActive = Convert.ToBoolean(DT.Rows[0]["User_IsActive"]),
                    IsDeleted = Convert.ToBoolean(DT.Rows[0]["User_IsDeleted"]),
                    CreatedBy = Convert.ToInt32(DT.Rows[0]["User_CreatedBy"]),
                    CreatedOn = Convert.ToDateTime(DT.Rows[0]["User_CreatedOn"]),
                    ModifiedBy = DT.Rows[0]["User_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(DT.Rows[0]["User_ModifiedBy"]),
                    ModifiedOn = DT.Rows[0]["User_ModifiedBy"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(DT.Rows[0]["User_ModifiedOn"])
                };
            }
        }
    }
}
