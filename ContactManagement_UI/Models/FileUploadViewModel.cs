using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement_UI.Models
{
    public class FileUploadViewModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] FileBytes { get; set; }

        public int UserId { get; set; }

        public DateTime UploadedDate { get; set; }

        public bool IsProcessed { get; set; }
    }
}