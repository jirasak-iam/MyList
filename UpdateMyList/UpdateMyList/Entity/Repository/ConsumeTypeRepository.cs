using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IConsumeTypeRepository : IBaseRepository<ConsumeTypeMast>
    {
        List<ConsumeTypeModel> Select();
        List<ConsumeTypeModel> SelectAll();
    }
    public class ConsumeTypeRepository : BaseRepository<ConsumeTypeMast>, IConsumeTypeRepository
    {
        public ConsumeTypeRepository(myListEntities context)
            : base(context)
        {
        }
        public List<ConsumeTypeModel> Select()
        {
            var rs = (
                    from a in _context.ConsumeTypeMasts
                    where a.recStatus == RecStatus.Active
                    orderby a.sortSeq
                    select new ConsumeTypeModel
                    {
                        consumeTypeId = a.consumeTypeId,
                        consumeTypeCode = a.consumeTypeCode,
                        consumeTypeDesc = a.consumeTypeDesc,
                        createBy = a.createBy,
                        createDate = a.createDate,
                        recStatus = a.recStatus,
                        sortSeq = a.sortSeq,
                        updateBy = a.updateBy,
                        updateDate = a.updateDate,
                    }
                ).ToList();
            return rs;
        }
        public List<ConsumeTypeModel> SelectAll()
        {
            var rs = (
                    from a in _context.ConsumeTypeMasts
                    orderby a.sortSeq
                    select new ConsumeTypeModel
                    {
                        consumeTypeCode = a.consumeTypeCode,
                        consumeTypeDesc = a.consumeTypeDesc,
                        consumeTypeId = a.consumeTypeId,
                        createBy = a.createBy,
                        createDate = a.createDate,
                        recStatus = a.recStatus,
                        sortSeq = a.sortSeq,
                        updateBy = a.updateBy,
                        updateDate = a.updateDate,
                    }
                ).ToList();
            return rs;
        }
    }
}
