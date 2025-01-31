using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemProxy
    {
        private readonly Item _item;

        public ItemProxy(Item item)
        {
            _item = item;
        }

        public string Name => _item.Name;
        public int SellIn => _item.SellIn;
        public int Quality => _item.Quality;

        public void IncrementQuality()
        {
            // The Quality of an item is never more than 50
            if (_item.Quality < 50)
            {
                _item.Quality++;
            }
        }

        public void DecrementQuality()
        {
            // The Quality of an item is never negative
            if (_item.Quality > 0)
            {
                _item.Quality--;
            }
        }

        public void ResetQuality()
        {
            _item.Quality = 0;
        }

        public void DecrementSellIn()
        {
            _item.SellIn--;
        }
    }
}
