# [Yazılımcı Mülakatı ve Değerlendirmesi](https://www.youtube.com/watch?v=IeCU51D8eW8&list=PLRp4oRsit1bz6myZyqonUrnA6mUGJ-kI6)

## Davranışsal Sorular:

### Soru 1: Kısaca kendinden bahseder misin?
Bu soru genellikle bir "elevator pitch" gibi yanıtlanmalı. Şöyle bir cevap verebilirsin:

> "Merhaba, ben [Adınız]. Yaklaşık 3 yıldır .NET backend geliştirme alanında çalışıyorum. Çalışma hayatım boyunca ASP.NET Core, RESTful API'ler, veri tabanı yönetimi (PostgreSQL), ve yazılım mimarisi prensipleri konusunda deneyim kazandım. Son işimde, [X projesi] üzerinde çalışarak performans optimizasyonları yaptım ve müşteri ihtiyaçlarına göre özelleştirilmiş çözümler ürettim. Teknik bilgimi sürekli güncel tutmak için veri yapıları ve algoritmalar üzerine çalışıyorum. Bunun dışında, teknoloji dışı alanlarda da kendimi geliştiriyorum; spor yapıyor, kültürel etkinliklere katılıyorum ve içerik üretimi gibi hobilerime vakit ayırıyorum."

### Soru 2: Neden iş değiştirmek istiyorsunuz?
Bu soruda dürüst olun ama negatiften ziyade pozitif bir dil kullanmaya çalışın:

> "Mevcut işimde iyi deneyimler kazandım, ancak artık kendimi daha büyük bir ekipte, daha zorlu projelerde geliştirmek ve kariyerimde bir adım ileriye taşımak istiyorum. Özellikle [X şirketi] gibi güçlü teknik ekiplerle çalışarak yazılım geliştirme süreçlerinde daha geniş bir perspektif kazanmak istiyorum. Aynı zamanda, finansal ve profesyonel anlamda daha tatmin edici bir ortamda bulunmanın beni motive edeceğine inanıyorum."

---

## Teknik Sorular:

### Soru 1: Eski iş yerinizden, bizim şirketimize getirmek istemediğiniz bir şey var mı?

Bu soruya negatif bir ton kullanmadan, gelişime açık yönlerden bahsetmek iyi bir yaklaşım olur:

> "Eski iş yerimde zaman zaman iletişim ve süreç yönetimi sorunlarıyla karşılaşabiliyorduk. Bu, bazen projelerin beklenenden daha uzun sürmesine neden olabiliyordu. Bu deneyimden öğrenerek, takım içi iletişimin ve net süreçlerin yazılım projelerinde ne kadar önemli olduğunu fark ettim. Yeni bir yerde bu deneyimden öğrendiklerimi, daha iyi bir iletişim ortamı oluşturmaya katkı sağlamak için kullanabilirim."

### Soru 2: En son ne ve ne zaman öğrendiniz?
Bu soruda, öğrenme alışkanlıklarınızı göstermek önemlidir:

> "En son veri yapıları ve algoritmalar konusunda çalıştım. Özellikle ağaç veri yapıları üzerinde durdum ve Binary Search Tree (BST) kavramını inceledim. Veri yapıları, verileri düzenlemek ve işlem yapmak için farklı yaklaşımlar sunar. BST gibi bir veri yapısı, veriyi hızlı bir şekilde arama, ekleme ve silme işlemleri için optimize edilmiş bir yapıdır."

#### Binary Search Tree (BST) Nedir?
- **Tanım:** Binary Search Tree, her düğümün maksimum iki çocuğu olduğu ve sol çocuğun değerinin düğümün kendisinden küçük, sağ çocuğun değerinin ise düğümün kendisinden büyük olduğu bir veri yapısıdır.
- **Özellikler:**
  - Sol alt ağaçtaki tüm düğümler, kök düğümden daha küçük olmalıdır.
  - Sağ alt ağaçtaki tüm düğümler, kök düğümden daha büyük olmalıdır.
  - Her bir alt ağaç da bir BST'dir.
