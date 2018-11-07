namespace GildedRose
{
    using System.Collections.Generic;

    public class GildedRose
    {
        private readonly Strategy _strategy;

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> Items)
        {
            this._items = Items;

            _strategy = new Strategy();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                _strategy.GetStrategy(item.Name).UpdateQuality(item);
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}