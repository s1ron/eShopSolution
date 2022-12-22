﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopUtilities.Exeptions
{
    public class EShopException : Exception
    {
        public EShopException()
        {

        }
        public EShopException(string message):base(message)
        {
            
        }
        public EShopException(string message, Exception inner):base(message, inner)
        {

        }
    }
}