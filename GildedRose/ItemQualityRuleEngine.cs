﻿using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Rules;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class ItemQualityRuleEngine
    {
        private List<RuleBase> _rules = new List<RuleBase>();
        private ItemQualityRuleEngine(List<RuleBase> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
        }

        public class Builder
        {
            private List<RuleBase> _builderRules = new List<RuleBase>();

            public Builder WithAgedBrieRule()
            {
                _builderRules.Add(new AgedBrieRule());
                return this;
            }

            public Builder WithSulfurasRule()
            {
                _builderRules.Add(new SulfurasRule());
                return this;
            }

            public Builder WithBackstagePassRule()
            {
                _builderRules.Add(new BackstagePassRule());
                return this;
            }

            public Builder WithConjuredItemRule()
            {
                _builderRules.Add(new  ConjuredItemRule());
                return this;
            }

            public ItemQualityRuleEngine Build()
            {
                // every engine has a normal item rule, make sure this is the last option
                _builderRules.Add(new NormalItemRule());

                return new ItemQualityRuleEngine(_builderRules);
            }
        }
    }
}