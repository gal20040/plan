using FluentNHibernate.Cfg;
using IU.Plan.Web.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Web;

namespace IU.Plan.Web.NHibernate
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;

        static NHibernateHelper()
        {
            var nhiberCfg = new Configuration().Configure();
            var configuration = Fluently.Configure(nhiberCfg)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EventMap>())
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}