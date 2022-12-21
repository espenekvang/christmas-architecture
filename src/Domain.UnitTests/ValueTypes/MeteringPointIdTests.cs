using Domain.ValueTypes;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.ValueTypes
{
    public class MeteringPointIdTests
    {
        [Fact]
        public void Ctr_MeasuringPointIdIs16Digits_ReturnTrue()
        {
            //arrange
            const string measuringPointIdNumber = "1234567890123456";

            //act
            var (successful, measuringPointId) = MeteringPointId.TryCreateMeasuringPointId(measuringPointIdNumber);

            //assert
            successful.Should().BeTrue();
            measuringPointId.Value.Should().Be(measuringPointIdNumber);
        }

        [Fact]
        public void Ctr_MeasuringPointIdIs10Digits_ReturnFalse()
        {
            //arrange
            const string measuringPointIdNumber = "1234567890";

            //act
            var (successful, measuringPointId) = MeteringPointId.TryCreateMeasuringPointId(measuringPointIdNumber);

            //assert
            successful.Should().BeFalse();
            measuringPointId.Value.Should().NotBe(measuringPointIdNumber);
        }
    }
}
