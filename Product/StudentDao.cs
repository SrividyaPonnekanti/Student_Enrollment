using DbContextLib;
using InterfaceLib;
using InventoryUtilits;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Product
{
    public class StudentDao : IStudentDao
    {
        #region Global variable
        LogHelpers objdaoLoggingHelpers = new LogHelpers();
        string className = "StudentDao";
        DbConnection objDbConnection = new DbConnection();
        #endregion

        #region InsertandUpdate
        /// <summary>
        /// This is for InsertandUpdate
        /// </summary>
        /// <param name="objStudentDto"></param>
        /// <returns>int</returns>
        public int InsertOrUpdate(StudentDto objStudentDto)
        {
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "InsertOrUpdate - Begin");
            int result;
            try
            {
                result = objDbConnection.Database.ExecuteSqlCommand("SP_INSERTORUPDATESTUDENT @STUDENTID,@NAME,@DATEOFBIRTH,@UNIVERSITYCOURSE,@STARTDATE,@ENDDATE,@WELSHLANGUAGEPROFICIENCY",
                    new SqlParameter("STUDENTID", objStudentDto.studentId),
                    new SqlParameter("NAME", objStudentDto.name),
                    new SqlParameter("DATEOFBIRTH", objStudentDto.dateOfBirth),
                    new SqlParameter("UNIVERSITYCOURSE", objStudentDto.universityCourse),
                    new SqlParameter("STARTDATE", objStudentDto.startDate),
                    new SqlParameter("ENDDATE", objStudentDto.endDate),
                    new SqlParameter("WELSHLANGUAGEPROFICIENCY", objStudentDto.welshLanguageProficiency));
            }
            catch (Exception ex)
            {
                objdaoLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "InsertOrUpdate - Error", ex);

                throw ex;
            }
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "InsertOrUpdate - End");
            return result;
        }
        #endregion

        #region Delete
        /// <summary>
        /// This is for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public int Delete(int id)
        {
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "Delete - Begin");
            int result;
            try
            {
                result = objDbConnection.Database.ExecuteSqlCommand("SP_DeleteStudent @StudentId",
                new SqlParameter("StudentId", id));
            }
            catch (Exception ex)
            {
                objdaoLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "Delete - Error", ex);
                throw ex;
            }
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "Delete - End");
            return result;
        }
        #endregion

        #region GetStudents
        /// <summary>
        /// This is for GetStudents
        /// </summary>
        /// <returns>List</returns>
        public List<StudentDto> GetStudents()
        {
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetStudents - Begin");
            List<StudentDto> lstStudentDto = new List<StudentDto>();
            try
            {
                lstStudentDto = objDbConnection.Database.SqlQuery<StudentDto>("SP_GetStudentInfo").ToList();
            }
            catch(Exception ex)
            {
                objdaoLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "GetStudents - Error", ex);
                return null;
            }
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetStudents - End");
            return lstStudentDto;
        }
        #endregion

        #region GetProductById
        /// <summary>
        /// This is for Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductDto</returns>
        public StudentDto GetById(int id)
        {
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetById - Begin");
            StudentDto objProductDto = null;
            if (id > 0)
            {
                 objProductDto = objDbConnection.Database.SqlQuery<StudentDto>("SP_GetStudentById @Studentid",
                 new SqlParameter("Studentid", id)).FirstOrDefault();
            }
            objdaoLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetById - End");
            return objProductDto;
        }
        #endregion

    }
}
