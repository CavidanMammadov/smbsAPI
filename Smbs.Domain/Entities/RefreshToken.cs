using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string RefreshTokenToken { get; set; }
        public DateTime RefreshTokenExpireIn { get; set; }
        public int RefreshTokenUserId { get; set; }
    }
}
