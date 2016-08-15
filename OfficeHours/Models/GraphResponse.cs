using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHours.Models
{
    public class GraphResponse
    {
        public string ProContext { get; set; }
        public string ProNextLink { get; set; }
        public List<Message> MessageList { get; set; }
    }
}