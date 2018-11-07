namespace GildedRose
{
    using System.Collections.Generic;

    internal class Strategy
    {
        private readonly Dictionary<string, IQualityUpdater> _strategies = new Dictionary<string, IQualityUpdater>()
        {
            ["Sulfuras, Hand of Ragnaros"] = new SulfurasQualityUpdater(),
            ["Aged Brie"] = new AgedBrieQualityUpdater(),
            ["Backstage passes to a TAFKAL80ETC concert"] = new BackstageQualityUpdater(),
        };

        public IQualityUpdater GetStrategy(string itemName)
        {
            if (_strategies.TryGetValue(itemName, out var updater))
            {
                return updater;
            }

            return new DefaultProductQualityUpdater();
        }
    }
}