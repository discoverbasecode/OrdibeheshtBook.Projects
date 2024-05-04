﻿namespace Shop.Managements.Domain.UserAggregate.Services;

public interface IUserDomainService
{
    bool IsEmailExist(string email);
    bool IsPhoneNumberExist(string phoneNumber);
}