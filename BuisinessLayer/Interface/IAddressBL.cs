using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interface
{
    public interface IAddressBL
    {
        bool addAddress(AddressRequest addressRequest, int userId);
        bool deleteAddress(int addressId);
        List<Address> getAllAddress(int userId);
        bool updateAddress(AddressRequest address, int addressId);
    }
}
