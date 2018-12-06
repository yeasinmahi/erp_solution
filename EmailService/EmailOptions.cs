using System;
using System.Collections.Generic;
using System.Reflection;

namespace EmailService
{
    public class EmailOptions
    {
        public List<string> ToAddress { get; set; }
        public string ToAddressDisplayName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Attachment { get; set; }
        
    }
}
