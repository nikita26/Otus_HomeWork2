using Domain.Entities;

namespace Services.Abstractons
{
    public interface IUserService
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAll();

        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<User> GetById(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Create(User comment);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Update(User comment);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}