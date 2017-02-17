using System;
using System.Collections.Generic;
using System.Data;
using ContactManagement_DAL.Generic;
using ContactManagement_Entities.Masters;
using ContactManagement_DAL;

namespace CentralExpenseManager_DAL.Masters
{
    public class State_DAL : GenericClass<State>
    {
        public override List<State> Select(State obj)
        {
            DataTable DT = SqlHelper.ExecuteSPReturnDT(new object[] { "Usp_Select_State_List", "@State_Id", obj == null ? (int?)null : (obj.Id ?? (int?)null), "@Country_Id", obj == null ? null : obj.CountryId });

            List<State> stateList = new List<State>();

            if (DT == null)
                return null;
            else if (DT.Rows.Count == 0)
                return stateList;
            else
            {
                foreach (DataRow row in DT.Rows)
                {
                    stateList.Add(new State()
                    {
                        Id = Convert.ToInt32(row["State_Id"]),
                        Name = row["State_Name"].ToString(),
                        CountryId = Convert.ToInt32(row["Country_Id"]),
                        CountryName = row["Country_Name"].ToString(),
                        IsActive = Convert.ToBoolean(row["State_IsActive"]),
                        IsDeleted = Convert.ToBoolean(row["State_IsDeleted"]),
                        CreatedBy = Convert.ToInt32(row["State_CreatedBy"]),
                        CreatedByUserName = row["AddedByUserName"].ToString(),
                        CreatedOn = Convert.ToDateTime(row["State_CreatedOn"]),
                        ModifiedBy = row["State_ModifiedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["State_ModifiedBy"]),
                        ModifiedByUserName = row["ModifiedByUserName"].ToString(),
                        ModifiedOn = row["State_ModifiedOn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["State_ModifiedOn"]),
                    });
                }
            }

            return stateList;
        }

        public override void Insert(ref State obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_State_Insert",
                                                            "@Country_Id", obj.CountryId,
                                                            "@State_Name", obj.Name,
                                                            "@State_IsActive", obj.IsActive,
                                                            "@State_CreatedBy", obj.CreatedBy
                                                        });
        }

        public override void Update(ref State obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_State_Update",
                                                            "@State_Id", obj.Id,
                                                            "@Country_Id", obj.CountryId,
                                                            "@State_Name", obj.Name,
                                                            "@State_IsActive", obj.IsActive,
                                                            "@State_ModifiedBy", obj.ModifiedBy
                                                        });
        }

        public override void Delete(ref State obj)
        {
            obj.DALResponse = SqlHelper.ExecuteSPReturnScaler(new object[] {  "Usp_State_Delete",
                                                            "@State_Id", obj.Id,
                                                            "@State_ModifiedBy", obj.ModifiedBy
                                                        });
        }
    }
}
