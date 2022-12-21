using Consultorio.Business.Modelos;
using System.Collections.Generic;
using System;

namespace Api_Consultorio.Modelos
{
    public class ClienteParameters//: QuerryStringParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
