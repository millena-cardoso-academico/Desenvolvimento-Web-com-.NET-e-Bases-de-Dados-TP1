using System;

class Program
{
    static void Main()
    {
        Func<string, string, string> concatenar = (nome, sobrenome) => $"{nome} {sobrenome}";
        Func<string, string, string> pipeline = concatenar
            .AndThen(s => s.ToUpper())
            .AndThen(s => s.Replace(" ", ""));

        Console.WriteLine(pipeline("João", "Silva"));
    }
}

public static class FuncExtensions
{
    public static Func<T1, T2, TResult> AndThen<T1, T2, TResult>(this Func<T1, T2, TResult> func, Func<TResult, TResult> next)
    {
        return (x, y) => next(func(x, y));
    }
}