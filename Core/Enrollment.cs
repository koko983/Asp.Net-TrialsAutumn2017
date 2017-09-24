using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }

        //navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
