using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreBoard : MonoBehaviour
{
    int score = 0;

    CollisionHandler collisionHandler;

    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
         tm = GetComponent<TextMesh>();

        collisionHandler = FindObjectOfType<CollisionHandler>();

        collisionHandler.Collided += CollisionHandler_Collided;
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        collisionHandler.Collided -= CollisionHandler_Collided;
    }

    private void CollisionHandler_Collided(int obj)
    {
        score += obj;
        tm.text = "Score =" + score;
        Debug.Log("Score updated " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
