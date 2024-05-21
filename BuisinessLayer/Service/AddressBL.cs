using BuisinessLayer.Interface;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using RepositaryLayer.Interface;
using RepositaryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Service
{
    public class AddressBL(IAddressRL repo) : IAddressBL
    {
        public bool addAddress(AddressRequest addressRequest, int userId)
        {
           return repo.addAddress(mapToEntity(addressRequest, userId));
        }

        public bool deleteAddress(int addressId)
        {
            return repo.deleteAddress(addressId);
        }

        public List<Address> getAllAddress(int userId)
        {
            return repo.getAllAddress(userId);
        }

        public bool updateAddress(AddressRequest address, int addressId)
        {
            Address a= new Address
            {
                city = address.city,
                address = address.address,
                state = address.state,
                type = address.type,
                mobileNumber = address.mobileNumber,
                name = address.name,
                addressId = addressId
            };
            return repo.updateAddress(a);
            
        }

        private Address mapToEntity(AddressRequest addressRequest, int userId)
        {
            return new Address
            {
                city = addressRequest.city,
                address=addressRequest.address,
                state = addressRequest.state,
                type = addressRequest.type,
                userId=userId,
                mobileNumber= addressRequest.mobileNumber,
                name= addressRequest.name
            };
        }
    }
}
