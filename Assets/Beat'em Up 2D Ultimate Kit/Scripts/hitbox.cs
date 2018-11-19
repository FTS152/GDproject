using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class hitbox : MonoBehaviour
{
    //place this script on the player gameobject
 
    public GameObject player; // in the inspector drag the gameobject the will be following the player to this field
    public int followDistanceX;
    public int followDistanceY;
    private List<Vector3> storedPositionsX;
    private List<Vector3> storedPositionsY;
    void Awake()
    {
        storedPositionsX = new List<Vector3>(); //create a blank list
        storedPositionsY = new List<Vector3>();

    }
 
    void Start()
    {
 
    }
 
    void Update()
    {
        bool moving = false;
        if (transform.position.x !=  player.transform.position.x + followDistanceX)
        {
            Vector3 temp = new Vector3(player.transform.position.x + followDistanceX,transform.position.y, transform.position.z);
            moving = true;
            transform.position = temp; //move
        }
 
        if (transform.position.y != player.transform.position.y + followDistanceY)
        {
            Vector3 temp = new Vector3(transform.position.x,player.transform.position.y + followDistanceY, transform.position.z);
            moving = true;
            transform.position = temp; //move
        }
    }
}
 