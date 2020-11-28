using System.Linq;
using BusinessException;
using Util;

namespace Hero.Item
{
    public class ItemResource: Resource<ItemContainer>
    {
        private static ItemResource _instance;

        private const string REPOSITORY_PATH = "Assets/Resources/Data/Hero/Item"; 
        
        private ItemResource()
        {
        }

        public static ItemResource GetInstance() => _instance ?? (_instance = new ItemResource());

        public Item[] Get()
        {
            var container = Get($"{REPOSITORY_PATH}/item.json");
            return container?.items;
        }
        public Item[] GetInventoryFrom(string playerName)
        {
            var container = Get($"{REPOSITORY_PATH}/{playerName.ToLower()}.json");
            return container?.items;
        }

        public Item GetItemByName(string itemName)
        {
            var items = Get();
            return (items ?? throw new CannotLoadItemException(itemName))
                .FirstOrDefault(item => item.name?.ToLower().Equals(itemName?.ToLower()) != null);
        }

        public void Save(string heroName, Item[] inventory)
        {
            base.Save(heroName, new ItemContainer(){items = inventory});
        }
    }
}