# [Yazılımcı Mülakatı #2 ve Değerlendirmesi](https://www.youtube.com/watch?v=7gDlAVWY3Lo&list=PLRp4oRsit1bz6myZyqonUrnA6mUGJ-kI6&index=2)

## Davranışsal Sorular

- Kendini Tanıtma
- Neden Başvurdun
- Anlaşmazlık Sorusu


## Teknik Sorular:

### Soru 1: Aşağıdaki konseptlerin hangisini duydun ve/veya hakimsin?

- volatile
- delegate
- event-driven
- race condition
- biginteger
- thread
- unit test
- encoding

### Soru 2: Ekran çıktısı ne olur?

```csharp
static List<int> results = new();

public static void Main()
{
    var val = 10;
    var res = Calc(val);

    var min = results.Min();
    var avg = results.Average();
    var max = results.Max();
    var sum = results.Sum();

    Console.WriteLine("Min: {0}, Avg: {1}, Max: {2}, Sum: {3}",min, avg, max, sum);
}

public static int Calc(int count = 50)
{
    results.Add(count);
    if(count < 0)
        return -1;
    
    count--;

    if(count % 2 == 0)
    {
        count -= 2;
        return Calc(count);
    }
    else
    {
        return Calc(count - 2);
    }
}
```

### Soru3: Bu metoda iki tane tam sayı, string olarak gönderilecek ve bu sayıların toplanıp geri gönderilmesi gerekiyor.

```csharp
public string Sum(string val1, string val2)
{

}
```