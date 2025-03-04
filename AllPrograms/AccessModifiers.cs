using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPrograms
{
    public sealed class AccessModifiers
    {
        string _identifier;
        int _power;

        public AccessModifiers()
        {
            _identifier = "Default";
            _power = 10;
        }

        public void Display()
        {

            Console.WriteLine($"identifier is  : {_identifier}");
            Console.WriteLine($"Power is  : {_power}");

        }
    }

    public class Access_Modofiers
    {
        private int myPrivateField =3;
        protected int myProtectedField =2;
        internal int myInternalField =5;
        public int myPublicField = 12 ;

        private void MyPrivateMethod()
        {
            Console.WriteLine($" My Public Field value called from private method : {myPublicField}");

            Console.WriteLine($" My Private Field accessing from private method : {myPrivateField}");
        }
       
        public void Calling_Private_Method()
        {
            MyPrivateMethod();

            Console.WriteLine($" My Private Field accessing from public method : {myPrivateField}");

        }

    }

    public class DerivedClass : Access_Modofiers
    {
        public void MyProtectedMethod() 
        {
           
            Console.WriteLine($" My Public Field value called from derived class: {myPublicField}");

            Console.WriteLine($"myProtectedField accessing from derived class  : {myProtectedField}");

            string code = @"
        using System;
        class MyClass
        {
            private int myPrivateField = 42;
            protected int myProtectedField = 20; 
            internal int myPublicField = 25

        }
        class Program
        {
            static void Main()
            {
                MyClass obj = new MyClass();
                Console.WriteLine(obj.myPrivateField); // CS0122: 'MyClass.myPrivateField' is inaccessible due to its protection level
                Console.WriteLine(obj.myProtectedField);
                Console.WriteLine(obj.myPublicField});
            }
        }"; ;

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

            // Create a compilation with the necessary references
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .Cast<MetadataReference>()
                .ToList();

            CSharpCompilation compilation = CSharpCompilation.Create(
                "CS0122Example",
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.ConsoleApplication)
            );

            // Emit the compilation and capture diagnostics
            var diagnostics = compilation.GetDiagnostics();

            // Print compilation issues
            foreach (var diagnostic in diagnostics)
            {
                if (diagnostic.Id == "CS0122") // Filter for CS0122 errors
                {
                    Console.WriteLine($"Error: {diagnostic.Id}");
                    Console.WriteLine($"Message: {diagnostic.GetMessage()}");
                    Console.WriteLine($"Location: {diagnostic.Location.GetLineSpan()}");
                    Console.WriteLine();
                }
            }
        }
    }

    internal class InternalClass
    {
        Access_Modofiers modifiers = new Access_Modofiers();

        internal void MyInternalMethod()
        {
            modifiers.myInternalField = 19;
            modifiers.myPublicField = 20;
            
        }
    }
}
