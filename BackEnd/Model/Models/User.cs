using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class User : BaseModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
    }

}
