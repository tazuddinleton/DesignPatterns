public class Book 
{
    public Book(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public string Isbn { get; set; }
    public Guid? CategoryId { get; set; }
}


