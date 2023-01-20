
using FlightManagement.Base.Position;

namespace FlightManagement.Tests;

public class PositionToStringMapperTests
{
    [Test]
    [TestCase("Pilot", ExpectedResult = PositionEnum.Pilot)]
    [TestCase("Kontroler", ExpectedResult = PositionEnum.Controller)]
    [TestCase("Steward", ExpectedResult = PositionEnum.Steward)]
    public PositionEnum MapToPositionEnumReturnExpectedResultWhenPassValidArgumentsTest(string position)
    {
        return PositionToStringMapper.MapTo(position);
    }

    [Test]
    [TestCase("pilot")]
    [TestCase("Controller")]
    [TestCase("Admin")]
    [TestCase("")]
    [TestCase(null)]
    public void MapToPositionEnumShouldThrowExceptionWhenPassInvalidArgumentsTest(string position)
    {
        Assert.That(() => PositionToStringMapper.MapTo(position), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    [TestCase(PositionEnum.Pilot, ExpectedResult = "Pilot")]
    [TestCase(PositionEnum.Controller, ExpectedResult = "Kontroler")]
    [TestCase(PositionEnum.Steward, ExpectedResult = "Steward")]
    public string MapToStringShouldReturnExpectedResultWhenPassValidArgumentsTest(PositionEnum position)
    {
        return PositionToStringMapper.MapTo(position);
    }

    [Test]
    [TestCase(PositionEnum.Admin)]
    [TestCase((PositionEnum)5)]
    public void MapToStringShouldThrowExceptionWhenPassInvalidArgumentsTest(PositionEnum position)
    {
        Assert.That(() => PositionToStringMapper.MapTo(position), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    [TestCase("Pilot", ExpectedResult = "Pilot")]
    [TestCase("Controller", ExpectedResult = "Kontroler")]
    [TestCase("Steward", ExpectedResult = "Steward")]
    [TestCase("Admin", ExpectedResult = "Admin")]
    public string TranslateShouldReturnExpectedResultWhenPassValidArgumentsTest(string position)
    {
        return PositionToStringMapper.Translate(position);
    }

    [Test]
    [TestCase("")]
    [TestCase("Kontroler")]
    [TestCase(null)]
    [TestCase("aaa")]
    public void TranslateThrowExceptionWhenPassWrongArgumentsTest(string position)
    {
        Assert.That(() => PositionToStringMapper.Translate(position), Throws.TypeOf<ArgumentException>());
    }
}