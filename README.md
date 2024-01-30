In C#, attributes provide a way to add metadata to elements of code, such as classes, methods, properties, etc. These metadata tags can be used by compilers, tools, or at runtime to influence the behavior of the program. Attributes are enclosed in square brackets `[]` and placed before the target element they are describing.

Here's a simple example of using attributes in C#:

```csharp
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
```

In this example:
- `MyAttribute` is a custom attribute class.
- The `MyClass` class and its `MyMethod` method are annotated with the `MyAttribute`.
- At runtime, the attributes are retrieved and their properties accessed to obtain metadata about the annotated elements.
- Output:
  ```
  Class Attribute: This is a sample class
  Method Attribute: This is a sample method
  Executing MyMethod
  ```

Attributes are extensively used in C# for various purposes like serialization, validation, configuration, and more. They provide a flexible way to attach additional information to code elements without affecting their behavior directly.
