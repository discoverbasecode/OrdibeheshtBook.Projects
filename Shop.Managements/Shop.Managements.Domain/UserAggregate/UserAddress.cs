using Framework.Core.Domain;

namespace Shop.Managements.Domain.UserAggregate;

public class UserAddress : EntityBase
{
    public long UserId { get; set; }

}