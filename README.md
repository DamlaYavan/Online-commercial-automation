# Online-commercial-automation
Bu çalışma, bir işletmenin ticari faaliyetlerini dijitalleştirmek ve etkin bir şekilde yönetmek amacıyla geliştirilen web tabanlı bir ticari otomasyon sistemini ele almaktadır. Proje, ASP.NET MVC framework'ü kullanılarak geliştirilmiş ve Microsoft SQL Server veritabanı ile entegre edilmiştir. Projenin ana hedefi, küçük ve orta ölçekli işletmelerin (KOBİ) iş süreçlerini daha verimli hale getirmektir. 

Bu Proje Sevgili Murat Yücedağ hocamızın  kursundan faydalanarak yapılmıştır. kendisine teşekkür ediyorum. 


##SORUN BİLDİRİMİ
Manuel süreçler, işletmelerin operasyonel verimliliğini düşürmekte, hata oranını artırmakta ve veri tutarsızlıklarına yol açmaktadır. Ayrıca, satış, stok ve müşteri bilgilerini izleme ve kontrol etme zorluğu, stratejik kararlar almayı güçleştirmekte ve müşteri memnuniyetini olumsuz etkilemektedir. Teknolojik çözümlerden yoksun kalan işletmeler, piyasada rekabet avantajını kaybetmektedir. Bu bağlamda, web tabanlı bir ticari otomasyon sistemi geliştirilmesi, KOBİ'lerin iş süreçlerini dijitalleştirerek verimliliği artırmayı, hataları minimize etmeyi ve müşteri memnuniyetini sağlamayı amaçlamaktadır. 

## PROJE AMACI 
Bu projenin temel amacı, küçük ve orta ölçekli işletmelerin (KOBİ) ticari faaliyetlerini dijitalleştirerek, iş süreçlerini daha verimli ve yönetilebilir hale getiren bir ticari otomasyon sistemi geliştirmektir. Günümüzde işletmeler, verimliliklerini artırmak ve rekabet avantajı elde etmek için teknolojiyi etkin bir şekilde kullanmak zorundadır. Bu bağlamda, işletmelerin ticari işlemlerini otomatikleştiren sistemler büyük önem taşımaktadır. 

#PROJENİN iŞLEVİ
Geliştirilen sistem, admin (İşletme) ve müşteri olmak üzere iki farklı kullanıcı tipi için giriş sağlar. Admin girişinde, işletme yöneticileri çeşitli modüller üzerinde tam yetkiyle CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirebilir. Bu modüller arasında departman yönetimi, kategori yönetimi, ürün yönetimi, müşteri yönetimi ve personel yönetimi bulunmaktadır. Yönetici arayüzü, işletmenin satış ve stok yönetimini kolaylaştırmak için geliştirilmiştir. Yöneticiler, personel satışlarını takip edebilir, ürünlerin stok durumlarını grafiksel olarak görüntüleyebilir ve analiz edebilir. 

Müşteri girişi ile kullanıcılar, geçmiş siparişlerini ve cari hesap durumlarını görüntüleyebilir. Ayrıca, işletme ile doğrudan mesajlaşarak destek alabilir . Bu özellikler, müşteri memnuniyetini artırmayı ve işletme-müşteri iletişimini güçlendirmeyi hedeflemektedir.

#İHTİYAÇ ANALİZİ
- C# Programlama Dili: Projede backend tarafı için C# programlama dili kullanıldı. C#, geniş bir standart kütüphane setine sahiptir ve nesne yönelimli programlama prensiplerini destekler. Bu da kodun daha okunabilir, düzenli ve sürdürülebilir olmasını sağlar.  

- ASP.NET MVC Framework: Projede web tabanlı bir uygulama olarak geliştirildi. ASP.NET MVC framework'ü, güçlü bir model-view-controller (MVC) mimarisi sunar ve bu da projenin modüler bir şekilde organize edilmesini sağlar. Ayrıca, ASP.NET MVC, RESTful web servislerini destekler ve bu da projenin genişletilebilirliğini artırır. 
 
