
using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;
using System.Net.Http.Headers;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository studentRepository = new StudentRepository();


        public async Task<string> CreateAsync(string fullname, string group, int average, Education education)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return "FullName bos ola bilmez";

            if (string.IsNullOrWhiteSpace(group))
                return "Group bos ola bilmez";

            if (average <= 0 || average >= 100)
                return "Average 0-dan az ve 100-den cox ola bilmez";

            Student student = new Student(fullname, group, average, education);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);

            await studentRepository.CreateAsync(student);

            return "Ugurla yaradildi";

        }

       

        public async Task GetAllAsync()
        {
            List<Student> students = await studentRepository.GetAllAsync();

            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id} Fullname:{student.Fullname} Group:{student.Group} Average:{student.Average} Education:{student.Education} CreatedAt:{student.CreatedAt} UptadetAt:{student.UptadetAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await studentRepository.GetAsync(x => x.Id == id);

            if (student == null)
                return "Telebe tapilmadi";

            Console.WriteLine($"Id{student.Id} Fullname{student.Fullname} Group{student.Group} Average{student.Average} Education{student.Education} CreatedAt{student.CreatedAt} UptadetAt{student.UptadetAt}");
            return "Telebe ugurla tapildi";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await studentRepository.GetAsync(x => x.Id == id);

            if (student == null)
                return "Telebe tapilmadi";

            await studentRepository.RemoveAsync(student);

            return "Ugurla Silindi";
        }

        public async Task<string> UptadeAsync(string id, string fullname, string group, int average, Education education)
        {
            Student student = await studentRepository.GetAsync(x => x.Id == id);

            if (string.IsNullOrWhiteSpace(fullname))
                return "FullName bos ola bilmez";

            if (string.IsNullOrWhiteSpace(group))
                return "Group bos ola bilmez";

            if (average <= 0 || average >= 100)
                return "Average 0-dan az ve 100-den cox ola bilmez";

            student.Fullname = fullname;
            student.Group = group;
            student.Average = average;
            student.Education = education;
            student.UptadetAt = DateTime.UtcNow.AddHours(4);

            return "Uptaded Successfully";
        }

    }
}
