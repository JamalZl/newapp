using ConsoleAppProject_Course_.Enums;
using ConsoleAppProject_Course_.Interfaces;
using ConsoleAppProject_Course_.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject_Course_.Services
{
    class CourseService : ICourseService
    {
        private List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;

        private List<Student> _students = new List<Student>();
        public List<Student> Students => _students;

        public string CreateGroup(ClassCategory category)
        {
            Group group = new Group(category);
            _groups.Add(group);
            return group.No;

        }

        public string CreateStudent(string fullname, EducationType edutype,Group groupno)
        {
            Student student = new Student(fullname, edutype,groupno);
            _students.Add(student);
            return $"{student.FullName} {edutype} {groupno}";
        }

        public void EditGroups(string No, string newNo)
        {
            Group excitedgroup = null;
            foreach (Group group in _groups)
            {
                if (group.No.ToLower().Trim() == No.ToLower().Trim())
                {
                    excitedgroup = group;
                    break;
                }
            }
            if (excitedgroup == null)
            {
                Console.WriteLine($"{No} group doesn't existed");
                return;
            }
            foreach (Group group in _groups)
            {
                if (newNo.ToLower().Trim() == group.No.ToLower().Trim())
                {
                    Console.WriteLine($"{newNo} has already existed");
                    return;
                }
            }
            excitedgroup.No = newNo.ToUpper();
            Console.WriteLine($"{No} succesfully updated to {newNo}");
        }
        public void GetGroupStudent(string no)
        {
            Group group = _groups.Find(g => g.No.ToLower().Trim() == no.ToLower().Trim());
            if (group == null)
            {
                Console.WriteLine($"{no} group doesnt existed");
                return;
            }
            foreach (var stud in group.students)
            {
                Console.WriteLine(stud);
            }
        }

        internal string CreateStudent(EducationType guarranted)
        {
            throw new NotImplementedException();
        }

        public void GetGroups()
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("There is no group ");
                return;
            }
            foreach (Group group in _groups)
            {
                Console.WriteLine(group);
            }
        }
        public void GetAllStdents()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("There is no student");
            }
            foreach (Student student in _students)
            {
                Console.WriteLine(student);
            }
        }
    }
}