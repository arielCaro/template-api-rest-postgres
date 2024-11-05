namespace template_api_rest_postgres.Dto.Output
{
    public class ResponseApi<T>
    {
        public string Message { get; set; }
        public T Entity { get; set; }
        public List<T> List { get; set; }
        public string State { get; set; }
        public Exception Ex { get; set; }

    }
}
