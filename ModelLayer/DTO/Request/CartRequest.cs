using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Request
{
    public class CartRequest
    {
        public int quantity { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
    }
}
