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
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(5.0, 5);
            Assert.AreEqual(55.0, cabInvoiceGeneratorTotalFare);
        }
    }
}