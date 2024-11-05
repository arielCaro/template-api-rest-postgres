namespace template_api_rest_postgres.Dto
{
    public class CompanyDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int ContactPhone { get; set; }

        public bool Active { get; set; }

        public DateOnly DateCreated { get; set; }

        public DateOnly DateModified { get; set; }

        public string UserCreated { get; set; } = null!;

        public string UserModifield { get; set; } = null!;
    }
}
