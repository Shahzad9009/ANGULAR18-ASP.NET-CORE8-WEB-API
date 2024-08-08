using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace EmployeePortal.Repository
{
    public class EployeeRepository
    {
        private readonly AppDbContext db;
        public EployeeRepository(AppDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await db.Employees.ToListAsync();
        }
        public async Task SaveEmployee(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            await db.SaveChangesAsync();
        }
        public async Task updateEmployee(int id ,Employee obj)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }
            employee.Name = obj.Name;
            employee.Email = obj.Email;
            employee.Mobile = obj.Mobile;
            employee.Age = obj.Age;
            employee.Salary = obj.Salary;
            employee.Status = obj.Status;

            await db.SaveChangesAsync();

        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee Not Found");
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

        }
    }
}
