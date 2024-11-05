namespace template.api.postgres.common
{
    public class Enumerator
    {
        public enum typeUser
        {
            AzureAd = 0,
            GCP = 1,
            SSO = 2,
        }

        public enum State
        {
            Success = 1,
            Error = 2,
            Warning = 3,
            Completed = 4,
            Found = 5,
        }

        public enum typeVerb
        {
            Created = 1,
            Update = 2,
            Select = 3,
            Delete = 4
        }

    }
}
