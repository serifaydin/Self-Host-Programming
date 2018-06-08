using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.NHDatabase;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IQSELFHOSTAPI.Repository
{
    public class RepositoryCompanyBase<T> : ICrudRepository<T> where T : class
    {
        ISession createSession;
        public RepositoryCompanyBase(string ServerName, string UserName, string Password, string Database)
        {
            createSession = CompanyNHDatabaseContext.SessionOpen(ServerName, UserName, Password, Database);
        }

        public bool Insert(T entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Insert(T entities, Exception exception) - Çalıştı.");

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

                        ConsoleMessage.ConsoleWrite("Insert(T entities, Exception exception) - Hata Oluştu : " + ex.Message + ", İşlem Geri Alındı.");

                        return false;
                    }
                }
            }
            return true;
        }

        public bool ReturnModelInsert(T entities, ref T resultModel, ref Exception excection)
        {
            ConsoleMessage.ConsoleWrite("ReturnModelInsert(T entities, ref T resultModel, ref Exception excection) - Çalıştı.");

            using (ISession _session = createSession)
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entities);
                        _transaction.Commit();

                        resultModel = entities;

                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        excection = ex;

                        ConsoleMessage.ConsoleWrite("ReturnModelInsert(T entities, ref T resultModel, ref Exception excection) - Hata Oluştu : " + ex.Message + ", İşlem Geri Alındı.");

                        return false;
                    }
                }
            }
            return true;
        }

        public bool Update(T entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Update(T entities, ref Exception exception) - Çalıştı.");

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

                        ConsoleMessage.ConsoleWrite("Update(T entities, ref Exception exception) - Hata Oluştu : " + ex.Message + ", İşlem Geri Alındı.");

                        exception = ex;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Delete(T entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Delete(T entities, ref Exception exception) - Çalıştı.");

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
            ConsoleMessage.ConsoleWrite("GetById(int id, ref T gyIdModel, ref Exception exception) - Çalıştı.");

            using (ISession _session = createSession)
            {
                try
                {
                    gyIdModel = _session.Get<T>(id);
                }
                catch (Exception ex)
                {
                    exception = ex;

                    ConsoleMessage.ConsoleWrite("GetById(int id, ref T gyIdModel, ref Exception exception) - Hata Oluştu : " + ex.Message);

                    return false;
                }
            }
            return true;
        }

        public bool GetList(ref List<T> List, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("GetList(BusinessLayerResult<T> List, ref Exception exception) - Çalıştı.");

            using (ISession _session = createSession)
            {
                try
                {
                    List = _session.Query<T>().ToList();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    ConsoleMessage.ConsoleWrite("GetList(BusinessLayerResult<T> List, ref Exception exception) - Hata Oluştu :." + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public bool GetList(Expression<Func<T, bool>> expression, ref List<T> List, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("GetList(Expression<Func<T, bool>> expression, ref List<T> List, ref Exception exception) - Çalıştı.");

            using (ISession session = createSession)
            {
                try
                {
                    List = session.Query<T>().Where(expression).ToList();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    ConsoleMessage.ConsoleWrite("GetList(Expression<Func<T, bool>> expression, ref List<T> List, ref Exception exception) - Hata Oluştu :." + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public bool Delete(IEnumerable<T> entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Delete(IEnumerable<T> entities, Exception exception) - Çalıştı.");

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
                        ConsoleMessage.ConsoleWrite("Delete(IEnumerable<T> entities, Exception exception) - Hata Oluştu : " + ex.Message + " , İşlem Geri Alındı.");
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Insert(IEnumerable<T> entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Insert(IEnumerable<T> entities, ref Exception exception) - Çalıştı.");

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
                        ConsoleMessage.ConsoleWrite("Insert(IEnumerable<T> entities, ref Exception exception) - Hata Oluştu : " + ex.Message + " , İşlem Geri Alındı.");
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Update(IEnumerable<T> entities, ref Exception exception)
        {
            ConsoleMessage.ConsoleWrite("Update(IEnumerable<T> entities, ref Exception exception) - Çalıştı.");

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
                        ConsoleMessage.ConsoleWrite("Update(IEnumerable<T> entities, ref Exception exception) - Hata Oluştu : " + ex.Message + " , İşlem Geri Alındı.");
                        return false;
                    }
                }
            }

            return true;
        }

    }
}