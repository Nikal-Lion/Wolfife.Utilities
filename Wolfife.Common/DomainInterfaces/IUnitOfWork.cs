using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wolfife.Common.DomainInterfaces
{
    public interface IUnitOfWork
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //IDbContextTransaction BeginTranscation();
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="transaction"></param>
        //void Commit(IDbContextTransaction transaction);
        /// <summary>
        /// 
        /// </summary>
        void Commit();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        void Commit(Func<bool> func);
        void Commit(Func<object, bool> func);
        Task CommitAsync(CancellationToken cancellation = default);
        /// <summary>
        /// 事务执行方法
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task CommitAsync(Func<bool> func, CancellationToken cancellation = default);
        Task CommitAsync(Func<object, bool> func, CancellationToken cancellation = default);
    }
}
