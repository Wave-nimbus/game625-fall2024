using Unity.AI.Navigation;
using UnityEngine;

public class Zone_Base : MonoBehaviour, Zone_Observer
{
    [SerializeField]
    public Material dirtFloor, lavaFloor;
    [SerializeField]
    public Light spotlight;
    [SerializeField]
    protected bool startSafe;
    [SerializeField]
    public NavMeshModifier NMMod;

    public bool currSafe;
    public bool goToWarning;
    public bool goToSwitch;

    public Zone_Hold HoldState = new Zone_Hold();
    public Zone_Warn WarnState = new Zone_Warn();
    public Zone_Switch SwitchState = new Zone_Switch();

    protected Zone_Interface currState;


    private void Start()
    {
        currState = HoldState;
        FindFirstObjectByType<Manager_Zone>().Warning += OnWarning;
        FindFirstObjectByType<Manager_Zone>().Switch += OnSwitch;

        if (startSafe)
        {
            spotlight.color = Color.green;
            GetComponent<Renderer>().material = dirtFloor;
            NMMod.area = 0;
        }
        else
        {
            spotlight.color = Color.red;
            GetComponent<Renderer>().material = lavaFloor;
            NMMod.area = 1;
        }

        currSafe = startSafe;

        goToWarning = false;
        goToSwitch = false;
    }

    private void Update()
    {
        currState = currState.DoState(this);
    }

    public void OnWarning()
    {
        goToWarning = true;
    }

    public void OnSwitch()
    {
        goToSwitch = true;
    }
}

