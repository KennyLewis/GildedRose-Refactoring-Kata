using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenBackstagePass
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
            _item = GetBackstagePass();
            _items.Add(_item);
        }

        public GildedRoseUpdateQualityGivenBackstagePass()
        {
            _service = new GildedRose(_items);
            _item = GetBackstagePass();
            _items.Add(_item);
        }

        private Item GetBackstagePass()
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Test]
        public void IncreasesBackstagePassQualityBy1GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY + 1, Is.EqualTo(_item.Quality));
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void IncreasesBackstagePassQualityBy2GivenPositiveSellInBetween5And10(int sellIn)
        {
            _item.SellIn = sellIn;
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY + 2, Is.EqualTo(_item.Quality));
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void IncreasesBackstagePassQualityBy3GivenPositiveSellInBetween1And5(int sellIn)
        {
            _item.SellIn = sellIn;
            _service.UpdateQuality();

            Assert.That(INITIAL_QUALITY + 3, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void SetBackstagePassQualityTo0GivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.That(0, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void DoesNotIncreaseQualityBeyond50()
        {
            _item.Quality = 50;
            _service.UpdateQuality();

            Assert.That(50, Is.EqualTo(_item.Quality));
        }

        [TestCase(49)]
        [TestCase(50)]
        public void DoesNotIncreaseQualityAbove50GivenNonPositiveSellIn(int initialQuality)
        {
            _item.SellIn = INITIAL_SELL_IN;
            _item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.That(50, Is.EqualTo(_item.Quality));
        }

        [Test]
        public void ReducesBackstagePassSellInBy1()
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
