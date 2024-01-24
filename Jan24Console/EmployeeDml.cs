using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jan24Console
{
    internal class EmployeeDml
    {
        public static void Display()
        {
            using (EmployeeEntities ee=new EmployeeEntities())
            {
               List<EmployeeDetail> arow= ee.EmployeeDetails.ToList();
                arow.ForEach(e=>Console.WriteLine($"{e.empId}\t{e.empName}\t{e.salary}"));
            }
        }
        public static void DisplayByid()
        {
            Console.WriteLine("Enter Id to update");
            int id = int.Parse(Console.ReadLine());
            using (EmployeeEntities ee = new EmployeeEntities())
            {
                List<EmployeeDetail> arow = ee.EmployeeDetails.ToList();
               var emp= arow.Where(e =>e.empId==id).FirstOrDefault();
                Console.WriteLine($"{emp.empId}\t{emp.empName}\t{emp.salary}");

            }
        }
        public static void InsertEmp()
        {
            Console.WriteLine("Enter EmpId :");
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Emp Name :");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Emp Salary");
            float sal=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter City");
            string ct=Console.ReadLine() ;
            using (EmployeeEntities ee = new EmployeeEntities())
            {
               EmployeeDetail e=new EmployeeDetail();
                e.empId=id;
                e.empName=name;
                e.salary=sal;
                e.city=ct;
                ee.EmployeeDetails.Add(e);
                ee.SaveChanges();
            }
            Console.WriteLine("Row Added Successfully");
            Display();
        }

        //update
        public static void Update()
        {
            Console.WriteLine("Enter Id to update");
            int id=int.Parse(Console.ReadLine());
            using (EmployeeEntities ee = new EmployeeEntities())
            {
                EmployeeDetail e = ee.EmployeeDetails.Where(emp => emp.empId == id).FirstOrDefault();
                Console.WriteLine("Enter Name");
                e.empName = Console.ReadLine();
                Console.WriteLine("Enter Salary");
                e.salary=float.Parse(Console.ReadLine());
                Console.WriteLine("Enter City");
                e.city= Console.ReadLine();
                ee.SaveChanges ();
            }
            Console.WriteLine("Updated Successfully");
            Display ();
        }
        public static void DeleteById() {
            Console.WriteLine("Enter Id to Delete");
            int id = int.Parse(Console.ReadLine());
            using (EmployeeEntities ee = new EmployeeEntities())
            {
                EmployeeDetail e = ee.EmployeeDetails.Where(emp => emp.empId == id).FirstOrDefault();
                ee.EmployeeDetails.Remove(e);
                ee.SaveChanges();
            }
            Console.WriteLine("Deleted A row");
            Display();
        }
    }
}
