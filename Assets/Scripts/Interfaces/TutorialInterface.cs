using System;
using UnityEngine;

public class TutorialInterface : MonoBehaviour
{
    private void Start()
    {
        // Any non default methods can be used.
        ClassWithInterface newClass = new();
        newClass.Example2();
        // To use default implementation, class must be cast into an interface.
        IInterfaceExample newInterface = newClass;
        newInterface.Example();
        newInterface.Example2();
        // You can also cast it within the class.
        ((IInterfaceExample)this).Example();
    }
}

public class ClassWithInterface : IInterfaceExample
{
    // Add a single property within the class to allow the default methods to be used.
    IInterfaceExample IExample => (IInterfaceExample)this;
    public void Example() => IExample.Example();


    public void Example2() => Debug.Log("Example 2 method.");
}

public interface IInterfaceExample
{
    // This method exists only in an interface cast.
    public void Example() => Debug.Log("Example 1 method.");

    // This method must exist, but user must define it.
    public void Example2();
}