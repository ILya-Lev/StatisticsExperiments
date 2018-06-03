using FellerProbability;
using FluentAssertions;
using Xunit;

namespace FellerProbabilityTests
{
    public class TurnistateTests
    {
        private readonly Turnistate _turnistate;

        public TurnistateTests()
        {
            _turnistate = new Turnistate();
            _turnistate.Reset();
        }

        [Fact]
        public void Coin_Locked_Unlock()
        {
            _turnistate.IsLocked().Should().BeTrue();

            _turnistate.Coin();

            _turnistate.IsLocked().Should().BeFalse();
        }

        [Fact]
        public void Pass_Locked_Alarm()
        {
            _turnistate.IsLocked().Should().BeTrue();
            _turnistate.Alarming().Should().BeFalse();

            _turnistate.Pass();

            _turnistate.IsLocked().Should().BeTrue();
            _turnistate.Alarming().Should().BeTrue();
        }

        [Fact]
        public void Coin_Unlocked_Refund()
        {
            _turnistate.IsLocked().Should().BeTrue();
            _turnistate.Coin();
            _turnistate.IsLocked().Should().BeFalse();

            _turnistate.Coin();

            _turnistate.IsLocked().Should().BeFalse();
            _turnistate.Refunds.Should().Be(1);
        }

        [Fact]
        public void Pass_Unlocked_Lock()
        {
            _turnistate.IsLocked().Should().BeTrue();
            _turnistate.Coin();
            _turnistate.IsLocked().Should().BeFalse();


            _turnistate.Pass();

            _turnistate.IsLocked().Should().BeTrue();
            _turnistate.Alarming().Should().BeFalse();
        }
    }
}
