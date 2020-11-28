using Util;

namespace Hero.Class
{
    public class ClassResource: Resource<Class>
    {
        private const string RepositoryPath = "Assets/Resources/Data/Hero/Class";
        
        private static ClassResource _instance;

        private ClassResource()
        {
        }

        public static ClassResource GetInstance() => _instance ?? (_instance = new ClassResource());

        public Class[] Get()
        {
            return base.Get<Class[]>($"{RepositoryPath}/class.json");
        }

        public Class GetClassFrom(string heroName)
        {
            return base.Get($"{RepositoryPath}/{heroName.ToLower()}.json");
        }

        public void Save(string heroName, Class data)
        {
            base.Save($"{RepositoryPath}/{heroName.ToLower()}.json", data);
        }
    }
}