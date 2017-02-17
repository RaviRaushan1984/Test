using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement_UI.Generic
{
    public static class UserProfile
    {
        public static void SetSessionValues(int userId, string userName, string userEmail, int userGroupId)
        {
            HttpContext.Current.Session["UserId"] = userId;
            HttpContext.Current.Session["UserName"] = userName;
            HttpContext.Current.Session["UserEmail"] = userEmail;
            HttpContext.Current.Session["UserGroup"] = userGroupId;
        }

        public static void DisposeSession()
        {
            HttpContext.Current.Session["UserId"] = null;
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["UserEmail"] = null;
            HttpContext.Current.Session["UserGroup"] = null;
        }

        public static bool IsSessionValid()
        {
            if (HttpContext.Current.Session["UserId"] == null || HttpContext.Current.Session["UserName"] == null || HttpContext.Current.Session["UserEmail"] == null || HttpContext.Current.Session["UserGroup"] == null)
                return false;
            else
                return true;
        }

    }
}