using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    

    [SerializeField] float moveDistance = 1f;

    [SerializeField] float AngleMovement = 45f;

    bool isMoving = false;

    [SerializeField] float rotateSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessControls();
    }

    private void ProcessControls()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Forward());


        else if (Input.GetKeyDown(KeyCode.W))
            StartCoroutine(RotateUp());

        else if (Input.GetKeyDown(KeyCode.D))
           StartCoroutine (RotateRight());

        else if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(RotateLeft());

        else if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(RotateDown());
    }

    IEnumerator Forward()
    {
        isMoving = true;

        Vector3 position = transform.localPosition;

        Vector3 goal = transform.forward * moveDistance + position;

       float currentTime = 0f;

        while (currentTime<1)
        {
            currentTime += Time.deltaTime;

            transform.position = Vector3.Lerp(position,goal,currentTime);


            yield return new WaitForEndOfFrame();

        }

        isMoving = false;

    }
    IEnumerator  RotateDown()
    {
        Debug.Log("Rotating down");

        isMoving = true;



        Vector3 goal = transform.rotation.eulerAngles;

        goal.x += AngleMovement;




        float index = 0;

        while (index < AngleMovement)
        {
            transform.Rotate(rotateSpeed, 0, 0);

            index += rotateSpeed;
            yield return new WaitForEndOfFrame();
        }

        isMoving = false;
    }

    IEnumerator RotateLeft()
    {
        Debug.Log("Rotating right");

        isMoving = true;






        Vector3 goal = transform.rotation.eulerAngles;

        goal.y -= AngleMovement;




        float index = 0;

        while (index>-AngleMovement)
        {
            transform.Rotate(0, -rotateSpeed, 0);

            index -= rotateSpeed;
            yield return new WaitForEndOfFrame();
        }

        isMoving = false;

    }

    IEnumerator RotateRight()
    {
        Debug.Log("Rotating right");

        isMoving = true;

      





        Vector3 goal = transform.rotation.eulerAngles;

        goal.y += AngleMovement;




        float index = 0;

        while (index < AngleMovement)
        {
            transform.Rotate(0, rotateSpeed, 0);

            index += rotateSpeed;
            yield return new WaitForEndOfFrame();
        }

        isMoving = false;

    }

    IEnumerator RotateUp()
    {
        Debug.Log("Rotating right");

        isMoving = true;


        Vector3 goal = transform.rotation.eulerAngles;

        goal.x -= AngleMovement;




        float index = 0;

        while (index > -AngleMovement)
        {
            transform.Rotate(-rotateSpeed, 0, 0);

            index -= rotateSpeed;
            yield return new WaitForEndOfFrame();
        }

        isMoving = false;
    }

    IEnumerator Backward()
    {
        Debug.Log("Moving");
        isMoving = true;
        float currentTime = 0;

        Vector3 position = transform.position;
        Vector3 goal = new Vector3(position.x, position.y, position.z - moveDistance);

        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;

            transform.position = Vector3.Lerp(position, goal, currentTime);

            yield return new WaitForEndOfFrame();
        }


        isMoving = false;
    }
}
