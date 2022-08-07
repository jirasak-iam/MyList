using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IGenreGroupRepository : IBaseRepository<GenreGroup>
    {
        List<GenreGroupModel> SelectGenreGroupByListId(int listId);
        List<GenreGroupModel> SelectGenreGroupBygenIdMany(List<int> genId);
        List<GenreGroupModel> SelectGenreGroupByListIdMany(List<int> listId);
        int Insert(GenreGroupModel data);
        int UpdateOut(GenreGroupModel data);
    }
    public class GenreGroupRepository : BaseRepository<GenreGroup>, IGenreGroupRepository
    {
        public GenreGroupRepository(myListEntities context)
            : base(context)
        {
        }

        public List<GenreGroupModel> SelectGenreGroupByListId(int listId)
        {
            var rs = (from a in _context.GenreGroups
                      //join b in _context.GenreMasts on a.genId equals b.genId
                      //join c in _context.MyListMasts on a.listId equals c.listId
                      orderby a.gengroupId
                      where a.recStatus == RecStatus.Active && a.listId == listId
                      select new GenreGroupModel
                      {
                          gengroupId = a.gengroupId,
                          genId = a.genId,
                          listId = a.listId,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();
            return rs;
        }
        public List<GenreGroupModel> SelectGenreGroupBygenIdMany(List<int> genId)
        {
            var rs = (from a in _context.GenreGroups
                          //join b in _context.GenreMasts on a.genId equals b.genId
                          //join c in _context.MyListMasts on a.listId equals c.listId
                      orderby a.gengroupId
                      where a.recStatus == RecStatus.Active && genId.Contains(a.genId)
                      select new GenreGroupModel
                      {
                          gengroupId = a.gengroupId,
                          genId = a.genId,
                          listId = a.listId,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();
            return rs;
        }
        public List<GenreGroupModel> SelectGenreGroupByListIdMany(List<int> listId)
        {
            var rs = (from a in _context.GenreGroups
                      join b in _context.GenreMasts on a.genId equals b.genId
                      //join c in _context.MyListMasts on a.listId equals c.listId
                      orderby a.gengroupId
                      where a.recStatus == RecStatus.Active && listId.Contains(a.listId)
                      select new GenreGroupModel
                      {
                          gengroupId = a.gengroupId,
                          genId = a.genId,
                          genCode = b.genCode,
                          genDesc = b.genDesc,
                          listId = a.listId,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();
            return rs;
        }
        public int UpdateOut(GenreGroupModel data)
        {
            var model = _context.GenreGroups.FirstOrDefault(p => p.gengroupId == data.gengroupId);
            if (model != null)
            {
                model.recStatus = data.recStatus;
                model.updateBy = data.updateBy;
                model.updateDate = data.updateDate;
            }
            var rs = _context.SaveChanges();
            return rs;
        }
        public int Insert(GenreGroupModel data)
        {
            if (data != null)
            {
                var model = new GenreGroup();
                model.genId = data.genId;
                model.listId = data.listId;
                model.recStatus = data.recStatus;
                model.createBy = data.createBy;
                model.createDate = data.createDate;
                _context.GenreGroups.Add(model);
            }
            var rs = _context.SaveChanges();
            return rs;
        }
    }
}
