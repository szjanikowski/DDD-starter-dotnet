using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddDomainService]
public interface LoyaltyConfigurationValidationService
{
    /// <summary>
    /// Validates a loyalty configuration for business rule compliance
    /// </summary>
    /// <param name="configuration">Configuration to validate</param>
    /// <returns>Validation result with any errors</returns>
    ConfigurationValidationResult ValidateConfiguration(LoyaltyConfiguration configuration);
    
    /// <summary>
    /// Validates if configuration changes are allowed based on current system state
    /// </summary>
    /// <param name="currentConfig">Current active configuration</param>
    /// <param name="newConfig">Proposed new configuration</param>
    /// <returns>Validation result indicating if change is allowed</returns>
    ConfigurationValidationResult ValidateConfigurationChange(
        LoyaltyConfiguration currentConfig, 
        LoyaltyConfiguration newConfig);
    
    /// <summary>
    /// Validates earning ratio values for business constraints
    /// </summary>
    /// <param name="earningRatio">Points per currency unit ratio</param>
    /// <returns>True if ratio is within acceptable business limits</returns>
    bool IsValidEarningRatio(decimal earningRatio);
    
    /// <summary>
    /// Validates redemption ratio values for business constraints
    /// </summary>
    /// <param name="redemptionRatio">Points per discount unit ratio</param>
    /// <returns>True if ratio is within acceptable business limits</returns>
    bool IsValidRedemptionRatio(decimal redemptionRatio);
    
    /// <summary>
    /// Validates expiration period for business constraints
    /// </summary>
    /// <param name="expirationMonths">Number of months until points expire</param>
    /// <returns>True if expiration period is within acceptable business limits</returns>
    bool IsValidExpirationPeriod(int expirationMonths);
}

/// <summary>
/// Result of configuration validation with detailed error information
/// </summary>
public readonly struct ConfigurationValidationResult
{
    public bool IsValid { get; }
    public IReadOnlyList<string> Errors { get; }
    
    private ConfigurationValidationResult(bool isValid, IReadOnlyList<string> errors)
    {
        IsValid = isValid;
        Errors = errors;
    }
    
    public static ConfigurationValidationResult Valid() => 
        new(true, Array.Empty<string>());
    
    public static ConfigurationValidationResult Invalid(params string[] errors) => 
        new(false, errors.ToList().AsReadOnly());
    
    public static ConfigurationValidationResult Invalid(IEnumerable<string> errors) => 
        new(false, errors.ToList().AsReadOnly());
}