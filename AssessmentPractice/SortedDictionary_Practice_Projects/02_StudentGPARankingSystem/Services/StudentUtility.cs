using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class StudentUtility
    {
        private SortedDictionary<double, List<Student>> _data = new SortedDictionary<double, List<Student>>();

        public void AddStudent(Student student)
        {
            if (student.GPA < 0 || student.GPA > 10)
            {
                throw new InvalidGPAException("GPA must be between 0 and 10");
            }

            foreach (var list in _data.Values)
            {
                if (list.Any(s => s.Id == student.Id))
                {
                    throw new DuplicateStudentException("Duplicate student");
                }
            }

            if (!_data.ContainsKey(student.GPA))
            {
                _data[student.GPA] = new List<Student>();
            }
            else
            {
                _data[student.GPA].Add(student);
            }
        }

        public void UpdateGPA(string id, double newGpa)
        {
            if (newGpa < 0 || newGpa > 10)
            {
                throw new InvalidGPAException("Invalid GPA");
            }

            Student? target = null;
            double oldKey = 0;

            foreach (var i in _data)
            {
                target = i.Value.FirstOrDefault(s => s.Id == id);
                if (target != null)
                {
                    oldKey = i.Key;
                    break;
                }
            }

            if (target == null)
            {
                throw new StudentNotFoundException("Student not found");
            }

            _data[oldKey].Remove(target);

            if (_data[oldKey].Count == 0)
            {
                _data.Remove(oldKey);
            }

            target.GPA = newGpa;

            if (!_data.ContainsKey(newGpa))
            {
                _data[newGpa] = new List<Student>();
            }

            _data[newGpa].Add(target);
        }

        public void DisplayRanking()
        {
            foreach (var i in _data.Reverse())
            {
                foreach (var j in i.Value)
                {
                    Console.WriteLine($"{i.Key} {j.Id} {j.Name}");
                }
            }
        }
    }
}