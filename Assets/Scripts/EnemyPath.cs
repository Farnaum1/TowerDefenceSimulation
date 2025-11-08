using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    [SerializeField] GameObject[] wayPoints;

    private void OnDrawGizmos()
    {
        if (wayPoints.Length > 0)
        {
            for (int i = 0; i < wayPoints.Length; i++)
            {
                SetWaypointLabel(i);

                if (i < wayPoints.Length - 1)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(wayPoints[i].transform.position, wayPoints[i + 1].transform.position);
                }
               
            }
        }
    }

    private void SetWaypointLabel(int i)
    {
        GUIStyle labelStyle = new GUIStyle();
        labelStyle.normal.textColor = Color.red;
        labelStyle.alignment = TextAnchor.MiddleCenter;
        Handles.Label(wayPoints[i].transform.position + Vector3.up * 0.7f, wayPoints[i].name, labelStyle);
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return wayPoints[index].transform.position;
    }


}
