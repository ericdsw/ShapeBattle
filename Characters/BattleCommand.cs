using System;

namespace ShapeBattle.Characters
{
    public abstract class BattleCommand
    {
        private String _name;
        private float _energyReplenishTime;

        public String Name
        {
            get => _name;
            set => _name = value;
        }
        public float EnergyReplenishTime
        {
            get => _energyReplenishTime;
            set => _energyReplenishTime = value;
        }

        public abstract void Execute();
    }
}
