using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddDomainService]
internal class DefaultLoyaltyConfigurationValidationService : LoyaltyConfigurationValidationService
{
    private const decimal MinEarningRatio = 0.01m; // Minimum 0.01 points per currency unit
    private const decimal MaxEarningRatio = 100m;  // Maximum 100 points per currency unit
    private const decimal MinRedemptionRatio = 1m; // Minimum 1 point per discount unit
    private const decimal MaxRedemptionRatio = 10000m; // Maximum 10000 points per discount unit
    private const int MinExpirationMonths = 1;     // Minimum 1 month expiration
    private const int MaxExpirationMonths = 120;   // Maximum 10 years expiration

    public ConfigurationValidationResult ValidateConfiguration(LoyaltyConfiguration configuration)
    {
        var errors = new List<string>();

        if (!IsValidEarningRatio(configuration.EarningRatio))
        {
            errors.Add($"Earning ratio must be between {MinEarningRatio} and {MaxEarningRatio} points per currency unit");
        }

        if (!IsValidRedemptionRatio(configuration.RedemptionRatio))
        {
            errors.Add($"Redemption ratio must be between {MinRedemptionRatio} and {MaxRedemptionRatio} points per discount unit");
        }

        if (!IsValidExpirationPeriod(configuration.ExpirationMonths))
        {
            errors.Add($"Expiration period must be between {MinExpirationMonths} and {MaxExpirationMonths} months");
        }

        if (configuration.MinimumOrderAmount < 0)
        {
            errors.Add("Minimum order amount cannot be negative");
        }

        // Business rule: Ensure redemption provides reasonable value
        // Example: If earning ratio is 1 point per $1 and redemption is 100 points per $1 discount,
        // customer needs to spend $100 to get $1 back (1% return)
        var effectiveReturnRate = configuration.EarningRatio / configuration.RedemptionRatio;
        if (effectiveReturnRate > 0.20m) // More than 20% return rate might be too generous
        {
            errors.Add("Configuration provides excessive return rate (>20%). Consider adjusting earning or redemption ratios");
        }

        if (effectiveReturnRate < 0.001m) // Less than 0.1% return rate might be too stingy
        {
            errors.Add("Configuration provides minimal return rate (<0.1%). Consider adjusting earning or redemption ratios");
        }

        return errors.Any() 
            ? ConfigurationValidationResult.Invalid(errors)
            : ConfigurationValidationResult.Valid();
    }

    public ConfigurationValidationResult ValidateConfigurationChange(
        LoyaltyConfiguration currentConfig, 
        LoyaltyConfiguration newConfig)
    {
        var errors = new List<string>();

        // First validate the new configuration itself
        var basicValidation = ValidateConfiguration(newConfig);
        if (!basicValidation.IsValid)
        {
            errors.AddRange(basicValidation.Errors);
        }

        // Additional validation for configuration changes
        
        // Prevent drastic changes that could harm customer trust
        var earningRatioChange = Math.Abs(newConfig.EarningRatio - currentConfig.EarningRatio) / currentConfig.EarningRatio;
        if (earningRatioChange > 0.50m) // More than 50% change
        {
            errors.Add("Earning ratio change exceeds 50% which may negatively impact customer experience");
        }

        var redemptionRatioChange = Math.Abs(newConfig.RedemptionRatio - currentConfig.RedemptionRatio) / currentConfig.RedemptionRatio;
        if (redemptionRatioChange > 0.50m) // More than 50% change
        {
            errors.Add("Redemption ratio change exceeds 50% which may negatively impact customer experience");
        }

        // Prevent shortening expiration period too drastically
        if (newConfig.ExpirationMonths < currentConfig.ExpirationMonths * 0.5m)
        {
            errors.Add("Cannot reduce expiration period by more than 50% as it may affect existing customer points");
        }

        // Prevent increasing minimum order amount too drastically
        if (newConfig.MinimumOrderAmount > currentConfig.MinimumOrderAmount * 2m)
        {
            errors.Add("Cannot increase minimum order amount by more than 100% as it may exclude existing customers");
        }

        return errors.Any() 
            ? ConfigurationValidationResult.Invalid(errors)
            : ConfigurationValidationResult.Valid();
    }

    public bool IsValidEarningRatio(decimal earningRatio)
    {
        return earningRatio >= MinEarningRatio && earningRatio <= MaxEarningRatio;
    }

    public bool IsValidRedemptionRatio(decimal redemptionRatio)
    {
        return redemptionRatio >= MinRedemptionRatio && redemptionRatio <= MaxRedemptionRatio;
    }

    public bool IsValidExpirationPeriod(int expirationMonths)
    {
        return expirationMonths >= MinExpirationMonths && expirationMonths <= MaxExpirationMonths;
    }
}