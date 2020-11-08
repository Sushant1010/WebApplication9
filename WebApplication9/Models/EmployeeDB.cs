using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;

namespace WebApplication9.Models
{
    public class EmployeeDB
    {
        TestDBEntities _db = new TestDBEntities();
        public List<Employee> ListAll()
        {
            List<Employee> lstemp = new List<Employee>();
            var emps = _db.tblEmployees.ToList();
            foreach (var item in emps)
            {
                lstemp.Add(new Employee() { EmployeeId = item.EmployeeID, Name = item.Name, Age = item.Age, Country = item.Country, State = item.State });
            }
            return lstemp;
        }

        //Method for Adding an Employee
        public int Add(Employee emp)
        {
            tblEmployee tb = new tblEmployee();
            tb.Name = emp.Name;
            tb.Age = emp.Age;
            tb.State = emp.State;
            tb.Country = emp.Country;

            _db.tblEmployees.Add(tb);
            return _db.SaveChanges();
        }

        //Method for Updating Employee record
        public int Update(Employee emp)
        {
            tblEmployee tb = _db.tblEmployees.Where(e => e.EmployeeID == emp.EmployeeId).FirstOrDefault();
            tb.Name = emp.Name;
            tb.Age = emp.Age;
            tb.State = emp.State;
            tb.Country = emp.Country;
            return _db.SaveChanges();
        }

        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            tblEmployee tb = _db.tblEmployees.Where(e => e.EmployeeID == ID).FirstOrDefault();
            _db.tblEmployees.Remove(tb);
            return _db.SaveChanges();
        }
    }
}