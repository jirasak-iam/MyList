using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IListTypeMastRepository : IBaseRepository<ListTypeMast>
    {
        List<ListTypeModel> Select();
        List<ListTypeModel> SelectAllType();
        #region temp
        //int UpdateById(ListTypeModel data);
        //int Insert(ListTypeModel data);
        #endregion

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
                      orderby a.sortSeq,a.listTypeId
                      where a.recStatus == RecStatus.Active
                      select new ListTypeModel
                      { 
                          listTypeId = a.listTypeId,
                          listTypeCode = a.listTypeCode,
                          listTypeDesc = a.listTypeDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = a.sortSeq,
                      }).ToList();

            return rs;
        }
        public List<ListTypeModel> SelectAllType()
        {
            var rs = (from a in _context.ListTypeMasts
                      orderby a.sortSeq, a.listTypeId
                      select new ListTypeModel
                      {
                          listTypeId = a.listTypeId,
                          listTypeCode = a.listTypeCode,
                          listTypeDesc = a.listTypeDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = a.sortSeq,
                      }).ToList();

            return rs;
        }
        #region temp 
        //public int UpdateById(ListTypeModel data)
        //{
        //    var model = _context.ListTypeMasts.FirstOrDefault(p => p.listTypeId == data.listTypeId);
        //    if (model != null)
        //    {
        //        model.listTypeCode = data.listTypeCode;
        //        model.listTypeDesc = data.listTypeDesc;
        //        model.recStatus = data.recStatus;
        //        model.sortSeq = data.sortSeq;
        //        model.updateBy = data.updateBy;
        //        model.updateDate = data.updateDate;
        //    }
        //    var rs = _context.SaveChanges();
        //    return rs;
        //}
        //public int Insert(ListTypeModel data)
        //{
        //    if (data != null)
        //    {
        //        var model = new ListTypeMast();
        //        model.listTypeCode = data.listTypeCode;
        //        model.listTypeDesc = data.listTypeDesc;
        //        model.recStatus = data.recStatus;
        //        model.sortSeq = data.sortSeq;
        //        model.createBy = data.createBy;
        //        model.createDate = data.createDate;
        //        _context.ListTypeMasts.Add(model);
        //    }
        //    var rs = _context.SaveChanges();
        //    return rs;
        //}
        #endregion
    }
}
