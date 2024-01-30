using System;

// Custom attribute definition
public class MyAttribute : Attribute
{
    public string Description { get; }

    public MyAttribute(string description)
    {
        Description = description;
    }
}

// Applying the custom attribute to a class
[My("This is a sample class")]
class MyClass
{
    // Applying the custom attribute to a method
    [My("This is a sample method")]
    public void MyMethod()
    {
        Console.WriteLine("Executing MyMethod");
    }
}

class Program
{
    [My("This is a Main method")]
    static void Main(string[] args)
    {
        // Retrieving and using attributes at runtime
        Type type = typeof(MyClass);
        var classAttribute = (MyAttribute)Attribute.GetCustomAttribute(type, typeof(MyAttribute));
        Console.WriteLine($"Class Attribute: {classAttribute.Description}");

        var method = typeof(MyClass).GetMethod("MyMethod");
        var methodAttribute = (MyAttribute)Attribute.GetCustomAttribute(method, typeof(MyAttribute));
        Console.WriteLine($"Method Attribute: {methodAttribute.Description}");

        MyClass myObj = new MyClass();
        myObj.MyMethod();
    }
}
