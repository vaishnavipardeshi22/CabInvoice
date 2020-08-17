﻿// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for invoice summary.
    /// </summary>
    public class InvoiceSummary
    {
        public int NumberOfRides;
        public double TotalFare;
        public double AverageFarePerRide;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="totalFare"></param>
        public InvoiceSummary(int length, double totalFare)
        {
            this.NumberOfRides = length;
            this.TotalFare = totalFare;
            this.AverageFarePerRide = this.TotalFare / this.NumberOfRides;
        }

        /// <summary>
        /// Override equals method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if specified object is equal to current object.</returns>
        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   this.NumberOfRides == summary.NumberOfRides &&
                   this.TotalFare == summary.TotalFare &&
                   this.AverageFarePerRide == summary.AverageFarePerRide;
        }

        /// <summary>
        /// Override get hash code method.
        /// </summary>
        /// <returns>hash code for current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
