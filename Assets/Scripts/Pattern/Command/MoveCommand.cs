using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ImpCommand
{
    PlayerMovement playerMovement;
    float h, v;

    public MoveCommand(PlayerMovement _playerMovement, float _h, float _v)
    {
        this.playerMovement = _playerMovement;
        this.h = _h;
        this.v = _v;
    }

    //Trigger perintah movement
    public override void Execute()
    {
      
    }

    public override void UnExecute()
    {
        
    }
}
