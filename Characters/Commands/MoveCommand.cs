using System;

namespace ShapeBattle.Characters.Commands
{
    public class MoveCommand : BattleCommand
    {
        public MoveCommand()
        {
            Name = "Move";
            EnergyReplenishTime = 1.0f;
        }

        public override void Execute()
        {
            
        }
    }
}
