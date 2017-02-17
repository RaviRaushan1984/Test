using System;
using System.Collections.Generic;
using ContactManagement_BAL.Generic;
using ContactManagement_Entities.Masters;
using CentralExpenseManager_DAL.Masters;
using ContactManagement_Entities.Common;

namespace ContactManagement_BAL.Masters
{
    public class City_BAL : GenericClass<City>
    {
        public override List<City> Select(City obj)
        {
            return (new City_DAL()).Select(obj);
        }

        public override MethodResponse Insert(ref City obj)
        {
            obj.OperationToPerform = MethodOperation.Insert;

            (new City_DAL()).Insert(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Update(ref City obj)
        {
            obj.OperationToPerform = MethodOperation.Update;

            (new City_DAL()).Update(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Delete(ref City obj)
        {
            obj.OperationToPerform = MethodOperation.Delete;

            (new City_DAL()).Delete(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }
    }
}
