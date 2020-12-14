using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;

namespace Thaz.BLL.Repositories
{
    public interface IPartnerRepository
    {
        Partner Create(PartnerDetails partner);
        Partner Update(PartnerDetails partner);
        PartnerDetails Get(int id);
        IEnumerable<Partner> List(PartnerSearchParams search);
    }
}