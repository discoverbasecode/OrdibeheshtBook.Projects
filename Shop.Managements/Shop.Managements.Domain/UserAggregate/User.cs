using Framework.Core.Domain;
using Framework.Core.Domain.Exceptions;
using Shop.Managements.Domain.UserAggregate.Enums;
using Shop.Managements.Domain.UserAggregate.Services;
using System.Net;

namespace Shop.Managements.Domain.UserAggregate;

public class User : AggregateRoot
{


    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Avatar { get; private set; }
    public string Password { get; private set; }
    public Genders Gender { get; private set; }
    public List<UserRole> UserRoles { get; private set; }
    public List<Wallet> Wallets { get; private set; }
    public List<UserAddress> UserAddresses { get; private set; }

    #region  Constacture - Edit -  User Methods

    public User(string name, string family,
        string phoneNumber, string email,
        string password, Genders gender,
        IUserDomainService userService)
    {
        ValidationRules(phoneNumber, email, userService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
    }

    public void EditUser(string name, string family,
        string phoneNumber, string email,
        string avatar, string password,
        IUserDomainService userService)
    {
        ValidationRules(phoneNumber, email, userService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Avatar = avatar;
        Password = password;
        UpdateDate = DateTime.Now;
    }

    #endregion
  
    #region Add - Edit - Remove User Address Methods


    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        UserAddresses.Add(address);
    }

    public void EditAddress(UserAddress address)
    {
        var findAddress = UserAddresses.FirstOrDefault(c => c.UserId == address.Id);
        if (findAddress == null)
            throw new NullOrEmptyDomainDataException("آدرس یافت نشد");

        UserAddresses.Remove(findAddress);
        findAddress.UpdateDate = DateTime.Now;
        UserAddresses.Add(address);

    }

    public void RemoveAddress(long addressId)
    {
        var findAddress = UserAddresses.FirstOrDefault(c => c.UserId == addressId);
        if (findAddress == null)
            throw new NullOrEmptyDomainDataException("آدرس یافت نشد");
        findAddress.RemoveDate = DateTime.Now;
        findAddress.IsRemove = true;
        UserAddresses.Remove(findAddress);
    }

    //public void StatusAddress(long addressId)
    //{
    //    var findAddress = UserAddresses.FirstOrDefault(c => c.UserId == addressId);
    //    if (findAddress == null)
    //        throw new NullOrEmptyDomainDataException("آدرس یافت نشد");

    //    UserAddresses.Remove(findAddress);
    //    findAddress.UpdateDate = DateTime.Now;
    //    findAddress.IsRemove;
    //    UserAddresses.Add(address);
    //}


    #endregion


}





