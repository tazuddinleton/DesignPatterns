namespace ChainOfResponsibilityPattern.PaymentProcessing;

public record class Item(string name, string description, decimal price);
public record class LineItem(Item item, int quantity);