using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Transform PacManPos;
    [SerializeField]
    public static GameController GC;
    [SerializeField]
    List<GameObject> ghostList;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    TMP_Text scoreText;

    protected int score;



    private void OnEnable()
    {
        GC = gameObject.GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {
        gameOverPanel.SetActive(true);
        foreach (GameObject ghost in ghostList)
        {
            ghost.GetComponent<Ghost>().FreezeControl(true);
        }
    }

    public Vector3 GetPacPos()
    {
        return PacManPos.position;
    }

    public Transform GetPacTrans()
    {
        return PacManPos;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void FreezeGhosts()
    {
        foreach(GameObject ghost in ghostList)
        {
            ghost.GetComponent<Ghost>().FreezeControl(true);
            Invoke("UnfreezeGhosts", 5);
        }
    }

    private void UnfreezeGhosts()
    {
        foreach (GameObject ghost in ghostList)
        {
            ghost.GetComponent<Ghost>().FreezeControl(false);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }

}
