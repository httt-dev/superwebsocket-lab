using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ErrorManager.MSTest
{
    [TestClass]
    public class ErrorTypeTests
    {
        [TestMethod]
        public void TestGetErrorCode()
        {
            // Arrange
            string errorType = ErrorTypeList.Failure;

            // Act
            string errorCode = ErrorTypeList.GetErrorCode(errorType);

            // Assert
            Assert.AreEqual("E0", errorCode);
        }

        [TestMethod]
        public void TestGetErrorType()
        {
            // Arrange
            string errorCode = "E1";

            // Act
            string errorType = ErrorTypeList.GetErrorType(errorCode);

            // Assert
            Assert.AreEqual(ErrorTypeList.InputError, errorType);
        }

        [TestMethod]
        public void TestIsValidErrorType_Valid()
        {
            // Arrange
            string errorType = ErrorTypeList.Unprocessed;

            // Act
            bool isValid = ErrorTypeList.IsValidErrorType(errorType);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestIsValidErrorType_Invalid()
        {
            // Arrange
            string errorType = "InvalidErrorType";

            // Act
            bool isValid = ErrorTypeList.IsValidErrorType(errorType);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
