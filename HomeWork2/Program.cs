using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Implementations;
using Services.Abstractons;
using AutoMapper;
using Services.Implementations.Mapping;

namespace HomeWork2
{
    public class Program
    {
        public static void Main()
        {

            var builder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration["ConnectionString"];
            if (connectionString == null)
            {
                throw new Exception("Connection string is null");
            }

            var dbOption = new DbContextOptionsBuilder<DataBaseContext>();
            dbOption.UseNpgsql(connectionString);


            #region Dependency Injection
            var mapperConf = new MapperConfiguration(conf => {
                conf.AddProfile<UserMappingProfile>();
            });

            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataBaseContext>(options => {
                    options.UseNpgsql(connectionString);
                })
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddSingleton<IMapper>(new Mapper(mapperConf))
                .BuildServiceProvider();

            var userDI = serviceProvider.GetService<IUserService>();
            var userData = userDI.GetAll();
            #endregion


            var user = new UserRepository(new DataBaseContext(dbOption.Options));
            var product = new ProductRepository(new DataBaseContext(dbOption.Options));
            var comment = new CommentRepository(new DataBaseContext(dbOption.Options));

            InsertDefaultDataInDataBase(user, product, comment);

            while (true)
            {
                ShowAllTables(user, product, comment);
                StartInsertData(user, product, comment);
            }
        }

        /// <summary>
        /// Заполение БД данными
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="comment"></param>
        public static void InsertDefaultDataInDataBase(IUserRepository user, IProductRepository product, ICommentRepository comment)
        {
            var u = user.GetAll().ToList();
            var p = product.GetAll().ToList();
            var c = comment.GetAll().ToList();

            foreach (var item in u)
                user.Delete(item.Id);
            user.SaveChanges();


            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            var productId1 = Guid.NewGuid();
            var productId2 = Guid.NewGuid();
            var productId3 = Guid.NewGuid();
            var productId4 = Guid.NewGuid();
            var productId5 = Guid.NewGuid();


            user.AddCollection(new User[]{
        new User() { Id = userId1, Email = "1@mainl.ru", Login = "user1", Password = "password", Name = "1", Surname = "2", Patronimic = "3",
            Products = new Product[]{
                new Product(){ Id=productId1,Cost=25000,Name="Ноутбук",Description="Продам ноутбук в хорошем состоянии"},
                new Product(){ Id=productId2,Cost=2500,Name="Коллекционна монета",Description="Коллекционная монета 1 рубль 1980 года"},
                new Product(){ Id=productId3,Cost=100000,Name="Продам авто",Description="Жигули 1990 года, 3 владельца, состояние на 3"},
            },
        },
        new User() { Id = userId2, Email = "2@mainl.ru", Login = "user2", Password = "password", Name = "a", Surname = "b", Patronimic = "c",
            Products = new Product[]{
                new Product(){ Id=productId4,Cost=25000,Name="Стол",Description="Продаю стол в хорошем состоянии"},
                new Product(){ Id=productId5,Cost=25000,Name="Телефон",Description="Старый телефон, работает"},
            }
        },
        new User() { Id = Guid.NewGuid(), Email = "3@mainl.ru", Login = "user3", Password = "password", Name = "Nik", Surname = "И", Patronimic = "Петрович" },
        new User() { Id = Guid.NewGuid(), Email = "4@mainl.ru", Login = "user4", Password = "password", Name = "Миша", Surname = "Иванов", Patronimic = "" },
        new User() { Id = Guid.NewGuid(), Email = "5@mainl.ru", Login = "user5", Password = "password", Name = "Ваня", Surname = "Сидоров", Patronimic = "" }
        });

            comment.AddCollection(new Comment[] {
            new Comment(){Id=Guid.NewGuid(),AuthorId = userId1,ProductId=productId1,Text="средний продавец" },
            new Comment(){Id=Guid.NewGuid(),AuthorId = userId1,ProductId=productId2,Text="отличный продавец" },
            new Comment(){Id=Guid.NewGuid(),AuthorId = userId1,ProductId=productId3,Text="плохой продавец" },
            new Comment(){Id=Guid.NewGuid(),AuthorId = userId2,ProductId=productId4,Text="хороший продавец" },
            new Comment(){Id=Guid.NewGuid(),AuthorId = userId2,ProductId=productId5,Text="нормальный продавец" },
        });

            user.SaveChanges();
            product.SaveChanges();
            comment.SaveChanges();

        }

