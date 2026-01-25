# 🚀 Blogy CMS Projesi: ASP.NET Core & Yapay Zeka Destekli İçerik Yönetim Sistemi

Bu proje, M&Y Yazılım Eğitim Akademisi'nde Full-Stack .NET eğitimi kapsamında geliştirilmiş, **N Katmanlı Mimari** ile tasarlanmış modern bir Blog Yönetim Sistemi (CMS) örneğidir. Proje, **.NET 8** üzerinde kurulmuş olup, temel CMS işlevlerinin yanı sıra **Gemini** ve **Hugging Face** gibi ileri düzey Yapay Zeka entegrasyonlarını içerir.

## ✨ Proje Amacı ve Kapsam

Amacımız; temiz kod prensipleri, kurumsal mimari yaklaşımları ve güncel teknolojileri bir araya getirerek, sadece dinamik bir blog sistemi değil, aynı zamanda yapay zekanın yazılım süreçlerine nasıl entegre edilebileceğini gösteren kapsamlı bir referans oluşturmaktır.

---

## ⚙️ Teknik Yapı ve Mimari Standartlar

| Etiket | Açıklama |
| :--- | :--- |
| **Platform** | .NET 8, ASP.NET Core MVC |
| **Veritabanı** | Entity Framework Core (SQL Server) |
| **Mimari** | N Katmanlı Mimari (N-Layer Architecture) |
| **Veri Yönetimi** | DTO (Data Transfer Object) ve AutoMapper |
| **Kullanıcı Yönetimi** | ASP.NET Core Identity |

### 🏗️ Temel Mimari Prensipler

* **N Katmanlı Mimari:** İş Mantığı, Veri Erişim ve Sunum katmanları arasında net bir ayrım sağlanmıştır.
* **EF Core – Code First:** Veritabanı yapısı koddan (C# Entity'ler) yola çıkılarak **Code First** yaklaşımı ile tasarlanmıştır ve **IdentityDbContext** entegrasyonu kullanılmıştır.
* **DTO & AutoMapper:** Katmanlar arası veri transferi, güvenlik ve düzenlilik için DTO'lar ile sağlanmış ve **AutoMapper** kütüphanesi ile Entity-DTO eşlemeleri otomatikleştirilmiştir.
* **Dependency Injection (DI):** Tüm servisler (Business katmanındaki servisler, AI servisleri vb.) **Program.cs** dosyası üzerinden kayıtları yapılarak yönetilebilir bir yapıda projelendirilmiştir.

### 🛡️ Güvenlik ve Modülerlik

* **Rol Yönetimi:** **Admin**, **Writer** ve **User** olmak üzere üç farklı kullanıcı rolü tanımlanmıştır.
* **Area ve Yetkilendirme:** Proje, rollerin ayrımını kolaylaştırmak için **Area** yapısıyla düzenlenmiş olup, erişim kontrolü **Controller** ve **Area** bazında (`[Authorize(Roles = "Admin")]`) uygulanmıştır.
* **View Components:** Tekrarlanan veya dinamik içeriklerin (Örn: Menüler, son bloglar listesi) yönetimini kolaylaştırmak amacıyla modüler **View Component** yapısı kullanılmıştır.

---

## 🧠 Yapay Zeka Entegrasyonları (AI Features)

Bu projenin en dikkat çekici kısımları, yapay zeka modelleri ile olan entegrasyonlardır:

### 1. Makale Üretimi (Gemini)
* **Özellik:** Admin panelinde verilen kısa bir konuya göre **1000 kelimeye** kadar otomatik makale içeriği oluşturulabilir.
* **Amaç:** Yazı yazma süreçlerini hızlandırmak ve içerik üretimini desteklemek.

### 2. Toksik Yorum Analizi (Hugging Face)
* **Özellik:** Yeni gelen yorumlar, yayınlanmadan önce **Hugging Face** servisi aracılığıyla toksik (zararlı/saldırgan) içerik barındırıp barındırmadığına dair analiz edilir.
* **Amaç:** Yüksek riskli yorumları otomatik olarak tespit edip moderasyon havuzuna yönlendirerek daha sağlıklı bir yorum ortamı sağlamak.

### 3. Otomatik Mesaj Yanıtlama (Gemini)
* **Özellik:** Gelen iletişim mesajları yapay zeka ile sınıflandırılır ve Gemini kullanılarak otomatik yanıt taslakları oluşturulur.
* **Amaç:** Yönetim yükünü azaltmak ve iletişim sürecini optimize etmek.

---

## 🛠️ Kurulum ve Çalıştırma

1.  **Repo'yu Klonlayın:**
    ```bash
    git clone [https://github.com/abdullahhaktan/MyAcademyBlogProject.git](https://github.com/abdullahhaktan/MyAcademyBlogProject.git)
    ```
2.  **Veritabanı Oluşturma:**
    * `appsettings.json` dosyasında kendi SQL Server bağlantı dizenizi (`ConnectionString`) güncelleyin.
    * Paket Yöneticisi Konsolu (PMC) üzerinden Migration'ları uygulayın:
        ```bash
        Update-Database
        ```
3.  **API Anahtarlarını Ayarlama:**
    * Gemini ve Hugging Face servisleri için gerekli API anahtarlarını/token'ları `appsettings.json` veya Secret Manager üzerinden projenize ekleyin.
4.  **Uygulamayı Çalıştırın:**
    * Projeyi Visual Studio'da çalıştırın veya CLI üzerinden başlatın:
        ```bash
        dotnet run
        ```
        
---

## 🏷️ Etiketler

`#dotnet` `#net8` `#aspnetcore` `#csharp` `#MVC` `#softwaredevelopment` `#Gemini` `#HuggingFace` `#AI` `#CodeFirst` `#NLayerArchitecture`
