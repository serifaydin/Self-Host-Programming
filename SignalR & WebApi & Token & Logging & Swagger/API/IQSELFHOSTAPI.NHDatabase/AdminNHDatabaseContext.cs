using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IQSELFHOSTAPI.Admin.NHEntitiesMapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace IQSELFHOSTAPI.NHDatabase
{
    public class AdminNHDatabaseContext
    {
        private static ISessionFactory session;

        private static ISessionFactory CreateSession(string ServerName, string UserName, string Password, string Database)
        {
            if (session != null)
                return session;

            FluentConfiguration _config = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.Server(@ServerName).Username(UserName).Password(Password).Database("BackOfficeAdminDB")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompaniesMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorityGroupMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModulesMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyApplicationUserMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorityGroupModulesMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ApplicationMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyApplicationLicenseMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserTokenMapping>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            session = _config.BuildSessionFactory();
            return session;
        }

        public static ISession SessionOpen(string ServerName, string UserName, string Password, string Database)
        {
            return CreateSession(ServerName, UserName, Password, Database).OpenSession();
        }
    }
}