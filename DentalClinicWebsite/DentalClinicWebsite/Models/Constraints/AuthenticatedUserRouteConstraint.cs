namespace DentalClinicWebsite.Models.Constraints
{
    public class AuthenticatedUserRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool isAuthenticated = httpContext.User.Identity.IsAuthenticated;
            return !isAuthenticated;
        }
    }
}
