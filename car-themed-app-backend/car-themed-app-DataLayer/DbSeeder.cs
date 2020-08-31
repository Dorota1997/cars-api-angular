using car_themed_app_DataLayer.Extensions;
using car_themed_app_Repository.Interfaces;
using car_themed_app_Repository.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace car_themed_app_DataLayer
{
    public class DbSeeder : IDbSeeder
    {
        private readonly AppDbContext _context;

        private readonly Random _rnd;

        private CultureInfo _provider;

        public DbSeeder(AppDbContext context)
        {
            _context = context;
            _rnd = new Random();
            _provider = CultureInfo.InvariantCulture;
        }

        public void ClearDatabase()
        {
            // _context.ServiceHistory.Clear();
            // _context.Cars.Clear();
            _context.Orders.Clear();
            // _context.Drivers.Clear();
            _context.Dealers.Clear();
            // _context.Mechanics.Clear();
        }

        public async Task<int> SeedDatabase()
        {
            int rowsAddedCounter = 0;

            ClearDatabase();

            // rowsAddedCounter += await AddRecordsFromList(ReturnListOfMechanics());
            rowsAddedCounter += await AddRecordsFromList(ReturnListOfDealers());
            // rowsAddedCounter += await AddRecordsFromList(ReturnListOfDrivers());
            // rowsAddedCounter += await AddRecordsFromList(ReturnListOfCars());
            rowsAddedCounter += await AddRecordsFromList(ReturnListOfOrders());
            // rowsAddedCounter += await AddRecordsFromList(ReturnListOfServices());

            return rowsAddedCounter;
        }

        private async Task<int> AddRecordsFromList<T>(List<T> data) where T : class
        {
            await _context.AddRangeAsync(data);
            int amountOfRowsAdded = await _context.SaveChangesAsync();
            return amountOfRowsAdded;
        }

        private int RandomizeId(List<int> listOfIds)
        {
            int index = _rnd.Next(1, listOfIds.Count);
            return listOfIds[index];
        }

        private DateTime ReturnDateTimeForGivenString(string value)
        {
            return DateTime.ParseExact(value, "dd.MM.yyyy", _provider);
        }

        #region Predefined Data 

        private List<Car> ReturnListOfCars()
        {
            List<int> ids = _context.Drivers.Select(d => d.Id).ToList();

            List<Car> cars = new List<Car>()
            {
                new Car("BMW", "E90", "2010", "1GD01ZEGXBF458955", "5YE 98X", RandomizeId(ids)),
                new Car("Hyundai", "Elantra", "1995", "SCBBR9ZA5AC700002", "1TE 926", RandomizeId(ids)),
                new Car("Nissan", "Altima", "2013", "JA32U1FU2AU976531", "3GR 586", RandomizeId(ids)),
                new Car("Hyundai", "Azera", "2008", "1G4CU541014704660", "NYS 531", RandomizeId(ids)),
                new Car("Hyundai", "Azera", "2011", "5UXFB53535L909220", "TMS-259", RandomizeId(ids)),
                new Car("Mazda", "Miata", "1998", "1GTG5AE38F1240361", "AWY 21B", RandomizeId(ids)),
                new Car("Pontiac", "Vibe", "2002", "19UUA9F78DA668122", "XGU-966", RandomizeId(ids)),
                new Car("Honda", "CR-V", "2001", "4A31K3DT6BE298237", "FHL 483", RandomizeId(ids)),
                new Car("Ford", "Explorer", "1994", "WAUCFAFRXCA221995", "LUH 154", RandomizeId(ids)),
                new Car("Chevrolet", "Tahoe", "2003", "JN1BJ0HP9EM335770", "ZHB 395", RandomizeId(ids)),
                new Car("Chevrolet", "Tahoe", "2008", "3C4PDDBG5FT698735", "TCR 168", RandomizeId(ids)),
                new Car("Honda", "Odyssey", "1997", "4JGDA0EB0FA176408", "N23 6AE", RandomizeId(ids)),
                new Car("Toyota", "Tacoma", "1998", "19UUA65676A266957", "T29 7NY", RandomizeId(ids)),
                new Car("Toyota", "Prius", "2001", "2T2BK1BAXDC837747", "K91 4BT", RandomizeId(ids)),
                new Car("Subaru", "Impreza", "1999", "WBADX7C59DJ666767", "D98 3GN", RandomizeId(ids)),
                new Car("Audi", "A4", "2005", "1D4PT5GK1AW710231", "K27 3RW", RandomizeId(ids)),
                new Car("Audi", "A6", "2005", "2C4RVAAG4CR603280", "U40 5HA", RandomizeId(ids)),
                new Car("Audi", "A8", "2005", "WDDGF4HB6DG112184", "Z90 9RU", RandomizeId(ids)),
                new Car("BMW", "325", "2005", "WAUWMAFC3FN710623", "E14 3YP", RandomizeId(ids)),
                new Car("BMW", "525", "2005", "4USBT33494L223314", "AMT U90", RandomizeId(ids)),
                new Car("BMW", "530i", "2005", "5FPYK1F42DB630906", "AFP D53", RandomizeId(ids)),
                new Car("BMW", "545", "2005", "WAUXU54B32N359549", "ANL W12", RandomizeId(ids)),
                new Car("BMW", "X3", "2005", "2C3CDXDT6CH840917", "AKC Y76", RandomizeId(ids)),
                new Car("BMW", "X5", "2005", "1N6AD0CU5AC877216", "ADP B56", RandomizeId(ids)),
                new Car("Chevrolet", "Monte Carlo", "2005", "3C4PDDGG4ET644060", "AJC T29", RandomizeId(ids)),
                new Car("Ford", "Crown Victoria", "2005", "SALME1D49BA940289", "AHG V40", RandomizeId(ids)),
            };

            return cars;
        }

        private List<Order> ReturnListOfOrders()
        {
            List<int> ids = _context.Dealers.Select(d => d.Id).ToList();

            List<Order> orders = new List<Order>()
            {
                new Order("Front glass to Honda Accord IX generation", ReturnDateTimeForGivenString("16.08.2018"), RandomizeId(ids)),
                new Order("Tyres 25-10-12, back glass, mask for BMW E90", ReturnDateTimeForGivenString("18.08.2018"), RandomizeId(ids)),
                new Order("Engine replacement for Toyota Auris II", ReturnDateTimeForGivenString("09.04.2018"), RandomizeId(ids)),
                new Order("Tyres replacement for Jaguar", ReturnDateTimeForGivenString("23.07.2017"), RandomizeId(ids)),
                new Order("New suspension for Aston Martin Rapide", ReturnDateTimeForGivenString("16.03.2016"), RandomizeId(ids)),
                new Order("New brake pads for Honda Civic 3D", ReturnDateTimeForGivenString("21.05.2019"), RandomizeId(ids)),
                new Order("Engine replacement for Citroen C3 Picasso", ReturnDateTimeForGivenString("04.07.2017"), RandomizeId(ids)),
            };

            return orders;
        }

        private List<Dealer> ReturnListOfDealers()
        {
            List<Dealer> dealers = new List<Dealer>
            {
                new Dealer("Honda Cars/Motors Equipment", "Wiejka 15", "00-001", "Poland"),
                new Dealer("Tomaz Car Engines, Accessories", "Krucza 2", "20-022", "Poland"),
                new Dealer("CarVegIo - Equipment for Tesla cars", "689 Elm St.", "10461", "United States"),
                new Dealer("Extortia Ford and BMW replacements", "62 William Dr.", "14150", "United States"),
                new Dealer("Nuova - Car engines", "8276 W. Woodsman Rd.", "P5E 9M4", "Canada"),
                new Dealer("Ranway Premium Car Service", "959 Old York St.", "BC V9A 7L8", "Canada"),
                new Dealer("Parmatty - Best quality tyres", "98 Park Road", "SW83 5KH", "United Kingdom"),
                new Dealer("Trapped, fast Jaguar engines delievery", "17 The Drive", "TD41 8YP", "United Kingdom"),
                new Dealer("Aston Martin service", "9763 Green Lane", "S58 2W", "United Kingdom"),
                new Dealer("Toyota Car Service", "577 King Street", "TA2 0BO", "United Kingdom")
            };

            return dealers;
        }

        private List<Driver> ReturnListOfDrivers()
        {
            List<Driver> drivers = new List<Driver>
            {
                new Driver("Daniel Razmansky", ReturnDateTimeForGivenString("10.04.1994"), ReturnDateTimeForGivenString("16.02.2014")),
                new Driver("Katya Angel", ReturnDateTimeForGivenString("10.10.2004"), ReturnDateTimeForGivenString("05.12.2018")),
                new Driver("Gordon Barns", ReturnDateTimeForGivenString("05.02.1992"), ReturnDateTimeForGivenString("10.02.2017")),
                new Driver("Sean Canney", ReturnDateTimeForGivenString("21.01.1990"), ReturnDateTimeForGivenString("10.02.2017")),
                new Driver("Dawid Gerstring", ReturnDateTimeForGivenString("10.02.1998"), ReturnDateTimeForGivenString("22.04.2015")),
                new Driver("Joan Farnsky", ReturnDateTimeForGivenString("10.02.1999"), ReturnDateTimeForGivenString("11.04.2018")),
                new Driver("Hans Holleur", ReturnDateTimeForGivenString("04.11.1996"), ReturnDateTimeForGivenString("14.08.2017")),
                new Driver("Kate Newsman", ReturnDateTimeForGivenString("22.12.1989"), ReturnDateTimeForGivenString("10.11.2017")),
                new Driver("Robert Orwell", ReturnDateTimeForGivenString("05.08.1990"), ReturnDateTimeForGivenString("04.04.2017")),
                new Driver("Triss Merigold", ReturnDateTimeForGivenString("17.09.1993"), ReturnDateTimeForGivenString("13.08.2017")),
                new Driver("Alice Hamsky", ReturnDateTimeForGivenString("01.09.1997"), ReturnDateTimeForGivenString("05.02.2016")),
                new Driver("Noe Dawman", ReturnDateTimeForGivenString("10.06.1998"), ReturnDateTimeForGivenString("09.05.2017")),
                new Driver("Frank Sintre", ReturnDateTimeForGivenString("19.07.1997"), ReturnDateTimeForGivenString("17.10.2015")),
                new Driver("Oleg Nos", ReturnDateTimeForGivenString("23.03.1995"), ReturnDateTimeForGivenString("23.03.2019")),
                new Driver("Tamara Speed", ReturnDateTimeForGivenString("20.10.1995"), ReturnDateTimeForGivenString("26.04.2016")),
                new Driver("Angela Komner", ReturnDateTimeForGivenString("14.11.1992"), ReturnDateTimeForGivenString("13.11.2019")),
                new Driver("Martin Viedensk", ReturnDateTimeForGivenString("06.04.1993"), ReturnDateTimeForGivenString("11.02.2017"))
            };

            return drivers;
        }

        private List<Mechanic> ReturnListOfMechanics()
        {

            List<Mechanic> mechanics = new List<Mechanic>
            {
                new Mechanic("Martin Gonzalez", "000 000 993", ReturnDateTimeForGivenString("10.02.2015")),
                new Mechanic("Jan Volominsky", "000 000 007", ReturnDateTimeForGivenString("23.07.2016")),
                new Mechanic("Alexandra Martinez", "000 000 807", ReturnDateTimeForGivenString("16.05.2018")),
                new Mechanic("Marta Szainder", "000 000 127", ReturnDateTimeForGivenString("10.10.2018")),
                new Mechanic("Robert Carrney", "000 010 111", ReturnDateTimeForGivenString("04.11.2018")),
                new Mechanic("Gareth Bane", "000 000 041", ReturnDateTimeForGivenString("02.02.2019")),
                new Mechanic("Robin Maxwell", "000 000 023", ReturnDateTimeForGivenString("02.02.2019")),
                new Mechanic("Gareth Bane", "000 000 068", ReturnDateTimeForGivenString("13.04.2019")),
                new Mechanic("Adam Thomsky", "000 011 908", ReturnDateTimeForGivenString("16.05.2019")),
                new Mechanic("Ronald Fane", "000 000 701", ReturnDateTimeForGivenString("23.05.2019")),
                new Mechanic("Monica Palermo", "000 000 487", ReturnDateTimeForGivenString("14.09.2019")),
                new Mechanic("Thomas Kalasky", "000 000 386", ReturnDateTimeForGivenString("12.10.2019")),
                new Mechanic("Thomas Borgeu", "000 000 401", ReturnDateTimeForGivenString("12.10.2019")),
                new Mechanic("Patrick Vox", "000 000 032", ReturnDateTimeForGivenString("19.10.2019")),
                new Mechanic("Martha Corey", "000 000 211", ReturnDateTimeForGivenString("04.11.2019")),
                new Mechanic("Jonathan Corwin", "000 000 143", ReturnDateTimeForGivenString("11.11.2019")),
                new Mechanic("Jim Bayley", "000 000 283", ReturnDateTimeForGivenString("19.11.2019"))
            };

            return mechanics;
        }

        private List<Service> ReturnListOfServices()
        {
            List<int> mechanics_ids = _context.Mechanics.Select(d => d.Id).ToList();
            List<int> cars_ids = _context.Cars.Select(d => d.Id).ToList();

            List<Service> services = new List<Service>
            {
                new Service("Engine oil change", ReturnDateTimeForGivenString("12.06.2018"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Varnish change", ReturnDateTimeForGivenString("10.05.2010"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Suspension repair", ReturnDateTimeForGivenString("13.09.2014"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Brake blocks replacement", ReturnDateTimeForGivenString("05.08.2017"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Engine oil change", ReturnDateTimeForGivenString("01.02.2004"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Engine oil change", ReturnDateTimeForGivenString("03.05.2009"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Put on winter tyres", ReturnDateTimeForGivenString("09.08.2006"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Glass replacement", ReturnDateTimeForGivenString("17.10.2006"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Dimming glass", ReturnDateTimeForGivenString("19.11.2013"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Seats replacement", ReturnDateTimeForGivenString("07.05.2016"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Steering wheal replacement", ReturnDateTimeForGivenString("18.02.2017"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Gearbox replacement", ReturnDateTimeForGivenString("12.08.2013"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Engine oil change", ReturnDateTimeForGivenString("09.10.2001"), RandomizeId(mechanics_ids), RandomizeId(cars_ids)),
                new Service("Seats replacement", ReturnDateTimeForGivenString("13.08.2015"), RandomizeId(mechanics_ids), RandomizeId(cars_ids))
            };

            return services;
        }

        #endregion
    }
}
