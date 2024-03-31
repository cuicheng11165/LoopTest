using Microsoft.IdentityModel.Clients.ActiveDirectory;

public class AzureDetails
{
    public static string ClientID = "<Client ID or App ID>";
    public static string ClientSecret = "<Client Secret or Password>";
    public static string TenantID = "<Tenant ID>";
    public static string AccessToken { get; set; }


    public static void GetAuthorizationToken()
    {
        ClientCredential cc = new ClientCredential(AzureDetails.ClientID, AzureDetails.ClientSecret);
        var context = new AuthenticationContext("https://login.microsoftonline.com/" + AzureDetails.TenantID);
        var result = context.AcquireTokenAsync("https://management.azure.com/", cc);
        if (result == null)
        {
            throw new InvalidOperationException("Failed to obtain the Access token");
        }

        AzureDetails.AccessToken = result.Result.AccessToken;
    }
}