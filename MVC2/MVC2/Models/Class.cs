using Microsoft.EntityFrameworkCore;
using MVC2.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MVC2.Models
{
    public class Class : BaseModel<Class>
    {
        private SchoolContext dbContext;

        public Class()
        {
            Students = new HashSet<Student>();
            dbContext = new SchoolContext();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Numbers { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public async Task<Class> AddObjectAsync(Class obj)
        {
            await dbContext.AddAsync(obj);
            await dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteObjectSync(object id)
        {
            var students = await dbContext.Students.ToListAsync();
            for (int i = 0; i < students.Count; i++)
            {
                var item = students[i];
                if (item.ClassId == Convert.ToInt32(id))
                {
                    item.ClassId = null;
                    dbContext.Update(item);
                }
            }
            var @class = await GetObjectAsync(id);
            dbContext.Classes.Remove(@class);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Class>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await dbContext.Classes.ToListAsync();
        }

        public async Task<Class> GetObjectAsync(params object[] id)
        {
            return await dbContext.Classes.FirstOrDefaultAsync(m => m.Id == Convert.ToDouble(id[0]));
        }

        public Task<List<Class>> SearchObjectAsync(Func<Class, bool> predicate = null, int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateObjectAsync(Class obj)
        {
            dbContext.Update(obj);
            await dbContext.SaveChangesAsync();
        }
    }
}
