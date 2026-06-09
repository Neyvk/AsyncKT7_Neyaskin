using System;

public class CustomObservable : IObservable<int>
{
    public IDisposable Subscribe(IObserver<int> observer)
    {
        for (int i = 1; i <= 5; i++)
        {
            observer.OnNext(i);
        }

        observer.OnCompleted();
        return null;
    }
}

public class CustomObserver : IObserver<int>
{
    public void OnNext(int value)
    {
        Console.WriteLine(value);
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Error: {error}");
    }

    public void OnCompleted()
    {
        Console.WriteLine("Генерация завершена");
    }
}
class Program
{
    static void Main()
    {
        var observable = new CustomObservable();
        var observer = new CustomObserver();

        observable.Subscribe(observer);

    }
}