-Microsoft SQL Server (MSSQL): Projede kullanılacak veritabanı yönetim sistemi olarak MSSQL tercih edildi.  MSSQL, güvenilirliği, performansı ve geniş özellik yelpazesi ile bilinen bir ilişkisel veritabanı yönetim sistemidir. Büyük veri hacimlerini işlemek, veritabanı güvenliğini sağlamak ve yüksek performanslı sorgular çalıştırmak için ideal bir seçimdir.

-Entity Framework Code First Yaklaşımı: Veritabanı modeli kod tabanlı olarak oluşturmak ve yönetmek için Entity Framework Code First yaklaşımı kullanıldı.  
Entity Framework (EF), Microsoft tarafından geliştirilen bir Object-Relational Mapping (ORM) framework'üdür. ORM, veritabanı ile nesne tabanlı programlama arasındaki uyumu sağlayan bir teknolojidir.

-Migration Kullanımı Projede veritabanı değişikliklerini yönetmek ve izlemek için Entity Framework Migration'ları kullanılmıştır. Migration'lar, veritabanı şemasında yapılan değişikliklerin kaydedilmesini ve uygulanmasını sağlar. Bu sayede, veritabanı şeması ile model sınıfları arasında senkronizasyon sağlanır ve veritabanı yapısındaki değişiklikler kolayca yönetilebilir. Migration'lar, veritabanı güncellemelerinin aşamalı ve güvenli bir şekilde uygulanmasına olanak tanır, böylece veritabanı ve uygulama modeli arasındaki uyumsuzluklar minimize edilir. 

##VERİTABANI SINIF DİYAGRAMI
<img src="![Başlıksız Diyagram](https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/4ee26cf1-2c6c-4662-bbfb-0b50e09e7566)>

##AUTHENTİCATİON
Projede oturum açma (authentication) ve yetkilendirme (authorization) işlemleri, kullanıcıların sisteme güvenli bir şekilde giriş yapabilmesi ve yetkili oldukları alanlara erişim sağlayabilmesi için önemli bir rol oynamaktadır. Bu süreç, kullanıcıların kimlik doğrulama işlemi yaparak sisteme giriş yapmalarını ve yalnızca yetkili oldukları sayfalara erişim sağlamalarını içerir. 

istemde iki farklı kullanıcı tipi bulunmaktadır: admin ve cari (müşteri). Her iki kullanıcı tipi için ayrı giriş ekranları oluşturulmuştur. Kullanıcılar, kullanıcı adı ve şifre bilgileri ile sisteme giriş yapar. Giriş işlemi başarılı olduğunda, kullanıcının kimliği doğrulanarak oturum açılır ve kullanıcının yetkili olduğu sayfalara yönlendirilir. 

Kullanıcı girişi işlemlerinde, Forms Authentication kullanılarak kimlik doğrulama çerezi oluşturulmuştur. Kullanıcı bilgileri oturum bilgisi olarak saklanmış ve bu bilgiler uygulamanın diğer bölümlerinde kullanılarak kullanıcının yetkili olduğu işlemlere erişimi sağlanmıştır. 


##AUTHORİZATİON
Yetkilendirme işlemleri, kullanıcının oturum açma durumu ve yetkili olduğu sayfalar göz önünde bulundurularak gerçekleştirilmiştir. Web.config dosyasında, oturum açmamış kullanıcıların yetkisiz sayfalara erişimini engellemek amacıyla gerekli ayarlamalar yapılmıştır. Bu sayede, oturum açma bilgisi olmayan kullanıcılar yetkilendirme gerektiren sayfalara erişmeye çalıştığında login sayfasına yönlendirilir. 

