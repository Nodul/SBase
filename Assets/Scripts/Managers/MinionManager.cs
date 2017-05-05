using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionManager : MonoBehaviour {

    private static MinionManager _instance;
    public static MinionManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public List<Minion> Minions = new List<Minion>();

    public void FindAllMinions()
    {
        Minions.Clear();
        var minions = GameObject.FindGameObjectsWithTag("Minion");

        foreach (var m in minions)
        {
            Minions.Add(m.GetComponent<Minion>());
            m.GetComponent<Minion>().UpdateMinion();
        }

    }

    public void UpdateMinions()
    {
        foreach(Minion m in Minions)
        {
            m.UpdateMinion();
        }
    }

    public void MoveAllMinionsTo(Pathfinding.Node endNode)
    {
        foreach(Minion m in Minions)
        {
            m.MyMoveGoal = endNode;
            m.GiveMoveOrder();
        }
    }
}
