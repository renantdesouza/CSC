namespace Hero.Class
{
    public class ClassService
    {
        private static ClassService _itemService;
        private readonly ClassResource ClassResource;

        private ClassService()
        {
            ClassResource = ClassResource.GetInstance();
        }

        public static ClassService GetInstance() => _itemService ?? (_itemService = new ClassService());

        public Class[] Get()
        {
            return ClassResource.Get();
        }

        public Class GetClassFrom(string heroName)
        {
            return ClassResource.GetClassFrom(heroName);
        }

        public void Reinitialize()
        {

        }
    }
}