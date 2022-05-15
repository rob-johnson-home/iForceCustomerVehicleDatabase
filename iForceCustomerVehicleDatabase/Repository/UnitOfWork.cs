using System;

namespace iForceCustomerVehicleDatabase.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly CustomerVehicleDatabaseDbContext _context;
        private ICustomerRepo _customerRepo;
        private IVehicleRepo _vehicleRepo;

        public UnitOfWork(CustomerVehicleDatabaseDbContext context)
        {
            _context = context;
        }

        public ICustomerRepo GetCustomerRepository()
        {
            if (this._customerRepo == null)
            {
                this._customerRepo = new CustomerRepo(_context);
            }
            return _customerRepo;
        }

        public IVehicleRepo GetVehicleRepository()
        {
            if (this._vehicleRepo == null)
            {
                this._vehicleRepo = new VehicleRepo(_context);
            }
            return _vehicleRepo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
