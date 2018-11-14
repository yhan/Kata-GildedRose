namespace GildedRose
{
    class BackstageQualityUpdater: IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.IncreaseQuality();
            if (item.SellIn < 11)
            {
                item.IncreaseQuality();
            }
            if (item.SellIn < 6)
            {
                item.IncreaseQuality();
            }
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}