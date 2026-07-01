using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace backend_csharp.Security;

public static class AuthorizationPolicies
{
    public const string AdminOnly = "AdminOnly";
    public const string ManageCatalog = "ManageCatalog";
    public const string PurchaseOrder = "PurchaseOrder";
    public const string DailyRevenueReport = "DailyRevenueReport";
    public const string BestSellingReport = "BestSellingReport";
    public const string ReceiveInventory = "ReceiveInventory";
    public const string InventoryCheck = "InventoryCheck";
    public const string CreateDrinkOrder = "CreateDrinkOrder";
    public const string CreateInvoice = "CreateInvoice";

    public static void AddQlbPolicies(AuthorizationOptions options)
    {
        options.AddPolicy(AdminOnly, policy => RequireAdmin(policy));
        options.AddPolicy(ManageCatalog, policy => RequirePermission(policy, "Q08"));
        options.AddPolicy(PurchaseOrder, policy => RequirePermission(policy, "Q04"));
        options.AddPolicy(DailyRevenueReport, policy => RequirePermission(policy, "Q05"));
        options.AddPolicy(BestSellingReport, policy => RequirePermission(policy, "Q07"));
        options.AddPolicy(ReceiveInventory, policy => RequirePermission(policy, "Q09"));
        options.AddPolicy(InventoryCheck, policy => RequirePermission(policy, "Q10"));
        options.AddPolicy(CreateDrinkOrder, policy => RequirePermission(policy, "Q01"));
        options.AddPolicy(CreateInvoice, policy => RequirePermission(policy, "Q03"));
    }

    private static void RequireAdmin(AuthorizationPolicyBuilder policy)
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => HasGroup(context.User, "N04"));
    }

    private static void RequirePermission(AuthorizationPolicyBuilder policy, string permissionCode)
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context => HasGroup(context.User, "N04") || HasPermission(context.User, permissionCode));
    }

    private static bool HasGroup(ClaimsPrincipal user, string groupCode)
    {
        return user.HasClaim("ma_nhom", groupCode);
    }

    private static bool HasPermission(ClaimsPrincipal user, string permissionCode)
    {
        return user.HasClaim("ma_quyen", permissionCode);
    }
}
