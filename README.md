📦 OrderApiProject –  Api Tabanlı Sipariş ve Rezervasyon  Sistemi (ASP.NET Core Web API)
📝 Proje Hakkında

OrderApi, ASP.NET Core Web API kullanılarak geliştirilmiş,
%100 API tabanlı bir Sipariş Yönetim Sistemidir.

Proje kapsamında; kullanıcıların ürünleri sepete ekleyebildiği, sipariş oluşturabildiği ve sipariş süreçlerinin güvenli şekilde yönetilebildiği ölçeklenebilir bir backend mimarisi oluşturulmuştur.

Tüm iş akışları RESTful API üzerinden yürütülmektedir.

🚀 Kullanılan Teknolojiler

ASP.NET Core Web API

.NET 8

Entity Framework Core

MS SQL Server

JWT (JSON Web Token)

Repository Pattern

DTO Pattern

Dependency Injection

Swagger / OpenAPI

🏗 Mimari Yapı

Proje, Katmanlı Mimari (Layered Architecture) yaklaşımıyla geliştirilmiştir.

Entity Layer
→ Veritabanı varlıkları

Data Access Layer
→ EF Core, Repository implementasyonları

Business Layer
→ İş kuralları ve servisler

API Layer
→ Controller’lar ve endpoint’ler

DTO Layer
→ Veri transfer nesneleri

Bu yapı sayesinde:

Kod okunabilirliği artar

Bakım ve geliştirme kolaylaşır

Proje sürdürülebilir hale gelir

🔐 Kimlik Doğrulama & Yetkilendirme (JWT)

Projede JWT tabanlı authentication kullanılmıştır.

Kullanıcı giriş yaptıktan sonra JWT token üretilir

Token, yetkilendirme gerektiren endpoint’lerde doğrulanır

[Authorize] attribute’u ile API güvenliği sağlanır

Kullanıcıya ait bilgiler token içerisinden okunur

📌 Temel Özellikler

👤 Kullanıcı bazlı işlem yapısı

🛒 Sepete ürün ekleme / çıkarma

📦 Sipariş oluşturma

📄 Sipariş listeleme

🔐 JWT ile güvenli API erişimi

📊 Genişletilebilir backend mimarisi

⚙️ Kurulum & Çalıştırma

Repoyu klonlayın:

git clone https://github.com/erkancayiroglu/OrderApiProject.git


context.cs =>Veritabanı bağlantı bilgileri `DbContext` sınıfı içerisinde yapılandırılmıştır.

Migration’ları uygulayın:

update-database


Projeyi çalıştırın:

dotnet run


Swagger arayüzüne erişin:

https://localhost:{port}/swagger

🔗 Örnek API Endpoint’leri
POST    /api/Auth/Login
POST    /api/Sepet/AddItem
GET     /api/Sepet/GetUserSepet/{userId}
POST    /api/Order/CreateOrder
GET     /api/Order/GetOrders

🎯 Proje Amacı

Bu proje;
ASP.NET Core Web API, Entity Framework Core, JWT Authentication ve katmanlı mimari kullanılarak gerçek hayata uygun bir backend geliştirme pratiği kazanmak amacıyla geliştirilmiştir.

👨‍💻 Geliştirici

Erkan
Junior .NET Developer
ASP.NET Core | Web API | SQL | Backend Development
