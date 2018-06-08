using FluentNHibernate.Mapping;
using IQSELFHOSTAPI.Company.Entities.HelperModels;

namespace IQSELFHOSTAPI.Company.NHEntitiesMapping
{
    public class CustomClassMap<T> : ClassMap<T>
    {
        public CustomClassMap()
        {
            EntityBase eBase = new EntityBase();
            Id(x => eBase.TabloID).GeneratedBy.Identity();
            Map(x => eBase.CreatedOn).Not.Nullable().Default("getdate()");
            Map(x => eBase.IsActive).Default("1");
        }
    }
}