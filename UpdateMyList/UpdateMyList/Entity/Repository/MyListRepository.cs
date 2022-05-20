using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IMyListRepository : IBaseRepository<MyListMast>
    {
        List<MyListModel> SelectByType(ListTypeModel model);
    }
    public class MyListRepository : BaseRepository<MyListMast>, IMyListRepository
    {
        public MyListRepository(myListEntities context)
            : base(context)
        {
        }
        public List<MyListModel> SelectByType(ListTypeModel model)
        {
            var rs = (from a in _context.MyListMasts
                      join b in _context.StsMasts on a.stsId equals b.stsId 
                      select new MyListModel
                      {
                          listId = a.listId,
                          listCode = a.listCode,
                          listName = a.listName,
                          listEP = a.listEP,
                          listTypeId = a.listTypeId,
                          listLink = a.listLink,
                          stsId = a.stsId,
                          listComment = a.listComment,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          recStatus = a.recStatus,
                          stsDesc = b.stsDesc,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();
            return rs;
        }

    }
}
