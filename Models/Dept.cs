using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCore2.Models
{
    [Table("DeptTbl")]
    public class Dept //Depts
    {
        [Key]
        public Int64 DID { get; set; }
        public string DeptName { get; set; }
        public virtual List<Emp>  Emps { get; set; }
    }
}
