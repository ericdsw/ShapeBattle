using System;
using System.Collections.Generic;

namespace ShapeBattle.Characters
{
    public interface IBattleCommandProvider
    {
        List<BattleCommand> ProvideCommands();
    }
}
