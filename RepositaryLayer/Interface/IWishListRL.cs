using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Interface
{
    public interface IWishListRL
    {
        bool addWishList(WishList wishList);
        bool deleteWishList(int uId, int cartId);
       List< WishList> getWishList(int uId);
    }
}
