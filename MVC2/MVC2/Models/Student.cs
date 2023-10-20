using Microsoft.EntityFrameworkCore;
using MVC2.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC2.Models
{
    public class Student : BaseModel<Student>
    {
        private SchoolContext dbContext;

        public long Id { get; set; }
        public string? Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? PlaceOfBirth { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }

        public Student()
        {
            dbContext = new SchoolContext();
        }

        public async Task<Student> AddObjectAsync(Student obj)
        {
            if (dbContext == null)
                return null;
            await dbContext.AddAsync(obj);
            await dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteObjectSync(object id)
        {
            var student = await GetObjectAsync(id);
            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            if(dbContext == null)
                return new List<Student>();
            return await dbContext.Students.Include(s => s.Class).ToListAsync();
        }

        public async Task<Student> GetObjectAsync(params object[] id)
        {
            if (dbContext == null)
                return null;
            return await dbContext.Students.Include(s => s.Class).FirstOrDefaultAsync(m => m.Id == Convert.ToDouble(id[0]));
        }

        public async Task<List<Student>> SearchObjectAsync(Func<Student, bool> predicate = null, int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();

        }

        public async Task UpdateObjectAsync(Student obj)
        {
            dbContext.Update(obj);
            await dbContext.SaveChangesAsync();
        }
    }
}
