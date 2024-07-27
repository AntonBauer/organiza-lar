namespace OrganizaLar.Domain.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var tmp = 1 + 1;

        Assert.That(tmp, Is.EqualTo(2));

        Console.WriteLine("Test is done");
    }
}
