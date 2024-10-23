using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Time_Rewind : MonoBehaviour
{
    private Stack<Inter_Command> commandStack = new Stack<Inter_Command>();
    private bool isRewinding;


    public void RecordCommand(Inter_Command comm)
    {
        if(!isRewinding)
        {
            commandStack.Push(comm);
        }
    }

    public void Rewind()
    {
        StartCoroutine(RewindCoroutine());
    }


    private IEnumerator RewindCoroutine()
    {
        isRewinding = true;
        while(commandStack.Count > 0)
        {
            Inter_Command comm = commandStack.Pop();
            comm.Undo();
            yield return null;
        }

        isRewinding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRewinding && Input.GetKeyDown(KeyCode.R))
        {
            Rewind();
        }

    }

    public bool GetIsRewinding() {  return isRewinding; }
}
