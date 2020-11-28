using Util;

namespace Hero.Level
{
    public class LevelResource: Resource<Level>
    {
        private static LevelResource _instance;
        
        private const string RepositoryPath = "Assets/Resources/Data/Hero/Level";

        private LevelResource()
        {
        }

        public static LevelResource GetInstance() => _instance ?? (_instance = new LevelResource());

        public Level GetLevelFrom(string heroName)
        {
            return Get($"{RepositoryPath}/{heroName.ToLower()}.json");
        }

        public void Save(string heroName, Level data)
        {
            base.Save($"{RepositoryPath}/{heroName.ToLower()}.json", data);
        }
    }
}