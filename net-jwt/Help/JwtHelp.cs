using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using net_jwt.Models;

namespace net_jwt.Help;

public class JwtHelp
{
    public static string createJWT(User user)
    {
        var key = Encoding.UTF8.GetBytes("Password"); // key encoded
        var securityKey = new SymmetricSecurityKey(key); // create object
        var handler = new JwtSecurityTokenHandler(); // for creating jwt
        
        
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // header
        var tokenDescriptor = new SecurityTokenDescriptor // issuer, audience?
        {
            SigningCredentials = credentials, // header
            Expires = DateTime.Now.AddHours(1),
            Subject = GenerateClaims(user) //payload
        };
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claimsIdentity = new ClaimsIdentity(); // set claims for the payload
        
        claimsIdentity.AddClaim(new Claim("id", user.Id.ToString()));
        claimsIdentity.AddClaim(new Claim("username", user.Username));
        
        // maybe add roles here later
        return claimsIdentity;
    }
}