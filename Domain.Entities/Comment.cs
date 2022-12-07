using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment:IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор автора отзыва
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Автор отзыва
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Идентификатор товара на который совершен отзыв
        /// </summary>
        public Guid ProductId{ get; set; }

        /// <summary>
        /// Товар на который совершен отзыв
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string Text{ get; set; }        

    }
}
