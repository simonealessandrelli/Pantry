using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Pantry.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pantry.Models.Repositories {
    public class EntityRepository<T> : IRepository<T> where T : IEntity {

        public T Add(T entity) {
            using (var session = NHibernateHelper.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    session.Save(entity);
                    transaction.Commit();
                }
                return entity;
            }
        }

        public void Remove(T entity) {
            using (var session = NHibernateHelper.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public T GetById(int id) {
            using (var session = NHibernateHelper.OpenSession())
                return session.Get<T>(id);
        }

        public IEnumerable<T> Get() {
            using (var session = NHibernateHelper.OpenSession())
                return session.Query<T>().ToList();
        }

        public T GetByName(string name) {
            using (var session = NHibernateHelper.OpenSession()) {
                ICriteria cr = session.CreateCriteria(typeof(Units));
                return cr.Add(Expression.Eq("Name", name)).List<T>()[0];
            }
        }

        public T Update(T entity) {
            using (var session = NHibernateHelper.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    session.SaveOrUpdate(entity);
                    try {
                        transaction.Commit();
                    } catch (Exception) {
                        throw;
                    }
                }
                return entity;
            }
        }
    }
}