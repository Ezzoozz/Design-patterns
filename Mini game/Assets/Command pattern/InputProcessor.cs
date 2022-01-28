using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour,IEntity
{
    [SerializeField] float moveDistance=50f;

    [SerializeField] float angleMovement = 50f;

    CommandProcessor commandProcessor;
    // Start is called before the first frame update
    void Start()
    {
        commandProcessor = GetComponent<CommandProcessor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            var forwardCommand = new ForwardCommand(this, moveDistance);

           StartCoroutine(commandProcessor.ExecuteCommand(forwardCommand));

       
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            var rotateUpCommand = new RotateUpCommand(this, angleMovement);

            StartCoroutine(commandProcessor.ExecuteCommand(rotateUpCommand));

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            var rotateDownCommand = new RotateDownCommand(this, angleMovement);

            StartCoroutine(commandProcessor.ExecuteCommand(rotateDownCommand));

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            var rotateRightCommand = new RotateRightCommand(this, angleMovement);

            StartCoroutine(commandProcessor.ExecuteCommand(rotateRightCommand));

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            var rotateLeftCommand = new RotateLeftCommand(this, angleMovement);

            StartCoroutine(commandProcessor.ExecuteCommand(rotateLeftCommand));
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartCoroutine(commandProcessor.Undo());

        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(commandProcessor.Redo());

        }
    }
}
