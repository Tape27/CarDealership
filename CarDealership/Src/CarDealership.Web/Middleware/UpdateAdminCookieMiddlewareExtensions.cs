namespace CarDealership.Web.Middleware
{
    public static class UpdateAdminCookieMiddlewareExtensions
    {
        public static IApplicationBuilder UseUpdateAdminCookies(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UpdateAdminCookieMiddleware>();
        }
    }
}
