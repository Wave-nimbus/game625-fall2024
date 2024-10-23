using UnityEngine;

public class Zone_Warn : Zone_Interface
{
    public Zone_Interface DoState(Zone_Base currState)
    {
        if (currState.goToSwitch)
        {
            return currState.SwitchState;
        }
        else
        {
            currState.spotlight.color = Color.yellow;
            return currState.WarnState;
        }
    }
}
