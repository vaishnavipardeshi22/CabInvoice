// <copyright file="Rides.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Model class to store multiple rides.
    /// </summary>
    public class Rides
    {
        public double Distance;
        public int Time;
        public RideType RideTypeValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rides"/> class.
        /// Constuctor for model rides.
        /// </summary>
        /// <param name="rideType"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Rides(RideType rideType, double distance, int time)
        {
            this.RideTypeValue = rideType;
            this.Distance = distance;
            this.Time = time;
        }

        public enum RideType
        {
            /// <summary>
            /// Enum for normal ride.
            /// </summary>
            NORMAL_RIDE,

            /// <summary>
            /// Enum for premium ride.
            /// </summary>
            PREMIUM_RIDE,
        }
    }
}
