namespace Builder.Test;

public class GenericBuilderTest
{
    [Fact]
    public void Test1()
    {

        const string isbn = "Test_ISBN";
        
        var bookBuilder = new BookBuilder().With("new book") as Builder<Book>;
        var book = bookBuilder.With(b => b.Isbn, b =>
        {
            return isbn;
        }).Build();
    
    
        Assert.NotNull(bookBuilder);
        Assert.Equal("new book", book.Title);
        Assert.Equal(isbn, book.Isbn);

    }
}


    
    
    
public interface IBookWithRequiredProperties
{
    IBuildable<Book> With(string title);
}


public interface IBookFromExistingBook
{
    
    Builder<Book> With(Book book);
}



public class BookBuilder : IBookWithRequiredProperties, IBookFromExistingBook
{
    private Book _instance;
    public IBuildable<Book> With(string title)
    {
        this._instance = new Book(title);
        return Builder<Book>.GetBuilder(_instance);
    }

    public Builder<Book> With(Book book)
    {
        this._instance = book;
        return Builder<Book>.GetBuilder(this._instance);
    }
}