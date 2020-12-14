using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories;

namespace Thaz.BLL.Services
{
    public class PartnerService
    {
        public PartnerService(IPartnerRepository partnerRepository)
        {
            PartnerRepository = partnerRepository;
        }

        private IPartnerRepository PartnerRepository { get; }
        public Partner Create(PartnerDetails partner)
        {
            return PartnerRepository.Create(partner);
        }

        public Partner Update(PartnerDetails partner)
        {
            return PartnerRepository.Update(partner);
        }

        public PartnerDetails Get(int id)
        {
            return PartnerRepository.Get(id);
        }

        public IEnumerable<Partner> List(PartnerSearchParams search)
        {
            return PartnerRepository.List(search);
        }
    }
}