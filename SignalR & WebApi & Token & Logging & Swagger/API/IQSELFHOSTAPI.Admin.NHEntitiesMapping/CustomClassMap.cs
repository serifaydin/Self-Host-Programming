using FluentNHibernate.Mapping;
using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class CustomClassMap<T> : ClassMap<T>
    {
        public void OtherColumnsSet(CustomClassMapStatus customStatus)
        {
            EntityBase eBase = new EntityBase();
            Id(x => eBase.TabloID).GeneratedBy.Identity();

            if (customStatus == CustomClassMapStatus.SadeceID)
                return;

            Map(x => eBase.CreatedOn).Not.Nullable();
            Map(x => eBase.ModifiedOn).Not.Nullable();
            Map(x => eBase.ModifiedUsername);
            Map(x => eBase.IsActive);

            if (customStatus == CustomClassMapStatus.CustomFieldlarıEkleme)
                return;

            Map(x => eBase.CustomField1);
            Map(x => eBase.CustomField2);
            Map(x => eBase.CustomField3);
            Map(x => eBase.CustomField4);
            Map(x => eBase.CustomField5);
            Map(x => eBase.CustomField6);
            Map(x => eBase.CustomField7);
            Map(x => eBase.CustomField8);
            Map(x => eBase.CustomField9);
            Map(x => eBase.CustomField10);
        }
    }

    public enum CustomClassMapStatus
    {
        SadeceID = 0,
        CustomFieldlarıEkleme = 1,
        TumParametreler = 2
    }
}