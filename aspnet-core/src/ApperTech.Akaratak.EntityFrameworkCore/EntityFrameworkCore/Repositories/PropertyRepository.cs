//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Validation;
//using System.Text;
//using System.Threading.Tasks;
//using Abp.Domain.Repositories;
//using Abp.EntityFrameworkCore;
//using Abp.MultiTenancy;
//using ApperTech.Akaratak.Realestate;

//namespace ApperTech.Akaratak.EntityFrameworkCore.Repositories
//{
//    public interface IPropertyRepository : IRepository<Property, int>
//    {
//        Task<Property> Add(Property prop);
//    }

//    public class PropertyRepository : AkaratakRepositoryBase<Property, int>, IPropertyRepository
//    {
//        private readonly IDbContextProvider<AkaratakDbContext> _dbContextProvider;

//        public PropertyRepository(IDbContextProvider<AkaratakDbContext> dbContextProvider) : base(dbContextProvider)
//        {
//            _dbContextProvider = dbContextProvider;
//        }

//        public async Task<Property> Add(Property prop)
//        {
//            var context = _dbContextProvider.GetDbContext(MultiTenancySides.Host);
//            try
//            {
//                var result = (await context.Properties.AddAsync(prop)).Entity;
//                await context.SaveChangesAsync();
//                return result;
//            }
//            catch (Exception e)
//            {

//                throw;
//            }


//        }
//    }
//}
