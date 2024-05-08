using InterfaceLib;
using InventoryUtilits;
using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using UntityProvider;
using System.Net.Mail;
using System.Collections;

namespace Inventory.Controllers
{
    [RoutePrefix("api/entrollment")]
    public class EntrollmentController : ApiController
    {
        #region Global variable
        LogHelpers objLoggingHelpers = new LogHelpers();
        string className = "EntrollmentController";
        IStudents objIStudents = null;
        UnitityFramework objUnitityFramework = new UnitityFramework();
        #endregion

        #region InsertandUpdate
        /// <summary>
        /// This for InsertandUpdate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objStudentDto"></param>
        /// <returns>string</returns>
        [HttpPost]
        [Route("insertorupdate")]
        public string InsertOrUpdate(long id, StudentDto objStudentDto)
        {
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "InsertOrUpdate - Begin");
            string strMsg = string.Empty;
            try
            {
                objIStudents = objUnitityFramework.GetProvider<IStudents>("IStudents");
                int result = objIStudents.InsertOrUpdate(objStudentDto);
                strMsg = (result > 0) ? "Save record successfully." : "save record failed.";
            }
            catch (Exception ex)
            {
                objLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "InsertOrUpdate - Error", ex);
                strMsg = ex.Message;
            }
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "InsertOrUpdate - End");

            return strMsg;
        }
        #endregion

        #region Delete
        /// <summary>
        /// This is for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete]
        [Route("delete")]
        public string Delete(int id)
        {
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "Delete - Begin");
            string strMsg = string.Empty;
            try
            {
                objIStudents = objUnitityFramework.GetProvider<IStudents>("IStudents");
                int result = objIStudents.Delete(id);
                strMsg = (result > 0) ? "Record deleted successfully" : "Delete record failed";
            }
            catch (Exception ex)
            {
                objLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "Delete - Error", ex);
                strMsg = ex.Message;
            }
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "Delete - End");
            return strMsg;
        }
        #endregion

        #region GetStudents
        /// <summary>
        /// this is for GetStudents
        /// </summary>
        /// <returns>List<StudentDto></returns>
        [HttpGet]
        [Route("get")]
        public List<StudentDto> GetStudents()
        {
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetStudents - Begin");
            List<StudentDto> lstStudentDto = null;
            try
            {
                objIStudents = objUnitityFramework.GetProvider<IStudents>("IStudents");
                lstStudentDto = objIStudents.GetStudents();
                if (lstStudentDto != null && lstStudentDto.Count > 0)
                {
                    lstStudentDto = lstStudentDto.OrderBy(o => o.studentId).ToList();
                }
            }
            catch (Exception ex)
            {
                objLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "GetStudents - Error", ex);
            }
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetStudents - End");

            return lstStudentDto;
        }
        #endregion

        #region GetStudentById
        /// <summary>
        /// This is for GetStudentById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        [HttpGet]
        [Route("getbyid")]
        public StudentDto GetById(int id)
        {
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetById - Begin");
            StudentDto objStudentDto = null;
            try
            {
                objIStudents = objUnitityFramework.GetProvider<IStudents>("IStudents");
                if (id > 0)
                {
                    objStudentDto = objIStudents.GetById(id);
                }
            }
            catch (Exception ex)
            {
                objLoggingHelpers.Log(LoggingLevels.Error, "class :: " + className + "GetById - Error", ex);
            }
            objLoggingHelpers.Log(LoggingLevels.Info, "class :: " + className + "GetById - End");
            return objStudentDto;
        }
        #endregion

    }
}
