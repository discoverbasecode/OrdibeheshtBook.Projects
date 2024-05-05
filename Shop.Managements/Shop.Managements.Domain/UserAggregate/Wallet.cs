using Framework.Core.Domain;
using Framework.Core.Domain.Exceptions;
using Shop.Managements.Domain.UserAggregate.Enums;

namespace Shop.Managements.Domain.UserAggregate;


public class Wallet : EntityBase
{
    public long UserId { get; internal set; }

    public long Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }
    public WalletType WalletType { get; private set; }

    public Wallet(
        long price, string description,
        bool isFinally, DateTime finallyDate,
        WalletType walletType)
    {
        if (Price < 500) throw new InvalidDomainDataException("یزید 500 تومن هم نیست مبلغت");
        Price = price;
        Description = description;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
        WalletType = walletType;
    }

    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $"کد پیگیری شما {refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}