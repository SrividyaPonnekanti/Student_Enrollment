using ModelLib;
using System.Collections.Generic;

namespace InterfaceLib
{
    public interface IStudentDao
    {
        int InsertOrUpdate(StudentDto objStudentDto);
        int Delete(int id);
        List<StudentDto> GetStudents();
        StudentDto GetById(int id);
    }
}
