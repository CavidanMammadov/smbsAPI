using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Messages
{
    public class MessageResult
    {
        public int MessageId { get; set; }
        public string MessageNameAndSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessagePhoneNumber { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
    }
}
