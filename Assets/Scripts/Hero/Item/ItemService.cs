using System.Linq;
using Battle;
using BusinessException;

namespace Hero.Item
{
    public class ItemService
    {
        private static ItemService _itemService;
        private readonly ItemResource ItemResource;

        private ItemService()
        {
            ItemResource = ItemResource.GetInstance();
        }

        public static ItemService GetInstance() => _itemService ?? (_itemService = new ItemService());

        private static bool CanBeUsedBy(HeroBattle hero, Item item)
        {
            return item.usedBy.Any(usedBy => usedBy.Equals(hero.Class.name));
        }

        public Item[] Get()
        {
            return ItemResource.Get();
        }

        public Item[] GetInventoryFrom(string heroName)
        {
            return ItemResource.GetInventoryFrom(heroName);
        }
        
        public void AddToInventory(HeroBattle hero, string itemName)
        {
            if (itemName == null)
            {
                throw new CannotUseNullAsAnItemException();
            }

            var item = ItemResource.GetItemByName(itemName);

            if (item == null)
            {
                throw new CannotFindItemException(itemName);
            }

            if (!CanBeUsedBy(hero, item))
            {
                throw new ItemCannotBeUsedByThisClassException();
            }

            var inventory = hero.Inventory.ToList();
            inventory.Add(item);
            hero.Inventory = inventory.ToArray();
            Save(hero.Name, hero.Inventory);
        }

        private void Save(string heroName, Item[] inventory)
        {
            ItemResource.Save(heroName, inventory);
        }
    }
}