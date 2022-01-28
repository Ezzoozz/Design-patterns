using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    List<Command> commands = new List<Command>();

    List<Command> redo = new List<Command>();

    int commandindex = -1;

    bool isMoving = false;

   


    // Start is called before the first frame update

    
    public IEnumerator ExecuteCommand(Command command)
    {
        Debug.Log("isMoving " + isMoving);
        if (!isMoving)
        {
            redo.Clear();

            
            Debug.Log("Moving forward");
            isMoving = true;

            commands.Add(command);

            StartCoroutine(command.Execute());

            commandindex = commands.Count - 1;

            yield return command.Execute();

            isMoving = false;
        }

        //else do nothing



    }

   public IEnumerator Undo()
    {
        Debug.Log("isMoving " + isMoving);

        if (commandindex >= 0 && !isMoving)
        {
            isMoving = true;

            StartCoroutine(commands[commandindex].Undo());

            yield return commands[commandindex].Undo();

            redo.Add(commands[commandindex]);
         

            commands.RemoveAt(commandindex);

            

            commandindex--;

           

            isMoving = false;

        }

    }

    public IEnumerator Redo()
    {
        if (!isMoving && redo.Count>0)
        {

           
            Debug.Log("redo count" + redo.Count);

            commands.Add(redo[redo.Count - 1]);
            commandindex++;


            isMoving = true;
            StartCoroutine(redo[redo.Count-1].Execute());


            yield return redo[redo.Count - 1].Execute();

            redo.RemoveAt(redo.Count - 1);

          

            
            isMoving = false;
        }

    }
}
