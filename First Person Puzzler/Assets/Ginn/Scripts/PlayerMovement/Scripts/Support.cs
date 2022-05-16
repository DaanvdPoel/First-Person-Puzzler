using UnityEngine;

public class Support
{
    // draw a ray and a solid disc where needed
    static public void DrawRay(Vector3 position, Vector3 direction, Color color)
    {
        if (direction.sqrMagnitude > 0.001f)
        {
            Debug.DrawRay(position, direction, color);
            DrawSolidDisc(position + direction, color);
        }
    }

    static public void DrawLabel(Vector3 position, string label, Color color)
    {
        // draws a label at a certain position in the provided color
        UnityEditor.Handles.BeginGUI();
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.Label(position, label);
        UnityEditor.Handles.EndGUI();
    }

    static public void DrawSolidDisc(Vector3 position, Color color)
    {
        // draws a disc at a certain position in the provided color
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.DrawSolidDisc(position, Vector3.up, 0.25f);
    }
}
