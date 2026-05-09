using CarBookProject.Application.DTO_s;
using CarBookProject.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result)
		{
			var cliams = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(result.Role))
				cliams.Add(new Claim(ClaimTypes.Role, result.Role));

			cliams.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

			if (!string.IsNullOrWhiteSpace(result.Username))
				cliams.Add(new Claim("Username", result.Username));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: cliams, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials : signingCredentials); ;

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
		}
	}
}
