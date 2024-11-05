using System.Numerics;

namespace template_api_rest_postgres.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; } 

        public string Email { get; set; }

        public bool Active { get; set; }

        public DateOnly DateCreated { get; set; }

        public DateOnly DateModified { get; set; }

        public string UserCreated { get; set; }

        public string UserModified { get; set; }

        public long IdCompany { get; set; }
        public long IdRole { get; set; }

        public string SecurityStamp { get; set; }

        public string CodePhoneCountry { get; set; }

        public int Phone {  get; set; }

        public int PhoneMobile { get; set; }

        public RoleDto Role {  get; set; }
        public CompanyDto Company {  get; set; } 

    }
}
