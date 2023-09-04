using System;
using UnityEngine;

public class DelegatesPractice : MonoBehaviour
{
    // Delegate that takes no parameters and returns void.
    private delegate void DelegateA();
    private DelegateA delegateA;

    // Delegate that takes in two floats and returns a bool.
    private delegate bool DelegateB(float x, float y);
    private DelegateB delegateB;

    // System Action that takes in two integers. (Always void return type.)
    private Action<int, int> delegateC;
    // System Function that takes in two integers and returns a bool.
    private Func<int, int, bool> delegateD;
    // Using a timer class to delay sending a message.
    [SerializeField] private DelegateTimer timer;

    private void Start()
    {
        delegateA = MethodA;
        delegateA += MethodB;
        delegateB = MethodC;
        Debug.Log($"3 > 2: {delegateB(3, 2)}");
        // Anonymous Method used.
        delegateA += delegate () { Debug.Log("Anonymous Method called."); };
        // Lambda Method used.
        delegateA += () => { Debug.Log("Lambda Method called."); };
        delegateA();
        delegateB -= MethodC;
        delegateB = (float x, float y) => { return x < y; };
        Debug.Log($"10 < 8: {delegateB(10, 8)}");
        // Action with a lambda.
        delegateC = (int a, int b) => { Debug.Log($"{a} + {b} = {a + b}"); };
        delegateC(5, 6);
        // Func with a lambda.
        delegateD = (int u, int v) => { return u == v; };
        Debug.Log($"10 == 10: {delegateD(10, 10)}");
        timer.SetTimer(2.0f, () => { Debug.Log("Timer Complete."); });
    }

    private void MethodA()
    {
        Debug.Log("MethodA called.");
    }

    private void MethodB()
    {
        Debug.Log("MethodB called.");
    }

    private bool MethodC(float x, float y)
    {
        return x > y;
    }
}
