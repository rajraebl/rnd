using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntApp.DAL.Custom
{
    public class UnitOfWork : IDisposable
    {
        private EntAppEntities _dbContext;
        private GenericRepository<User> _UserRepo;
        private GenericRepository<Product> _ProductRepo;

        public UnitOfWork()
        {
            _dbContext = new EntAppEntities();
            /* If you initialize here then these object will be created each time. better use props
            UserRepo = new GenericRepository<User>(dbContext);
            ProductRepo = new GenericRepository<Product>(dbContext);
            */
        }

        public GenericRepository<User> UserRepo
        {
            get
            {
                if (_UserRepo == null)
                {
                    _UserRepo = new GenericRepository<User>(_dbContext);
                }
                return _UserRepo;
            }
        }

        public GenericRepository<Product> ProductRepo
        {
            get
            {
                if (_ProductRepo == null)
                {
                    _ProductRepo = new GenericRepository<Product>(_dbContext);
                }
                return _ProductRepo;
            }
        }


        public void Save()
        {
            try 
            {
                _dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex) 
            {
                var outputLines = new List<string>();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw ex;
            }
            finally 
            {
                Dispose();
            }
        }



        //IDisposable area-------------------------------------------------

        #region Implementation of IDisposable 
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool explicitlyDisposing)
        {
            if (!disposed)
            {
                if (explicitlyDisposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
