using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTests
{
    public class EmailTemplate
    {
        /// <summary>
        /// Gets or sets the template name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public string Subject { get; set; }

        public EmailContact From { get; set; }

        public List<EmailContact> CC { get; set; }

        public List<EmailContact> BCC { get; set; }

        public List<EmailContact> To { get; set; }

        public string Body { get; set; }

        public EmailTemplate()
        {
            From = new EmailContact();
            To = new List<EmailContact>();
            CC = new List<EmailContact>();
            BCC = new List<EmailContact>();
        }
    }

    public class EmailContact
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
