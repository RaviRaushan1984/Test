using System;

namespace ContactManagement_Entities.Common
{
    /// <summary>
    /// Contains propertes which are common through out application
    /// </summary>
    public abstract class CommonProperties
    {
        /// <summary>
        /// Represents record's active status
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Represents record's deleted status
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Represents created by user id
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Represents record's creation time
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Represents record's modified by user id
        /// </summary>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Represents record's modified time
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Represents created by user name
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// Represents modified by user name
        /// </summary>
        public string ModifiedByUserName { get; set; }

        /// <summary>
        /// Represents response status of last request
        /// </summary>
        public bool ResponseStatus { get; set; }

        /// <summary>
        /// Represents response object returned from Data Access Layer
        /// </summary>
        public object DALResponse { get; set; }

        /// <summary>
        /// Represents operation type to be perform
        /// </summary>
        public MethodOperation OperationToPerform { get; set; }
    }
}
