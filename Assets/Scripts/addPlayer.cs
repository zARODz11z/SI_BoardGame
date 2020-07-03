using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPlayer : MonoBehaviour
{ 
    public GameObject[] characters;
    public Transform startTransform;
    public Vector3 startTransform2;
    public float offsetX, offsetY;
    public int index = -1;
        public GameObject[] InstatiatedPlayers = new GameObject[10];
    public void addAPlayer()

    {
        index += 1;
        startTransform2.x = startTransform2.x + offsetX;
        startTransform2.y = startTransform2.y + offsetY;

        InstatiatedPlayers[index]=Instantiate(characters[index],startTransform2, transform.rotation);
    }

}
