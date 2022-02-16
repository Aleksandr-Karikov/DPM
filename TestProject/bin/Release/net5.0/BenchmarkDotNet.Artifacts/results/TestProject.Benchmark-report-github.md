``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1526 (20H2/October2020Update)
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 5.0.2 (5.0.220.61120), X64 RyuJIT
  DefaultJob : .NET 5.0.2 (5.0.220.61120), X64 RyuJIT


```
|      Method |             Mean |          Error |         StdDev |  Gen 0 | Allocated |
|------------ |-----------------:|---------------:|---------------:|-------:|----------:|
| MultiThread |         2.007 μs |      0.0399 μs |      0.0392 μs | 0.0267 |     185 B |
|  Sequential | 2,996,463.473 μs |  8,911.8524 μs |  8,336.1523 μs |      - |     704 B |
|    Parallel |   541,744.735 μs | 10,715.6652 μs | 21,151.6776 μs |      - |   9,688 B |
