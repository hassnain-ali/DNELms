using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace DNELms.Keys
{
    public enum AspNetUserRoles
    {
        [Display(Name = "Administrator")]
        Admin = 0,

        [Display(Name = "Student")]
        Student = 1,

        [Display(Name = "Student")]
        Instructor = 2,
        [Display(Name = "Student")]
        Employee = 3,

        [Display(Name = "School Owner")]
        School_Owner = 4,

        [Display(Name = "School Student")]
        School_Student = 5,

        [Display(Name = "School Instructor")]
        School_Instructor = 6,

        [Display(Name = "School Employee")]
        School_Employee = 7
    }
}
