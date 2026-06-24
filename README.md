# 📝 Blogy CMS — AI Powered Content Management System

> Modern mimari prensiplerini yapay zeka yetenekleriyle birleştiren dinamik içerik yönetim sistemi.
> A dynamic content management system combining modern architecture with AI-powered capabilities.

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/en-us/)
[![EF Core](https://img.shields.io/badge/EF_Core-Code_First-blue)](https://learn.microsoft.com/en-us/ef/core/)
[![AI Integrated](https://img.shields.io/badge/AI-Gemini_%26_Hugging_Face-orange)](https://huggingface.co/)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/Database-SQL_Server-CC2927.svg)](https://www.microsoft.com/en-us/sql-server)

---

## 🤖 Yapay Zeka Entegrasyonları / AI Integrations

Bu projeyi standart bir CMS'den ayıran, içerik üretim ve moderasyon süreçlerinde kullanılan akıllı servislerdir.
What sets this project apart from a standard CMS are the intelligent services used in content generation and moderation.

| 🇹🇷 Türkçe | 🇬🇧 English |
|------------|------------|
| 🤖 **Gemini Pro** ile konu bazlı 1000 kelimeye kadar makale üretimi | 🤖 Article generation up to 1000 words with **Gemini Pro** |
| 🛡️ **Hugging Face** ile yorum yayınlanmadan önce toksiklik analizi | 🛡️ Toxicity analysis via **Hugging Face** before comments go live |
| 📩 İletişim formundaki mesajlara AI destekli otomatik yanıt üretimi | 📩 AI-powered auto-reply generation for contact form messages |

---

## 🚀 Özellikler / Features

| 🇹🇷 Türkçe | 🇬🇧 English |
|------------|------------|
| N Katmanlı Mimari (Presentation, Business, DataAccess, Entity) | N-Tier Architecture (Presentation, Business, DataAccess, Entity) |
| Entity Framework Core — Code First | Entity Framework Core — Code First |
| ASP.NET Core Identity ile rol & yetki yönetimi | Role & permission management via ASP.NET Core Identity |
| DTO & AutoMapper ile güvenli veri transferi | Secure data transfer with DTO & AutoMapper |
| Dependency Injection ile gevşek bağlılık | Loose coupling with Dependency Injection |
| View Components & responsive tasarım | View Components & responsive design |
| FluentValidation ile merkezi doğrulama | Centralized validation with FluentValidation |
| Chart.js ile istatistik dashboard | Statistics dashboard with Chart.js |
| Admin, Writer, User rol ayrımı & Area yapısı | Admin, Writer, User role separation & Area structure |

---

## 🏗️ Mimari / Architecture

```
BlogyCMS/
├── Blogy.BusinessLayer/
│   ├── Abstract/
│   └── Concrete/
│
├── Blogy.DataAccessLayer/
│   ├── Abstract/
│   └── Concrete/
│
├── Blogy.DtoLayer/
│   └── Dtos/
│
├── Blogy.EntityLayer/
│   └── Entities/
│
└── Blogy.PresentationLayer/
    ├── Areas/
    │   ├── Admin/
    │   ├── Writer/
    │   └── User/
    ├── Controllers/
    ├── Views/
    │   └── Components/
    └── wwwroot/
```

---

## 🛡️ Güvenlik & Modüler Yapı / Security & Modular Design

**TR:** Admin, Writer ve User olmak üzere üç farklı yetki seviyesi `Area` yapısıyla birbirinden mantıksal olarak ayrılmıştır. Veri girişleri FluentValidation ile güvence altına alınmış; yorum moderasyonu Hugging Face API ile otomatik olarak yönetilmektedir.

**EN:** Three distinct authorization levels — Admin, Writer, and User — are logically separated using the `Area` structure. Data inputs are secured via FluentValidation; comment moderation is handled automatically through the Hugging Face API.

---

## 🛠️ Kullanılan Teknolojiler / Tech Stack

| Katman / Layer | Teknoloji / Technology |
|----------------|------------------------|
| Backend | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core (Code First) |
| Veritabanı / Database | MS SQL Server |
| Kimlik / Identity | ASP.NET Core Identity |
| Nesne Mapleme / Mapping | AutoMapper |
| Doğrulama / Validation | FluentValidation |
| Yapay Zeka / AI | Google Gemini Pro, Hugging Face API |
| Frontend | Bootstrap, JavaScript, HTML5, CSS3 |
| Grafik / Chart | Chart.js |

---

## ⚙️ Kurulum / Setup

### Gereksinimler / Requirements
- .NET 8 SDK
- SQL Server
- Gemini API Key
- Hugging Face API Key

### Adımlar / Steps

```bash
# Repoyu klonla / Clone the repo
git clone https://github.com/abdullahhaktan/BlogyCMS.git
cd BlogyCMS
```

**`appsettings.json` — Bağlantı dizesi ve API anahtarlarını güncelle / Update connection string & API keys:**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BlogyDb;Trusted_Connection=True;"
  },
  "GeminiApiKey": "YOUR_GEMINI_API_KEY",
  "HuggingFaceApiKey": "YOUR_HUGGINGFACE_API_KEY"
}
```

```bash
# Package Manager Console üzerinden / Via Package Manager Console
update-database
```

> Projeyi Visual Studio ile açıp **F5** ile başlatın.
> Open the project in Visual Studio and press **F5** to run.

---

## 📸 Ekran Görüntüleri / Screenshots

![1](https://github.com/user-attachments/assets/d09cddb4-e35b-47fc-80b3-98286795a60b)
![2](https://github.com/user-attachments/assets/9c0c39be-1915-4142-a104-82511be10171)
![3](https://github.com/user-attachments/assets/5988dfcf-34f9-459b-a7db-9b98426ad0df)
![4](https://github.com/user-attachments/assets/989f8fa8-557f-40fc-a649-b5a4c380100d)
![5](https://github.com/user-attachments/assets/a955a700-8d8f-43e9-8aae-b55fdf7afd0f)
![6](https://github.com/user-attachments/assets/5ceb6b81-3a43-4666-a7fd-c05e4ad278f6)
![7](https://github.com/user-attachments/assets/85806050-86b0-4f29-903a-e6604a5a98a4)
![8](https://github.com/user-attachments/assets/06fc546c-2689-461b-9f0b-f40b7cfd3e10)

---

## 👨‍💻 Mühendis & Geliştirici / Engineer & Developer

**Abdullah Haktan**
GitHub → [abdullahhaktan](https://github.com/abdullahhaktan)
