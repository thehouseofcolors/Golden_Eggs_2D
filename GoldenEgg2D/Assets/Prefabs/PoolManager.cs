// SpawnerConfig.cs

using UnityEditor;
using Unity;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    
    [SerializeField] public PoolManager _config; 
    [Header("Player Settings")]
    public Vector3 playerPos;
    public GameObject playerPrefab;

    [Header("Boundary Settings")]
    public Transform startLine;
    public Transform endLine;

    [Header("Tile Settings")]
    public int tilesPerRow = 3;
    public float tileLength = 2f;

    [Header("Spawning Settings")]
    public Transform groundParent;
    public Transform objectParent;
    public float spawnInterval = 1f;
    public bool autoStartSpawning;





    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (_config == null || _config.startLine == null || _config.endLine == null)
            return;

        DrawLaneGuides();
        DrawBoundaryMarkers();
    }

    private void DrawLaneGuides()
    {
        float startZ = _config.startLine.position.z;
        float endZ = _config.endLine.position.z;

        DrawLaneGuide(startZ, endZ, -_config.tileLength, Color.cyan); // Left
        DrawLaneGuide(startZ, endZ, 0f, Color.magenta);              // Center
        DrawLaneGuide(startZ, endZ, _config.tileLength, Color.cyan); // Right
    }

    private void DrawLaneGuide(float startZ, float endZ, float xPos, Color color)
    {
        Gizmos.color = color;
        Vector3 start = new Vector3(xPos, 0, startZ);
        Vector3 end = new Vector3(xPos, 0, endZ);

        Gizmos.DrawLine(start, end);

        // Draw directional arrows
        for (float z = startZ; z < endZ; z += 2f)
        {
            Vector3 pos = new Vector3(xPos, 0, z);
            Gizmos.DrawLine(pos, pos + new Vector3(0.2f, 0, 0.2f));
            Gizmos.DrawLine(pos, pos + new Vector3(-0.2f, 0, 0.2f));
        }
    }

    private void DrawBoundaryMarkers()
    {
        float startZ = _config.startLine.position.z;
        float endZ = _config.endLine.position.z;

        DrawBoundaryMarker(startZ, "START", Color.green);
        DrawBoundaryMarker(endZ, "END", Color.red);
    }

    private void DrawBoundaryMarker(float zPos, string label, Color color)
    {
        float halfWidth = _config.tileLength * 1.5f;
        Vector3 center = new Vector3(0, 0, zPos);

        Gizmos.color = color;
        Gizmos.DrawLine(center - Vector3.right * halfWidth, center + Vector3.right * halfWidth);

        // Draw boundary indicators
        Gizmos.DrawCube(center - Vector3.right * halfWidth, Vector3.one * 0.3f);
        Gizmos.DrawCube(center + Vector3.right * halfWidth, Vector3.one * 0.3f);

        // Label
        UnityEditor.Handles.Label(
            center - Vector3.right * (halfWidth + 1f),
            label,
            new GUIStyle { normal = new GUIStyleState { textColor = color } }
        );
    }
    #endif


}




