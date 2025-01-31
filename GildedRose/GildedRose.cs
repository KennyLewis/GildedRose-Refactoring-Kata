﻿using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality(ItemProxy item)
    {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.DecrementQuality();
            }
        }
        else
        {
            item.IncrementQuality();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    item.IncrementQuality();
                }

                if (item.SellIn < 6)
                {
                    item.IncrementQuality();
                }
            }

        }

        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.DecrementSellIn();
        }

        if (item.SellIn < 0)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.DecrementQuality();
                    }
                }
                else
                {
                    item.ResetQuality();
                }
            }
            else
            {
                item.IncrementQuality();
            }
        }
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateQuality(new ItemProxy(Items[i]));
        }
    }
}