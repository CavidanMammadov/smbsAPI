using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Contacts
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactLocation { get; set; }
    }
}
