using System;
using System.Collections.Generic;
using System.Data;
using ContactManagement_DAL.Generic;
using ContactManagement_Entities.Masters;
using ContactManagement_DAL;
using System.Data.SqlClient;
using System.Configuration;
using ContactManagement_Entities;

namespace CentralExpenseManager_DAL.Masters
{
    public class City_DAL : GenericClass<City>
    {
        public override List<City> Select(City obj)
        {
            DataTable DT = SqlHelper.ExecuteSPReturnDT(new object[] { "Usp_Select_City_List", "@City_Id", obj == null ? (int?)null : (obj.Id ?? (int?)null), "@State_Id", obj == null ? null : obj.StateId });

            List<City> cityList = new List<City>();

            if (DT == null)
                return null;
            else if (DT.Rows.Count == 0)
                return cityList;
            else
            {
                foreach (DataRow row in DT.Rows)
                {
                    cityList.Add(new City()
                    {
                        Id = Convert.ToInt32(row["City_Id"]),
                        CountryId = Convert.ToInt32(row["Country_Id"]),
                        CountryName = row["Country_Name"].ToString(),
                        StateId = Convert.ToInt32(row["State_Id"]),
                        StateName = row["State_Name"].ToString(),
                        Name = row["City_Name"].ToString(),
                        IsActive = Convert.ToBoolean(row["City_IsActive"]),
                        IsDeleted = Convert.ToBoolean(row["City_IsDeleted"]),
                        CreatedBy = Convert.ToInt32(row["City_IsDeleted"]),
                        CreatedByUserName = row["AddedByUserName"].ToString(),
                        CreatedOn = Convert.ToDateTime(row["City_CreatedOn"]),
                        ModifiedBy = row["City_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["City_ModifiedBy"]),
                        ModifiedOn = row["City_ModifiedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["City_ModifiedOn"]),
                    });
                }
            }

            return cityList;
        }

        public override void Insert(ref City obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_City_Insert",
                                                            "@State_Id", obj.StateId,
                                                            "@City_Name", obj.Name,
                                                            "@City_IsActive", obj.IsActive,
                                                            "@City_CreatedBy", obj.CreatedBy
                                                        });

        }

        public override void Update(ref City obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_City_Update",
                                                            "@City_Id", obj.Id,                                            
                                                            "@State_Id", obj.StateId,
                                                            "@City_Name", obj.Name,
                                                            "@City_IsActive", obj.IsActive,
                                                            "@City_ModifiedBy", obj.ModifiedBy
                                                        });
        }

        public override void Delete(ref City obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] { "Usp_City_Delete", 
                "@City_Id", obj.Id, 
                "@City_ModifiedBy", obj.ModifiedBy });

        }
    }
}