using System;

namespace Smbs.Application.Features.MediatR.Results.Advice
{
    public class GetByIdAdviceResult
    {
        public int AdviceId { get; set; }
        public string AdviceTitle { get; set; }
        public string AdviceImage { get; set; }
        public string AdviceDescription { get; set; }
        public string AdviceContent { get; set; }
        public DateTime AdviceCreated { get; set; }
        public string AdviceDuration { get; set; }
    }
}
