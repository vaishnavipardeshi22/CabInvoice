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
        private double normalRideCostPerKilometer = 10;
        private int normalRideCostPerMinute = 1;
        private int normalRideMinimumFare = 5;
        private double premiumRideCostPerKilometer = 15;
        private int premiumRideCostPerMinute = 2;
        private int premiumRideMinimumFare = 20;

        private RideRepository rideRepository;

        public CabInvoice()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Function to calculate total fare of journey for multiple rides.
        /// </summary>
        /// <param name="rides"></param>
        /// <returns>Total fare of journey.</returns>
        public double GetTotalFare(Rides[] rides)
        {
            double totalFare = 0;
            foreach (Rides ride in rides)
            {
                if (ride.RideTypeValue.Equals(Rides.RideType.NORMAL_RIDE))
                {
                    totalFare += (ride.Distance * this.normalRideCostPerKilometer) + (ride.Time * this.normalRideCostPerMinute);
                    totalFare = Math.Max(totalFare, this.normalRideMinimumFare);
                }

                if (ride.RideTypeValue.Equals(Rides.RideType.PREMIUM_RIDE))
                {
                    totalFare += (ride.Distance * this.premiumRideCostPerKilometer) + (ride.Time * this.premiumRideCostPerMinute);
                    totalFare = Math.Max(totalFare, this.premiumRideMinimumFare);
                }
            }

            return totalFare;
        }

        /// <summary>
        /// Function to get invoice summary using ride data.
        /// </summary>
        /// <param name="rides"></param>
        /// <returns>invoice summary.</returns>
        public InvoiceSummary GetInvoiceSummary(Rides[] rides)
        {
            double totalFare = this.GetTotalFare(rides);
            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Function to get invoice summary using user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>invoice summary of particular ride.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            Rides[] rideList = this.rideRepository.GetRides(userId);
            double totalFare = this.GetTotalFare(rideList);
            return new InvoiceSummary(rideList.Length, totalFare);
        }

        /// <summary>
        /// Function to add rides.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Rides[] rides)
        {
            this.rideRepository.AddRides(userId, rides);
        }
    }
}
