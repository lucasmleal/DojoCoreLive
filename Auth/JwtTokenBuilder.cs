using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace DojoAspNetCore.Auth
{
    public sealed class JwtTokenBuilder
    {        
        public JwtTokenBuilder(SecurityKey securityKey, Dictionary<string, string> claims, int expiryInMinutes)
        {
            this.securityKey = securityKey;
            this.claims = claims;
            this.expiryInMinutes = expiryInMinutes;    
        }
        private SecurityKey securityKey = null;

        private Dictionary<string, string> claims = new Dictionary<string, string>();

        private int expiryInMinutes = 3;

        public JwtToken Build()
        {
            var claims = new List<Claim>
            {
                new Claim("nome", "Teste Token Core 2.0")
            }
            .Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken (
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                signingCredentials: new SigningCredentials (
                    this.securityKey,
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtToken(token);
        }
    }
}