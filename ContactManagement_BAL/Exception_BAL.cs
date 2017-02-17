using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement_DAL;

namespace ContactManagement_BAL
{
    public class Exception_BAL
    {
        public int LogException(int? loggedInUser, Exception ex)
        {
            return (new Exception_DAL()).LogException(loggedInUser, ex);
        }
    }
}
