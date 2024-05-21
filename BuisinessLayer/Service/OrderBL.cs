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
    public class OrderBL(IOrderRL order):IOrderBL
    {
        public List<Object> GetOrder(int userId)
        {
            return order.GetOrder(userId);
        }
        public List<Object> AddOrder(OrderRequest request, int userId)
        {
            return order.AddOrder(request, userId);
        }
    }
}
