using Util;

namespace Hero.Status
{
    public class StatusResource: Resource<Status>
    {
        private static StatusResource _statusResource;
        private const string RepositoryPath = "Assets/Resources/Data/Hero/Status";

        private StatusResource()
        {
        }
        
        public static StatusResource GetInstance() => _statusResource ?? (_statusResource = new StatusResource());
        
        public Status GetStatusFrom(string heroName)
        {
            return Get($"{RepositoryPath}/{heroName.ToLower()}.json");
        }

        public void Save(string heroName, Status status)
        {
            base.Save($"{RepositoryPath}/{heroName}.json", status);
        }
    }
}