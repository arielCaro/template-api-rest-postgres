namespace template_api_rest_postgres.Dto
{
    public class RoleDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public bool Active { get; set; }
    }
}
