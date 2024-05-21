using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System.Data;

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
                parameters.Add("name", address.name);
                parameters.Add("mobileNumber", address.mobileNumber);

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

        
        public bool deleteAddress(int addressId)
        {
            string query = "update address set isdeleted=@flag where addressId=@Id";
            return context.CreateConnection().Execute(query, new { flag = true, Id = addressId }) > 0;
        }

        public List<Address> getAllAddress(int userId)
        {
            IDbConnection con= context.CreateConnection();
          return  con.Query<Address>("getAddressByUserId",new  { userId },commandType:CommandType.StoredProcedure).ToList();
        }

        /* public bool updateAddress(Address a)
         {
             throw new NotImplementedException();
         }*/
        public bool updateAddress(Address address)
        {
            using (IDbConnection con = context.CreateConnection())
            {
                try
                {
                    string query = @"
                UPDATE Address
                SET 
                    Address = @Address,
                    City = @City,
                    State = @State,
                    Type = @Type,
                    name = @name,
                    mobileNumber = @mobileNumber
                WHERE AddressId = @AddressId";

                    var parameters = new DynamicParameters();
                    parameters.Add("AddressId", address.addressId);
                    parameters.Add("Address", address.address);
                    parameters.Add("City", address.city);
                    parameters.Add("State", address.state);
                    parameters.Add("Type", address.type);
                   // parameters.Add("UserId", address.userId);
                    parameters.Add("name", address.name);
                    parameters.Add("mobileNumber", address.mobileNumber);

                    int rowsAffected = con.Execute(query, parameters);
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception (e.g., using a logging framework)
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

    }
}
