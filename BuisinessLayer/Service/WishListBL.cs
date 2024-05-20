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
    public class WishListBL(IWishListRL repositary) : IWishListBL
    {
        private WishList mapToEntity(WishListRequest request, int Uid)
        {
            return new WishList
            {
                BookId = request.BookId,
                UserId = Uid
            };
        }

        public bool addWishList(WishListRequest request,int Uid)
        {
            return repositary.addWishList(mapToEntity(request,Uid));
        }

        

        public bool deleteWishList(int uId, int wishListId)
        {
            return repositary.deleteWishList(uId, wishListId);
        }

        public List<WishList> getWishList(int uId)
        {
            return repositary.getWishList(uId);
        }
    } 
}
