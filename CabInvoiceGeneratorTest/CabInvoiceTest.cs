// <copyright file="CabInvoiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Class to test cab invoice generator.
    /// </summary>
    public class CabInvoiceTest
    {
        /// <summary>
        /// Creating object for main class.
        /// </summary>
        private CabInvoice cabInvoiceGenerator;

        /// <summary>
        /// Set up method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoice();
        }

        /// <summary>
        /// Test method to check total fare of the journey.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ReturnTotalFare()
        {
            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, 5.0, 5) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(55.0, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to check minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLessThanMinimumFareGetCalculated_ThenReturnMinimumFare()
        {
            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, 0.132, 1) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(5, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to calculate total fare of journey for multiple rides.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenCalculated_ReturnTotalFare()
        {
            Rides[] rides =
            {
                new Rides(Rides.RideType.NORMAL_RIDE, 26.05, 29),
                new Rides(Rides.RideType.NORMAL_RIDE, 12.39, 25),
            };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(438.4, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to calculate invoice summery.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenCalculated_ReturnInvoiceSummery()
        {
            Rides[] rides =
            {
                new Rides(Rides.RideType.NORMAL_RIDE, 25.12, 40),
                new Rides(Rides.RideType.NORMAL_RIDE, 12.39, 25),
            };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);
            Assert.AreEqual(summary, invoiceSummary);
        }

        /// <summary>
        /// Test method to check invoice summary of particular user.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnUserInvoiceSummary()
        {
            string userId = "user@.com";
            Rides[] rides =
            {
                new Rides(Rides.RideType.NORMAL_RIDE, 25.12, 40),
                new Rides(Rides.RideType.NORMAL_RIDE, 12.39, 25),
            };
            this.cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);
            Assert.AreEqual(invoiceSummary, summary);
        }

        /// <summary>
        /// Test method to calculate total fare for normal ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForNormalRides_ShouldReturnTotalFare()
        {
            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, 25.12, 45) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(296.2, cabInvoiceGeneratorTotalFare, 0.1);
        }

        /// <summary>
        /// Test method to calculate total fare for premium ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRides_ShouldReturnTotalFare()
        {
            Rides[] rides = { new Rides(Rides.RideType.PREMIUM_RIDE, 25.12, 45) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(466.8, cabInvoiceGeneratorTotalFare, 0.1);
        }
    }
}