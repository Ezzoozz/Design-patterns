using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCommand : Command
{
    

    float moveDistance;

    public ForwardCommand(IEntity entity, float moveDistance) : base(entity)
    {

        this.moveDistance = moveDistance;
    }

    public override IEnumerator Execute()
    {
        

        
       

        Vector3 position = entity.transform.localPosition;

        Vector3 goal = entity.transform.forward * moveDistance + position;

        float currentTime = 0f;

        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;

            entity.transform.position = Vector3.Lerp(position, goal, currentTime);


            yield return new WaitForEndOfFrame();

        }

     
    }

    public override IEnumerator Undo()
    {
      
       
        float currentTime = 0;

        Vector3 position = entity.transform.position;
        Vector3 goal = new Vector3(position.x, position.y, position.z - moveDistance);

        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;

            entity.transform.position = Vector3.Lerp(position, goal, currentTime);

            yield return new WaitForEndOfFrame();
        }


     
    }

}
