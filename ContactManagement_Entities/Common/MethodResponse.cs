using System.Collections.Generic;

namespace ContactManagement_Entities.Common
{
    /// <summary>
    /// Contains properties which represents method's response
    /// </summary>
    public class MethodResponse
    {
        /// <summary>
        /// Represents unique id of the last added record
        /// </summary>
        public int AffectedId { get; set; }

        /// <summary>
        /// Represents last response status
        /// </summary>
        public bool ResponseStatus { get; set; }

        /// <summary>
        /// Represents response message of the last executed operation
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Represents response data returned from various layers
        /// </summary>
        public object ResponseData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Represents collection of validation summary
        /// </summary>
        public Dictionary<string, string> ValidationSummary { get; set; }
    }

    public enum MethodOperation
    {
        Insert,
        Update,
        Delete,
        IsExist
    }
}
