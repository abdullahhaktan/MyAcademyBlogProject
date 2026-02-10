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

## 🔗 Repo ve İletişim
**GitHub:** [Blogy CMS Repo](https://github.com/kullanici-adiniz/repo-adi)
