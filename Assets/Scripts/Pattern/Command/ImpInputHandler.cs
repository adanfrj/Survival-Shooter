using System;
using UnityEngine;
using System.Collections.Generic;
public class ImpInputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    //Queue untuk menyimpan list command
    Queue<ImpCommand> commands = new Queue<ImpCommand>();

    void FixedUpdate()
    {
        //Menghandle input movement
        ImpCommand moveCommand = InputMovementHandling();
        if (moveCommand != null)
        {
            commands.Enqueue(moveCommand);

            moveCommand.Execute();
        }
    }

    void Update()
    {
        //Mengahndle shoot
        ImpCommand shootCommand = InputShootHandling();
        if (shootCommand != null)
        {
            shootCommand.Execute();
        }
    }

    ImpCommand InputMovementHandling()
    {
        //Check jika movement sesuai dengan key nya
        if (Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(playerMovement, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(playerMovement, -1, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(playerMovement, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(playerMovement, 0, -1);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            //Undo movement
            return Undo();
        }
        else
        {
            return new MoveCommand(playerMovement, 0, 0); ;
        }
    }

    ImpCommand Undo()
    {
        //Jika Queue command tidak kosong, lakukan perintah undo
        if(commands.Count > 0)
        {
            ImpCommand undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }
    
    ImpCommand InputShootHandling()
    {
        //Jika menembak trigger shoot command
        if (Input.GetButtonDown("Fire1"))
        {
            return new ShootCommand(playerShooting);
        }
        else
        {
            return null;
        }
    }
}
