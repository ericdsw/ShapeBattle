﻿using System;
using System.Collections.Generic;

namespace ShapeBattle.Characters
{
    public abstract class PartyMember : IBattleCommandProvider
    {
        private String _name;
        private int _maxHP;
        private int _currentHP;

        public String Name
        {
            get => _name;
            set => _name = value;
        }
        public int MaxHP
        {
            get => _maxHP;
            set => _maxHP = value;
        }
        public int CurrentHP
        {
            get => _currentHP;
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

        protected PartyMember(String name, int maxHP)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.CurrentHP = maxHP;
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
    }
}
