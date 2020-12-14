using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Thaz.DAL.Entities
{
    public class Address
    {
        [Column("country")]
        public string Country { get; set; }
        [Column("state")]
        public string State { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("address")]
        public string AddressLine { get; set; }
        [Column("zip")]
        public string Zip { get; set; }

        public BLL.Model.Address toModel()
        {
            return new BLL.Model.Address()
            {
                City = City,
                Country = Country,
                State = State,
                AddressLine = AddressLine,
                Zip = Zip
            };
        }

        public static Address FromModel(BLL.Model.Address model)
        {
            return model is null ? null : new Address()
            {
                City = model.City,
                Country = model.Country,
                State = model.State,
                AddressLine = model.AddressLine,
                Zip = model.Zip
            };
        }
        
        public void UpdateFromModel(BLL.Model.Address model)
        {
            City = model.City;
            Country = model.Country;
                State = model.State;
                AddressLine = model.AddressLine;
                Zip = model.Zip;
        }
    }
}