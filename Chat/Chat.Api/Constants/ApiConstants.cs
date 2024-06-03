namespace Chat.Api.Constants;

/// <summary>
/// Contains a API constants.
/// </summary>
public static class ApiConstants
{
    /// <summary>
    /// Contains a Configuration constants.
    /// </summary>
    public static class Configurations
    {
        /// <summary>
        /// The name of the cors policy name.
        /// </summary>
        public const string CorsPolicyName = nameof(CorsPolicyName);
    
        /// <summary>
        /// The name of the cors origin.
        /// </summary>
        public const string CorsOrigin = nameof(CorsOrigin);

        /// <summary>
        /// The name of the Azure AD.
        /// </summary>
        public const string AzureAd = nameof(AzureAd);

        /// <summary>
        /// The name of the swagger.
        /// </summary>
        public const string Swagger = nameof(Swagger);

        /// <summary>
        /// The name of the SQL connection string.
        /// </summary>
        public const string SqlConnectionString = nameof(SqlConnectionString);
    }
    
    /// <summary>
    /// Contains a Authentication constants.
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// The name of the claim type.
        /// </summary>
        public const string NameClaimType = "name";
    }
}