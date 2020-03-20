using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        // logic goes here 
                        break;
                    
                    case "Backstage passes to a TAFKAL80ETC concert":
                        //logic goes here
                        break;
                    
                    case "Sulfuras, Hand of Ragnaros":
                        // logic goes here 
                        break;
                    
                    case "Conjured Mana Cake":
                        //logic goes here 
                        break; 
                    
                    default:
                        // logic goes here ;
                        break;
                }
            }
        }
    }
}