        /// <summary>
        /// Вывод данных из всех таблиц
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="comment"></param>
        public static void ShowAllTables(IUserRepository user, IProductRepository product, ICommentRepository comment)
        {
            var u = user.GetAll().ToList();
            var p = product.GetAll().ToList();
            var c = comment.GetAll().ToList();

            Console.WriteLine("\n1. Users");
            Console.WriteLine("Id Login Password Name Surname Patronimic");
            foreach (var item in u)
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", item.Id, item.Login, item.Password, item.Name, item.Surname, item.Patronimic, item.Email);

            Console.WriteLine("\n\n2. Products");
            Console.WriteLine("Id UserId Name Cost Description ");

            foreach (var item in p)
                Console.WriteLine("{0} | {1} | {2} | {3} | {4}", item.Id, item.UserId, item.Name, item.Cost, item.Description);

            Console.WriteLine("\n\n3. Comment");
            Console.WriteLine("Id AuthorId ProductId Text");

            foreach (var item in c)
                Console.WriteLine("{0} | {1} | {2} | {3}", item.Id, item.AuthorId, item.ProductId, item.Text);

        }

        /// <summary>
        /// Запуск сценария выбора таблиццы для ввода данных 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="comment"></param>
        public static void StartInsertData(IUserRepository user, IProductRepository product, ICommentRepository comment)
        {
            Console.WriteLine("\n\n1. Users");
            Console.WriteLine("2. Products");
            Console.WriteLine("3. Comment");
            Console.Write("Введите номер таблицы для ввода данных: ");
            var tableNum = Console.ReadLine();

            if (tableNum == "1")
                InsertIntoUsers(user);
            else if (tableNum == "2")
                InsertIntoProduct(product, user);
            else if (tableNum == "3")
                InsertIntoComment(comment, user, product);
            else
                InsertIntoUsers(user);

        }

        /// <summary>
        /// Запись в таблицу Users
        /// </summary>
        /// <param name="repository"></param>
        public static void InsertIntoUsers(IUserRepository repository)
        {
            var newUser = new User() { Id = Guid.NewGuid() };
            Console.Write("\nВведите Login: ");
            newUser.Login = Console.ReadLine();

            Console.Write("Введите Password: ");
            newUser.Password = Console.ReadLine();

            Console.Write("Введите Name: ");
            newUser.Name = Console.ReadLine();

            Console.Write("Введите Surname: ");
            newUser.Surname = Console.ReadLine();

            Console.Write("Введите Patronimic: ");
            newUser.Patronimic = Console.ReadLine();

            Console.Write("Введите Email: ");
            newUser.Email = Console.ReadLine();

            repository.Add(newUser);
            repository.SaveChanges();
        }

        /// <summary>
        /// Запись в таблицу Products
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userRepository"></param>
        public static void InsertIntoProduct(IProductRepository repository, IUserRepository userRepository)
        {
            var newProduct = new Product() { Id = Guid.NewGuid() };
            Console.Write("\nВведите Name: ");
            newProduct.Name = Console.ReadLine();

            Console.Write("Введите Cost: ");
            var costS = Console.ReadLine();
            var resultB = double.TryParse(costS, out var result);
            while (!resultB)
            {
                Console.Write("Введите Cost(должны быть числом): ");
                costS = Console.ReadLine();
                resultB = double.TryParse(costS, out result);
            }
            newProduct.Cost = result;

            Console.Write("Введите Description :");
            newProduct.Description = Console.ReadLine();

            var users = userRepository.GetAll().ToList();
            foreach (var item in users)
                Console.WriteLine("{0}. {1} {2}", users.IndexOf(item), item.Id, item.Login);

            Console.Write("Введите номер пользователя которому будет принадлежать новый товар: ");
            int userIndex = 0;
            if (int.TryParse(Console.ReadLine(), out var resultI))
                userIndex = resultI;

            newProduct.UserId = users[userIndex].Id;


            repository.Add(newProduct);
            repository.SaveChanges();

        }

        /// <summary>
        /// Запись в таблицу Comments
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userRepository"></param>
        /// <param name="productRepository"></param>
        public static void InsertIntoComment(ICommentRepository repository, IUserRepository userRepository, IProductRepository productRepository)
        {
            var newComment = new Comment() { Id = Guid.NewGuid() };
            Console.WriteLine("\nВведите Text: ");
            newComment.Text = Console.ReadLine();

            var users = userRepository.GetAll().ToList();
            foreach (var item in users)
                Console.WriteLine("{0}. {1} {2}", users.IndexOf(item), item.Id, item.Login);

            Console.Write("Введите номер пользователя которому будет принадлежать комментарий: ");
            int userIndex = 0;
            if (int.TryParse(Console.ReadLine(), out var resultI))
                userIndex = resultI;

            newComment.AuthorId = users[userIndex].Id;


            var products = productRepository.GetAll().ToList();
            foreach (var item in products)
                Console.WriteLine("{0}. {1} {2}", products.IndexOf(item), item.Id, item.Name);

            Console.Write("Введите номер товара которому будет принадлежать комментарий: ");
            int productIndex = 0;
            if (int.TryParse(Console.ReadLine(), out resultI))
                productIndex = resultI;

            newComment.ProductId = products[productIndex].Id;

            repository.Add(newComment);
            repository.SaveChanges();

        }

    }
}