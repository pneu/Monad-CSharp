# Monad-CSharp

Here is a example.
```cs
Monad<int> m1 = Maybe<int>.Just(1);
m1.Bind(x => Console.WriteLine(x));

var m2 = Maybe<int>.Just(2);
var m3 = m2.Bind(x => Maybe<double>.Just(x + 1d))
  .Bind(x => Maybe<long>.Just((long)(x * 3)));
Console.WriteLine(m3.FromMaybe());

Maybe<int> nothing = Maybe<int>.Nothing;
nothing.Bind(x => Console.WriteLine(x));
nothing.FromMaybe(() => {
  Console.WriteLine("error");
  return 0;
});
```

output
```
1
9
error
```
