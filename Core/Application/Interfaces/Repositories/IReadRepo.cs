using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IReadRepo<T> where T : class, IEntityBase,new()
    {
        /// <summary>
        /// Belirtilen kriterlere uyan tüm kayıtları asenkron olarak getirir.
        /// </summary>
        /// <param name="predicate">
        /// Uygulanacak isteğe bağlı bir filtreleme koşulu.
        /// </param>
        /// <param name="include">
        /// İlişkili varlıkları dahil etmek için isteğe bağlı bir fonksiyon.
        /// </param>
        /// <param name="orderBy">
        /// Sonuçları sıralamak için isteğe bağlı bir fonksiyon.
        /// </param>
        /// <param name="enableTracking">
        /// Entity Framework'ün değişiklik takip sistemini etkinleştirme seçeneği.
        /// Varsayılan olarak false, yani takip edilmez.
        /// </param>
        /// <returns>
        /// Kriterlere uyan varlıkların listesini döner.
        /// </returns>
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);
        /// <summary>
        /// Sayfalama özelliği ile belirtilen kriterlere uyan kayıtları asenkron olarak getirir.
        /// </summary>
        /// <param name="predicate">
        /// Uygulanacak isteğe bağlı bir filtreleme koşulu.
        /// </param>
        /// <param name="include">
        /// İlişkili varlıkları dahil etmek için isteğe bağlı bir fonksiyon.
        /// </param>
        /// <param name="orderBy">
        /// Sonuçları sıralamak için isteğe bağlı bir fonksiyon.
        /// </param>
        /// <param name="enableTracking">
        /// Entity Framework'ün değişiklik takip sistemini etkinleştirme seçeneği.
        /// Varsayılan olarak false, yani takip edilmez.
        /// </param>
        /// <param name="currentPage">
        /// Mevcut sayfa numarası.
        /// </param>
        /// <param name="pageSize">
        /// Sayfa başına düşen kayıt sayısı.
        /// </param>
        /// <returns>
        /// Belirtilen sayfaya ait varlıkların listesini döner.
        /// </returns>
        Task<IList<T>> GetAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);
        /// <summary>
        /// Belirtilen koşula uyan kayıtları asenkron olarak getirir.
        /// </summary>
        /// <param name="predicate">
        /// Uygulanacak filtreleme koşulu.
        /// </param>
        /// <param name="include">
        /// İlişkili varlıkları dahil etmek için isteğe bağlı bir fonksiyon.
        /// </param>
        /// <param name="enableTracking">
        /// Entity Framework'ün değişiklik takip sistemini etkinleştirme seçeneği.
        /// Varsayılan olarak false, yani takip edilmez.
        /// </param>
        /// <returns>
        /// Koşula uyan varlıkların listesini döner.
        /// </returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>,IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
        /// <summary>
        /// Belirtilen koşula uyan kayıtları sorgulamak için bir IQueryable döner.
        /// </summary>
        /// <param name="predicate">
        /// Uygulanacak filtreleme koşulu.
        /// </param>
        /// <returns>
        /// Koşula uyan varlıklar üzerinde ek işlemler yapabilmek için bir IQueryable döner.
        /// </returns>
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);
        /// <summary>
        /// Belirtilen koşula uyan kayıtların sayısını asenkron olarak döner.
        /// </summary>
        /// <param name="predicate">
        /// Sayma işlemi için isteğe bağlı bir filtreleme koşulu.
        /// </param>
        /// <returns>
        /// Koşula uyan kayıt sayısını döner.
        /// </returns>
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
