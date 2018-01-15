﻿using System;
using OpenRealEstate.NET.Core.Land;
using OpenRealEstate.NET.Core.Rental;
using OpenRealEstate.NET.Core.Residential;
using OpenRealEstate.NET.Core.Rural;
using Shouldly;
using Xunit;

namespace OpenRealEstate.NET.FakeData.Tests
{
    public class CreateListingsTests : TestHelperUtilities
    {
        [Theory]
        [InlineData(typeof(ResidentialListing))]
        [InlineData(typeof(RentalListing))]
        [InlineData(typeof(LandListing))]
        [InlineData(typeof(RuralListing))]
        public void GivenThatWeNeedASomeListings_CreateFakeListings_ReturnsASomeListings(Type type)
        {
            // Arrange.
            const int numberOfListings = 30;

            // Act.
            var listings = CreateListings(type, numberOfListings);

            // Assert.
            listings.ShouldNotBeNull();
            listings.Count.ShouldBe(numberOfListings);
            listings.ShouldAllBe(x => x.GetType() == type);
        }
    }
}