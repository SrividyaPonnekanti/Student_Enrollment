using System;


namespace ModelLib
{
    public class StudentDto
    {
        public long studentId { get; set; }
        public string name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string universityCourse { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int welshLanguageProficiency { get; set; }
    }
}
