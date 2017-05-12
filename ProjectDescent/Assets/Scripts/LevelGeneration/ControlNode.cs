using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNode : Node {
    public bool active;
    public Node above, right;

    public ControlNode(Vector3 _pos, bool _active, float squareSize) : base(_pos)
    {
        active = _active;
        above = new Node(_pos + Vector3.forward * squareSize / 2f);
        right = new Node(_pos + Vector3.right * squareSize / 2f);
    }

}
