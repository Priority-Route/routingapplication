﻿using System;
using System.Collections.Generic;
using PriorityRoute.Models;
using PriorityRoute.Data;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Views
{
    public partial class RouteScreen : ContentPage
    {
        User user;
        DBReceptacleOps recOps;

        public RouteScreen(User user)
        {
            InitializeComponent();
            FindMyLocation();
            this.user = user;
            recOps = new DBReceptacleOps();
        }

        private async void OptimizeClicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            var theMap = FindByName("map") as Xamarin.Forms.Maps.Map;
            var mapCenter = new Position(location.Latitude, location.Longitude);
            var pin = new Pin { Type = PinType.Generic, Position = mapCenter, Label = "MyCar" };
            theMap.Pins.Add(pin);

            // recOps.AddReceptacle(user.CompanyID, "name", Position, "label");
        }

        private async void FindMyLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    var theMap = FindByName("map") as Xamarin.Forms.Maps.Map;
                    var mapCenter = new Position(location.Latitude, location.Longitude);

                    theMap.MoveToRegion(MapSpan.FromCenterAndRadius(mapCenter, Distance.FromMiles(1)));
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle no supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}
