
namespace Singleton.App;
public class Game {

    private static Game? instance;
    private Game() {
        
    }

    public static Game GetInstance() {
        if (instance == null) {
            instance = new Game();
        }
        return instance;
    }
}