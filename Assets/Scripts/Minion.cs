using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

    public MinionTypeData MinionTypeData;
    public string LastName;
    public string FirstName;

    public void UpdateMinion()
    {
        this.GetComponent<MeshRenderer>().material = this.MinionTypeData.Material;
        this.gameObject.name = string.Format("M-{0}|{1}, {2}", MinionTypeData.Name,this.LastName,this.FirstName);
    }

}
