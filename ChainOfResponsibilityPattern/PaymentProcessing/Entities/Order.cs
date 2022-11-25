namespace ChainOfResponsibilityPattern.PaymentProcessing;


public class Order {
    private event Action _onPaymentConfirmed;
    private event Action _onPaymentCanceled;

    public LineItems LineItems { get; }
    // public SelectedPayments SelectedPayments { get; }
    public decimal TotalPaid { get; }
    public decimal AmountDue { get; }
    // public ShipmentStatus ShipmentStatus { get; }


    public Order() {
        LineItems = new LineItems();
        // LineItems.OnItemAdded(UpdateShipmentStatus);
        // LineItems.OnItemRemoved(UpdateShipmentStatus);

        // _onPaymentConfirmed += UpdateShipmentStatus;
        // _onPaymentCanceled += UpdateShipmentStatus;
    }

}
