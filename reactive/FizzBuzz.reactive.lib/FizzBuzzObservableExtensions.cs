using System.Reactive.Linq;

namespace FizzBuzz.reactive.lib;

public static class FizzBuzzObservableExtensions
{
    public static IObservable<string> FizzBuzz(this IObservable<int> observable) => 
        observable.Select(GetFizzBuzz);

    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";
    private const string FizzAndBuzz = Fizz + Buzz;
    
    private static string GetFizzBuzz(int i)
    {
        if (IsFizzBuzz(i)) return FizzAndBuzz;
        if (IsFizz(i)) return Fizz;
        if (IsBuzz(i)) return Buzz;
        
        return i.ToString();
    }
    
    private static bool IsFizzBuzz(int i) => IsFizz(i) && IsBuzz(i);
    
    private static bool IsFizz(int i) => IsDivisibleBy(i: i, divisor: 3);
    private static bool IsBuzz(int i) => IsDivisibleBy(i: i, divisor: 5);

    private static bool IsDivisibleBy(int i, int divisor) => i % divisor == 0;
}