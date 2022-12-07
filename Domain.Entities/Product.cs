using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product: IEntity<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Стоимость товара
        /// </summary>
        public double Cost { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; }
    }
}
