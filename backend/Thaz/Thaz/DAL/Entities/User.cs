using System.ComponentModel.DataAnnotations.Schema;

namespace Thaz.DAL.Entities
{
    [Table("users")]
    public class User
    {
        [Column("name")]
        public string Name { get; set; }
        
        [Column("id")]
        public int Id { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("password")]
        public string Password { get; set; }

        internal BLL.Model.User ToModel()
        {
            return new BLL.Model.User()
            {
                Id = Id,
                Name = Name,
                Email = Email,
            };
        }
    }
}