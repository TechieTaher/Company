using Company.Domain;
using Company.Models;
using System;
using System.Collections.Generic;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Techie Company");
            bool showMenu = true;
            BusinessUnitDomain businessUnitDomain = new BusinessUnitDomain();
            EmployeeDomain employeeDomain = new EmployeeDomain();
            EmployeeLeaveDomain employeeLeaveDomain = new EmployeeLeaveDomain();
            EmployeeProjectDomain employeeProjectDomain = new EmployeeProjectDomain();
            ProjectDomain projectDomain = new ProjectDomain();
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add Employee");
                Console.WriteLine("2) Add Employee Leave");
                Console.WriteLine("3) Add Employee Project");
                Console.WriteLine("4) Add Project");
                Console.WriteLine("5) List Project");
                Console.WriteLine("6) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        {
                            Employees employee = new Employees();
                            Console.Write("Enter Name : ");
                            employee.EmployeeName= Console.ReadLine().Trim();
                            Console.Write("Enter Phone No : ");
                            employee.PhoneNo= Convert.ToInt64(Console.ReadLine().Trim());
                            Console.Write("Enter Email : ");
                            employee.Email = Console.ReadLine().Trim();
                            Console.Write("Enter Employee Type : ");
                            employee.EmployeeType= Convert.ToInt32(Console.ReadLine().Trim());
                            Console.WriteLine("No     Name");
                            foreach (BusinessUnits businessUnit in businessUnitDomain.GetBusinessUnits())
                            {
                                Console.WriteLine($"{businessUnit.BusinessUnitId}     {businessUnit.BusinessUnitName}");
                            }
                            Console.Write("Select Business Unit by No : ");
                            employee.BusinessUnitId= Convert.ToInt32(Console.ReadLine().Trim());
                            employeeDomain.AddEmployee(employee);
                            Console.Write("Employee Added");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            EmployeeLeaves employeeLeave = new EmployeeLeaves();
                        EmployeeName:
                            Console.Write("Enter Employee Name : ");
                            var Employees = employeeDomain.GetByEmployeeName(Console.ReadLine().Trim());
                            Console.WriteLine("No     Employee Name     EmployeeType     PhoneNo");
                            foreach (Employees employee in Employees)
                            {
                                Console.WriteLine($"{employee.EmployeeId}     {employee.EmployeeName}     {employee.EmployeeType}     {employee.PhoneNo}");
                            }
                            Console.WriteLine("You want to Search Again then enter '0' or Enter Employee No?");
                            int employeeId = Convert.ToInt32(Console.ReadLine().Trim());
                            if (employeeId == 0)
                            {
                                goto EmployeeName;
                            }
                            employeeLeave.EmployeeId = employeeId;
                            Console.Write("Enter Start Date : ");
                            employeeLeave.StartDate = Convert.ToDateTime(Console.ReadLine().Trim());
                            Console.Write("Enter End Date : ");
                            employeeLeave.EndDate = Convert.ToDateTime(Console.ReadLine().Trim());
                            employeeLeaveDomain.AddEmployeeLeave(employeeLeave);
                            Console.Write("Employee Leave is Created");
                            break;
                        }
                    case "3":
                        {
                            EmployeeProjects employeeProject = new EmployeeProjects();
                        EmployeeName:
                            Console.Write("Enter Employee Name : ");
                            List<Employees> Employees = employeeDomain.GetByEmployeeName(Console.ReadLine().Trim());
                            Console.WriteLine("No     Employee Name     EmployeeType     PhoneNo");
                            foreach (Employees employee in Employees)
                            {
                                Console.WriteLine($"{employee.EmployeeId}     {employee.EmployeeName}     {employee.EmployeeType}     {employee.PhoneNo}");
                            }
                            Console.WriteLine("You want to Search Again then enter '0' or Enter Employee No?");
                            int employeeId = Convert.ToInt32(Console.ReadLine().Trim());
                            if (employeeId == 0)
                            {
                                goto EmployeeName;
                            }
                            employeeProject.EmployeeId = employeeId;
                            Console.WriteLine("No     Project Name");
                            foreach (Projects project in projectDomain.GetByBusinessUnit(Employees.Find(t=>t.EmployeeId==employeeId).BusinessUnitId))
                            {
                                Console.WriteLine($"{project.ProjectId}     {project.ProjectName}");
                            }
                            Console.Write("Select Project by No : ");
                            employeeProject.ProjectId = Convert.ToInt32(Console.ReadLine().Trim());
                            employeeProjectDomain.AddEmployeeProject(employeeProject);
                            Console.Write("Project is Assign to Employee");
                            break;
                        }
                    case "4":
                        {

                            Projects project= new Projects();
                            Console.Write("Enter Name : ");
                            project.ProjectName = Console.ReadLine().Trim();
                            Console.Write("Enter Budget : ");
                            project.Budget = Convert.ToInt32(Console.ReadLine().Trim());
                            Console.Write("Enter Start Date : ");
                            project.StartDate = Convert.ToDateTime(Console.ReadLine().Trim());
                            Console.Write("Enter Deadline Date : ");
                            project.DeadLine = Convert.ToDateTime(Console.ReadLine().Trim());
                            Console.WriteLine("No     Name");
                            foreach (BusinessUnits businessUnit in businessUnitDomain.GetBusinessUnits())
                            {
                                Console.WriteLine($"{businessUnit.BusinessUnitId}     {businessUnit.BusinessUnitName}");
                            }
                            Console.Write("Select Business Unit by No : ");
                            project.BusinessUnitId = Convert.ToInt32(Console.ReadLine().Trim());

                        EmployeeName:
                            Console.Write("Enter Employee Name : ");
                            List<Employees> Employees = employeeDomain.GetByEmployeeName(Console.ReadLine().Trim());
                            Console.WriteLine("No     Employee Name     EmployeeType     PhoneNo");
                            foreach (Employees employee in Employees)
                            {
                                Console.WriteLine($"{employee.EmployeeId}     {employee.EmployeeName}     {employee.EmployeeType}     {employee.PhoneNo}");
                            }
                            Console.WriteLine("You want to Search Again then enter '0' or Enter Employee No?");
                            int employeeId = Convert.ToInt32(Console.ReadLine().Trim());
                            if (employeeId == 0)
                            {
                                goto EmployeeName;
                            }
                            project.ProjectManagerId = employeeId;

                            project.Status = 10;
                            projectDomain.AddProject(project);
                            Console.Write("ManufactureUnit Added");
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("No     Project Name     BusinessUnit     Project Manager     Start Date     DeadLine");
                            foreach (Projects project in projectDomain.GetProjects())
                            {
                                Console.WriteLine($"{project.ProjectId}     {project.ProjectName}     {project.BusinessUnit.BusinessUnitName}     {project.ProjectManager.EmployeeName}     {project.StartDate}     {project.DeadLine}");

                            }
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            showMenu = false;
                            break;
                        }
                    default:
                        Console.WriteLine("please enter correct option");
                        break;
                }
            }
        }
    }
}
