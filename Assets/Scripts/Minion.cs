using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinionState
{
    Idle,
    Moving,
    Working,
    Fighting,
    Incapacitated,
    Dead

}

public class Minion : MonoBehaviour {

    public MinionTypeData MinionTypeData;
    public string LastName;
    public string FirstName;
    public Node MyMoveGoal;

    public MinionState MinionState;
    private MinionMovementControl moveControl;

    private void Awake()
    {
        if (moveControl == null) moveControl = GetComponent<MinionMovementControl>();
    }

    /// <summary>
    /// For use when minion gets new MinionTypeData, so he can properly update his material, stats etc
    /// </summary>
    public void UpdateMinion()
    {
        
        this.GetComponentInChildren<MeshRenderer>().material = this.MinionTypeData.Material;
        this.gameObject.name = string.Format("M-{0}|{1}, {2}", MinionTypeData.Name,this.LastName,this.FirstName);
    }

    public void GiveMoveOrder()
    {
        this.moveControl.MoveOrder(this.MyMoveGoal);
        this.MinionState = MinionState.Moving;
    }

    
}
