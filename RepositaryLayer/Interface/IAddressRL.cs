using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Interface
{
    public interface IAddressRL
    {
        bool addAddress(Address address);
        bool deleteAddress(int addressId);
        List<Address> getAllAddress(int userId);
        bool updateAddress(Address a);
    }
}
