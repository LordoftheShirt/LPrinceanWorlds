using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpFacesCursor : MonoBehaviour
{
    [SerializeField] Transform cursor;
    public Vector2 screenPosition, lineInSpace;
    public Vector3 worldPosition;
    private Ray mouseRay, playerToCursorRay;

    void Update()
    {
        RecordCursorLocation();
        UpTowardsCursor();
    }

    private void RecordCursorLocation()
    {
        // Gets input of mouse, Ray "mouseRay" records the Vector2 (x and y) of the mouse position on screen relative to resolution.
        screenPosition = Input.mousePosition;
        mouseRay = Camera.main.ScreenPointToRay(screenPosition);

        // Vector3 worldPosition translates the x and y to where that position is in the real world. Since it is Vector3 (has z), z must be set to 0. Otherwise it'll be on the same z as camera.
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;

        // moves "end" object to cursor location.
        cursor.position = worldPosition;
    }

    private void UpTowardsCursor()
    {
        //
        lineInSpace = new Vector2(cursor.position.x - transform.position.x, cursor.position.y - transform.position.y);
        transform.up = lineInSpace;
    }
}
