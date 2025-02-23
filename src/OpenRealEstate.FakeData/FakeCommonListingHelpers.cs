using FizzWare.NBuilder.Generators;
using OpenRealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenRealEstate.FakeData
{
    internal static class FakeCommonListingHelpers
    {
        internal static HashSet<string> CreateDefaultTags()
        {
            return new HashSet<string> 
            {
                "houseAndLandPackage",
                "solarPanels",
                "waterTank",
                "hotWaterService-gas",
                "heating-other",
                "balcony",
                "shed",
                "courtyard",
                "isANewConstruction"
            };
        }

        internal static void SetCommonListingData(Listing listing,
                                                  string agencyId = "XNWXNW",
                                                  StatusType statusType = StatusType.Available,
                                                  string description =
                                                      "Don't pass up an opportunity like this! First to inspect will buy! Close to local amenities and schools. Features lavishly appointed bathrooms, modern kitchen, rustic outhouse.Don't pass up an opportunity like this! First to inspect will buy! Close to local amenities and schools. Features lavishly appointed bathrooms, modern kitchen, rustic outhouse.",
                                                  string title = "SHOW STOPPER!!!")
        {
            SetFeatures(listing, tags: CreateDefaultTags());
            listing.Address = FakeAddress.CreateAFakeAddress();
            listing.Agents = FakeAgent.CreateFakeAgents().ToList();
            SetFloorPlans(listing);
            SetImages(listing);
            SetInspections(listing);
            SetLandDetails(listing);
            SetLinks(listing);
            SetVideos(listing);

            listing.AgencyId = agencyId;
            listing.CreatedOn = new DateTime(2009, 1, 1, 12, 30, 00, DateTimeKind.Utc);
            listing.UpdatedOn = listing.CreatedOn;
            listing.StatusType = statusType;
            SetSourceStatus(listing);
            listing.Description = description;
            listing.Title = title;
        }

        internal static void SetFeatures(Listing listing,
                                         byte bedrooms = 4,
                                         byte bathrooms = 2,
                                         byte ensuite = 2,
                                         byte livingAreas = 0,
                                         byte carports = 2,
                                         byte garages = 3,
                                         byte openSpaces = 0,
                                         byte toilets = 0,
                                         HashSet<string> tags = null)
        {
            listing.Features = new Features
            {
                Bedrooms = bedrooms,
                Bathrooms = bathrooms,
                Ensuites = ensuite,
                LivingAreas = livingAreas,
                CarParking = new CarParking
                {
                    Carports = carports,
                    Garages = garages,
                    OpenSpaces = openSpaces
                },
                Toilets = toilets,
                Tags = tags ?? new HashSet<string>()
            };
        }
        
        internal static void SetFloorPlans(Listing listing)
        {
            listing.FloorPlans = new List<Media>
            {
                new Media
                {
                    Url = "http://www.someWebSite.com.au/tmp/floorplan1.gif",
                    CreatedOn = new DateTime(2009, 1, 1, 12, 30, 0, DateTimeKind.Utc),
                    Order = 1
                },
                new Media
                {
                    Url = "http://www.someWebSite.com.au/tmp/floorplan2.gif",
                    CreatedOn = new DateTime(2009, 1, 1, 12, 30, 0, DateTimeKind.Utc),
                    Order = 2
                }
            };
        }

        internal static void SetImages(Listing listing)
        {
            listing.Images = new List<Media>
            {
                new Media
                {
                    Url = "http://www.someWebSite.com.au/tmp/imageM.jpg",
                    CreatedOn = new DateTime(2009, 1, 1, 12, 30, 0, DateTimeKind.Utc),
                    Order = 1
                },
                new Media
                {
                    Url = "http://www.someWebSite.com.au/tmp/imageA.jpg",
                    CreatedOn = new DateTime(2009, 1, 1, 12, 30, 0, DateTimeKind.Utc),
                    Order = 2
                }
            };
        }

        internal static void SetInspections(Listing listing)
        {
            listing.Inspections = new List<Inspection>
            {
                new Inspection
                {
                    OpensOn = new DateTime(2009, 1, 21, 11, 00, 00, DateTimeKind.Utc),
                    ClosesOn = new DateTime(2009, 1, 21, 13, 00, 00, DateTimeKind.Utc)
                },
                new Inspection
                {
                    OpensOn = new DateTime(2009, 1, 22, 15, 00, 00, DateTimeKind.Utc),
                    ClosesOn = new DateTime(2009, 1, 22, 15, 30, 00, DateTimeKind.Utc)
                }
            };
        }

        internal static void SetLandDetails(Listing listing)
        {
            var sides = new List<Side>
            {
                new Side {Name = "frontage", Type = "meter", Value = 20 },
                new Side {Name = "rear", Type = "meter", Value = 40 },
                new Side {Name = "left", Type = "meter", Value = 60 },
                new Side {Name = "right", Type = "meter", Value = 20 }
            };

            listing.LandDetails = new LandDetails
            {
                Area = new UnitOfMeasure {Type = "squareMeter", Value = 80},
                CrossOver = "left",
                Sides = sides,
            };
        }

        internal static void SetLinks(Listing listing)
        {
            listing.Links = new List<string>
            {
                "http://www.au.open2view.com/properties/314244/tour#floorplan",
                "http://www.google.com/hello"
            };
        }

        internal static void SetVideos(Listing listing)
        {
            listing.Videos = new List<Media>
            {
                new Media
                {
                    Url = "http://www.foo.tv/abcd.html",
                    Order = 1,
                }
            };
        }

        internal static void SetBuildingDetails(IBuildingDetails listing )
        {
            listing.BuildingDetails = new BuildingDetails
            {
                Area = new UnitOfMeasure {Type = "squareMeter", Value = 40},
                EnergyRating = 4.5M
            };
        }

        internal static void SetSalePrice(ISalePricing listing,
                                          int salePrice = 500000,
                                          string salePriceText = "Between $400,000 and $600,000",
                                          bool isUnderOffer = false,
                                          DateTime? soldOn = null,
                                          int  ? soldPrice = null,
                                          string soldPriceText = null)
        {
            listing.Pricing = new SalePricing
            {
                SalePrice = salePrice,
                SalePriceText = salePriceText,
                IsUnderOffer = isUnderOffer,
                SoldOn = soldOn,
                SoldPrice = soldPrice,
                SoldPriceText = soldPriceText
            };
        }

        /// <summary>
        /// Setting the SourceStatus value to be REAXml mapped values. Urgh :~(
        /// </summary>
        internal static void SetSourceStatus(Listing listing)
        {
            if (listing == null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            switch(listing.StatusType)
            {
                case StatusType.Available:
                    listing.SourceStatus = "Current";
                    break;
                case StatusType.Removed:
                    var randomInt = GetRandom.PositiveInt(3);
                    switch(randomInt)
                    {
                        case 0: listing.SourceStatus = "Withdrawn"; break;
                        case 1: listing.SourceStatus = "OffMarket"; break;
                        case 2: listing.SourceStatus = "Deleted"; break; 
                    }
                    break;
                default:
                    listing.SourceStatus = listing.StatusType.ToDescription();
                    break;
            }
        }
    }
}
