using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IQSELFHOSTAPI.Company.NHEntitiesMapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace IQSELFHOSTAPI.NHDatabase
{
    public class CompanyNHDatabaseContext
    {
        private static ISessionFactory session;

        private static ISessionFactory CreateSession(string ServerName, string UserName, string Password, string Database)
        {
            if (session != null)
                return session;

            FluentConfiguration _config = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                     x => x.Server(@ServerName).Username(UserName).Password(Password).Database(Database)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<posApplicationLogsMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<posTransactionLogsMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DashboardPanelMapping>())
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