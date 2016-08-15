using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHours.Models
{
    public class Message
    {
        public string Subject { get; set; }
        public EmailAddress from { get; set; }
    }

    public class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}