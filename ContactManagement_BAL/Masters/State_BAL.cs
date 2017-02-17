using System;
using System.Collections.Generic;
using ContactManagement_BAL.Generic;
using ContactManagement_Entities.Masters;
using CentralExpenseManager_DAL.Masters;
using ContactManagement_Entities.Common;

namespace ContactManagement_BAL.Masters
{
    public class State_BAL : GenericClass<State>
    {
        public override List<State> Select(State obj)
        {
            return (new State_DAL()).Select(obj);
        }

        public override MethodResponse Insert(ref State obj)
        {
            obj.OperationToPerform = MethodOperation.Insert;

            (new State_DAL()).Insert(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Update(ref State obj)
        {
            obj.OperationToPerform = MethodOperation.Update;

            (new State_DAL()).Update(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Delete(ref State obj)
        {
            obj.OperationToPerform = MethodOperation.Delete;

            (new State_DAL()).Delete(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }
    }
}
