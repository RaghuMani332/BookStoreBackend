using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interface
{
    public interface IWishListBL
    {
        bool addWishList(WishListRequest request,int Uid);
        bool deleteWishList(int uId, int cartId);
        List<WishList> getWishList(int uId);
    }
}
