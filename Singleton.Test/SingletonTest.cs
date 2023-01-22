namespace Singleton.Test;


public class SingletonTest {

    [Fact]
    public void TestSingleInstance() {
        var instance1 = Game.GetInstance();
        var instance2 = Game.GetInstance();


        Assert.Equal(instance1, instance2);
    }
}