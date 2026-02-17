# 📝 Blogy CMS - AI Powered Content Management System

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/en-us/)
[![EF Core](https://img.shields.io/badge/EF_Core-Code_First-blue)](https://learn.microsoft.com/en-us/ef/core/)
[![AI Integrated](https://img.shields.io/badge/AI-Gemini_%26_Hugging_Face-orange)](https://huggingface.co/)

**Blogy CMS**, M&Y Yazılım Eğitim Akademi bünyesinde geliştirdiğim, modern mimari prensiplerini yapay zeka yetenekleriyle birleştiren dinamik bir içerik yönetim sistemidir. 

---

## 🧠 Yapay Zeka (AI) Entegrasyonları

Bu projeyi standart bir CMS'den ayıran, içerik üretim ve moderasyon süreçlerinde kullanılan akıllı servislerdir:

* **🤖 Gemini Pro ile Makale Üretimi:** Kullanıcının belirlediği konuya göre 1000 kelimeye kadar anlamlı ve yapılandırılmış içerik üretilir.
* **🛡️ Hugging Face ile Toksik Yorum Analizi:** Yorumlar yayınlanmadan önce moderasyon servisine gönderilir. Yüksek oranda toksiklik (zararlı içerik) tespit edilirse yayınlanması sistem tarafından otomatik olarak engellenir.
* **📩 Akıllı Mesaj Yanıtlama:** İletişim formundan gelen mesajlar yapay zeka ile sınıflandırılır ve uygun yanıtlar otomatik olarak hazırlanır.

---

## ⚙️ Teknik Mimari ve Standartlar

Proje, kurumsal yazılım geliştirme standartları takip edilerek **N-Tier (N-Katmanlı) Mimari** ile inşa edilmiştir:

| Özellik | Açıklama |
| :--- | :--- |
| **Mimari** | N-Layer Architecture (Presentation, Business, DataAccess, Entity) |
| **Veri Yönetimi** | Entity Framework Core - Code First Yaklaşımı |
| **Güvenlik** | ASP.NET Core Identity (Rol & Yetki Yönetimi) |
| **Veri Transferi** | DTO (Data Transfer Object) & AutoMapper Entegrasyonu |
| **Esneklik** | Dependency Injection & Servis Kayıt Yönetimi |
| **UI Bileşenleri** | View Components & Responsive Tasarım |

---

## 🛡️ Güvenlik ve Modüler Yapı

* **Gelişmiş Rol Yönetimi:** Admin, Writer (Yazar) ve User rolleri için farklı yetkilendirme seviyeleri.
* **Area Yapısı:** Yönetim panelleri (Admin, Writer, User) mantıksal olarak birbirinden ayrılmıştır.
* **Dinamik Dashboard:** Blog istatistikleri ve yorum verileri grafiklerle (Chart.js vb.) görselleştirilmiştir.
* **Validation:** Veri girişleri FluentValidation ve model bazlı kontrollerle güvence altına alınmıştır.

---

## 🛠️ Kullanılan Teknolojiler

* **Backend:** .NET 8, ASP.NET Core MVC
* **Frontend:** Bootstrap, JavaScript, HTML5, CSS3
* **Database:** MS SQL Server
* **AI SDKs:** Google Generative AI (Gemini), Hugging Face API
* **Tools:** AutoMapper, Entity Framework Core

---

## 🚀 Kurulum

1.  Repoyu klonlayın: `git clone https://github.com/kullanici-adiniz/repo-adi.git`
2.  `appsettings.json` dosyasında SQL Server Connection String ve AI API anahtarlarınızı (Gemini & Hugging Face) tanımlayın.
3.  Package Manager Console üzerinden `update-database` komutunu çalıştırın.
4.  Projeyi ayağa kaldırın.

---

Proje Görselleri

![MyAcademyBlog1](https://github.com/user-attachments/assets/d09cddb4-e35b-47fc-80b3-98286795a60b)

---

![MyAcademyBlog2](https://github.com/user-attachments/assets/9c0c39be-1915-4142-a104-82511be10171)

---

![MyAcademyBlog3](https://github.com/user-attachments/assets/5988dfcf-34f9-459b-a7db-9b98426ad0df)

---

![MyAcademyBlog4](https://github.com/user-attachments/assets/989f8fa8-557f-40fc-a649-b5a4c380100d)

---

![MyAcademyBlog5](https://github.com/user-attachments/assets/a955a700-8d8f-43e9-8aae-b55fdf7afd0f)

----

![MyAcademyBlog6](https://github.com/user-attachments/assets/5ceb6b81-3a43-4666-a7fd-c05e4ad278f6)

---

![MyAcademyBlog8](https://github.com/user-attachments/assets/85806050-86b0-4f29-903a-e6604a5a98a4)

---

![MyAcademyBlog7](https://github.com/user-attachments/assets/06fc546c-2689-461b-9f0b-f40b7cfd3e10)
