using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square {

    public ControlNode topLeft, topRight, bottomLeft, bottomRight;
    public Node centerTop, centerRight, centerBottom, centerLeft;

    public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomLeft, ControlNode _bottomRight)
    {
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;

        centerTop = topLeft.above;
        centerRight = bottomRight.above;
        centerBottom = bottomLeft.right;
        centerLeft = bottomLeft.above;
    }
}
