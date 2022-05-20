using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Repository
{
    public interface IStsMastRepository : IBaseRepository<StsMast>
    {

    }
    public class StsMastRepository : BaseRepository<StsMast>, IStsMastRepository
    {
        public StsMastRepository(myListEntities context)
            : base(context)
    {
    }

}
}
