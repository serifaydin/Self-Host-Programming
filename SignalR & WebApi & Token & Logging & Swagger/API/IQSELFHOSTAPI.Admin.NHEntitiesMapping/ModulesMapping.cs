using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class ModulesMapping : CustomClassMap<Modules>
    {
        public ModulesMapping()
        {
            Table("tblModules");
            Map(x => x.ModuleName).Not.Nullable();
            Map(x => x.TopModuleID).Not.Nullable().Default("0");

            OtherColumnsSet(CustomClassMapStatus.SadeceID);
        }
    }
}