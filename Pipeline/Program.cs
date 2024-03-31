using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyObject { Name = "", Age = 111 };
            var pipeline = new ValidationPipeline<MyObject>();

            pipeline.AddStep(new NameValidationStep());
            pipeline.AddStep(new AgeValidationStep());

            var validationResult = pipeline.Validate(obj);

            if (validationResult.IsValid)
            {
                Console.WriteLine("Object is valid.");
            }
            else
            {
                Console.WriteLine($"Validation failed. Error code: {validationResult.ErrorCode}, Error message: {validationResult.ErrorMessage}");
            }

            Console.ReadLine();
        }
    }
}
