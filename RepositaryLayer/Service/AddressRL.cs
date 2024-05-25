
using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RepositaryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private readonly DapperContext context;

        public AddressRL(DapperContext context)
        {
            this.context = context;
        }

        public bool addAddress(Address address)
        {
            using (IDbConnection con = context.CreateConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("Address", address.address);
                    parameters.Add("City", address.city);
                    parameters.Add("State", address.state);
                    parameters.Add("Type", address.type);
                    parameters.Add("UserId", address.userId);
                    parameters.Add("Name", address.name);
                    parameters.Add("MobileNumber", address.mobileNumber);

                    con.Execute("InsertAddress", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {

                    //
                    // Log the exception (e.g., using a logging framework)
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }



        public bool deleteAddress(int addressId)
        {
            using (IDbConnection con = context.CreateConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("AddressId", addressId);

                    int rowsAffected = con.Execute("DeleteAddress", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception (e.g., using a logging framework)
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }



        public List<Address> getAllAddress(int userId)
        {
            using (IDbConnection con = context.CreateConnection())
            {
                return con.Query<Address>("GetAddressByUserId", new { userId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }



        public bool updateAddress(Address address)
        {
            using (IDbConnection con = context.CreateConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("AddressId", address.addressId);
                    parameters.Add("Address", address.address);
                    parameters.Add("City", address.city);
                    parameters.Add("State", address.state);
                    parameters.Add("Type", address.type);
                    parameters.Add("Name", address.name);
                    parameters.Add("MobileNumber", address.mobileNumber);

                    int rowsAffected = con.Execute("UpdateAddress", parameters, commandType: CommandType.StoredProcedure);
                    return true;
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
