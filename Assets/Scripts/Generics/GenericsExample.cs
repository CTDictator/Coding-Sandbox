using Unity.VisualScripting;
using UnityEngine;

public class GenericsExample : MonoBehaviour
{
    // A delegate that takes in two generic parameters and returns a third generic.
    private delegate TResult myDelegate<T1, T2, TResult>(T1 arg1, T2 arg2);

    // New class with two generics required as parameters.
    private TheNewClass<int, float> theClass = new();

    private Unit<Fighter> u1 = new();
    private Unit<Archer> u2 = new();

    private void Start()
    {
        PrintInput("Alpha");
        PrintInput(99);
        theClass.PrintInputs(9, 9.8f);
        u1.unit.Attack();
        u2.unit.Attack();
        u1.unit.Defend();
        u2.unit.Defend();
    }

    private void PrintInput<T>(T t)
    {
        Debug.Log(t);
    }
}

public class TheNewClass<T1, T2>
{
    public T1 a;
    public T2 b;

    public void PrintInputs(T1 a, T2 b)
    {
        this.a = a; 
        this.b = b;
        Debug.Log($"{this.a} & {this.b}");
    }
}

public interface IEnemy
{
    static void Attack() => Debug.Log("Attacking!");
    static void Defend() => Debug.Log("Defending!");
}

public class Fighter : IEnemy
{
    public void Attack() => IEnemy.Attack();
    public void Defend() => Debug.Log("Blocking!");
}

public class Archer : IEnemy
{
    public void Attack() => Debug.Log("Shooting!");
    public void Defend() => IEnemy.Defend();
}

public class Unit<T> where T : class, IEnemy, new()
{
    public T unit = new();
}
