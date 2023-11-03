

using Academy.Core.Enums;

namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullname, string group, int average, Education education);
        public Task<string> UptadeAsync(string id, string fullname, string group, int average, Education education);
        public Task<string> RemoveAsync(string id);

        public Task<string> GetAsync(string id);
        public Task GetAllAsync();
    } 
}
