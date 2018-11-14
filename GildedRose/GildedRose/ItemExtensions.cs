namespace GildedRose
{
    public static class ItemExtensions
    {
        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        public static void DecrementSellIn(this Item item)
        {
            item.SellIn--;
        }

        public static void DecrementQuality(this Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}