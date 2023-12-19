namespace Adapter;

public class NewsFeedClient {

    public void GetFeed() {
        var http = new HttpClient();
        
        var response =   http.GetAsync("https://www.prlog.org/news/rss.xml");
        var content = response.Content.ReadAsStringAsync();

    }
}