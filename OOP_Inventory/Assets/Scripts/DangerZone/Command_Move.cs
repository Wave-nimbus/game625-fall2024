using UnityEngine;

public class Command_Move : Inter_Command
{
    private Transform objTransform;
    private Vector3 moveDir;
    private Vector3 prevPos;

    public Command_Move(Transform objToMove, Vector3 movement)
    {
        objTransform = objToMove;
        moveDir = movement;
    }

    public void Execute()
    {
        prevPos = objTransform.position;
        objTransform.position += moveDir;
    }

    public void Undo()
    {
        objTransform.position = prevPos;
    }
}
