using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.IdentityToken
{
    public interface ITokenService
    {
        JwtSecurityToken GenerationAcessToken(IEnumerable<Claim> claims, IConfiguration _config);
    }
}
