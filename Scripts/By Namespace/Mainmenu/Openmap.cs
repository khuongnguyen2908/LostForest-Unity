using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openmap : MonoBehaviour
{
    public GameObject map; // Assign in inspector
    private bool isShowing;
    public Animator anim;

    

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
           
            isShowing = !isShowing;
            map.SetActive(isShowing);
            anim.Play("Mappanel");
        }
    }
}
