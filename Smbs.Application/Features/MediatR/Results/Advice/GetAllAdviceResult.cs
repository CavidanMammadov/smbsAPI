using System;

namespace Smbs.Application.Features.MediatR.Results.Advice
{
    public class GetAllAdviceResult
    {
        public int AdviceId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Duration { get; set; }
    }
}
