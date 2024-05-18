using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Service
{
    public class AddressRL(DapperContext context) : IAddressRL
    {
        public bool addAddress(Address address)
        {
            IDbConnection con=context.CreateConnection();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Address", address.address);
                parameters.Add("City", address.city);
                parameters.Add("State", address.state);
                parameters.Add("Type", address.type);
                parameters.Add("UserId", address.userId);

                con.Execute("InsertAddress", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logging framework)
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Address> getAllAddress(int userId)
        {
            IDbConnection con= context.CreateConnection();
          return  con.Query<Address>("getAddressByUserId",new  { userId },commandType:CommandType.StoredProcedure).ToList();
        }
    }
}
