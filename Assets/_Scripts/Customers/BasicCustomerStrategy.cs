using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventBus;

public class BasicCustomerStrategy : CustomerBehaviour
{
    public Dictionary<string, ShopManager.ProductHolder> activeProductsDict { get; set; }
    public BasicCustomerStrategy(Dictionary<string, ShopManager.ProductHolder> activeProductsDict)
    {
        this.activeProductsDict = activeProductsDict;
    }
    
    public void Buy()
    {
        //Calculate the total value of all active products
        int totalValue = 0;
        foreach (var productHolder in activeProductsDict)
        {
            //Loop over the products in the product holder and add their value to the total value
            foreach (var product in productHolder.Value.products)
            {
                totalValue += product.productInfo.productValue;
            }
        }
        
        //Add the total value to the shop's money
        EventBus<ChangeMoneyEvent>.Raise(new ChangeMoneyEvent(totalValue, true));
    }
}
