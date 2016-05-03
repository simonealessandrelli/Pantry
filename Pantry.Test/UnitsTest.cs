using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using Pantry.Models.Repositories;
using Pantry.Models;
using NHibernate.Tool.hbm2ddl;

namespace Pantry.Test {
    [TestClass]
    public class UnitsTest {

        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;
        private static IRepository<Units> _repository;

        [ClassInitialize]
        public static void SetUp(TestContext context) {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Units).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
            _repository = new EntityRepository<Units>();
            new SchemaExport(_configuration).Execute(false, true, false);
        }

        [TestMethod]
        public void CanGenerateSchema() {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Units).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }


        [TestMethod]
        public void CanAddNewUnit() {
            var unit = new Units { Name = "gr" };
            _repository.Add(unit);
        }

        [TestMethod]
        public void CanGetUnit() {
            var unit = _repository.GetByName("gr");
        }

        [TestMethod]
        public void CanUpdateUnit() {
            var unit = _repository.GetByName("gr");
            unit.Name = "Kg";
            _repository.Update(unit);
        }

        [TestMethod]
        public void CanRemoveUnit() {
            var unit = _repository.GetByName("Kg");
            _repository.Remove(unit);
        }
    }
}
