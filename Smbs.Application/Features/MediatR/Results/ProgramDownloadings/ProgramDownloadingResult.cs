using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.ProgramDownloadings
{
    public class ProgramDownloadingResult
    {
        public int ProgramDownloadingId { get; set; }
        public string ProgramDownloadingName { get; set; }
        public string ProgramDownloadingSurname { get; set; }
        public string ProgramDownloadingEmail { get; set; }
        public string ProgramDownloadingBrochureTitle { get; set; }
        public string ProgramDownloadingPhoneNumber { get; set; }
    }
}
