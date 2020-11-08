using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class EmployeeController : ApiController
    {
        //Get
        //api/Employee
        //Get
        //api/Employee/1
        //Post
        //api/Employee
        //PUT
        //api/Emplolyee
        //DELETE
        //api/Employee/1

        EmployeeDB empDB = new EmployeeDB();

        public List<Employee> Get()
        {
            return empDB.ListAll();
        }
        public void Post(Employee emp)
        {
            empDB.Add(emp);
        }
        public Employee Get(int ID)
        {
            var emp = empDB.ListAll().Find(x => x.EmployeeId.Equals(ID));
            return emp;
        }
        public void Put(Employee emp)
        {
            empDB.Update(emp);
        }
        public void Delete(int ID)
        {
            empDB.Delete(ID);
        }
    }
}
