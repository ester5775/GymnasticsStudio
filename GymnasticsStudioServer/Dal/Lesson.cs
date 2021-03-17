//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lesson
    {
        public Lesson()
        {
            this.Attendances = new HashSet<Attendance>();
            this.StudentInLessons = new HashSet<StudentInLesson>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public string Day { get; set; }
        public string StartHower { get; set; }
        public string FinishHower { get; set; }
        public Nullable<int> MaxStudensNum { get; set; }
        public Nullable<int> MaxSerologersStudensNum { get; set; }
    
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual Teacher1 Teacher1 { get; set; }
        public virtual ICollection<StudentInLesson> StudentInLessons { get; set; }
    }
}