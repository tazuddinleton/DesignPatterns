using System.Collections;

namespace ChainOfResponsibilityPattern.PaymentProcessing;

public class LineItems : IEnumerable<LineItem> {
    private List<LineItem> _lineItems;
    private event Action _onItemAdded;
    private event Action _onItemRemoved;
    public LineItems() {
        _lineItems = new List<LineItem>();        
        // To prevent null reference exception add to empty action
        _onItemAdded += () => {};
        _onItemRemoved += () => {};
    }

    public void Add(Item item, int qty) {
        var exists = Find(item);
        if (exists == null) {
            _lineItems.Add(new LineItem(item, qty));
            _onItemAdded.Invoke();
        }
    }

    private LineItem? Find(Item item) => _lineItems.Find(x => x.item == item);
    public void Remove(Item item) {
        var lItem = Find(item);
        if (lItem != null) {
            this._lineItems.Remove(lItem);
            _onItemRemoved.Invoke();
        }        
    }

    public decimal TotalPrice() {
        return _lineItems.Sum(li => li.item.price * li.quantity);
    }

    public void OnItemAdded(Action action) {
        _onItemAdded += action;
    }
    public void OnItemRemoved(Action action) {
        _onItemRemoved += action;
    }

    public IEnumerator<LineItem> GetEnumerator() {
        return _lineItems.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return this.GetEnumerator();
    }
}
