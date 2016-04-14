using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGroupController : MonoBehaviour
{
    CameraTransition camController = new CameraTransition();
    List<Transform> players = new List<Transform>();
    int currentPlayer = 0;

    public Vector3 lookAtTarget;


    void Start()
    {
        //add players to list
        for(int i = 0; i < transform.childCount; ++i)
            players.Add(transform.GetChild(i).transform);

        //get the distance from the first player position to the camera
        Vector3 distance = (Camera.main.transform.position - players[0].position);
        distance.y = 0;

        //loop through positions to find the shortest one. this tells
        //us who the camera is behind, therefore who's turn it is
        int index = 0;
        foreach (Transform t in players)
        {
            
            Vector3 newDistance = Camera.main.transform.position - t.position;
            newDistance.y = 0;
            //Debug.Log("Dist 2: " + newDistance.sqrMagnitude);

            if (newDistance.sqrMagnitude < distance.sqrMagnitude)
            {
                distance = newDistance;
                currentPlayer = index;
            }
            index++;
        }

    }

    public void EndTurn()
    {
        
        //next player
        currentPlayer += 1;
        
        //if every player has gone, reset
        if (currentPlayer > players.Count -1)
            currentPlayer = 0;
        
        StartCoroutine(camController.Transition(
                       players[currentPlayer], lookAtTarget));
    }

    void OnGUI()
    {
    }
}
