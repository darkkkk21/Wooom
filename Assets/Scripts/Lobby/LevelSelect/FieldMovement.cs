using System;
using System.Collections.Generic;
using System.Linq;
using Lobby.LevelSelect;
using UnityEngine;

public class FieldMovement : MonoBehaviour
{
    [SerializeField] private PointSwitcher pointSwitcher;
    private Vector3 minScreenPoint;
    private Vector3 maxScreenPoint;
    private float peding = 0.2f;
    private List<bool> availables = new List<bool>();

    private void Start()
    {
        minScreenPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }

    void Update()
    {
        Movement();
    }

    private Vector2 touchStartPos;
    private Vector2 prevTouchPos;

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            prevTouchPos = Input.mousePosition;
            pointSwitcher.Activate(true);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = (Vector2) Input.mousePosition - prevTouchPos;

            if (IsCanMove())
                transform.Translate(deltaPos.x * Time.deltaTime, deltaPos.y * Time.deltaTime, 0);

            prevTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            pointSwitcher.Activate(false);
        }
    }

    private bool IsCanMove()
    {
        var availablePoints = pointSwitcher.ActivePoint;

        if (availablePoints == null || availablePoints.Count == 0)
            return false;

        availables.Clear();

        foreach (var point in availablePoints)
        {
            switch (point.CurrentSideType)
            {
                case SideType.Left:
                    availables.Add(point.transform.position.x > minScreenPoint.x);
                    break;

                case SideType.Right:
                    availables.Add(point.transform.position.x < maxScreenPoint.x);
                    break;

                case SideType.Bottom:
                    if (point.transform.position.y  >= minScreenPoint.y + peding)
                    {
                        availables.Add(true);
                    }
                    else
                    {
                        var delta = point.transform.position.y - (minScreenPoint.y + peding);
                        transform.position -= new Vector3(0,  delta,0);
                        availables.Add(false);
                    }
                    break;

                case SideType.Top:
                    if (point.transform.position.y < maxScreenPoint.y)
                    {
                        availables.Add(true);
                    }
                    else
                    {
                        availables.Add(false);
                       //transform.position = new Vector3(transform.position.x, transform.position.y - maxScreenPoint.y);
                    }

                    break;
            }
        }

        return availables.All(a => a);
    }
}