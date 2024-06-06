using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ShopMilk.HelperAuthen
{
    public class JWTAuthen
    {
        public static string Issuer {  get; set; }
        public static string Audience { get; set; }
        public static SymmetricSecurityKey Key {  get; set; }
        public static string KeyString {  get; set; }
        public static ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandlder = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandlder.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = Key,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                ClockSkew = TimeSpan.Zero // Không cho phép độ lệch thời gian
            }, out _);
            return claimsPrincipal;
        }
        //Lấy ID user từ token JWT
        public static string GetUserId(string token)
        {
            var claimsPrincipal = DecodeToken(token);

            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim != null)
            {
                return userIdClaim;
            }
            return "";
        }
        //Hash password
        public static string hashPassword(string password)
        {
            if (password != null)
            {
                var saltBytes = Encoding.ASCII.GetBytes(KeyString);
                var passwordBytes = Encoding.ASCII.GetBytes(password);
                var hmac = new HMACSHA256(saltBytes);
                var hash = hmac.ComputeHash(passwordBytes);
                var hexhash = BitConverter.ToString(hash).Replace("-", "");
                return hexhash;
            }
            else
            {
                return "";
            }
        }
        //
        public static string GenerateToke(string id, string role)
        {
            var credientials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,id),
                new Claim(ClaimTypes.Role,role),
            };
            var token = new JwtSecurityToken(
                Issuer,
                Audience,
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credientials
             );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
