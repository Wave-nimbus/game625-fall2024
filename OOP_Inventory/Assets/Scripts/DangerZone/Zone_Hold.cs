using UnityEngine;

public class Zone_Hold : Zone_Interface
{
    public Zone_Interface DoState(Zone_Base currState)
    {
        if(currState.goToWarning)
        {
            return currState.WarnState;
        }
        else
        {
            return currState.HoldState;
        }
    }



}
