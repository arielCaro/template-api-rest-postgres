namespace template_api_rest_postgres.Dto
{
    public class SessionDto
    {
        public long Id { get; set; }
        public DateTime SessionOn { get; set; }
        public DateTime SessionOut { get; set; }
        public string TokenBearer { get; set; }
        public Boolean Active { get; set; }
        public long IdUser { get; set; }
        public int IdApp { get; set; }
    }
}
