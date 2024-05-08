using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Responce
{
    public class ResponceDto<T>
    {

        public T data { get; set; }
        public String messasge { get; set; }
        public bool isSuccess { get; set; } = true;

    }
}
