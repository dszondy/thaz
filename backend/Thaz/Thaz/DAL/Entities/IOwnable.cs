using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thaz.DAL.Entities
{
    public interface IOwnable
    {
        public User Owner { get; set; }
    }
}