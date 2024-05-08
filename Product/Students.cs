using System;
using ModelLib;
using System.Collections.Generic;
using InterfaceLib;
using UntityProvider;
using InventoryUtilits;

namespace Product
{
    public class Students : IStudents
    {
        #region Global variable
        LogHelpers objStudentsLoggingHelpers = new LogHelpers();
        string className = "Students";
        IStudentDao objIStudentDao = null;
        UnitityFramework objUnitityFramework = new UnitityFramework();
        #endregion

        #region InsertandUpdate
        /// <summary>
        /// This is for InsertandUpdate
        /// </summary>
        /// <param name="objStudentDto"></param>
        /// <returns>int</returns>
        public int InsertOrUpdate(StudentDto objStudentDto)
        {
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "InsertOrUpdate - Begin");
            int result;
            try
            {
                 objIStudentDao = objUnitityFramework.GetProvider<IStudentDao>("IStudentDao");
                 result = objIStudentDao.InsertOrUpdate(objStudentDto);
            }
            catch (Exception ex)
            {
                objStudentsLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "InsertOrUpdate - Error", ex);
                throw ex;
            }
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "InsertOrUpdate - End");
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
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "Delete - Begin");

            int result;
            try
            {
                objIStudentDao = objUnitityFramework.GetProvider<IStudentDao>("IStudentDao");
                result = objIStudentDao.Delete(id);
            }
            catch (Exception ex)
            {
                objStudentsLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "Delete - Error", ex);

                throw ex;
            }
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "Delete - End");

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
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetStudents - Begin");
            List<StudentDto> lstStudentDto = new List<StudentDto>();
            try
            {
                objIStudentDao = objUnitityFramework.GetProvider<IStudentDao>("IStudentDao");
                lstStudentDto = objIStudentDao.GetStudents();
            }
            catch (Exception ex)
            {
                objStudentsLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "GetStudents - Error", ex);
                throw ex;
            }
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetStudents - End");
            return lstStudentDto;
        }
        #endregion

        #region GetStudentById
        /// <summary>
        /// This is for GetStudentById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        public StudentDto GetById(int id)
        {
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetById - Begin");
            StudentDto objStudentDto = new StudentDto();
            try
            {

                objIStudentDao = objUnitityFramework.GetProvider<IStudentDao>("IStudentDao");
                objStudentDto = objIStudentDao.GetById(id);
            }
            catch (Exception ex)
            {
                objStudentsLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "GetById - Error", ex);
                throw ex;
            }
            objStudentsLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetById - End");
            return objStudentDto;
        }
        #endregion
    }
}
