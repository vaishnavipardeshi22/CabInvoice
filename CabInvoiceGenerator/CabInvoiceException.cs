// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_USER, 
            INVALID_RIDE_TYPE,
        }

        public CabInvoiceException(string message, ExceptionType exceptionType)
            : base(message)
        {
            this.exceptionType = exceptionType;
        }

        public ExceptionType exceptionType;
    }
}
