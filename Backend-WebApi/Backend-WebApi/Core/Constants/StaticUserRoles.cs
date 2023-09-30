namespace Backend_WebApi.Core.Constants;

public static class StaticUserRoles
{
    //This class will be used to avoid typing errors

    public const string OWNER = "OWNER";
    public const string ADMIN = "ADMIN";
    public const string MANAGER = "MANAGER";
    public const string USER = "USER";
    public const string OwnerAdmin = "OWNER,ADMIN";
    public const string OwnerAdminmManager = "OWNER,ADMIN,MANAGER";
    public const string OwnerAdminmManagerUser = "OWNER,ADMIN,MANAGER,USER";
}
