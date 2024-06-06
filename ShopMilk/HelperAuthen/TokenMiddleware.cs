using System.IdentityModel.Tokens.Jwt;

namespace ShopMilk.HelperAuthen
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenMiddleware(RequestDelegate next) { }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                string token = context.Request.Headers["Authentication"].ToString();
                if (string.IsNullOrEmpty(token))
                {
                    context.Items["UserId"] = "";
                }
                else
                {
                    string id = token.ToString().Substring(7);
                    string UserId = token = JWTAuthen.GetUserId(id);
                    context.Items["UserId"] = UserId;
                }
                await _next(context);
            }
            catch
            {
                context.Items["UserId"] = "";
                await _next(context);
            }
        }
    }
}
