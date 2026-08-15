using Ex04.StudentManagement.Enums;

namespace Ex04.StudentManagement.Models;

public class Student
{
    public string StudentId { get; private set; }
    public string FullName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Major { get; private set; }
    public double GPA { get; private set; }
    public StudentStatus Status { get; private set; }

    public Student(
        string studentId,
        string fullName,
        DateTime dateOfBirth,
        Gender gender,
        string email,
        string phone,
        string major,
        double gpa,
        StudentStatus status)
    {
        StudentId = studentId.Trim();
        FullName = fullName.Trim();
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Email = email.Trim();
        Phone = phone.Trim();
        Major = major.Trim();
        GPA = gpa;
        Status = status;
    }

    public void Update(
        string fullName,
        DateTime dateOfBirth,
        Gender gender,
        string email,
        string phone,
        string major,
        double gpa,
        StudentStatus status)
    {
        FullName = fullName.Trim();
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Email = email.Trim();
        Phone = phone.Trim();
        Major = major.Trim();
        GPA = gpa;
        Status = status;
    }
}
