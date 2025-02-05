using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenSulfuras
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
            _item = GetSulfuras();
            _items.Add(_item);
        }

        public GildedRoseUpdateQualityGivenSulfuras()
        {
            _service = new GildedRose(_items);
            _item = GetSulfuras();
            _items.Add(_item);
        }

        private Item GetSulfuras()
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Test]
        public void DoesNotReduceQuality()
        {
            _service.UpdateQuality();

            Assert.That(INITIAL_SELL_IN, Is.EqualTo(_item.SellIn));
        }

        [Test]
        public void DoesNotReduceSellIn()
        {
            _service.UpdateQuality();

            Assert.That(INITIAL_SELL_IN, Is.EqualTo(_item.SellIn));
        }
    }
}
