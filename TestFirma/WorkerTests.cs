using System;
using Firma_zadanie.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFirma
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void Contract_ContractIsInternship_ReturnsInternship()
        {
            // Arrange
            var worker = new Worker();

            // Act
            worker.Contract = "Internship";

            // Assert
            Assert.AreEqual("Internship", worker.Contract, "Internship");
        }
        [TestMethod]
        public void Contract_ContractIsEmployee_ReturnsEmployee()
        {
            var worker = new Worker();

            worker.Contract = "Employee";

            Assert.AreEqual("Employee", worker.Contract);
        }
        [TestMethod]
        public void Contract_ContractIsMisspelled_ReturnsInternship()
        {
            var worker = new Worker();

            worker.Contract = "Employeee";

            Assert.AreEqual("Internship", worker.Contract);
        }
        [TestMethod]
        public void Contract_ContractIsWrong_ReturnsInternship()
        {
            var worker = new Worker();

            worker.Contract = "UnVtership";

            Assert.AreEqual("Internship", worker.Contract);
        }
        [TestMethod]
        public void Contract_ContractIsNumerical_ReturnsInternship()
        {
            var worker = new Worker();

            worker.Contract = "225124";

            Assert.AreEqual("Internship", worker.Contract);
        }
        [TestMethod]
        public void Overtime_OvertimeIsLessThanZero_ReturnsZero()
        {
            var worker = new Worker();

            worker.Overtime = -12;

            Assert.AreEqual(0, worker.Overtime);
        }
        [TestMethod]
        public void Overtime_OvertimeIsGreaterThanZero_ReturnsValue()
        {
            var worker = new Worker();

            worker.Overtime = 25;

            Assert.AreEqual(25, worker.Overtime);
        }
        [TestMethod]
        public void Salary_SalaryIs4600_Returns4600()
        {
            var worker = new Worker();

            worker.Contract = "Employee";
            worker.Salary = 4600f;

            Assert.AreEqual(4600f, worker.Salary);
        }
        [TestMethod]
        public void CalculateSalary_ContractIsEmployeeAndZeroOvertime_Returns4600()
        {
            PrivateObject obj = new PrivateObject(typeof(Worker));

            float result = (float) obj.Invoke("CalculateSalary", new Object[] { 0, "Employee" });

            Assert.AreEqual(4600f, result);
        }
        [TestMethod]
        public void CalculateSalary_ContractIsEmployeeAnd12HoursOvertime_Returns5520()
        {
            PrivateObject obj = new PrivateObject(typeof(Worker));

            float result = (float)obj.Invoke("CalculateSalary", new Object[] { 12, "Employee" });

            Assert.AreEqual(5520f, result);
        }
        [TestMethod]
        public void CalculateSalary_ContractIsInternshipAnd12HoursOvertime_Returns2000()
        {
            PrivateObject obj = new PrivateObject(typeof(Worker));

            float result = (float)obj.Invoke("CalculateSalary", new Object[] { 12, "Internship" });

            Assert.AreEqual(2000f, result);
        }
        [TestMethod]
        public void CalculateSalary_ContractIsWrongAnd12HoursOvertime_Returns2000()
        {
            PrivateObject obj = new PrivateObject(typeof(Worker));

            float result = (float)obj.Invoke("CalculateSalary", new Object[] { 12, "Intern" });

            Assert.AreEqual(2000f, result);
        }


        // Just in case testing simple properties 
        [TestMethod]
        public void FirstName_FirstNameIsJan_ReturnsJan()
        {
            var worker = new Worker();

            worker.FirstName = "Jan";

            Assert.AreEqual("Jan", worker.FirstName);
        }
        [TestMethod]
        public void LastName_LastNameIsKowalski_ReturnsKowalski()
        {
            var worker = new Worker();

            worker.LastName = "Kowalski";

            Assert.AreEqual("Kowalski", worker.LastName);
        }
    }
}