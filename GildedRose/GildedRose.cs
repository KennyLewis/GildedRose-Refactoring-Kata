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

    public void UpdateQuality(ItemProxy item)
    {
        var ruleEngine = new ItemQualityRuleEngine
            .Builder()
            .WithAgedBrieRule()
            .WithSulfurasRule()
            .WithBackstagePassRule()
            .WithConjuredItemRule()
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