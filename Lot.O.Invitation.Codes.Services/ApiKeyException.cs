﻿/*
 * Third Party Code that is not to be changed.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Lot.O.Invitation.Codes.Services
{
    public class ApiKeyException : Exception    
    {
        public ApiKeyException(string message)
            : base(message) { }
    }
}
