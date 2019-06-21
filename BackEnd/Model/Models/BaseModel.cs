using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class BaseModel
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
