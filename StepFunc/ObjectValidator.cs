using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepFunc.Validate
{
    public class ObjectValidator
    {
        public static Result ValidateObject(MyObject obj)
        {
            var result = Result.Success("Validation");

            result = result.Bind(() => CheckDataValidity(obj));
            result = result.Bind(() => CheckAccessPermission(obj));
            result = result.Bind(() => CheckBusinessConditions(obj));

            return result;
        }

        private static Result CheckDataValidity(MyObject obj)
        {
            // Perform data validity check
            if (obj == null || string.IsNullOrEmpty(obj.Name))
            {
                return Result.Failure("Invalid data", "DataValidityCheck");
            }
            return Result.Success("DataValidityCheck");
        }

        private static Result CheckAccessPermission(MyObject obj)
        {
            // Perform access permission check
            if (!User.HasPermission(obj))
            {
                return Result.Failure("Access denied", "AccessPermissionCheck");
            }
            return Result.Success("AccessPermissionCheck");
        }

        private static Result CheckBusinessConditions(MyObject obj)
        {
            // Perform business conditions check
            if (obj.Price <= 0)
            {
                return Result.Failure("Invalid price", "BusinessConditionsCheck");
            }
            return Result.Success("BusinessConditionsCheck");
        }
    }

    public class MyObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Other properties...
    }

    public class User
    {
        public static bool HasPermission(MyObject obj)
        {
            // Check user permission logic
            return true;
        }
    }

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

        public Result Bind(Func<Result> func)
        {
            if (!IsSuccess)
                return this;

            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, StepName);
            }
        }

    }



}
