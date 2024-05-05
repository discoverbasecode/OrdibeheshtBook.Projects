using Framework.Core.Domain;

namespace Shop.Managements.Domain.UserAggregate;

public class UserRole : EntityBase
{
    public UserRole(long roleId)
    {
        RoleId = roleId;
    }

    public long UserId { get;  internal set; }
    public long RoleId { get; private set; }

}