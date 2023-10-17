using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class RoleAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public RoleAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var user = context.User;

        if (user != null && user.Identity.IsAuthenticated)
        {
            // Check if the user has the required role
            if (!IsUserAuthorized(user))
            {
                context.Response.StatusCode = 403; // Forbidden
                return;
            }
        }

        await _next(context);
    }

    private bool IsUserAuthorized(ClaimsPrincipal user)
    {
        // Implement your role-based authorization logic here
        // You can check user.Roles or any other claims to determine authorization

        // Example: Allow access if the user has the 'Admin' role
        return user.IsInRole("Admin");
    }
}
