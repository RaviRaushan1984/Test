using System.Collections.Generic;
using ContactManagement_Entities.Common;

namespace ContactManagement_BAL.Generic
{
    public abstract class GenericClass<T>
    {
        public abstract List<T> Select(T obj);

        public abstract MethodResponse Insert(ref T obj);

        public abstract MethodResponse Update(ref T obj);

        public abstract MethodResponse Delete(ref T obj);

        //protected abstract MethodResponse ValidateObject(T objToValidate, out bool objIsValid);

        /// <summary>
        /// Method to return response message
        /// </summary>
        /// <param name="rData"></param>
        /// <param name="operationPerformed"></param>
        /// <returns></returns>
        protected MethodResponse SetResponseObject(string rData, MethodOperation operationPerformed)
        {
            MethodResponse methodResponseObj = null;

            var result = Cast(SetMessage(rData), new { IsSuccess = false, Response = string.Empty });

            
            switch (operationPerformed)
            {
                case MethodOperation.Insert:
                    methodResponseObj = new MethodResponse()
                    {
                        ResponseMessage = result.IsSuccess ? "Record has been added successfully." : result.Response,
                        ResponseStatus = result.IsSuccess
                    };
                    break;
                case MethodOperation.Update:
                    methodResponseObj = new MethodResponse()
                    {
                        ResponseMessage = result.IsSuccess ? "Record has been updated successfully." : result.Response,
                        ResponseStatus = result.IsSuccess
                    };
                    break;
                case MethodOperation.Delete:
                    methodResponseObj = new MethodResponse()
                    {
                        ResponseMessage = result.IsSuccess ? "Record has been deleted successfully." : result.Response,
                        ResponseStatus = result.IsSuccess
                    };
                    break;
                case MethodOperation.IsExist:
                    methodResponseObj = new MethodResponse()
                    {
                        ResponseMessage = result.Response,
                        ResponseStatus = result.IsSuccess
                    };
                    break;
            }
            return methodResponseObj;
        }

        private object SetMessage(string lastResponse)
        {
            switch (lastResponse)
            {
                case "-2":
                    return new { IsSuccess = false, Response = "Record already exists into database." };
                case "-1":
                    return new { IsSuccess = false, Response = "SQL error occured, please verify."};
                case "1002":
                    return new { IsSuccess = false, Response = "More than one row exists with same id, uptaion could cause issue." };
                case "1003":
                    return new { IsSuccess = false, Response = "No record found." };
                default:
                    return new { IsSuccess = true, Response = "Operation completed successfully." };
            }
        }

        private X Cast<X>(object obj, X type)
        {
            return (X)obj;
        }
    }
}
