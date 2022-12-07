using Domain.Entities;

namespace Services.Abstractons
{
    public interface ICommentService
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetAll();

        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Comment> GetById(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Create(Comment comment);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Update(Comment comment);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}