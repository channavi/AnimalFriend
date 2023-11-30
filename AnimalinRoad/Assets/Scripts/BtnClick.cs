using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject pannel;

    private void Start()
    {

    }
    public void NameBoardOff()
    {
        pannel.SetActive(false);
    }
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
