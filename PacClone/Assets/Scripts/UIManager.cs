using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    public void StBtnClick()
    {
        SceneManager.LoadScene(1);
    }

}
