using System;

namespace Inveon.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
