// <copyright file="CabInvoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Main class for cab invoice generator.
    /// </summary>
    public class CabInvoice
    {
        private double costPerKilometer = 10;
        private int costPerMinute = 1;
        private int minimumFare = 5;

        /// <summary>
        /// Function to calculate total fare of journey.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns>Total fare of journey.</returns>
        public double GetTotalFare(double distance, int time)
        {
            double totalFare = (this.costPerKilometer * distance) + (this.costPerMinute * time);
            totalFare = Math.Max(totalFare, this.minimumFare);
            return totalFare;
        }
    }
}
