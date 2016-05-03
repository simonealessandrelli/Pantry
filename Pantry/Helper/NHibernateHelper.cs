using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Pantry.Models;

namespace Pantry.Helper {
    public class NHibernateHelper {

        //OpenSession
        public static ISession OpenSession() {
            return SessionFactory.OpenSession();
        }

        //Configuration
        #region Configuration
        private static Configuration _configuration;
        private static Configuration Configuration{
            get{
                if (_configuration == null)
                    _configuration = CreateConfiguration();
                return _configuration;
            }
        }
        private static Configuration CreateConfiguration() {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(Units).Assembly);
            return configuration;
        }
        #endregion

        //Session Factory
        #region SessionFactory
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory{
            get{
                if (_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory();
                return _sessionFactory;
            }
        }
   
        private static ISessionFactory CreateSessionFactory() {
            var sessionFactory = Configuration.BuildSessionFactory();
            new SchemaExport(Configuration).Execute(false, true, false);
            return sessionFactory;
        }
        #endregion
    }
}