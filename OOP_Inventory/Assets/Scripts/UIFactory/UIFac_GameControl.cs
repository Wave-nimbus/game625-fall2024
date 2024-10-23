using UnityEngine;

public class UIFac_GameControl : MonoBehaviour
{
    [SerializeField]
    GameObject enemyTurret1, enemyTurret2, enemyTurret3;
    [SerializeField]
    GameObject playerTurret1, playerTurret2, playerTurret3;
    [SerializeField]
    GameObject menuBar;

    public int currLane;

    float laneTimer;
    bool lane2Active, lane3Active;

    public static UIFac_GameControl GC;

    private void Awake()
    {
        if (GC == null)
            GC = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTurret2.SetActive(false);
        enemyTurret3.SetActive(false);
        playerTurret2.SetActive(false);
        playerTurret3.SetActive(false);
        lane2Active = false;
        lane3Active = false;
        laneTimer = 0;
        currLane = -1;

        TB_Lane lane1 =(TB_Lane) UIFactorySingleton.UIFac.facTBLane.BuildProduct(menuBar.transform);
        lane1.SetMyLane(0);
    }

    // Update is called once per frame
    void Update()
    {
        laneTimer += Time.deltaTime;
        if (!lane2Active && laneTimer >= 10)
        {
            enemyTurret2.SetActive(true);
            playerTurret2.SetActive(true);
            TB_Lane lane2 = (TB_Lane)UIFactorySingleton.UIFac.facTBLane.BuildProduct(menuBar.transform);
            lane2.SetMyLane(1);
            lane2Active = true;
        }
        if (!lane3Active && laneTimer >= 30)
        {
            TB_Lane lane3 = (TB_Lane)UIFactorySingleton.UIFac.facTBLane.BuildProduct(menuBar.transform);
            lane3.SetMyLane(2);
            enemyTurret3.SetActive(true);
            playerTurret3.SetActive(true);
            lane3Active = true;
        }

    }

    public void FireShots(int numShots)
    {
        if (currLane == -1)
        {
            return;
        }
        switch (currLane)
        {
            case 0:
                playerTurret1.GetComponent<PlayerTurret>().StartMultishot(numShots);
                break;
            case 1:
                playerTurret2.GetComponent<PlayerTurret>().StartMultishot(numShots);
                break;
            case 2:
                playerTurret3.GetComponent<PlayerTurret>().StartMultishot(numShots);
                break;
            default:
                break;
        }
    }
}
