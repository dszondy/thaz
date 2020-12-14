using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Entities;
using Thaz.DAL.QueryBuilders;
using Bill = Thaz.BLL.Model.Bill;
using User = Thaz.BLL.Model.User;

namespace Thaz.DAL.Repositories
{
    public class BillRepository : RepositoryBase, IBillRepository
    {
        public BillDetails CreateBill(BillDetails bill)
        {
            var entity = new Entities.Bill()
            {
                Created = bill.Created,
                Partner = bill.Partner != null ? Partners
                    .Single(x => x.Id == bill.Partner.Id) : null,
                Condominium = bill.Condominium != null ? Condominiums
                    .Single(x => x.Id == bill.Condominium.Id) : null,
                Description = bill.Description,
                Serial = bill.Serial,
                PaymentDeadline = bill.PaymentDeadline,
                Done = bill.Done,
                Items = bill.Items
                    .Select(x => new Entities.BillItem(){Description = x.Description, Price = x.Price})
                    .ToList(), 
                Tags = bill.Tags
                    .Select(x => new BillTag(){Label = x.Label, Ratio = x.Rate})
                    .ToList()
            };
            DbContext.Add(entity);
            DbContext.Add(entity.Tags);
            DbContext.Add(entity.Items);
            DbContext.SaveChanges();
            
            return entity.ToModelWithItems();
        }


        public BillDetails GetBill(int id)
        {
            return Bills
                .Include(x => x.Tags)
                .Single(x => x.Id == id).ToModelWithItems();
        }

        public List<Bill> GetBills(BillSearchParams search )
        {
            return Bills.ApplySearch(search)
                .Select(x => x.ToModel())
                .ToList();
        }

        public BillDetails Edit(BillDetails bill)
        {
            var entity = Bills.First(x => x.Id == bill.Id);
            entity.Created = bill.Created??DateTime.Now;
            entity.Partner = bill.Partner is null ?  null: 
                Partners.Single(x => x.Id == bill.Partner.Id);
            entity.Condominium = bill.Condominium is null ? null: 
                Condominiums.Single(x => x.Id == bill.Condominium.Id);
            entity.Description = bill.Description;
            entity.Serial = bill.Serial;
            entity.PaymentDeadline = bill.PaymentDeadline;
            entity.Done = bill.Done;
            
            DbContext.RemoveRange(BillItems.Where(x => x.Bill == entity));
            entity.Items = bill.Items
                .Select(x => new Entities.BillItem(){Description = x.Description, Price = x.Price})
                .ToList();
            DbContext.AddRange(entity.Items);
            
            DbContext.RemoveRange(DbContext.BillTags.Where(x => x.Bill==entity));
            entity.Tags = bill.Tags
                .Select(x => new BillTag() {Label = x.Label, Ratio = x.Rate})
                .ToList();
            DbContext.AddRange(entity.Tags);

            DbContext.SaveChanges();
            
            return entity.ToModelWithItems();
        }

        public BillRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
}