``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1526 (20H2/October2020Update)
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 5.0.2 (5.0.220.61120), X64 RyuJIT
  DefaultJob : .NET 5.0.2 (5.0.220.61120), X64 RyuJIT


```
|      Method |            Mean |         Error |        StdDev |   Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------ |----------------:|--------------:|--------------:|--------:|-------:|-------:|----------:|
| MultiThread | 1,799,452.32 ns | 20,057.180 ns | 18,761.498 ns | 21.4844 | 3.9063 | 3.9063 |   7,184 B |
|  Sequential |        84.77 ns |      0.518 ns |      0.459 ns |       - |      - |      - |         - |
|    Parallel |     8,322.89 ns |     71.619 ns |     59.805 ns |  1.2054 |      - |      - |   7,548 B |
