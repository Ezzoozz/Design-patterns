using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDownCommand : Command
{
    // Start is called before the first frame update
     

    float angleMovement;

    public RotateDownCommand(IEntity entity, float angleMovement) : base(entity)
    {

        this.angleMovement = angleMovement;
    }

    public override IEnumerator Execute()
    {




        for (int i = 0; i < (angleMovement / 3f) / 2f; i++)
        {
            entity.transform.Rotate(3, 0, 0);


            yield return new WaitForEndOfFrame();

        }

    }

    public override IEnumerator Undo()
    {
        for (int i = 0; i < (angleMovement / 3f) / 2f; i++)
        {
            entity.transform.Rotate(3, 0, 0);


            yield return new WaitForEndOfFrame();

        }
    }
}
