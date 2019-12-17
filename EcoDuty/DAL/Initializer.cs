using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entities;

namespace DAL
{
    public class Initializer
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.TechnicTypes.Any())
            {
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro1", Fuel = "Petrol", SizeFine = 600});
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro2", Fuel = "Petrol", SizeFine = 500 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro3", Fuel = "Petrol", SizeFine = 400 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro4", Fuel = "Petrol", SizeFine = 300 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro5", Fuel = "Petrol", SizeFine = 200 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro6", Fuel = "Petrol", SizeFine = 0 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro1", Fuel = "Diesel", SizeFine = 650 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro2", Fuel = "Diesel", SizeFine = 550 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro3", Fuel = "Diesel", SizeFine = 450 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro4", Fuel = "Diesel", SizeFine = 350 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro5", Fuel = "Diesel", SizeFine = 250 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Euro6", Fuel = "Diesel", SizeFine = 50 });
                context.TechnicTypes.Add(new TechnicType() { Type = "Auto", Classification = "Electic", Fuel = "Electric", SizeFine = -100});
                context.SaveChanges();
            }

            if (!context.PlaceTypes.Any())
            {
                context.PlaceTypes.Add(new PlaceType() { HousingType = "Apartment"});
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Solar", SizeFine = -500 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Wind", SizeFine = -300 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Earth energy", SizeFine = -500 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Biofuel", SizeFine = -1000 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Solar", SizeFine = -500 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Electric", SizeFine = 100 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Natural gas", SizeFine = 100 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Coal", SizeFine = 700 });
                context.PlaceTypes.Add(new PlaceType() { HousingType = "House", EcoType = "Аirewood", SizeFine = 500 });
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                context.Cities.Add(new City() { Country = "Ukraine", Name = "Kharkiv"});
                context.Cities.Add(new City() { Country = "Ukraine", Name = "Kiev" });
                context.Cities.Add(new City() { Country = "Ukraine", Name = "Odessa" });
                context.Cities.Add(new City() { Country = "Ukraine", Name = "Lviv" });
                context.SaveChanges();
            }
        }
    }
}
