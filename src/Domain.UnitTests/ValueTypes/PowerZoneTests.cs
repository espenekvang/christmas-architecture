using Domain.ValueTypes;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.ValueTypes
{
    public class PowerZoneTests
    {
        [Theory]
        [InlineData("NO1")]
        [InlineData("NO2")]
        [InlineData("NO3")]
        [InlineData("NO4")]
        [InlineData("NO5")]
        public void Ctr_PowerZoneIsValid_ReturnTrue(string zone)
        {
            //arrange & act
            var (successful, powerZone) = PowerZone.TryCreatePowerZone(zone);

            //assert
            successful.Should().BeTrue();
            powerZone.Code.Should().BeEquivalentTo(zone);
        }

        [Theory]
        [InlineData("no1")]
        [InlineData("no2")]
        [InlineData("no3")]
        [InlineData("no4")]
        [InlineData("no5")]
        public void Ctr_PowerZoneIsValiSmallCase_ReturnTrue(string zone)
        {
            //arrange & act
            var (successful, powerZone) = PowerZone.TryCreatePowerZone(zone);

            //assert
            successful.Should().BeTrue();
            powerZone.Code.Should().BeEquivalentTo(zone.ToUpper());
        }

        [Fact]
        public void Ctr_PowerZoneIsInvalid_ReturnFalse()
        {
            //arrange & act
            var invalidPowerZone = "NO0";
            var (successful, powerZone) = PowerZone.TryCreatePowerZone(invalidPowerZone);

            //assert
            successful.Should().BeFalse();
            powerZone.Should().BeEquivalentTo(default(PowerZone));
        }
    }
}
