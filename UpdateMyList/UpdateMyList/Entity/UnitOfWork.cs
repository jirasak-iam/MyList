using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Entity.Repository;

namespace UpdateMyList.Entity
{
    public interface IUnitOfWork
    {
        int Save();
        void Dispose();
        IMyListRepository MyListRepository { get; }
        IListTypeMastRepository ListTypeMastRepository { get; }
        IStsMastRepository StsMastRepository { get; }
        ISeasonMastRepository SeasonMastRepository { get; }
        IGenreMastRepository GenreMastRepository { get; }
        IMapSetingParamRepository MapSetingParamRepository { get; }
        IGenreGroupRepository GenreGroupRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public myListEntities _context;
        private bool _disposed;

        public UnitOfWork()
        {
            _context = new myListEntities();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
            _disposed = true;
        }

        private MyListRepository _myListRepository;
        private ListTypeMastRepository _listTypeMastRepository;
        private StsMastRepository _stsMastRepository;
        private SeasonMastRepository _seasonMastRepository;
        private GenreMastRepository _genreMastRepository;
        private MapSetingParamRepository _mapSettingParamRepository;
        private GenreGroupRepository _genreGroupRepository;
        public IMyListRepository MyListRepository
        {
            get { return _myListRepository ?? (_myListRepository = new MyListRepository(_context)); }
        }
        public IListTypeMastRepository ListTypeMastRepository
        {
            get { return _listTypeMastRepository ?? (_listTypeMastRepository = new ListTypeMastRepository(_context)); }
        }
        public IStsMastRepository StsMastRepository
        {
            get { return _stsMastRepository ?? (_stsMastRepository = new StsMastRepository(_context)); }
        }
        public ISeasonMastRepository SeasonMastRepository
        {
            get { return _seasonMastRepository ?? (_seasonMastRepository = new SeasonMastRepository(_context)); }
        }
        public IGenreMastRepository GenreMastRepository
        {
            get { return _genreMastRepository ?? (_genreMastRepository = new GenreMastRepository(_context)); }
        }
        public IMapSetingParamRepository MapSetingParamRepository
        {
            get { return _mapSettingParamRepository ?? (_mapSettingParamRepository = new MapSetingParamRepository(_context)); }
        }
        public IGenreGroupRepository GenreGroupRepository
        {
            get { return _genreGroupRepository ?? (_genreGroupRepository = new GenreGroupRepository(_context)); }
        }
    }
}
