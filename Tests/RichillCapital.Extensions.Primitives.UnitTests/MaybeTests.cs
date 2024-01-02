namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class MaybeTests
{
    [TestMethod]
    public void From_Should_ReturnMaybeHasValue()
    {
        Maybe<int> maybe = Maybe.From(5);

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(5);
    }

    [TestMethod]
    public void ImplicitCast_Should_ReturnMaybeHasValue()
    {
        Maybe<int> maybe = 5;

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(5);
    }

    [TestMethod]
    public void ImplicitCast_Should_ReturnPrimitiveValue()
    {
        Maybe<string> maybe = "Maybe";

        string value = maybe;

        value.Should().Be("Maybe");
    }
}