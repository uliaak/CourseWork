using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Entities
{
    public class Assignment
    {
        #region Properties

        public int Time { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        #endregion

        #region Constructors 
        public Assignment() 
        {
            Status = Status.NotStarted;
        }    
        public Assignment ( int time, string name, string description, Priority priority)
        {
            Time = time;
            Name = name;
            Description = description;
            Status = Status.NotStarted;
            Priority = priority;
        }
        #endregion
    }
}
