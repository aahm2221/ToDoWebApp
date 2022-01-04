using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class Task
    {
        public int Id { get; set; }
        public string Description{ get; set;  }
        public bool IsCompleted{ set; get; }
        public DateTime LastUpdated{ get; set; }
    }
}
