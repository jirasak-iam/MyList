using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IMyListRepository : IBaseRepository<MyListMast>
    {
        List<MyListModel> SelectByType(ListTypeModel model);
        int GetMaxCodeByType(int typeId);
        #region temp
        //int UpdateByApp(MyListModel model);
        //int Insert(MyListModel model);
        //int DeleteMyList(int listId);
        #endregion

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
                      join b in _context.StsMasts.Where(p => p.recStatus == RecStatus.Active) on a.stsId equals b.stsId
                      join bab in _context.StsMasts.Where(p => p.recStatus == RecStatus.Active) on a.stsIdLast equals bab.stsId into p
                      from bb in p.DefaultIfEmpty()
                      join c in _context.SeasonMasts.Where(p => p.recStatus == RecStatus.Active) on a.seaId equals c.seaId  into c2
                      from cc in c2.DefaultIfEmpty()
                      where a.listTypeId == model.listTypeId
                      select new MyListModel
                      {
                          listId = a.listId,
                          listCode = a.listCode,
                          listName = a.listName,
                          listEP = a.listEP,
                          listEPLast = (a.listEPLast ?? string.Empty),
                          listTypeId = a.listTypeId,
                          listLink = a.listLink,
                          stsId = a.stsId,
                          stsIdLast = a.stsIdLast,
                          listComment = a.listComment,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          recStatus = a.recStatus,
                          stsDesc = b.stsDesc,
                          stsDescLast = bb.stsDesc,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          seaId = cc.seaId,
                          seaDesc = cc.seaDesc,
                      }).ToList();
            return rs;
        }
        
        public int GetMaxCodeByType(int typeId)
        {
            var rs = 0;
            if (typeId > 0)
            {
                rs = _context.MyListMasts.Where(p => p.listTypeId == typeId).Select(o => o.listCode).Max() ?? 0;
                rs += 1;
            }
            return rs;
        }
        #region temp 
        //public int UpdateByApp(MyListModel model)
        //{
        //    var rs = 0;
        //    if (model.listId > 0)
        //    {
        //        var data = Read().FirstOrDefault(p => p.listId == model.listId);
        //        data.listName = model.listName;
        //        data.listLink = model.listLink;
        //        data.listEP = model.listEP;
        //        data.listEPLast = model.listEPLast;
        //        data.listComment = model.listComment;
        //        data.stsId = model.stsId;
        //        data.stsIdLast = model.stsIdLast;
        //        data.seaId = model.seaId;
        //        data.updateBy = model.updateBy;
        //        data.updateDate = model.updateDate;
        //        _context.SaveChanges();
        //        rs = data.listId;
        //    }

        //    return rs;
        //}
        //public int Insert(MyListModel model)
        //{
        //    var rs = 0;
        //    if (model != null)
        //    {
        //        var data = new MyListMast
        //        {
        //            listTypeId = model.listTypeId,
        //            listCode = GetMaxCodeByType(model.listTypeId),
        //            listName = model.listName,
        //            listLink = model.listLink,
        //            listEP = model.listEP,
        //            listEPLast = model.listEPLast,
        //            listComment = model.listComment,
        //            stsId = model.stsId,
        //            stsIdLast = model.stsIdLast,
        //            seaId = model.seaId,
        //            recStatus = model.recStatus,
        //            createBy = model.createBy,
        //            createDate = model.createDate,
        //            updateDate = model.updateDate
        //        };
        //        _context.MyListMasts.Add(data);
        //        _context.SaveChanges();
        //        rs = data.listId;
        //    }

        //    return rs;
        //}
        //public int DeleteMyList(int listId)
        //{
        //    var myList = _context.MyListMasts.FirstOrDefault(p => p.listId == listId);
        //    _context.MyListMasts.Remove(myList);
        //    var rs = _context.SaveChanges();
        //    return rs;
        //}
        #endregion

    }
}
