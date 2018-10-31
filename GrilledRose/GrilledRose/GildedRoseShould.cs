namespace GildedRose
{
    using System.Collections.Generic;

    using NFluent;

    using NUnit.Framework;

    [TestFixture]
    public class GildedRoseShould
    {
        [Test]
        public void DexterityVest_degrade_quality_and_sellIn_by_after_one_day()
        {
            var sellIn = 10;
            var quality = 20;
            var regularItem = "+5 Dexterity Vest";
            var item = new Item { Name = regularItem, SellIn = sellIn, Quality = quality };

            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();

            Check.That(item.Quality).IsEqualTo(quality - 1);
            Check.That(item.SellIn).IsEqualTo(sellIn - 1);
        }

        [Test]
        public void aged_brie_passes_quality_increase_by_1_when_quality_less_than_50()
        {
            var sellIn = 2;
            var quality = 0;
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();
            Check.That(item.Quality).IsEqualTo(quality + 1);
        }

        [Test]
        public void BackstagePass_quality_increased_by_2_When_sellin_smaller__or_equals_to_10_and_quality_inferior_to_50()
        {
            var sellIn = 10;
            var quality = 20;
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();

            Check.That(item.Quality).IsEqualTo(quality + 2);
        }

        [Test]
        public void BackstagePass_quality_increased_by_3_When_sellin_smaller_or_equals_to_5_and_quality_inferior_to_50()
        {
            var sellIn = 5;
            var quality = 20;
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();

            Check.That(item.Quality).IsEqualTo(quality + 3);
        }

        [Test]
        public void Regular_product_Once_the_sell_by_date_has_passed_Quality_degrades_twice_as_fast()
        {
            var sellIn = 0;
            var quality = 20;
            var regularItem = "+5 Dexterity Vest";
            var item = new Item { Name = regularItem, SellIn = sellIn, Quality = quality };

            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();

            Check.That(item.Quality).IsEqualTo(quality - 2);
        }

        [Test]
        public void BackstagePass_quality__drop_to_0_after_the_concert()
        {
            var sellIn = 0;
            var quality = 20;
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();

            Check.That(item.Quality).IsEqualTo(0);
        }

        [Test]
        public void Age_brie_quality_increases_by_2_when_sellin_passes()
        {
            var sellIn = 0;
            var quality = 10;
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();
            Check.That(item.Quality).IsEqualTo(quality + 2);
        }

        [Test]
        public void Age_brie_quality_never_surpassed_50()
        {
            var sellIn = 0;
            var quality = 50;
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            var gildedRose = new GildedRose(new[] { item });
            gildedRose.UpdateQuality();
            var maxQuality = 50;
            Check.That(item.Quality).IsEqualTo(maxQuality);
        }
    }



    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                                                          new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                                          new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                                          new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                                          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                                          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                                                          new Item
                                                              {
                                                                  Name = "Backstage passes to a TAFKAL80ETC concert",
                                                                  SellIn = 15,
                                                                  Quality = 20
                                                              },
                                                          new Item
                                                              {
                                                                  Name = "Backstage passes to a TAFKAL80ETC concert",
                                                                  SellIn = 10,
                                                                  Quality = 49
                                                              },
                                                          new Item
                                                              {
                                                                  Name = "Backstage passes to a TAFKAL80ETC concert",
                                                                  SellIn = 5,
                                                                  Quality = 49
                                                              },
                                                          // this conjured item does not work properly yet
                                                          new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                                      };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                System.Console.WriteLine("");
                app.UpdateQuality();
            }

        }

    }


}