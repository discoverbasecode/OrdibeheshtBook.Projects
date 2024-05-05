using Framework.Core.Domain;
using Framework.Core.Domain.Exceptions;
using Shop.Managements.Domain.UserAggregate.Services;

namespace Shop.Managements.Domain.UserAggregate;

public class UserAddress : EntityBase
{


    public long UserId { get; internal set; }

    public string Name { get; private set; }
    public string NationalCode { get; private set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool ActiveAddress { get; set; }

    #region CRUD Address

    public UserAddress(
        string name,
        string nationalCode,
        string shire,
        string city,
        string postalCode,
        string postalAddress,
        string phoneNumber)
    {
        Name = name;
        NationalCode = nationalCode;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        ActiveAddress = false;
    }

    public void EditUserAddress(
        string name,
        string nationalCode,
        string shire,
        string city,
        string postalCode,
        string postalAddress,
        string phoneNumber)
    {
        ValidationRules(name, nationalCode, shire, city, postalCode, postalAddress, phoneNumber);
        Name = name;
        NationalCode = nationalCode;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        UpdateDate = DateTime.Now;
    }


    public void SetActive() => ActiveAddress = true;



    #endregion



    #region Validation Rules

    private void ValidationRules(
        string name,
        string nationalCode,
        string shire,
        string city,
        string postalCode,
        string postalAddress,
        string phoneNumber
        )
    {
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("کد ملی صحیح نیست");

    }

    #endregion
}