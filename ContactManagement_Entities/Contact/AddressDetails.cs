using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement_Entities.Contact
{
    public class AddressDetails : Common.CommonProperties
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string Address_Line_1 { get; set; }

        public string Address_Line_2 { get; set; }

        public string Address_Line_3 { get; set; }

        public int Country_Id { get; set; }

        public string Country_Name { get; set; }

        public int State_Id { get; set; }

        public string State_Name { get; set; }

        public int City_Id { get; set; }

        public string City_Name { get; set; }

        public string PinCode { get; set; }

        public bool IsPrimary { get; set; }
    }
}