- **Avantajlar:**
  - O(log n) zaman karmaşıklığı ile arama, ekleme ve silme işlemleri yapılabilir. (Dengeli bir BST'de)
  - Veriyi sıralı bir şekilde saklayabilir ve kolayca dolaşabilirsiniz (örneğin, sıralama için In-Order Traversal).

### Soru 3: OOP'nin ilkelerini açıklayabilir misiniz?

#### OOP’nin Dört Temel Prensibi:
1. **Encapsulation (Kapsülleme):**
   - Veriyi ve bu veriyle ilişkili işlemleri tek bir yerde toplar.
   - Örnek:
     ```csharp
     public class Account
     {
         private decimal balance;
         public void Deposit(decimal amount) => balance += amount;
         public decimal GetBalance() => balance;
     }
     ```

2. **Inheritance (Kalıtım):**
   - Bir sınıfın başka bir sınıfın özelliklerini devralmasını sağlar.
   - Örnek:
     ```csharp
     public class Animal { public void Eat() => Console.WriteLine("Eating..."); }
     public class Dog : Animal { public void Bark() => Console.WriteLine("Barking..."); }
     ```

3. **Polymorphism (Çok Biçimlilik):**
   - Aynı işlem farklı şekillerde gerçekleştirilebilir.
   - Örnek:
     ```csharp
     public virtual void Speak() => Console.WriteLine("Animal sound");
     public class Dog : Animal { public override void Speak() => Console.WriteLine("Bark"); }
     ```

4. **Abstraction (Soyutlama):**
   - Gereksiz detayları gizler ve sadece gerekli bilgileri sunar.
   - Örnek:
     ```csharp
     public abstract class Shape { public abstract double CalculateArea(); }
     public class Circle : Shape { public override double CalculateArea() => Math.PI * radius * radius; }
     ```

### Soru 4: SOLID prensipleri sizce önemli midir? Neden?

#### Cevap (Maddeler Halinde):
Evet, SOLID prensipleri yazılımın sürdürülebilirliği, okunabilirliği ve bakımı açısından son derece önemlidir. Prensiplerin her birine ayrı bir örnek vererek açıklayabiliriz:

1. **Single Responsibility Principle (SRP):**
   - Tanım: Her sınıf yalnızca tek bir sorumluluğa sahip olmalıdır.
   - Örnek:
     ```csharp
     public class ReportGenerator { public string GenerateReport() => "Report data"; }
     public class ReportPrinter { public void Print(string report) => Console.WriteLine(report); }
     ```

2. **Open/Closed Principle (OCP):**
   - Tanım: Bir sınıf değişikliğe kapalı, genişlemeye açık olmalıdır.
   - Örnek:
     ```csharp
     public abstract class Shape { public abstract double Area(); }
     public class Circle : Shape { public override double Area() => Math.PI * radius * radius; }
     public class Rectangle : Shape { public override double Area() => width * height; }
     ```

3. **Liskov Substitution Principle (LSP):**
   - Tanım: Türetilmiş sınıflar, temel sınıfın yerine kullanılabilir olmalıdır.
   - Örnek (LSP ihlali):
     ```csharp
     public class Bird { public virtual void Fly() => Console.WriteLine("Flying"); }
     public class Penguin : Bird { public override void Fly() => throw new NotImplementedException(); }
     ```

4. **Interface Segregation Principle (ISP):**
   - Tanım: Bir arayüz, bir sınıfın ihtiyaç duymadığı metotları içermemelidir.
   - Örnek:
     ```csharp
     public interface IPrinter { void Print(); }
     public interface IScanner { void Scan(); }
     public class MultiFunctionPrinter : IPrinter, IScanner { }
     ```

5. **Dependency Inversion Principle (DIP):**
   - Tanım: Üst seviye modüller, alt seviye modüllere bağımlı olmamalıdır.
   - Örnek:
     ```csharp
     public interface ILogger { void Log(string message); }
     public class ConsoleLogger : ILogger { public void Log(string message) => Console.WriteLine(message); }
     public class Application { private readonly ILogger logger; public Application(ILogger logger) { this.logger = logger; } }
     ```

### Soru 5: Design Pattern neyi amaçlıyor?

#### Cevap (Maddeler Halinde):
1. **Tekrarlanan Sorunlara Çözüm Sağlar:**
   - Yazılım geliştirme sırasında sık karşılaşılan sorunlara, yeniden kullanılabilir çözümler sunar.

2. **Kodun Okunabilirliğini ve Modülerliğini Artırır:**
   - Kodun daha anlaşılır, bakımının kolay ve genişlemeye açık olmasını sağlar.

3. **Ekip Çalışmasını Kolaylaştırır:**
   - Tasarım desenlerini bilen bir ekip üyesi, başka birinin yazdığı kodu kolayca anlayabilir.

#### Örnek Tasarım Desenleri:
1. **Singleton:** Bir sınıfın sadece bir örneğinin oluşmasını sağlar.
   ```csharp
   public class Singleton
   {
       private static Singleton instance;
       private Singleton() { }
       public static Singleton Instance => instance ??= new Singleton();
   }
   ```
2. **Factory Method:** Nesne oluşturma sürecini soyutlayarak farklı türde nesnelerin üretilmesine olanak tanır.
   ```csharp
   public abstract class Creator { public abstract IProduct FactoryMethod(); }
   public class ConcreteCreatorA : Creator { public override IProduct FactoryMethod() => new ProductA(); }
   ```

### Soru 6: Kodun satır sayısını düşürme
Kod refactor edilerek daha okunabilir hale getirilebilir:
```csharp
public class DataProvider
{
    private static DataProvider instance;
    public static DataProvider Instance => instance ??= new DataProvider();
}
```

### Soru 7: FizzBuzz Uygulaması
Kodun basit ve temiz olmasına dikkat edin:
```csharp
for (int i = 1; i <= 100; i++)
{
    if (i % 15 == 0) Console.WriteLine("FizzBuzz");
    else if (i % 3 == 0) Console.WriteLine("Fizz");
    else if (i % 5 == 0) Console.WriteLine("Buzz");
    else Console.WriteLine(i);
}
```

### Soru 8: Value ve Reference Types Nedir?

## 1. Value Types (Değer Türleri)

- **Depolama**: Değer türleri, belleğin *stack* bölümünde depolanır. Bu türlerdeki bir değişken, doğrudan kendi verisini saklar.
- **Kopyalama**: Bir değer türünü başka bir değişkene atadığınızda, verinin bir kopyası oluşturulur. İki değişken birbirinden bağımsızdır.
- **Performans**: Küçük boyutlu ve hızlı erişim gerektiren veriler için uygundur.
- **Örnekler**: 
  - Basit veri türleri: `int`, `float`, `double`, `bool`, `char`
  - Yapılar (`struct`lar)
  - Enumerations (`enum`)

### Örnek
```csharp
int a = 5;
int b = a; // 'b' değişkenine 'a'nın değeri kopyalanır.
b = 10;    // 'b'nin değeri değiştirilir, ancak 'a' değişmeden kalır.
Console.WriteLine(a); // Çıktı: 5
Console.WriteLine(b); // Çıktı: 10
```

---

## 2. Reference Types (Referans Türleri)

- **Depolama**: Referans türleri, belleğin *heap* bölümünde saklanır. Değişken, heap üzerindeki verinin bir adresini (referansını) taşır.
- **Kopyalama**: Referans türünü başka bir değişkene atadığınızda, yalnızca referans kopyalanır. İki değişken aynı bellek adresine işaret eder.
- **Performans**: Daha büyük ve karmaşık veriler için uygundur.
- **Örnekler**:
  - Nesneler (`class`lar)
  - Diziler
  - Delegeler

### Örnek
```csharp
class Person
{
    public string Name { get; set; }
}

Person person1 = new Person { Name = "Ali" };
Person person2 = person1; // 'person2', 'person1'in işaret ettiği bellek adresine işaret eder.
person2.Name = "Veli";    // 'person2' üzerinden yapılan değişiklik 'person1'i de etkiler.
Console.WriteLine(person1.Name); // Çıktı: Veli
```

---

## Karşılaştırma: Value vs Reference Types

| Özellik                 | Value Types                        | Reference Types                    |
|-------------------------|-------------------------------------|-------------------------------------|
| **Depolama Yeri**       | Stack                              | Heap                               |
| **Kopyalama**           | Değerin bir kopyası oluşturulur    | Sadece referans (adres) kopyalanır |
| **Bağımsızlık**         | Bağımsız                          | Aynı nesneye işaret eder           |
| **Performans**          | Küçük boyutlu veriler için hızlıdır | Büyük veriler için kullanılır      |

---

## Değer ve Referans Türleri Arasında Dönüşüm

1. **Boxing**: Değer türünün referans türüne dönüştürülmesidir. Örneğin, bir `int` değeri bir `object` içine kutulanır.
   ```csharp
   int num = 10;
   object obj = num; // Boxing
   ```

2. **Unboxing**: Referans türünün tekrar değer türüne dönüştürülmesidir.
   ```csharp
   object obj = 10;
   int num = (int)obj; // Unboxing
   ```

---

## Özet

- **Value Types**: Verinin kendisini taşır ve birbirinden bağımsız kopyalar oluşturur.
- **Reference Types**: Veriye işaret eden referansları taşır ve aynı bellek alanını paylaşır.
- Performansı optimize etmek ve hataları önlemek için doğru türü seçmek önemlidir.