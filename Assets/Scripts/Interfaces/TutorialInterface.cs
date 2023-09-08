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
        ((IInterfaceExample)newClass).Example();

        Debug.Log($"Field is: {newClass.Property}");
    }
}

public class ClassWithInterface : IInterfaceExample
{
    private int field = 30;
    public int Property { get { return field; } set { field = value; } }

    public void Example2() => Debug.Log("Example 2 method.");
}

public interface IInterfaceExample
{
    // This method exists only in an interface cast.
    public void Example() => Debug.Log("Example 1 method.");

    // This method must exist, but user must define it.
    public void Example2();

    // Properties are permitted as well.
    public int Property {  get; set; }
}