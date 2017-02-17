using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement_DAL
{
    public class Exception_DAL
    {
        public int LogException(int? loggedInUser, Exception ex)
        {
            return Convert.ToInt32(
                SqlHelper.ExecuteSPReturnScaler(new object[] { "Usp_Log_Exception",
                                                                "@ErrorMessage", ex.Message,
                                                                "@InnerException", ex.InnerException,
                                                                "@ErrorSource", ex.Source,
                                                                "@StackTrace", ex.StackTrace,
                                                                "@Error_OccuredAt", ex.TargetSite,
                                                                "@AddedBy", loggedInUser.HasValue? loggedInUser.Value : 0, // 0 - Represents Admin
                                                              }));
        }
    }
}
