
using ChainOfResponsibilityPattern.PaymentProcessing;
using Xunit;

namespace ChainOfResponsibilityPattern.Test;

public class LineItemsTest
{

    [Fact]
    public void ShouldBeAbleToCreateLineItemWithItem() {

        var lineItems = new LineItems();
        lineItems.Add(new Item("Test item", "Test Item", 10), 10);
        Assert.NotNull(lineItems);
        Assert.Equal(100, lineItems.TotalPrice());
    }

    [Fact]
    public void ShouldCalculateTotalPriceWhenLineItemsAddedAndRemoved() {

        var lineItems = new LineItems();
        lineItems.Add(new Item("Test item", "Test Item", 10), 10);
        lineItems.Add(new Item("Test item 2", "Test Item", 10), 10);
        Assert.Equal(200, lineItems.TotalPrice());
        lineItems.Remove(new Item("Test item", "Test Item", 10));
        Assert.Equal(100, lineItems.TotalPrice());
    }
    [Fact]
    public void ShouldAddLineItem()
    {

        var isAdded = false;
        var lineItems = new LineItems();
        lineItems.OnItemAdded(() => isAdded = true);

        lineItems.Add(new Item("Test item", "Test Item", 10), 10);
        Assert.NotNull(lineItems);
        Assert.True(isAdded);        
    }
    
    [Fact]
    public void ShouldRemoveLineItem()
    {
        var isRemoved = false;
        var lineItems = new LineItems();
        lineItems.OnItemRemoved(() => isRemoved = true);

        lineItems.Add(new Item("Test item", "Test Item", 10), 10);
        Assert.NotNull(lineItems);
        Assert.Equal(100, lineItems.TotalPrice());
        lineItems.Remove(new Item("Test item", "Test Item", 10));
        Assert.True(isRemoved);        
    }

}