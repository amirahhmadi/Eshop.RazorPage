﻿using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.UserAddress;
using Eshop.RazorPage.ViewModels.Users.Addresses;

namespace Eshop.RazorPage.Services.UserAddress;

public interface IUserAddressService
{
    Task<ApiResult> CreateAddress(CreateUserAddressCommand command);
    Task<ApiResult> EditAddress(EditUserAddressCommand command);
    Task<ApiResult> DeleteAddress(long addressId);
    Task<ApiResult> SetActiveAddress(long addressId);

    Task<AddressDto?> GetAddressById(long id);
    Task<List<AddressDto>> GetUserAddresses();
}