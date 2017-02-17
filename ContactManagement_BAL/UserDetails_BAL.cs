using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement_Entities;
using ContactManagement_Entities.Common;
using ContactManagement_DAL;

namespace ContactManagement_BAL
{
    public class UserDetails_BAL : Generic.GenericClass<UserDetails>
    {
        MethodResponse methodResponseObj;
        bool objIsValid = true;

        public override List<UserDetails> Select(UserDetails obj)
        {
            return (new UserDetails_DAL()).Select(obj);
        }

        public override MethodResponse Insert(ref UserDetails obj)
        {
            obj.OperationToPerform = MethodOperation.Insert;

            (new UserDetails_DAL()).Insert(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Update(ref UserDetails obj)
        {
            obj.OperationToPerform = MethodOperation.Update;

            (new UserDetails_DAL()).Update(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Delete(ref UserDetails obj)
        {
            obj.OperationToPerform = MethodOperation.Delete;

            (new UserDetails_DAL()).Delete(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public UserDetails GetUserDetails(UserDetails obj)
        {
            return (new UserDetails_DAL()).GetUserDetails(ref obj);
        }        
    }
}
