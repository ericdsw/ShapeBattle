using Godot;
using System;
using System.Collections.Generic;

namespace ShapeBattle.Characters
{
    public abstract class PartyMember : Node, IBattleCommandProvider
    {
        private String _name;
        private int _maxHP;
        private int _currentHP;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }
        public int CurrentHP
        {
            get  { return _currentHP; }
            set
            {
                if (value <= 0)
                {
                    _currentHP = 0;
                } 
                else if (value >= MaxHP)
                {
                    _currentHP = MaxHP;
                }
                else
                {
                    _currentHP = value;
                }
            }
        }

        public List<BattleCommand> Commands;

        public void AddCommand(BattleCommand command)
        {
            Commands.Add(command);
        }

        public List<BattleCommand> ProvideCommands()
        {
            return Commands;
        }

        public PartyMember()
        {
            Commands = new List<BattleCommand>();
        }
    }
}
