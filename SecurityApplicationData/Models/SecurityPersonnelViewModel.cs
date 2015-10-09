using System.ComponentModel;
using System.Web.Mvc;
using SecurityApplicationData.ModelData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMvcDemoApp.Models
{
    public class SecurityPersonnelViewModel
    {
        public long SecurityPersonnelID { get; set; }
        [DisplayName("Security Personnel Name: ")]
        [Required(ErrorMessage = "Name is required!")]
        public string SecurityPersonnelName { get; set; }
        [DisplayName("Security Personnel Age: ")]
        [Required(ErrorMessage = "Age is required!")]
        public short SecurityPersonnelAge { get; set; }

        [DisplayName("Security Personnel Address: ")]
        public string SecurityPersonnelAddress { get; set; }
        public SelectList SecurityDepartment { get; set; }
        [DisplayName("Security Personnel Department: ")]
        public SecurityDepartmentDetail DepartmentDetail { get; set; }
        public int SecurityDepartmentID { get; set; }
    }
}