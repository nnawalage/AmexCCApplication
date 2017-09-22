using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.Common.NotificationUtility
{
    public class Email
    {
        /// <summary>
        /// Gets or sets From address.
        /// Set the value if the email needs to be sent using a specific from address
        /// Otherwise do not set, value will be set to default from 
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public string From { get; set; }

        public IList<string> To { get; set; }

        public string Subject { get; set; }

        public string  Body { get; set; }
    }
}
