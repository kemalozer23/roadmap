# [Senior Yazılımcı Mülakatı #3](https://www.youtube.com/watch?v=rOk38shlPx4&list=PLRp4oRsit1bz6myZyqonUrnA6mUGJ-kI6&index=3)

## Kendinden biraz bahseder misin?

## Agile kullanıyor musun? (metodolojiler)

## Clouda başlayacak biri için neler önerirsin? Nerden başlanmalı nasıl ilerlenmeli?

## Bir kodun yolculuğu. Yazdığımız kod son kullanıcıya ulaşana kadar neler gerçekleşiyor?
- ### CI/CD ne yapıyor?

## Monitoring toollarında en çok hangi metriklere dikkat ediyorsun?

## Blob Storage

## Reverse Proxy'yi bir cümlede nasıl anlatırsın?
- ### peki normal proxy'den farkı ne? neden reverse?

## Linux Containerization (opsiyonel soru) internal olarak nasıl sağlanıyor?

## Secret Management bir proje için neden önemlidir ? nasıl kullanıyorsun ? bunun için kullandığın özel bir tool var mı?

## Data Consistency Mikroservislerde veri bütünlüğü neden önemli ve nasıl çözümler üretilmiş ?

## Loglama hakkında ne düşünüyorsun ?

## Mikroservislerde Retry Mekanizması kurarken neye dikkat etmek gerekir ?

## Visiual Studio Compiler'ını yazan bir ekipte çalıştığımızı düşünelim. Solution içerisindeki projelerin derlenmesi görevi de bize verilmiş. Her proje için gerçek derleme metotları yazılmış. biz ise solutiondaki tüm projelerin derleme metotlarını çağıracağız ancak bunu bir ahenk içerisinde yapmamız gerekiyor ki referand edilen projelerin derlenmesini de sağlayabilelim. Bu işi yapacak c# kodunu nasıl yazabiliriz?


---

## Kendinden biraz bahseder misin?

3 yıldır .NET backend developer olarak çalışıyorum. Şu
ana kadar çeşitli kurumsal projelerde yer aldım. Monolith mimariden
mikroservislere geçiş, RabbitMQ ile asenkron işlem yönetimi, PostgreSQL
ile performanslı sorgular yazma gibi konularda deneyim sahibiyim. Şu
anda hem teknik becerilerimi geliştiriyor hem de sistem tasarımı ve
cloud konularında derinleşmeye çalışıyorum.

## Agile kullanıyor musun? (metodolojiler)

Evet, çalıştığım ekiplerde genellikle Scrum metodolojisiyle çalıştık.
Daily, sprint planning, retrospective gibi seremonileri düzenli olarak
yapıyoruz. Jira üzerinden task yönetimi sağlıyoruz. Gerektiğinde Kanban
tarzı akışa da geçtik.

## Clouda başlayacak biri için neler önerirsin? Nerden başlanmalı nasıl ilerlenmeli?

Öncelikle temel cloud kavramları öğrenilmeli: IaaS, PaaS, SaaS gibi.
Sonrasında bir sağlayıcı seçilmeli (AWS, Azure, GCP). Azure üzerinden
gitmek isteyen biri için örnek rota: - Azure Fundamentals sertifikası
(AZ-900) - App Service, Blob Storage, Function, Logic App gibi
servisleri deneyimleme - DevOps tarafı: Azure DevOps veya GitHub Actions
ile CI/CD

## Bir kodun yolculuğu. Yazdığımız kod son kullanıcıya ulaşana kadar neler gerçekleşiyor?

Kod yazılır, test edilir, versiyon kontrol sistemine (örneğin Git) push
edilir. CI süreci tetiklenir: build, test, code analysis gibi adımlar
çalışır. Ardından CD süreci başlar: test ortamına deploy edilir, son
kontrollerden sonra prod'a alınır. Bu süreçte containerization (Docker),
orchestration (Kubernetes) devreye girebilir.

### CI/CD ne yapıyor?

CI (Continuous Integration): Kodun entegre edilip test edilmesini
sağlar. Otomatik build ve unit test süreçlerini kapsar. CD (Continuous
Delivery/Deployment): CI'dan geçen kodun staging veya production
ortamlarına otomatik olarak deploy edilmesini sağlar.

## Monitoring toollarında en çok hangi metriklere dikkat ediyorsun?

