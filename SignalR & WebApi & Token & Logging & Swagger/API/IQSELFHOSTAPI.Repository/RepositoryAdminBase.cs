using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.NHDatabase;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IQSELFHOSTAPI.Repository
{
    public class RepositoryAdminBase<T> : ICrudRepository<T> where T : class
    {
        ISession createSession;
        public RepositoryAdminBase(string ServerName, string UserName, string Password, string Database)
        {
            createSession = AdminNHDatabaseContext.SessionOpen(ServerName, UserName, Password, Database);
        }

        public bool Insert(T entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - Insert(T entities, ref Exception exception) - Çalıştı.");

            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entities);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ReturnModelInsert(T entities, ref T returnModel, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - ReturnModelInsert(T entities, ref T returnModel, ref Exception exception) - Çalıştı.");

            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entities);
                        _transaction.Commit();

                        returnModel = entities;
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Update(T entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - Update(T entities, ref Exception exception) - Çalıştı");
            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entities);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Delete(T entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - Delete(T entities, ref Exception exception) - Çalıştı.");

            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entities);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        ConsoleMessage.ConsoleWrite("Delete(T entities, ref Exception exception) : " + ex.Message + ", İşlem Geri Alındı.");
                        return false;
                    }
                }
            }
            return true;
        }

        public bool GetById(int id, ref T gyIdModel, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - GetById(int id, ref T gyIdModel, ref Exception exception) - Çalıştı");
            using (ISession _session = createSession)
            {
                try
                {
                    gyIdModel = _session.Get<T>(id);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    return false;
                }
            }
            return true;
        }

        public bool GetList(ref List<T> List, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - GetList(ref List<T> List, ref Exception exception) - Çalıştı");

            using (ISession _session = createSession)
            {
                try
                {
                    List = _session.Query<T>().ToList();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    return false;
                }
            }
            return true;
        }

        public bool GetList(Expression<Func<T, bool>> expression, ref List<T> List, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - GetList(Expression<Func<T, bool>> expression, ref List<T> List, ref Exception exception) - Çalıştı");
            using (ISession session = createSession)
            {
                try
                {
                    List = session.Query<T>().Where(expression).ToList();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    return false;
                }
            }
            return true;
        }

        public bool Delete(IEnumerable<T> entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - Delete(IEnumerable<T> entities, ref Exception exception) - Çalıştı");
            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        foreach (T entity in entities)
                        {
                            _session.Delete(entity);
                        }

                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Insert(IEnumerable<T> entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - Insert(IEnumerable<T> entities, ref Exception exception) - Çalıştı");
            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        foreach (T entity in entities)
                        {
                            _session.Save(entity);
                        }

                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Update(IEnumerable<T> entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Admin - Update(IEnumerable<T> entities, ref Exception exception) - Çalıştı");
            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        foreach (T entity in entities)
                        {
                            _session.Update(entity);
                        }

                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        exception = ex;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}