using System;
using System.Collections.Generic;
using System.Data;
using ContactManagement_DAL.Generic;
using ContactManagement_Entities.Masters;
using ContactManagement_DAL;
using ContactManagement_DAL;
using System.Data.SqlClient;
using System.Configuration;
using ContactManagement_Entities;

namespace ContactManagement_DAL.Masters
{
    public class Country_DAL : GenericClass<Country>
    {
        public override List<Country> Select(Country obj)
        {
            DataTable DT = SqlHelper.ExecuteSPReturnDT(new object[] { "Usp_Select_Country_List", "@Country_Id", obj == null ? null : obj.Id });

            List<Country> countryList = new List<Country>();

            if (DT == null)
                return null;
            else if (DT.Rows.Count == 0)
                return countryList;
            else
            {
                foreach (DataRow row in DT.Rows)
                {
                    countryList.Add(new Country()
                    {
                        Id = Convert.ToInt32(row["Country_Id"]),
                        CountryCode = row["Country_Code"].ToString(),
                        CountryName = row["Country_Name"].ToString(),
                        IsActive = Convert.ToBoolean(row["Country_IsActive"]),
                        IsDeleted = Convert.ToBoolean(row["Country_IsDeleted"]),
                        CreatedBy = Convert.ToInt32(row["Country_CreatedBy"]),
                        CreatedByUserName = row["AddedByUserName"].ToString(),
                        CreatedOn = Convert.ToDateTime(row["Country_CreatedOn"]),
                        ModifiedBy = row["Country_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["Country_ModifiedBy"]),
                        ModifiedByUserName = row["ModifiedByUserName"].ToString(),
                        ModifiedOn = row["Country_ModifiedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Country_ModifiedOn"]),
                    });
                }
            }

            return countryList;
        }

        public override void Insert(ref Country obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_Country_Insert",
                                                            "@Country_Code", obj.CountryCode,
                                                            "@Country_Name", obj.CountryName,
                                                            "@Country_IsActive", obj.IsActive,
                                                            "@Country_CreatedBy", obj.CreatedBy
                                                        });
        }

        public override void Update(ref Country obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_Country_Update",
                                                            "@Country_Id", obj.Id,
                                                            "@Country_Code", obj.CountryCode,
                                                            "@Country_Name", obj.CountryName,
                                                            "@Country_IsActive", obj.IsActive,
                                                            "@Country_ModifiedBy", obj.ModifiedBy
                                                        });
        }

        public override void Delete(ref Country obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {"Usp_Country_Delete",
                "@Country_Id", obj.Id, 
                "@Country_ModifiedBy", obj.ModifiedBy 
            });

        }
    }
}
