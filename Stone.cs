﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Route currentRoute;
   // public Route currentRoute2;
    int routePosition,routePosition2;

    public int steps;
    
    bool isMoving;
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.K) && !isMoving)
         {
             steps = Random.Range (1,7);
             Debug.Log ("Dice Rolled" + steps);
             StartCoroutine(Move());
            // if(routePosition+steps < currentRoute.childNodeList.Count)
            // {
            //    StartCoroutine(Move());
            // }
            // else
            // {
            //     Debug.Log("Rolled Number is to high");
            // }
         }
     }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps>0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;
           // routePosition2 %= currentRoute2.childNodeList.Count;
            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while(MoveToNextNode(nextPos)){yield return null;}
            yield return new WaitForSeconds(0.1f);
            steps--;
        }

        isMoving =false;
    }
    bool MoveToNextNode(Vector3 goal)
    {
        return goal !=(transform.position = Vector3.MoveTowards(transform.position,goal,10f * Time.deltaTime));
       // transform.position = Vector3.MoveTowards(transform.position,goal,2f * Time.deltaTime);
    }
}
