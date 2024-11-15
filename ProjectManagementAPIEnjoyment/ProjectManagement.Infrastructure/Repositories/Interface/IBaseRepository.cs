using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {

    }
}
