namespace Services.Contracts
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор автора отзыва
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Автор отзыва
        /// </summary>
        public UserDto Author { get; set; }

        /// <summary>
        /// Идентификатор товара на который совершен отзыв
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Товар на который совершен отзыв
        /// </summary>
        public ProductDto Product { get; set; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string Text { get; set; }

    }
}