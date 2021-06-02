using System;
using System.Collections.Generic;
using System.Text;
using CourseWork.Entities.Exceptions;
using System.Linq;

namespace CourseWork.Entities
{
    public class Employee
    {
        private const int WeeklyCapacity = 40;
        #region Properties
        public string FullName
        {
            get => FirstName + " " + LastName;  
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ID { get; set; }

        public List<Assignment> Assignments = new List<Assignment>();

        public int Load
        {
            get
            {
                int Sum = 0;
                var uncompletedAssignments = from assignment in Assignments // LINQ to Objects
                                           where assignment.Status != Status.Done
                                           select assignment;
                foreach (var assignment in uncompletedAssignments)
                {
                    Sum += assignment.Time;
                }
                return Sum;
            }
        }
        public int Capacity => WeeklyCapacity - Load;
        #endregion

        #region Constructors
        public Employee() { }


        public Employee(string firstName, string lastName, Guid id)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
        }
        #endregion
       
        public void TakeAssignment(Assignment assignment)
        {
            if (assignment.Time <= Capacity)
            {
                Assignments.Add(assignment);
            }
            else
            {
                throw new EmployeeCapacityException("No capacity");
            }
        }


        
        public void CompleteWork(int hours)
        {
            if (hours <= 0)  
                return;
            var uncompletedAssignments = from assignment in Assignments // LINQ to Objects
                                         where assignment.Status != Status.Done
                                         orderby assignment.Status
                                         select assignment;
            foreach (var assignment in uncompletedAssignments)
            {
                assignment.Status = Status.InProgress;
                assignment.Time = assignment.Time - hours; 
                if(assignment.Time > 0)
                {
                    hours = 0;
                    break;
                }
                else
                {
                    hours = -1 * assignment.Time;
                    Assignments.FirstOrDefault(a => a.Equals(assignment)).Status = Status.Done;  
                } 
            }
        }
    }
}
