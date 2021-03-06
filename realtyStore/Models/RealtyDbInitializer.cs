using System.Data.Entity;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;

namespace realtyStore.Models
{
    public class RealtyDbInitializer : DropCreateDatabaseAlways<RealtyContext>
    {
        protected override void Seed(RealtyContext db)
        {
            const string imgUrl = "https://thenationalpilot.ng/wp-content/uploads/2017/07/small-add-placeholder.png";

            db.Roles.Add(new Role { Id = 1, Name = "user" });
            db.Roles.Add(new Role { Id = 2, Name = "realtor" });

            db.Cities.Add(new City { Name = "Москва" });
            db.Cities.Add(new City { Name = "Белгород" });
            db.Cities.Add(new City { Name = "Воронеж" });

            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 19, RealtyId = 1 } );
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 19, RealtyId = 2 } );
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 19, RealtyId = 6 } );
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 18, RealtyId = 1 } );
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 18, RealtyId = 2 } );
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 18, RealtyId = 6 } );
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 1, RealtyId =  4 });
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 1, RealtyId = 5 });
            db.FavoriteRealties.Add(new FavoriteRealties { UserId = 1, RealtyId = 6 });

            db.Users.Add(new myUser {RoleId=1, LogIn = "user13749", Password = "452412", LastName = "Петров", FirstName = "Дмитрий", Patronymic = "Петрович", Phone = "89999964999", Passport = "1413 222332", CityId = 1, Address = "Владимирская Ул., дом 43, кв. 141" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user12049", Password="452412", LastName = "Писаренко", FirstName = "Алена", Patronymic = "Владимировна", Phone = "89203355333", Passport = "1413 666996", CityId = 3, Address = "Чкалова, дом 3, кв. 110" });
            db.Users.Add(new myUser {RoleId=1, LogIn= "user13746", Password="452412", LastName = "Блинов", FirstName = "Фёдор", Patronymic = "Константинович", Phone = "89610036000", Passport = "1414 750077", CityId = 2, Address = "Коммунаров, дом 4, кв. 55" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user13799", Password="452412", LastName = "Папков", FirstName = "Алексей", Patronymic = "Павлович", Phone = "89610036500", Passport = "1415 779077", CityId = 2, Address = "Маяковского Ул., дом 14, кв. 25" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user4659", Password="452412", LastName = "Ермаков", FirstName = "Данила", Patronymic = "Львович", Phone = "89610036080", Passport = "1416 770097", CityId = 2, Address = "Пермякова, дом 2, кв. 72" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user48651", Password="452412", LastName = "Коровина", FirstName = "Мария", Patronymic = "Савельевна", Phone = "89610046000", Passport = "1417 070077", CityId = 2, Address = "Коммуны, дом 129, кв. 60" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user48652", Password="452412", LastName = "Родионов", FirstName = "Михаил", Patronymic = "Тимурович", Phone = "89610436000", Passport = "1418 770073", CityId = 2, Address = "Кожевенный Пер., дом 17, кв. 51" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user562419", Password="452412", LastName = "Рудаков", FirstName = "Роман", Patronymic = "Владиславович", Phone = "89619362000", Passport = "1419 770027", CityId = 2, Address = "90 Лет Победы Ул., дом 55, кв. 92" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user745296", Password="452412", LastName = "Чернышева", FirstName = "Николь", Patronymic = "Кирилловна", Phone = "89610039600", Passport = "1420 770070", CityId = 2, Address = "Первомайская, дом 87/1, кв. 106" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user8563215", Password="452412", LastName = "Яковлева", FirstName = "Айлин", Patronymic = "Дмитриевна", Phone = "895102345612", Passport = "1420 777799", CityId = 2, Address = "Фучика Ул., дом 72, кв. 156" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user85453", Password="452412", LastName = "Кошелев", FirstName = "Демид", Patronymic = "Матвеевич", Phone = "89997777777", Passport = "1418 774577", CityId = 3, Address = "Красноармейская, дом 109, кв. 251" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user863", Password="452412", LastName = "Игнатов", FirstName = "Андрей", Patronymic = "Давидович", Phone = "89301234567", Passport = "1415 713757", CityId = 1, Address = "Стара Загора Ул., дом 153, кв. 81" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user25896", Password="452412", LastName = "Ермолаев", FirstName = "Кирилл", Patronymic = "Макарович", Phone = "89351234567", Passport = "1415 713757", CityId = 1, Address = "Пушкина Ул., дом 112, кв. 101" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user45296", Password="452412", LastName = "Никифоров", FirstName = "Демид", Patronymic = "Дмитриевич", Phone = "89301234437", Passport = "1415 713757", CityId = 1, Address = "Карбышева Бульв., дом 1, кв. 61" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user13649", Password="452412", LastName = "Иванов", FirstName = "Дмитрий", Patronymic = "Максимович", Phone = "89301900567", Passport = "1415 713757", CityId = 1, Address = "Гусарова Ул., дом 9, кв. 72" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user13640", Password="456412", LastName = "Наумова", FirstName = "Малика", Patronymic = "Денисовна", Phone = "89301234500", Passport = "1415 713757", CityId = 1, Address = "Димитрова Ул., дом 10, кв. 54" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user13641", Password="456412", LastName = "Худяков", FirstName = "Кирилл", Patronymic = "Иванович", Phone = "89301234521", Passport = "1415 713757", CityId = 1, Address = "Зорге Р. Ул., дом 5, кв. 83" });
            db.Users.Add(new myUser {RoleId=1, LogIn="user13648", Password="456412", LastName = "Сухарева", FirstName = "Диана", Patronymic = "Максимовна", Phone = "89301000567", Passport = "1415 713757", CityId = 1, Address = "Северная, дом 20, кв. 86" });
                                   
                                   
            db.Users.Add(new myUser {RoleId=2, LogIn="someLogin1", Password="123456", LastName = "Иванов", FirstName = "Иван", Patronymic = "Петрович", Phone = "89999999999", Passport = "1413 222222", CityId = 1, Address = "Братьев Кашириных, дом 101, кв. 3108" });
            db.Users.Add(new myUser {RoleId=2, LogIn="someLogin2", Password="123456", LastName = "Козлицина", FirstName = "Анна", Patronymic =  "Владимировна", Phone = "89203333333", Passport = "1413 666666", CityId = 3, Address = "Постышева, дом 43, кв. 40" });
            db.Users.Add(new myUser {RoleId=2, LogIn="someLogin3", Password="123456", LastName = "Суслов", FirstName = "Дмитрий", Patronymic = "Павлович", Phone = "89610000000", Passport = "1420 777777", CityId = 2, Address = "Балкарская, дом 19, кв. 38" });

            db.Realties.Add(new Realty { ImgUrl = "", Floors = 10, Type = Types.APARTMENT, NumberRoom = 1, Square = 34, Floor = 2, Status = Statuses.RENT_OUT, CityId = 1, Address = "Северная, дом 20", OwnerId = 3, Price = 12000, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed." });
            db.Realties.Add(new Realty { ImgUrl = "", Floors = 10, Type = Types.APARTMENT, NumberRoom = 3, Square = 70, Floor = 5, Status = Statuses.RENT_OUT, CityId = 1, Address = "Кондарева Ул., дом 2", OwnerId = 3, Price = 30000, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed." });
            db.Realties.Add(new Realty { ImgUrl = "", Floors = 12, Type = Types.APARTMENT, NumberRoom = 2, Square = 55, Floor = 7, Status = Statuses.SALE, CityId = 1, Address = "Маяковского Ул., дом 14", OwnerId = 1, Price = 3000000, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed." });
            db.Realties.Add(new Realty { ImgUrl = "", Floors = 2, Type = Types.HOUSE, NumberRoom = 5, Square = 102, Status = Statuses.FOR_RENT_DAILY, CityId = 1, Address = "Маяковского Ул., дом 14", OwnerId = 2, Price = 5000, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed." });
            db.Realties.Add(new Realty { ImgUrl = "", Floors = 1, Type = Types.WAREHOUSE, Square = 100, Floor = 1, Status = Statuses.SALE, CityId = 1, Address = "102 Квартал, дом 56", OwnerId = 1, Price = 30000, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed." });
            db.Realties.Add(new Realty { ImgUrl = "", Floors = 10, Type = Types.ROOM, Square = 15, Floor = 10, Status = Statuses.RENT_OUT, CityId = 1, Address = "236 Квартал, дом 20", OwnerId = 1, Price = 5000, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed." });
            db.Realties.Add(new Realty { ImgUrl = "", Id = 7, Status = Statuses.LEASED, Type = Types.APARTMENT, NumberRoom = 2, Floor = 2, Floors = 10, CityId = 1, Address = "Каштановая Ул., дом 15, кв. 32", OwnerId = 3, Price = 1200000, RealtorId = 3});
            db.Realties.Add(new Realty { ImgUrl = "", Id = 8, Status = Statuses.LEASED, Type = Types.BUILDING, Floors = 10, CityId = 2, Address = "Учительская Ул., дом 48", OwnerId = 4, Price = 3000000, RealtorId = 3, });
            db.Realties.Add(new Realty { ImgUrl = "", Id = 9, Status = Statuses.LEASED, Type = Types.GARAGE, Floors = 1, CityId = 3, Address = "Океанский Проспект, дом 10", OwnerId = 5, Price = 3000000, RealtorId = 3, });
            db.Realties.Add(new Realty { ImgUrl = "", Id = 10, Status = Statuses.RENT_OUT, Type = Types.ROOM, Square = 25, Floor = 2, Floors = 10, CityId = 3, Address = "Океанский Проспект, дом 10, кв. 40", OwnerId = 6, Price = 5000, RealtorId=1 });
            db.Realties.Add(new Realty { ImgUrl = "", Id = 11, Status = Statuses.FOR_RENT_DAILY, Type = Types.BED, Floor = 5, Floors = 10, CityId = 1, Address = "Бабушкиной Н. Ул., дом 16, кв. 147", OwnerId = 1, Price = 3200, RealtorId=2 });
            db.Realties.Add(new Realty { ImgUrl = "", Id = 12, Status = Statuses.LEASED, Type = Types.HOUSE, NumberRoom = 5, Floors = 3, CityId = 2, Address = "50-Й Мк-Н, дом 29", OwnerId = 2, Price = 5250000, RealtorId = 1 });

            db.SaveChanges();

            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };

            foreach (var r in db.Realties)
            {
                List<String> filesFound = new List<String>();
                string path = HttpContext.Current.Server.MapPath($"~/Files/{r.Id}/");
                foreach (var filter in filters)
                {
                    if (Directory.Exists(path))
                    {
                        //Directory.
                        filesFound.AddRange(Directory.EnumerateFiles(path, String.Format("*.{0}", filter), SearchOption.AllDirectories));
                        //filesFound.AddRange(Directory.GetFiles(path, String.Format("*.{0}", filter), SearchOption.AllDirectories));
                    }
                }

                foreach (var file in filesFound)
                {
                    r.ImgUrl += $" /Files/{r.Id}/{Path.GetFileName(file)}";
                }
                if (r.ImgUrl == "")
                {
                    r.ImgUrl = imgUrl;
                }
                r.ImgUrl = r.ImgUrl.Trim();
            }

            db.Sold.Add(new Sold {RealtyType = Types.APARTMENT, CityId = 1, Address = "Малышева Ул., дом 32, кв. 83", OwnerId = 3, Price = 1200000, BuyerId=4, RealtorId=1, Date = (new DateTime(2020, 5, 15)).ToString("yyyy-MM-dd") });
            db.Sold.Add(new Sold {RealtyType = Types.APARTMENT, CityId = 2, Address = "Ново-Измайловский Пр., дом 3/39, кв. 55", OwnerId = 4, Price = 3000000, BuyerId = 5, RealtorId=1, Date = (new DateTime(2020, 6, 10)).ToString("yyyy-MM-dd") });
            db.Sold.Add(new Sold {RealtyType = Types.APARTMENT, CityId = 3, Address = "Маркса К. Ул., дом 141, кв. 61", OwnerId = 5, Price = 3000000, BuyerId = 6, RealtorId=1, Date = (new DateTime(2021, 4, 13)).ToString("yyyy-MM-dd") });
            db.Sold.Add(new Sold {RealtyType = Types.WAREHOUSE, CityId = 1, Address = "Пушкина, дом 11/11", OwnerId = 6, Price = 5000000, BuyerId = 7, RealtorId=2, Date = (new DateTime(2021, 3, 20)).ToString("yyyy-MM-dd") });
            db.Sold.Add(new Sold {RealtyType = Types.WAREHOUSE, CityId = 2, Address = "Марины Расковой, дом 3", OwnerId = 1, Price = 3200000, BuyerId = 8, RealtorId=3, Date = (new DateTime(2021, 2, 3)).ToString("yyyy-MM-dd") });
            db.Sold.Add(new Sold {RealtyType = Types.HOUSE, CityId = 3, Address = "Базовская Ул., дом 20", OwnerId = 2, Price = 5250000, BuyerId = 9, RealtorId=2, Date = (new DateTime(2021, 11, 2)).ToString("yyyy-MM-dd") });

            db.Leased.Add(new Leased { RealtyId=7, Status = Statuses.RENT_OUT, RealtyType = Types.APARTMENT, CityId = 1, Address = "Каштановая Ул., дом 15, кв. 32", OwnerId = 3, Price = 1200000, BuyerId = 4, RealtorId = 3, Date = (new DateTime(2020, 5, 15)).ToString("yyyy-MM-dd"), DateCheckOut = (new DateTime(2021, 11, 15)).ToString("yyyy-MM-dd") });
            db.Leased.Add(new Leased { RealtyId=8, Status = Statuses.RENT_OUT, RealtyType = Types.BUILDING, CityId = 2, Address = "Учительская Ул., дом 48", OwnerId = 4, Price = 3000000, BuyerId = 5, RealtorId = 3, Date = (new DateTime(2020, 6, 10)).ToString("yyyy-MM-dd"), DateCheckOut = (new DateTime(2021, 12, 10)).ToString("yyyy-MM-dd") });
            db.Leased.Add(new Leased { RealtyId=9, Status = Statuses.RENT_OUT, RealtyType = Types.GARAGE, CityId = 3, Address = "Океанский Проспект, дом 10", OwnerId = 5, Price = 3000000, BuyerId = 6, RealtorId = 3, Date = (new DateTime(2021, 4, 13)).ToString("yyyy-MM-dd"), DateCheckOut = (new DateTime(2021, 12, 13)).ToString("yyyy-MM-dd") });
            db.Leased.Add(new Leased { RealtyId=10, Status = Statuses.FOR_RENT_DAILY, RealtyType = Types.ROOM, CityId = 3, Address = "Океанский Проспект, дом 10, кв. 40", OwnerId = 6, Price = 5000000, BuyerId = 7, RealtorId = 1, Date = (new DateTime(2021, 11, 17)).ToString("yyyy-MM-dd"), DateCheckOut = (new DateTime(2021, 11, 20)).ToString("yyyy-MM-dd") });
            db.Leased.Add(new Leased { RealtyId=11, Status = Statuses.FOR_RENT_DAILY, RealtyType = Types.BED, CityId = 1, Address = "Бабушкиной Н. Ул., дом 16, кв. 147", OwnerId = 1, Price = 3200000, BuyerId = 8, RealtorId = 2, Date = (new DateTime(2021, 10, 30)).ToString("yyyy-MM-dd"), DateCheckOut = (new DateTime(2021, 11, 3)).ToString("yyyy-MM-dd") });
            db.Leased.Add(new Leased { RealtyId=12, Status = Statuses.RENT_OUT, RealtyType = Types.HOUSE, CityId = 2, Address = "50-Й Мк-Н, дом 29", OwnerId = 2, Price = 5250000, BuyerId = 9, RealtorId = 1, Date = (new DateTime(2021, 11, 2)).ToString("yyyy-MM-dd"), DateCheckOut = (new DateTime(2021, 12, 2)).ToString("yyyy-MM-dd") });


            db.Apps.Add(new ApplicationToRealtor { Status = Statuses.RENT, RealtyType = Types.HOUSE, Price = 30000, Square = 100, CityId = 1, Phone = "81973339965", LastName = "Крылов", FirstName = "Ярослав", Patronymic = "Андреевич", Address = "Воронежская Ул., дом 5, кв. 108", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed.", Floors = 2, NumberRoom = 6 });
            db.Apps.Add(new ApplicationToRealtor { Status = Statuses.RENT_OUT, RealtyType = Types.APARTMENT, Price = 10000, Square = 60, CityId = 2, Phone = "89414521572", LastName = "Фролова", FirstName = "Валерия", Patronymic = "Михайловна", Address = "Раевского Ул., дом 8, кв. 30", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed.", Floor = 1, Floors = 10, NumberRoom = 1});
            db.Apps.Add(new ApplicationToRealtor { Status = Statuses.FOR_RENT_DAILY, RealtyType = Types.ROOM, Price = 15000, Square = 80, CityId = 3, Phone = "89519740623", LastName = "Васильева", FirstName = "Анастасия", Patronymic = "Степановна", Address = "Сумской Пр., дом 126/К. 2, кв. 26", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed.", Floor = 2, Floors = 15});
            db.Apps.Add(new ApplicationToRealtor { Status = Statuses.RENT, RealtyType = Types.BED, Price = 20000, Square = 90, CityId = 1, Phone = "89519012409", LastName = "Хомякова", FirstName = "Кира", Patronymic = "Дмитриевна", Address = "Мира, дом 29, кв. 78", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed.", Floor = 3, Floors = 3, NumberRoom = 2 });
            db.Apps.Add(new ApplicationToRealtor { Status = Statuses.BUY, RealtyType = Types.LAND_PLOT, Price = 50000, Square = 120, CityId = 2, Phone = "88563990281", LastName = "Антонов", FirstName = "Алексей", Patronymic = "Вячеславович", Address = "Чудинова, дом 1, кв. 63", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed."});
            db.Apps.Add(new ApplicationToRealtor { Status = Statuses.SALE, RealtyType = Types.TRADING_AREA, Price = 50000, Square = 200, CityId = 3, Phone = "89827176471", LastName = "Кузнецов", FirstName = "Фёдор", Patronymic = "Тимофеевич", Address = "Юбилейный Мкрн, дом 41, кв. 60", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum rhoncus iaculis facilisis. Ut mollis libero magna, ut dapibus mi eleifend sit amet. Nam lacinia sodales tellus, vel tristique nisi auctor quis. Nulla congue mauris ac accumsan laoreet. Proin ac dui in ligula commodo facilisis. Integer pretium velit sollicitudin luctus interdum. Nam ac dui at risus posuere fringilla. Donec ac lacus ligula. Duis blandit lacus et leo euismod gravida. Aliquam leo enim, fermentum vitae felis quis, rutrum fringilla nisl. Aliquam erat volutpat. Nullam mattis magna magna, et fermentum odio imperdiet sed.", Floors = 1 });


            base.Seed(db);
        }
    }

}