using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject pannel;

    private void Start()
    {
        pannel.SetActive(false);
    }
    public void NameBoardOn()
    {
        pannel.SetActive(true);
    }
}
