using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyMvcDemoApp.Models;
using SecurityApplicationData.ModelData;

namespace SecurityApplicationData
{
    public class SecurityPersonnelService
    {
        public long AddNewSecurityPersonel(SecurityPersonnelDetail securityPerson)
        {
            using (var context = new SecurityDepartmentEntities())
            {
                context.SecurityPersonnelDetails.Add(securityPerson);
                context.SaveChanges();
                return securityPerson.SecurityPersonnelID;
            }
        }

        public List<SecurityDepartmentDetail> GetDepartments()
        {
            using (var context = new SecurityDepartmentEntities())
            {
                var depts = context.SecurityDepartmentDetails.ToList();
                return depts;
            }
        }

        public SecurityPersonnelDetail GetSecurityDetails(long id)
        {
            using (var context = new SecurityDepartmentEntities())
            {
                var details = context.SecurityPersonnelDetails.SingleOrDefault(x=>x.SecurityPersonnelID==id);
                if (details == null) return null;
                details.SecurityDepartmentDetail =
                    context.SecurityDepartmentDetails.FirstOrDefault(x => x.SecurityDepartmentID == details.SecurityDepartmentID);
                return details;
            }
        }
    }
}
