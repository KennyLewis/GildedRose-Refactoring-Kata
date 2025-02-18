using System.Collections.Generic;
using DesignPatternsInCSharp.KataWithPatterns;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateSulfuras(ItemProxy item)
    {
        // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    }

    public void UpdateAgedBrie(ItemProxy item)
    {
        item.IncrementQuality();
        item.DecrementSellIn();

        // "Aged Brie" actually increases in Quality the older it gets
        if (item.SellIn < 0)
        {
            item.IncrementQuality();
        }
    }

    public void UpdateBackstagePasses(ItemProxy item)
    {
        // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches
        item.IncrementQuality();

        // Quality increases by 2 when there are 10 days or less
        if (item.SellIn <= 10)
        {
            item.IncrementQuality();
        }

        // Quality increases by 3 when there are 5 days or less
        if (item.SellIn <= 5)
        {
            item.IncrementQuality();
        }

        item.DecrementSellIn();

        // but Quality drops to 0 after the concert
        if (item.SellIn < 0)
        {
            item.ResetQuality();
        }
    }

    public void UpdateConjuredItem(ItemProxy item)
    {
        // "Conjured" items degrade in Quality twice as fast as normal items
        item.DecrementQuality();
        item.DecrementQuality();

        item.DecrementSellIn();

        // Once the sell by date has passed, Quality degrades twice as fast
        if (item.SellIn < 0)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }
    }

    public void UpdateNormalItem(ItemProxy item)
    {
        item.DecrementQuality();
        item.DecrementSellIn();

        // Once the sell by date has passed, Quality degrades twice as fast
        if (item.SellIn < 0)
        {
            item.DecrementQuality();
        }
    }

    //public void UpdateQuality(ItemProxy item)
    //{
    //    switch (item.Name)
    //    {
    //        case "Aged Brie":
    //            UpdateAgedBrie(item);
    //            break;
    //        case "Backstage passes to a TAFKAL80ETC concert":
    //            UpdateBackstagePasses(item);
    //            break;
    //        case "Sulfuras, Hand of Ragnaros":
    //            UpdateSulfuras(item);
    //            break;
    //        case "Conjured Mana Cake":
    //            UpdateConjuredItem(item);
    //            break;
    //        default:
    //            UpdateNormalItem(item);
    //            break;
    //    }
    //}

    public void UpdateQuality(ItemProxy item)
    {
        var ruleEngine = new ItemQualityRuleEngine
            .Builder()
            .WithAgedBrieRule()
            .Build();
        ruleEngine.ApplyRules(item);
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateQuality(new ItemProxy(Items[i]));
        }
    }
}