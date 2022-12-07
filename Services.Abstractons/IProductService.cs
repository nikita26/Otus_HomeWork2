using Domain.Entities;

namespace Services.Abstractons
{
    public interface IProductService
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAll();

        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns></returns>
        Task<Product> GetById(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Create(Product comment);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Update(Product comment);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}