Tüm sayfalarda yetkilendirme işlemlerinin uygulanabilmesi için, global olarak yetkilendirme filtresi eklenmiştir. Bu filtre, tüm controller ve action metotlarında yetkilendirme kontrolü yapılmasını sağlar. Ancak, login sayfası gibi herkesin erişebilmesi gereken sayfalarda anonim erişim izni verilmiştir. Bu sayfalar için özel olarak anonim erişim attribute'u eklenmiştir, böylece oturum açma gereksinimi olmadan erişim sağlanabilir. 

##LİNQ SORGULARI
Projede , veri tabanına yönelik birçok sorgu LINQ kullanarak gerçekleştirildi . Örneğin, istatistikler sayfasında çeşitli raporlar ve analizler için LINQ sorguları  kullanıldı. Bu sorgular, veritabanındaki verileri analiz etmek, filtrelemek, sıralamak ve gruplamak  için kullanıldı. Linq sorgulaıryla oluşturulmuş İstatistikler sayfasının göünüşü:  
<img width="934" alt="istatistikler" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/3ebcea45-d618-4edb-a5d4-b66acb0623c5">



##TRİGGER
Trigger, yani tetikleyici, bir veritabanı işlemi (INSERT, UPDATE, DELETE) gerçekleştirildiğinde otomatik olarak çalışan bir tür veritabanı nesnesidir. Tetikleyiciler, veritabanı yönetim sistemlerinde (DBMS) veri bütünlüğünü ve doğruluğunu sağlamak amacıyla kullanılır. Tetikleyiciler, belirli olaylar meydana geldiğinde belirli işlemlerin otomatik olarak gerçekleştirilmesine olanak tanır. 
Projede veritabanı bütünlüğünü ve veri doğruluğunu sağlamak için tetikleyiciler (triggers) kullanılmıştır. Bu tetikleyiciler, satış hareketleri ve fatura kalemleri gibi işlemlerin ardından otomatik olarak belirli güncellemelerin yapılmasını sağlar. İki ana tetikleyici mekanizması uygulanmıştır: 

- Satış hareketleri tablosuna yeni bir kayıt eklendiğinde (INSERT işlemi), ilgili ürünün stok sayısını otomatik olarak güncelleyen bir tetikleyici kullanılmıştır. Bu tetikleyici, ürün stoklarının her zaman güncel olmasını ve veri tutarlılığını sağlar. 

- Fatura kalemleri tablosuna yeni bir kayıt eklendiğinde, ilgili faturanın toplam tutarını otomatik olarak güncelleyen bir tetikleyici kullanılmıştır. Bu tetikleyici, her fatura kalemi eklendiğinde, fatura toplamının doğru bir şekilde hesaplanmasını sağlar.

# PROJE GÖRSELLERİ

<img width="918" alt="loginekrani" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/66384e4c-c65b-4efa-b436-fa02da594420">

<img width="858" alt="kayitekrani" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/45eaccb6-d54a-459c-8c8c-3d2a40e9a982">

<img width="940" alt="hizlibakistablolari" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/1987f6b7-12de-4b1b-8fc8-9fb6074c6efd">

<img width="935" alt="mesajkutusu" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/9c5909e0-5da3-4325-bd9b-12b3055e7d15">

<img width="937" alt="müsterigirisihesabim" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/11c95de6-94ff-43d3-b54e-56c6cdd233f3">

<img width="931" alt="personellersayfasi" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/5c51fcd4-1cfb-4c89-969f-3f6d23f780fa">

<img width="940" alt="satislar" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/097d7ad9-c0ee-4de5-9883-443138221364">

<img width="935" alt="ürünlersayfasi" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/1ca45a36-ae0c-4981-91d5-f31644819c0b">

<img width="941" alt="yapilacaklarsayfasi" src="https://github.com/DamlaYavan/Online-commercial-automation/assets/116723754/a53c512c-1b3e-4e6e-ac86-99ff49a7878c">
