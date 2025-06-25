# 🔐 Password Manager App

Modern ve güvenli şifre yöneticisi uygulaması. ASP.NET MVC ile geliştirilmiş, kullanıcı dostu arayüze sahip web uygulaması.



## 🌟 Özellikler

### 🔑 Temel Özellikler
- **Güvenli Kullanıcı Sistemi**: ASP.NET Identity ile güvenli kayıt/giriş
- **Şifre Yönetimi**: Tam CRUD operasyonları (Oluştur, Oku, Güncelle, Sil)
- **Kategori Sistemi**: Şifreleri organize etmek için özelleştirilebilir kategoriler
- **Güçlü Şifre Üretici**: Özelleştirilebilir uzunluk ve karakter seçenekleri
- **Arama ve Filtreleme**: Hızlı şifre bulma özellikleri

### 🚀 Premium Özellikler
- **🤖 AI Chatbot Asistanı**: Şifre yönetimi konusunda akıllı yardım
- **📊 Güvenlik Analizi**: Şifre güvenlik durumu analizi ve raporlama
- **📱 Responsive Tasarım**: Tüm cihazlarda mükemmel görünüm
- **🎨 Modern UI/UX**: Gradient renkler ve smooth animasyonlar

## 🛠️ Teknoloji Stack

| Kategori | Teknoloji |
|----------|-----------|
| **Backend** | C#, ASP.NET MVC 5 |
| **Database** | Entity Framework Code First, SQL Server LocalDB |
| **Frontend** | HTML5, CSS3, JavaScript, Bootstrap 5 |
| **Authentication** | ASP.NET Identity |
| **ORM** | Entity Framework 6 |

## 📊 Güvenlik Analizi

Uygulama, şifrelerinizin güvenlik seviyesini analiz eder:

- 🔴 **Zayıf Şifreler**: 12 karakterden kısa
- 🟡 **Orta Güçlü Şifreler**: Geliştirilmesi gereken
- 🟢 **Güçlü Şifreler**: Güvenli
- 📈 **Genel İstatistikler**: Toplam şifre analizi

## 🤖 SifreBot Asistanı

Entegre AI chatbot özellikleri:
- Güvenli şifre oluşturma önerileri
- Kategori yönetimi yardımı
- Güvenlik en iyi uygulamaları
- Kullanım kılavuzu ve ipuçları



### 🏠 Ana Dashboard
- Şifre istatistikleri
- Hızlı erişim menüleri
- Arama ve filtreleme

### 🔐 Şifre Yönetimi
- Şifre ekleme/düzenleme formu
- Password generator aracı
- Kategori seçimi

### 📊 Güvenlik Analizi
- Şifre güvenlik durumu
- Detaylı güvenlik önerileri
- Görsel analiz grafikleri

## 🚀 Kurulum

### Gereksinimler
- Visual Studio 2019 veya üzeri
- .NET Framework 4.7.2+
- SQL Server LocalDB

### Adımlar

1. **Repository'yi klonlayın**
   ```bash
   git clone https://github.com/kullanici-adi/PasswordManagerApp.git
   cd PasswordManagerApp
   ```

2. **Visual Studio'da açın**
   ```
   PasswordManagerApp.sln dosyasını çift tıklayın
   ```

3. **Veritabanını oluşturun**
   ```bash
   Package Manager Console'da:
   Update-Database
   ```

4. **Uygulamayı çalıştırın**
   ```
   F5 veya Ctrl+F5 ile başlatın
   ```

## 📁 Proje Yapısı

```
WebApplication11/
├── Controllers/           # MVC Controller'ları
│   ├── AccountController.cs
│   ├── PasswordsController.cs
│   ├── CategoriesController.cs
│   └── HomeController.cs
├── Models/               # Veri modelleri
│   ├── PasswordEntry.cs
│   ├── Category.cs
│   ├── ApplicationUser.cs
│   └── ApplicationDbContext.cs
├── Views/                # Razor görünümleri
│   ├── Account/
│   ├── Passwords/
│   ├── Categories/
│   └── Home/
├── Scripts/              # JavaScript dosyaları
├── Content/              # CSS ve statik dosyalar
└── Migrations/           # EF Code First migrations
```


## 📈 Performans

- **Entity Framework**: Optimize edilmiş veritabanı sorguları
- **Lazy Loading**: İhtiyaç duyulduğunda veri yükleme
- **Responsive Design**: Hızlı yükleme süreleri
- **Minimal Dependencies**: Sadece gerekli kütüphaneler

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit yapın (`git commit -m 'Add some AmazingFeature'`)
4. Branch'i push edin (`git push origin feature/AmazingFeature`)
5. Pull Request açın


## 👨‍💻 Geliştirici

**[Merve Doğru]**
- GitHub: [https://github.com/mervede45/WebApplication11]
- Email: mervedogru002@gmail.com



## 📚 Ek Kaynaklar

- [ASP.NET MVC Dokumentasyonu](https://docs.microsoft.com/en-us/aspnet/mvc/)
- [Entity Framework Kılavuzu](https://docs.microsoft.com/en-us/ef/)
- [Bootstrap Dokumentasyonu](https://getbootstrap.com/docs/)

---

⭐ **Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!** ⭐