namespace AbpCompanyName.AbpProjectName.Authorization.Accounts.Dto;

public class IsTenantAvailableOutput
{
    public TenantAvailabilityState State { get; set; }

    public System.Guid? TenantId { get; set; }

    public IsTenantAvailableOutput()
    {
    }

    public IsTenantAvailableOutput(TenantAvailabilityState state, System.Guid? tenantId = null)
    {
        State = state;
        TenantId = tenantId;
    }
}
