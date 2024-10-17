using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaser : MonoBehaviour
{
    // all vector laser variables
    private LineRenderer lineRenderer;
    [SerializeField] private LayerMask laserMask;
    [SerializeField] private Transform cursor;
    [SerializeField] private float defaultLength = 50;

    // all cursor detection variables.
    public Vector2 screenPosition;
    public Vector3 worldPosition;
    private Ray mouseRay;
    private RaycastHit2D hit;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        RecordCursorLocation();
    }
    void FixedUpdate()
    {

    }

    private void RecordCursorLocation()
    {
        // Gets input of mouse, Ray "mouseRay" records the Vector2 (x and y) of the mouse position on screen relative to resolution.
        screenPosition = Input.mousePosition;
        mouseRay = Camera.main.ScreenPointToRay(screenPosition);

        // Vector3 worldPosition translates the x and y to where that position is in the real world. Since it is Vector3 (has z), z must be set to 0. Otherwise it'll be on the same z as camera.
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;

        // moves "cursor" object to cursor location.
        cursor.position = worldPosition;
    }

    private void NormalLaser()
    {
        lineRenderer.SetPosition(0, transform.position);

        hit = Physics2D.Raycast(transform.position, worldPosition, laserMask);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else { lineRenderer.SetPosition(1, transform.position + (worldPosition * defaultLength)); }
    }
}
