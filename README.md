# 🛒 CQRS & Mediator E-Commerce Project

Full-Stack .NET eğitim sürecimde geliştirdiğim **10. proje** olan bu çalışmada; modern yazılım mimarileri kullanılarak uçtan uca, ölçeklenebilir bir e-ticaret sistemi geliştirilmiştir.

---

## ✨ Proje Amacı ve Kapsam

Bu projenin amacı; kurumsal mimari desenleri doğru senaryolarda uygulayarak, sürdürülebilir, genişletilebilir ve temiz kod prensiplerine uygun bir .NET e-ticaret altyapısı sunmaktır.

---

## ⚙️ Teknik Yapı ve Mimari Standartlar

| Alan | Açıklama |
| --- | --- |
| Platform | .NET 8, ASP.NET Core MVC |
| Veritabanı | Entity Framework Core (SQL Server) |
| Mimari | CQRS & Mediator Pattern |
| Veri Yönetimi | DTO & Repository Pattern |
| Transaction | Unit of Work |
| Depolama | Google Cloud Storage |

---

## 🏗️ Kullanılan Mimari Yaklaşımlar

- **CQRS (Command Query Responsibility Segregation)**  
  Okuma (Query) ve yazma (Command) sorumlulukları net şekilde ayrıştırılmıştır.

- **MediatR (Mediator Pattern)**  
  Controller katmanı yalnızca isteği iletir, tüm iş mantığı Handler katmanında işlenir.

- **Unit of Work & Transaction Yönetimi**  
  Veritabanı işlemleri tek bir transaction altında yönetilerek veri tutarlılığı sağlanır.

- **Observer Pattern**  
  Event bazlı tetiklenen süreçler için kullanılmıştır.

- **Chain of Responsibility**  
  Doğrulama ve operasyon adımları zincir yapıda ele alınmıştır.

---

## 🧩 Modüler Yapı

- Admin paneli Area bazlı olarak tasarlanmıştır.
- Kullanıcı, kategori, ürün ve kampanya yönetimi modülerdir.
- Clean Code prensipleri benimsenmiştir.

---

## ☁️ Ürün & Medya Yönetimi

Ürün görselleri Google Cloud Storage üzerinde saklanmaktadır.

---

## 🛠️ Kurulum ve Çalıştırma

### 1. Repoyu Klonlayın
git clone https://github.com/kullanici-adiniz/repo-adi.git

### 2. Veritabanı Migration
appsettings.json dosyasında bağlantı bilgisini güncelleyin ve:

Update-Database

### 3. Google Cloud Storage
- Bucket oluşturun
- Service Account JSON anahtarını tanımlayın
- JSON dosyasını .gitignore içine ekleyin

### 4. Çalıştırma
dotnet run

---

## 🔗 Repo

https://lnkd.in/d_XiHNbD
