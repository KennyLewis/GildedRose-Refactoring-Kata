using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenConjuredItem
    {
        private List<Item> _items = new List<Item>();
        private Item _item;
        private GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        [SetUp]
        public void Setup()
        {
            _items = new List<Item>();
            _service = new GildedRose(_items);
            _item = GetNormalItem();
            _items.Add(_item);
        }

        public GildedRoseUpdateQualityGivenConjuredItem()
        {
            _service = new GildedRose(_items);
            _item = GetNormalItem();
            _items.Add(_item);
        }

        private Item GetNormalItem()
        {
            return new Item { Name = "Conjured Mana Cake", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Test]
        public void DecreasesNormalItemQualityBy2GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY - 2, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void DecreasesNormalItemQualityBy4GivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY - 4, Is.EqualTo(_item.Quality));
        }

        [TestCase(1)]
        [TestCase(0)]
        public void DoesNotDecreaseQualityBelow0GivenNonPositiveSellIn(int initialQuality)
        {
            _item.SellIn = 0;
            _item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.That(0, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void ReducesNormalItemSellInBy1()
        {
            _service.UpdateQuality();

            Assert.That(INITIAL_SELL_IN - 1, Is.EqualTo(_item.SellIn));
        }

        [Test]
        public void DoesReduceSellInBelowZero()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.That(-1, Is.EqualTo(_item.SellIn));
        }
    }
}
