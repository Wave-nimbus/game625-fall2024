using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Zone_Switch : Zone_Interface
{
    public Zone_Interface DoState(Zone_Base currState)
    {
        if(currState.currSafe) //Swtich to lava
        {
            currState.spotlight.color = Color.red;
            currState.GetComponent<Renderer>().material = currState.lavaFloor;
            currState.NMMod.area = 1;
        }
        else //Switch to dirt
        {
            currState.spotlight.color = Color.green;
            currState.GetComponent<Renderer>().material = currState.dirtFloor;
            currState.NMMod.area = 0;
        }
        currState.currSafe = !currState.currSafe;
        currState.goToSwitch = false;
        currState.goToWarning = false;
        return currState.HoldState;
    }
}
