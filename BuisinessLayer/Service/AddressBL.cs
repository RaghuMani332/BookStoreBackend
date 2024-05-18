using BuisinessLayer.Interface;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using RepositaryLayer.Interface;
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

        public List<Address> getAllAddress(int userId)
        {
            return repo.getAllAddress(userId);
        }

        private Address mapToEntity(AddressRequest addressRequest, int userId)
        {
            return new Address
            {
                city = addressRequest.city,
                address=addressRequest.address,
                state = addressRequest.state,
                type = addressRequest.type,
                userId=userId
            };
        }
    }
}
