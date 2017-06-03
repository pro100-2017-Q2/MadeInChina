using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour {

    public string Name;

    public ChestFunctionality ChestMenu;

    public abstract void UpdateStats();

}
