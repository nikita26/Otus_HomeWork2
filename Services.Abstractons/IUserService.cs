using Domain.Entities;
using Services.Contracts;

namespace Services.Abstractons
{
    public interface IUserService
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDto> GetAll();

        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<UserDto> GetById(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        UserDto Create(UserDto comment);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task Update(UserDto comment);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}