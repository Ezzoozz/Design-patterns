using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeftCommand : Command
{

    float angleMovement;

    public RotateLeftCommand(IEntity entity, float angleMovement) : base(entity)
    {

        this.angleMovement = angleMovement;
    }

    public override IEnumerator Execute()
    {
     




    

        for(int i=0; i< (angleMovement / 3f) / 2f; i++)
        {
            entity.transform.Rotate(0, -3, 0);

           
            yield return new WaitForEndOfFrame();

        }
        

    }

    public override IEnumerator Undo()
    {
        for (int i = 0; i < (angleMovement / 3f) / 2f; i++)
        {
            entity.transform.Rotate(0, 3, 0);


            yield return new WaitForEndOfFrame();

        }
    }

    }

