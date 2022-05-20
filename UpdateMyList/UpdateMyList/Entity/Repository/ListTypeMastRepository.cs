using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IListTypeMastRepository : IBaseRepository<ListTypeMast>
    {
        List<ListTypeModel> Select();
    }
    public class ListTypeMastRepository : BaseRepository<ListTypeMast>, IListTypeMastRepository
    {
        public ListTypeMastRepository(myListEntities context)
            : base(context)
        {
        }

        public List<ListTypeModel> Select()
        {
            var rs = (from a in _context.ListTypeMasts
                      select new ListTypeModel
                      { 
                          listTypeId = a.listTypeId,
                          listTypeCode = a.listTypeCode,
                          listTypeDesc = a.listTypeDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();

            return rs;
        }
    }
}
