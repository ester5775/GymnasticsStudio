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
    
    public partial class StudentInLesson
    {
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> LessonId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
    
        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
    }
}
