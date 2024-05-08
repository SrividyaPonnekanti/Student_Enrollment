using ModelLib;
using System.Collections.Generic;


namespace InterfaceLib
{
    public interface IStudents
    {
        int InsertOrUpdate(StudentDto objStudentDto);
        int Delete(int id);
        List<StudentDto> GetStudents();
        StudentDto GetById(int id);


    }
}
