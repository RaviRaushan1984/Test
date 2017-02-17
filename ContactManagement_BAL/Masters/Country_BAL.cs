using System;
using System.Collections.Generic;
using ContactManagement_BAL.Generic;
using ContactManagement_DAL.Masters;
using ContactManagement_Entities.Common;
using ContactManagement_Entities.Masters;

namespace ContactManagement_BAL.Masters
{
    public class Country_BAL : GenericClass<Country>
    {
        bool objIsValid = true;

        public override List<Country> Select(Country obj)
        {
            return (new Country_DAL()).Select(obj);
        }

        public override MethodResponse Insert(ref Country obj)
        {
            obj.OperationToPerform = MethodOperation.Insert;

            (new Country_DAL()).Insert(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Update(ref Country obj)
        {
            obj.OperationToPerform = MethodOperation.Update;

            (new Country_DAL()).Update(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Delete(ref Country obj)
        {
            obj.OperationToPerform = MethodOperation.Delete;

            (new Country_DAL()).Delete(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }
    }
}
