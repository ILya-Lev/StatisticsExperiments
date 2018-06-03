namespace FellerProbability
{
    /// <summary>
    /// monostate pattern demonstration for final state machine implementation
    /// </summary>
    public class Turnistate
    {
        private static bool _isLocked = true;
        private static bool _isAlarming = false;
        private static int _coins = 0;
        private static int _refunds = 0;

        protected static readonly Turnistate Locked = new Locked();
        protected static readonly Turnistate Unlocked = new Unlocked();
        protected static Turnistate _state = Locked;

        public void Reset()
        {
            Lock(true);
            Alarm(false);
            _coins = 0;
            _refunds = 0;
            _state = Locked;
        }

        public bool IsLocked() => _isLocked;
        public bool Alarming() => _isAlarming;

        public virtual void Coin() => _state.Coin();

        public virtual void Pass() => _state.Pass();

        public int Coins => _coins;
        public int Refunds => _refunds;
        public void Deposit() => _coins++;
        public void Refund() => _refunds++;

        protected void Alarm(bool shouldAlarm) => _isAlarming = shouldAlarm;

        protected void Lock(bool shouldLock) => _isLocked = shouldLock;
    }

    internal class Unlocked : Turnistate
    {
        public override void Coin()
        {
            Refund();
        }

        public override void Pass()
        {
            Lock(true);
            _state = Locked;
        }
    }

    internal class Locked : Turnistate
    {
        public override void Coin()
        {
            Lock(false);
            Alarm(false);
            Deposit();
            _state = Unlocked;
        }

        public override void Pass()
        {
            Alarm(true);
        }
    }
}
