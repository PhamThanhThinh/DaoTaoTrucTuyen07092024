//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Code { get; set; }
        public string QuestionList { get; set; }
        public string AnswerList { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<short> TotalScore { get; set; }
        public Nullable<short> Time { get; set; }
        public Nullable<short> TotalQuestion { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string QuestionEssay { get; set; }
        public string UserList { get; set; }
        public string SoreList { get; set; }
    }
}
