using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenAgedBrie
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
            _item = GetAgedBrie();
            _items.Add(_item);
        }

        public GildedRoseUpdateQualityGivenAgedBrie()
        {
            _service = new GildedRose(_items);
            _item = GetAgedBrie();
            _items.Add(_item);
        }

        private Item GetAgedBrie()
        {
            return new Item { Name = "Aged Brie", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Test]
        public void IncreasesAgedBrieQualityBy1GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY + 1, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void IncreasesAgedBrieQualityBy2GivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY + 2, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void DoesNotIncreaseQualityBeyond50()
        {
            _item.Quality = 50;
            _service.UpdateQuality();

            Assert.That(50, Is.EqualTo(_item.Quality));
        }

        [TestCase(48)]
        [TestCase(49)]
        [TestCase(50)]
        public void DoesNotIncreaseQualityAbove50GivenNonPositiveSellIn(int initialQuality)
        {
            _item.SellIn = 0;
            _item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.That(50, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void ReducesAgedBrieSellInBy1()
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