-   CPU ve bellek kullanımı
-   Response time (API latency)
-   Error rate (örneğin 500 hataları)
-   Request count
-   Custom application metrics (örneğin sepet oluşturma sayısı)
-   Logging & tracing (örneğin Application Insights, Grafana, Kibana,
    Prometheus)

## Blob Storage

Blob Storage, büyük veri nesnelerini (örneğin görseller, videolar, log
dosyaları) saklamak için kullanılan bir depolama sistemidir. Azure'da
yaygın olarak kullanılır. Public veya private erişim sağlanabilir.
Genelde CDN ile birlikte kullanılır.

## Reverse Proxy'yi bir cümlede nasıl anlatırsın?

Reverse Proxy, istemcilerin taleplerini alıp arka plandaki sunuculara
yönlendiren bir tür vekil sunucudur.

### peki normal proxy'den farkı ne? neden reverse?

Normal proxy istemcinin kimliğini gizlerken, reverse proxy sunucuların
kimliğini gizler. Load balancing, caching, SSL termination gibi
görevlerde kullanılır. Trafiği yönlendirme açısından oldukça önemlidir.

## Linux Containerization (opsiyonel soru) internal olarak nasıl sağlanıyor?

Containerlar, Linux kernel'in özellikleri olan namespaces (isolasyon) ve
cgroups (kısıtlama) kullanılarak oluşturulur. Bu sayede her container
kendi işlem alanına ve kaynaklarına sahip olur. Örneğin Docker da bu
yapıyı kullanır.

## Secret Management bir proje için neden önemlidir ? nasıl kullanıyorsun ? bunun için kullandığın özel bir tool var mı?

Secret yönetimi, şifreler, API anahtarları gibi hassas verilerin
güvenliğini sağlar. Kod içerisinde hardcode edilmemeli. Kullanılan
yöntemler: - Azure Key Vault - Environment variables - User Secrets
(development için) - HashiCorp Vault (gelişmiş senaryolarda)

## Data Consistency Mikroservislerde veri bütünlüğü neden önemli ve nasıl çözümler üretilmiş ?

Mikroservislerde her servis kendi veritabanına sahiptir, bu da
distributed data consistency problemlerine yol açar. Çözümler: - SAGA
Pattern (orchestration veya choreography) - Eventual consistency -
Idempotency - Outbox pattern

## Loglama hakkında ne düşünüyorsun ?

Loglama, hata ayıklama, izleme ve güvenlik için çok önemlidir.
Structured logging kullanılmalı. Her mikroservis için merkezi bir log
sistemi (örneğin ELK stack veya Azure Application Insights) tercih
edilmeli.

## Mikroservislerde Retry Mekanizması kurarken neye dikkat etmek gerekir ?

-   Retry count ve delay dikkatli ayarlanmalı
-   Exponential backoff kullanılmalı
-   İdempotent işlemler retry edilmeli
-   Circuit Breaker ile beraber kullanılmalı

## Visual Studio Compiler'ını yazan bir ekipte çalıştığımızı düşünelim. Solution içerisindeki projelerin derlenmesi görevi de bize verilmiş. Her proje için gerçek derleme metotları yazılmış. biz ise solutiondaki tüm projelerin derleme metotlarını çağıracağız ancak bunu bir ahenk içerisinde yapmamız gerekiyor ki referand edilen projelerin derlenmesini de sağlayabilelim. Bu işi yapacak c# kodunu nasıl yazabiliriz?

Burada topolojik sıralama (topological sort) kullanılabilir. Her
projenin bağımlılıkları bir directed graph üzerinde temsil edilir.
Bağımlılıklara göre sıralama yapılır ve her projeyi sırası geldiğinde
derleriz.

Kaba C# algoritması:

``` csharp
void BuildAllProjects(Dictionary<string, List<string>> dependencyGraph)
{
    var visited = new HashSet<string>();
    var result = new List<string>();

    void Visit(string project)
    {
        if (visited.Contains(project)) return;
        foreach (var dep in dependencyGraph[project])
            Visit(dep);
        visited.Add(project);
        result.Add(project);
    }

    foreach (var project in dependencyGraph.Keys)
        Visit(project);

    foreach (var project in result)
        Compile(project); // Gerçek derleme metodu
}
```
