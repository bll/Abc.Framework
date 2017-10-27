using DevFramework.Core.Entities;
using System.Linq;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQuerybleRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;
        public NhQuerybleRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

       
        public IQueryable<T> Table => this.Entities;
        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _nHibernateHelper.OpenSession().Query<T>();
                }

                return _entities;
            }
        }

    }
}
