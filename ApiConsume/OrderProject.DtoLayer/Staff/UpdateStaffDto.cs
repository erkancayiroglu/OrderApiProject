using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.Staff
{
    public class UpdateStaffDto
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffPosition { get; set; }
        public string StaffImage { get; set; }

        public string SocialMedia1 { get; set; }
    }
}
