using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DtoLayer.About
{
    public class CreateAboutDto
    {
        public string Title { get; set; }

        public int StaffCount { get; set; }

        public int CustomerCount { get; set; }

        public int RestourantCount { get; set; }

        public string MapLocation { get; set; }
    }
}
