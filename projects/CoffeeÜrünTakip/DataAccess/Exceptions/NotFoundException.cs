using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException (int id) : base($"id si :{id}, olan kategoride ürün yoktur.")
        {

        }


    }

    public class BusinessException : Exception
    {

    }
}

