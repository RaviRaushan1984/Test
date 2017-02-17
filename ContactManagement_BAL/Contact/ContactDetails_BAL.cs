using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement_BAL.Generic;
using ContactManagement_Entities.Contact;
using ContactManagement_Entities.Common;
using ContactManagement_DAL.Contact;

namespace ContactManagement_BAL.Contact
{
    public class ContactDetails_BAL : GenericClass<ContactDetails>
    {
        MethodResponse methodResponseObj;
        bool objIsValid = true;

        public override List<ContactDetails> Select(ContactDetails obj)
        {
            return (new ContactDetails_DAL()).Select(obj);
        }

        public ContactDetails SingleSelect(int contactId)
        {
            return (new ContactDetails_DAL()).SingleSelect(contactId);
        }

        public override MethodResponse Insert(ref ContactDetails obj)
        {
            obj.OperationToPerform = MethodOperation.Insert;

            (new ContactDetails_DAL()).Insert(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Update(ref ContactDetails obj)
        {
            obj.OperationToPerform = MethodOperation.Update;

            (new ContactDetails_DAL()).Update(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public override MethodResponse Delete(ref ContactDetails obj)
        {
            obj.OperationToPerform = MethodOperation.Delete;

            (new ContactDetails_DAL()).Delete(ref obj);

            return SetResponseObject(obj.DALResponse.ToString(), obj.OperationToPerform);
        }

        public int UploadContacts(ContactDetails obj)
        {
            return (new ContactDetails_DAL()).UploadContacts(obj);
        }
    }
}
