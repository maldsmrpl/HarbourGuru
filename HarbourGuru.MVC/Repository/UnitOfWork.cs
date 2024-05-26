using CloudinaryDotNet;
using HarbourGuru.MVC.Data;
using HarbourGuru.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HarbourGuru.MVC.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext context;
        private GenericRepository<Country> countryRepository;
        private GenericRepository<Harbour> harbourRepository;
        private GenericRepository<HarbourCard> harbourCardRepository;

        public UnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            context = new ApplicationDbContext(options);
        }

        public GenericRepository<Country> CountryRepository
        {
            get
            {

                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<Country>(context);
                }
                return countryRepository;
            }
        }

        public GenericRepository<Harbour> HarbourRepository
        {
            get
            {

                if (this.harbourRepository == null)
                {
                    this.harbourRepository = new GenericRepository<Harbour>(context);
                }
                return harbourRepository;
            }
        }
        public GenericRepository<HarbourCard>HarbourCardRepository
        {
            get
            {

                if (this.harbourCardRepository == null)
                {
                    this.harbourCardRepository = new GenericRepository<HarbourCard>(context);
                }
                return harbourCardRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
