using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DataSourceLayer;
using Assignment1.DomainLayer.HelperClasses;
using Assignment1.DomainLayer.Interfaces;
using Assignment1.DomainLayer.Models;

namespace Assignment1.DomainLayer.Modules
{
    public class EmployeesModule : IBaseModule
    {
        #region Properties
        private EmployeeGateway Gateway { get; }
        public IEnumerable<Employee> EmployeesDataSet { get; set; }
        #endregion

        #region Constructor
        public EmployeesModule(string connectionString)
        {
            Gateway = new EmployeeGateway(connectionString);
        }
        #endregion

        public IEnumerable<Employee> GetEmployees() => ContextCreator.CreateEmployeesContext(Gateway.GetEmployeeData());

        public IEnumerable<Employee> GetEmployeeById(int id) =>
            ContextCreator.CreateEmployeesContext(Gateway.GetEmployeeDataById(id));

        public IEnumerable<Employee> GetEmployeeByUsername(string username) =>
            ContextCreator.CreateEmployeesContext(Gateway.GetEmployeeDataByUsername(username));

        public void InsertEmployeeData(Employee newEmployee) =>
            Gateway.InsertEmployeeData(newEmployee.Username, newEmployee.Password);

        public void UpdateEmployeeData(Employee updatedEmployee) =>
            Gateway.UpdateEmployeeData(updatedEmployee.Id, updatedEmployee.Username, updatedEmployee.Password);

        public void DeleteEmployeeById(int id) => Gateway.DeleteEmployeeById(id);
    }
}
