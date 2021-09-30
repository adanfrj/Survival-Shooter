using System;
using UnityEngine;

public class ShootCommand : ImpCommand
{

    PlayerShooting playerShooting;

    public ShootCommand(PlayerShooting _playerShooting)
    {
        playerShooting = _playerShooting;
    }

    public override void Execute()
    {
   
    }

    public override void UnExecute()
    {
        
    }
}

