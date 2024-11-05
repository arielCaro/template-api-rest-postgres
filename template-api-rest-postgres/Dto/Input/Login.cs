namespace template_api_rest_postgres.Dto.Input
{
    public class Login
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string CodeVerficated { get; set; }
        public bool IsChangePassword { get; set; }
        public bool IsRecoveryoPassword { get; set; }

    }
}
