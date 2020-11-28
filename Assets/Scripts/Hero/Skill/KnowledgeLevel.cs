namespace Hero.Skill
{
    public class KnowledgeLevel
    {
        private const string ASSIMILATE = "assimilate";
        private const string LEARN = "learn";
        
        public static readonly KnowledgeLevel Assimilate = new KnowledgeLevel(1, ASSIMILATE);
        public static readonly KnowledgeLevel Learn = new KnowledgeLevel(3, LEARN);

        public readonly int NecessaryPoints;
        public readonly string Name;
        
        private KnowledgeLevel(int necessaryPoints, string name)
        {
            NecessaryPoints = necessaryPoints;
            Name = name;
        }
    }
}