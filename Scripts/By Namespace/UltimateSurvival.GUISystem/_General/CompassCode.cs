using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassCode : MonoBehaviour
{
    public Transform player;
    Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vector.z = player.eulerAngles.y;
        transform.localEulerAngles = vector;
    }
}
