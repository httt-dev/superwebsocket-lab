using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepFunc
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var result =
            Step1()
            .Bind(Step2, "Step 2")
            .Bind(Step3, "Step 3")
            .Bind(Step4, "Step 4");

            if (!result.IsSuccess)
            {
                Console.WriteLine($"Error: {result.StepName} - {result.ErrorMessage}");
            }
            else
            {
                Console.WriteLine("Success!");
            }

            Console.ReadLine();
        }
        public static Result Step1()
        {
            // Perform Step1
            return Result.Success("Step 1"); // or Result.Failure("Error message");
        }

        public static Result Step2(Result previousResult)
        {
            // Perform Step2
            //return Result.Success("Step 2"); // or
            return Result.Failure("Error message" , "Step 2");
        }

        public static Result Step3(Result previousResult)
        {
            // Perform Step3
            return Result.Success("Step 3"); // or Result.Failure("Error message");
        }

        public static Result Step4(Result previousResult)
        {
            // Perform Step4
            return Result.Success("Step 4"); // or Result.Failure("Error message");
        }


    }

    public delegate Result StepFunc<Result>(Result previousResult);

    public class Result
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        public string StepName { get; }

        private Result(bool isSuccess, string errorMessage, string stepName)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            StepName = stepName;
        }

        public static Result Success(string stepName) => new Result(true, null, stepName);
        public static Result Failure(string errorMessage, string stepName) => new Result(false, errorMessage, stepName);
    }

    public static class StepExtensions
    {
        public static Result Bind(this Result result, StepFunc<Result> func, string stepName)
        {
            if (!result.IsSuccess)
                return result;

            try
            {
                return func(result);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, stepName);
            }
        }
    }
}
