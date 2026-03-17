using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebUI.Dtos.AdminUserDto
{
    public class ResultUsersDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }


        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }

        }
        public List<Order> Orders { get; set; }
    }
}
