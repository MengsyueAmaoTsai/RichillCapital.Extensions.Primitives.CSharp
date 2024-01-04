namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class OneOfTests
{
    [TestMethod]
    public void Case1_Should_MatchCase1_WithIntType()
    {
        // Arrange
        var oneOf = OneOf<int, string, bool>.Case1(42);

        // Act & Assert
        oneOf.Match(
            case1 => case1.Should().Be(42),
            case2 => throw new InvalidOperationException(),
            case3 => throw new InvalidOperationException());
    }

    [TestMethod]
    public void Case2_Should_MatchCase2_WithStringType()
    {
        // Arrange
        var oneOf = OneOf<int, string, bool>.Case2("Test");

        // Act & Assert
        oneOf.Match(
            case1 => throw new InvalidOperationException(),
            case2 => case2.Should().Be("Test"),
            case3 => throw new InvalidOperationException());
    }

    [TestMethod]
    public void Case3_Should_MatchCase3_WithBoolType()
    {
        // Arrange
        var oneOf = OneOf<int, string, bool>.Case3(true);

        // Act & Assert
        oneOf.Match(
            case1 => throw new InvalidOperationException(),
            case2 => throw new InvalidOperationException(),
            case3 => case3.Should().BeTrue());
    }

    [TestMethod]
    public void Match_Should_ThrowException_IfNoneOfTheCasesMatch()
    {
        // Arrange
        var oneOf = OneOf<int, string, bool>.Case1(42);

        Action action = () => oneOf.Match<int>(
            case1 => throw new InvalidOperationException("None of the cases match."),
            case2 => throw new InvalidOperationException("None of the cases match."),
            case3 => throw new InvalidOperationException("None of the cases match."));

        action
            .Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("None of the cases match.");
    }
}