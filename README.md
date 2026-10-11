CinemaVR API — Етап 2
Технології: .NET 8 Web API, Entity Framework Core, SQLite

Опис проєкту
CinemaVR — це Web API для управління кінотеатром.
Система дозволяє працювати з такими ресурсами:

Фільми (Films)

Сеанси (Sessions)

Користувачі (Users)

Бронювання (Bookings)

API підтримує CRUD‑операції, фільтрацію, пошук, сортування, отримання пов’язаних даних та асинхронну роботу з базою.

Використана СУБД
Проєкт використовує SQLite — легку файл‑орієнтовану реляційну базу даних.

Файл бази даних створюється автоматично через міграції:
Cinema.db
Структура моделі даних
Сутності

'Film'

Властивість             Тип	            Обов’язковість
Id	                    int	                  PK
Title	                string	            Required
Genre	                string	            Required
Price	                decimal	            Required
Year	                int	                Required
Sessions	       ICollection<Session>	    Навігаційна


'Session'

Властивість	            Тип	            Обов’язковість
Id	                    int	                 PK
FilmId	                int	              FK → Film
Date	                DateTime	        Required
Hall	                string	            Required
Film	                Film	          Навігаційна
Bookings	       ICollection<Booking>	  Навігаційна

'User'

Властивість	            Тип	            Обов’язковість
Id	                    int	                 PK
FullName	            string	           Required
Email	                string	           Required
Bookings	        Collection<Booking>	  Навігаційна


'Booking'

Властивість	            Тип	            Обов’язковість
Id	                    int	                  PK
SessionId	            int	             FK → Session
UserId	                int	                FK → User
Seat	                int	                Required
Price	                decimal	            Required
Session	                Session	          Навігаційна
User	                User	          Навігаційна

Зв’язки між сутностями
Film 1 →* Sessions

Session 1 → *Bookings

User 1 → * Bookings

Усі зв’язки налаштовані через Fluent API у OnModelCreating:

Foreign keys

Навігаційні властивості

Каскадне видалення

DbContext
Файл: CinemaContext.cs

Містить:

DbSet для всіх сутностей

Fluent API конфігурацію зв’язків

Каскадне видалення

Підключення до бази даних
appsettings.json

"ConnectionStrings": {
  "DefaultConnection": "Data Source=Cinema.db"
}

Program.cs
builder.Services.AddDbContext<CinemaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

Міграції
Створення першої міграції

dotnet ef migrations add InitialCreate

Створення бази

dotnet ef database update

CRUD‑операції
Реалізовані для всіх основних ресурсів:

GET — список та окремий елемент

POST — створення

PUT — оновлення

DELETE — видалення

LINQ‑запити
Передбачено:

фільтрацію

пошук

сортування

Include / ThenInclude для пов’язаних даних

Приклад (FilmsController):
query = query.Where(f => f.Title.Contains(search));
query = query.OrderByDescending(f => f.Price);
Асинхронна робота з БД
Використовуються:

ToListAsync()

FindAsync()

FirstOrDefaultAsync()

SaveChangesAsync()

📦 DTO та валідація
Усі операції використовують DTO:

FilmDto

SessionDto

BookingDto

UserRegisterDto

Валідація через:

[Required]

[StringLength]

[Range]

[EmailAddress]