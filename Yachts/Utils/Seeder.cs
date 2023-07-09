using Yachts.Models;

namespace Yachts.Utils
{
    public class Seeder
    {
        private readonly YachtsDbContext _dbContext;

        public Seeder(YachtsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed() 
        {
            if (_dbContext.Database.CanConnect()) 
            {
                if (!_dbContext.Customers.Any()) 
                {
                    var result = GetCustomers();
                    _dbContext.Customers.AddRange(result);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Yachts.Any())
                {
                    var result = GetYachts();
                    _dbContext.Yachts.AddRange(result);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Reservations.Any())
                {
                    var result = GetReservation();
                    _dbContext.Reservations.AddRange(result);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Opinions.Any())
                {
                    var result = GetOpinions();
                    _dbContext.Opinions.AddRange(result);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Customer> GetCustomers() 
        {
            var customers = new List<Customer>() 
            {
                new Customer() 
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PhoneNumber = "123456789"
                },
                new Customer()
                {
                    FirstName = "Adam",
                    LastName = "Nowak",
                    PhoneNumber = "987654321"
                }
            };
            return customers;
        }

        private IEnumerable<Yacht> GetYachts()
        {
            var customers = new List<Yacht>()
            {
                new Yacht()
                {
                    Name = "Antila",
                    Type = "27",
                    PricePerDay = 550,
                    PhotoUrl = "https://www.czarteryklubmila.pl/uploads/Antila-27_8504575-scaled.jpg",
                    Description = "Antila 27 jest jednostką uniwersalną, zarówno dla ludzi chcących czerpać doznania żeglarskie na wysokim poziomie, jak i dużego komfortu użytkowania hotelowego jachtu."
                },
                new Yacht()
                {
                    Name = "SunCamper",
                    Type = "30",
                    PricePerDay = 630,
                    PhotoUrl = "https://baltyacht.pl/wp-content/uploads/2016/11/SC30a.jpg",
                    Description = "SunCamper 30 to łódź spacerowa, która gwarantuje pełen komfort spania 6 dorosłym osobom."
                }
            };
            return customers;
        }
        private IEnumerable<Reservation> GetReservation()
        {
            var customers = new List<Reservation>()
            {
                new Reservation()
                {
                    YachtId= 1,
                    CustomerId= 2,
                    StartDate = DateTime.ParseExact( "20/12/2022","dd/MM/yyyy", null),
                    EndDate = DateTime.ParseExact( "23/12/2022","dd/MM/yyyy", null)
                },
                new Reservation()
                {
                    YachtId= 2,
                    CustomerId= 3,
                    StartDate = DateTime.ParseExact( "25/12/2022","dd/MM/yyyy", null),
                    EndDate = DateTime.ParseExact( "31/12/2022","dd/MM/yyyy", null)
                }
            };
            return customers;
        }

        private IEnumerable<Opinion> GetOpinions()
        {
            var customers = new List<Opinion>()
            {
                new Opinion()
                {
                    Author = "Anonim",
                    Description = "Świety czarter, napewno w przyszłości skorzystam.",
                    Rate = 2,
                },
                new Opinion()
                {
                    Author = "Jan Wankiel",
                    Description = "OK",
                    Rate = 7,
                },
                new Opinion()
                {
                    Author = "Ada Nowakowska",
                    Description = "Pływają",
                    Rate = 10,
                },
            };
            return customers;
        }
    }
}
