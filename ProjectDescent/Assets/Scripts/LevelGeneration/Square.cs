using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square {

    public ControlNode topLeft, topRight, bottomLeft, bottomRight;
    public Node centerTop, centerRight, centerBottom, centerLeft;
    public int configurationOfActive;

    public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomRight, ControlNode _bottomLeft)
    {
        topLeft = _topLeft;
        topRight = _topRight;
        bottomRight = _bottomRight;
        bottomLeft = _bottomLeft;

        centerTop = topLeft.right;
        centerRight = bottomRight.above;
        centerBottom = bottomLeft.right;
        centerLeft = bottomLeft.above;

        if (topLeft.active)
            configurationOfActive += 8;
        if (topRight.active)
            configurationOfActive += 4;
        if (bottomRight.active)
            configurationOfActive += 2;
        if (bottomLeft.active)
            configurationOfActive += 1;
    }
}
