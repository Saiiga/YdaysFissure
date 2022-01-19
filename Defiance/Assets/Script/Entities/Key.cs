using System.Collections;
using UnityEngine;

namespace Assets.Script.Entities
{
    public class Key : InstantBonus
    {
        public override void OnPickUp(Player _player)
        {
            _player.AddItem(this);

            base.OnPickUp(_player);
        }

        public override void Action(Player _player = null)
        {
        }
    }
}