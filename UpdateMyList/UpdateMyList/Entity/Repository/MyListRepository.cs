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
        int UpdateByApp(MyListModel model);
        int Insert(MyListModel model);
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
                      where a.listTypeId == model.listTypeId
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
        public int UpdateByApp(MyListModel model)
        {
            var rs = 0;
            if (model.listId > 0)
            {
                var data = Read().FirstOrDefault(p => p.listId == model.listId);
                data.listName = model.listName;
                data.listLink = model.listLink;
                data.listEP = model.listEP;
                data.listComment = model.listComment;
                data.stsId = model.stsId;
                data.updateDate = DateTime.Now;
            }
            rs = _context.SaveChanges();
            return rs;
        }
        public int Insert(MyListModel model)
        {
            var rs = 0;
            if (model != null)
            {
                var data = new MyListMast
                {
                    listTypeId = model.listTypeId,
                    listCode = GetMaxCodeByType(model.listTypeId),
                    listName = model.listName,
                    listLink = model.listLink,
                    listEP = model.listEP,
                    listComment = model.listComment,
                    stsId = model.stsId,
                    recStatus= model.recStatus,
                    createBy = model.createBy,
                    createDate = model.createDate,
                    updateDate = model.updateDate
                };
                _context.MyListMasts.Add(data);
            }
            rs = _context.SaveChanges();
            return rs;
        }
        private int GetMaxCodeByType(int typeId)
        {
            var rs = 1;
            if (typeId > 1)
            {
                rs = _context.MyListMasts.Where(p => p.listTypeId == typeId).Select(o => o.listCode).Max() ?? 1;
                rs += 1;
            }
            return rs;
        }

    }
}
