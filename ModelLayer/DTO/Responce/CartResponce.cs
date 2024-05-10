using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Responce
{
    public class CartResponce
    {
        public int CartId { get; set; }
        public int QuantityInCart { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsOrdered { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int QuantityAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
