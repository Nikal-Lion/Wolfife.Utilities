using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Wolfife.Common.Extensions
{
    public static partial class IQueryExtensions
    {
        #region WhereIf
        /// <summary>
        /// 当condition == true 条件成立时，为query追加 predicate 条件 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">原始查询query</param>
        /// <param name="predicate">追加的查询条件</param>
        /// <param name="condition">是否追加</param>
        /// <returns>追加查询条件的query</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, bool condition)
            => condition ? query.Where(predicate) : query;

        /// <summary>
        /// 当condition == true 条件成立时，为query追加 predicate 条件 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">原始查询query</param>
        /// <param name="predicate">追加的查询条件</param>
        /// <param name="condition">是否追加</param>
        /// <returns>追加查询条件的query</returns>
        /// <remarks>
        /// predicate 的第二个（int）参数可用于索引，或者统计数量等外部传入数量参数限制
        /// </remarks>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, int, bool>> predicate, bool condition)
            => condition ? query.Where(predicate) : query;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">原始查询query</param>
        /// <param name="condition">是否追加</param>
        /// <param name="firstPredicate"></param>
        /// <param name="secondPredicate"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIfElse<T>
            (this IQueryable<T> query, bool condition
            , Expression<Func<T, bool>> firstPredicate
            , Expression<Func<T, bool>> secondPredicate)
            => condition ? query.Where(firstPredicate) : query.Where(secondPredicate);

        #endregion
        #region Get Page Result
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, string>> orderBy, int c, int ps)
            where T : class
        {
            return query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, int?>> orderBy, int c, int ps)
            where T : class
        {
            return query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, DateTime?>> orderBy, int c, int ps)
            where T : class
        {
            return query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, decimal?>> orderBy, int c, int ps)
            where T : class
        {
            return query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, bool?>> orderBy, int c, int ps)
            where T : class
        {
            return query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, string>> orderBy
            , int c, int ps, string sort)
            where T : class
        {
            return sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToList()
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, int?>> orderBy
            , int c, int ps, string sort)
            where T : class
        {
            return sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToList()
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, DateTime?>> orderBy
            , int c, int ps, string sort)
            where T : class
        {
            return sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToList()
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, decimal?>> orderBy
            , int c, int ps, string sort)
            where T : class
        {
            return sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToList()
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }
        /// <summary>
        /// Get IQueryable<T> query to page list
        /// </summary>
        /// <typeparam name="T">domain entity's type</typeparam>
        /// <param name="query"></param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <returns>The list of entities</returns>
        public static IEnumerable<T> ToPageResult<T>(this IQueryable<T> query, Expression<Func<T, bool?>> orderBy
            , int c, int ps, string sort)
            where T : class
        {
            return sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToList()
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToList();
        }

        /// <summary>
        /// to page list async
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="query">query </param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <param name="cancellationToken">cancel token</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>(this IQueryable<T> query, Expression<Func<T, string>> orderBy, int c, int ps, CancellationToken cancellationToken = default)
            where T : class
        {
            return await query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken);
        }
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>(this IQueryable<T> query, Expression<Func<T, int?>> orderBy, int c, int ps, CancellationToken cancellationToken = default)
            where T : class
        {
            return await query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken);
        }
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>(this IQueryable<T> query, Expression<Func<T, DateTime?>> orderBy, int c, int ps, CancellationToken cancellationToken = default)
            where T : class
        {
            return await query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken);
        }
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>(this IQueryable<T> query, Expression<Func<T, decimal?>> orderBy, int c, int ps, CancellationToken cancellationToken = default)
            where T : class
        {
            return await query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken);
        }
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool?>> orderBy, int c, int ps, CancellationToken cancellationToken = default)
            where T : class
        {
            return await query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// to page list async
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="query">query </param>
        /// <param name="c">page index</param>
        /// <param name="ps">page size</param>
        /// <param name="cancellationToken">cancel token</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>
            (this IQueryable<T> query, Expression<Func<T, string>> orderBy
            , int c, int ps, string sort
            , CancellationToken cancellationToken = default)
            where T : class
        {
            return await (
                sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken)
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <param name="c"></param>
        /// <param name="ps"></param>
        /// <param name="sort"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>
            (this IQueryable<T> query, Expression<Func<T, int?>> orderBy
            , int c, int ps, string sort
            , CancellationToken cancellationToken = default)
            where T : class
        {
            return await (
                sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken)
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <param name="c"></param>
        /// <param name="ps"></param>
        /// <param name="sort"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>
            (this IQueryable<T> query, Expression<Func<T, DateTime?>> orderBy
            , int c, int ps, string sort
            , CancellationToken cancellationToken = default)
            where T : class
        {
            return await (
                sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken)
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <param name="c"></param>
        /// <param name="ps"></param>
        /// <param name="sort"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>
            (this IQueryable<T> query, Expression<Func<T, decimal?>> orderBy
            , int c, int ps, string sort
            , CancellationToken cancellationToken = default)
            where T : class
        {
            return await (
                sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken)
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <param name="c"></param>
        /// <param name="ps"></param>
        /// <param name="sort"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ToPageResultAsync<T>
            (this IQueryable<T> query, Expression<Func<T, bool?>> orderBy
            , int c, int ps, string sort
            , CancellationToken cancellationToken = default)
            where T : class
        {
            return await (
                sort.IgEqual("desc")
                ? query.OrderByDescending(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken)
                : query.OrderBy(orderBy).Skip((c - 1) * ps).Take(ps).ToListAsync(cancellationToken));
        }

        #endregion
        #region Get orderby query
        /// <summary>
        /// 随机排序扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByCheckSum<T>(this IEnumerable<T> source, string along)
        {
            return source.AsQueryable().OrderBy(d => CheckSum(along));
        }

        #endregion
    }
    partial class IQueryExtensions
    {
        /// <summary>
        /// 使用new guid 排序
        /// </summary>
        /// <returns></returns>
        [DbFunction("SqlServer", "NEWID")]
        public static Guid NewId()
        {
            return Guid.NewGuid();
        }
        /// <summary>
        /// 使用check sum 排序
        /// </summary>
        /// <param name="text">需要计算的源参数</param>
        /// <remarks>
        /// The built-in CHECKUM function in SQL Server is built on a series of 4 bit left rotational xor operations.
        /// See this [post](https://www.sqlteam.com/forums/topic.asp?TOPIC_ID=70832) for more explanation.
        /// </remarks>
        /// <returns></returns>
        [DbFunction("SqlServer", "CHECKSUM")]
        public static int CheckSum(string text)
        {
            long sum = 0;
            byte overflow;
            for (int i = 0; i < text.Length; i++)
            {
                sum = (long)((16 * sum) ^ Convert.ToUInt32(text[i]));
                overflow = (byte)(sum / 4294967296);
                sum -= overflow * 4294967296;
                sum ^= overflow;
            }

            if (sum > 2147483647)
            {
                sum -= 4294967296;
            }
            else if (sum >= 32768 && sum <= 65535)
            {
                sum -= 65536;
            }
            else if (sum >= 128 && sum <= 255)
            {
                sum -= 256;
            }

            return (int)sum;

        }

    }
}
