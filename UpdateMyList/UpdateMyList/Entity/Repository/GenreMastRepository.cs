using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IGenreMastRepository : IBaseRepository<GenreMast>
    {
        List<GenreModel> Select();
        List<GenreModel> SelectAllType();
        List<GenreModel> SelectAll();
        int UpdateById(GenreModel data);
        int Insert(GenreModel model);
    }
    public class GenreMastRepository : BaseRepository<GenreMast>, IGenreMastRepository
    {
        public GenreMastRepository(myListEntities context)
            : base(context)
        {
        }

        public List<GenreModel> Select()
        {
            var rs = (from a in _context.GenreMasts
                      orderby a.genCode
                      where a.recStatus == RecStatus.Active
                      select new GenreModel
                      { 
                          genreId = a.genId,
                          genreCode = a.genCode,
                          genreDesc = a.genDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = a.sortSeq,
                      }).ToList();

            return rs;
        }
        public List<GenreModel> SelectAllType()
        {
            var rs = (from a in _context.GenreMasts
                      orderby a.genCode
                      select new GenreModel
                      {
                          genreId = a.genId,
                          genreCode = a.genCode,
                          genreDesc = a.genDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = a.sortSeq,
                      }).ToList();

            return rs;
        }
        public List<GenreModel> SelectAll()
        {
            var rs = new List<GenreModel>();
            rs.Add(new GenreModel
            {
                sortSeq = 0,
                genreId = 0,
                genreCode = null,
                genreDesc = "All"
            });
            rs.AddRange(from a in _context.GenreMasts
                        orderby a.genCode
                        where a.recStatus == RecStatus.Active
                        select new GenreModel
                        {
                            genreId = a.genId,
                            genreCode = a.genCode,
                            genreDesc = a.genDesc,
                            recStatus = a.recStatus,
                            createBy = a.createBy,
                            createDate = a.createDate,
                            updateBy = a.updateBy,
                            updateDate = a.updateDate,
                            sortSeq = a.sortSeq,
                        });

            return rs;
        }
        public int UpdateById(GenreModel data)
        {
            var model = _context.GenreMasts.FirstOrDefault(p => p.genId == data.genreId);
            if (model != null)
            {
                model.genCode = data.genreCode;
                model.genDesc = data.genreDesc;
                model.recStatus = data.recStatus;
                model.sortSeq = data.sortSeq;
                model.updateBy = data.updateBy;
                model.updateDate = data.updateDate;
            }
            var rs = _context.SaveChanges();
            return rs;
        }
        public int Insert(GenreModel data)
        {
            if (data != null)
            {
                var model = new GenreMast();
                model.genCode = data.genreCode;
                model.genDesc = data.genreDesc;
                model.recStatus = data.recStatus;
                model.sortSeq = data.sortSeq;
                model.createBy = data.createBy;
                model.createDate = data.createDate;
                _context.GenreMasts.Add(model);
            }
            var rs = _context.SaveChanges();
            return rs;
        }
    }
}
