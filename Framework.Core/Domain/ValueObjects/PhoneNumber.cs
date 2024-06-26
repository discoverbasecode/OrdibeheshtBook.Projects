﻿using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.Utils;

namespace Framework.Core.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
            throw new InvalidDomainDataException("شماره تلفن نامعتبر است");
        Value = value;
    }

    public string Value { get; private set; }
}