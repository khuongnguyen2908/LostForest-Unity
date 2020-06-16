using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    public GameObject ClosePanel;
    public GameObject ClosePanel2;


    public void OpenPanel()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            
        }
    }

    public void ClosePan()
    {
        ClosePanel.gameObject.SetActive(false);
    }

    public void ClosePan2()
    {
        ClosePanel.gameObject.SetActive(false);
    }


}
