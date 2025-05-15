using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour
{
    [Header("Boundary Settings")]
    public Transform startLine;  // Drag your starting line object here
    public Transform endLine;    // Drag your ending line object here
    public float spawnInterval = 1f;

    [Header("Tile Settings")]
    public int tilesPerRow = 3;
    public float tileLength = 2f;

    [Header("References")]
    public bool autoStartSpawning = false;

    private Coroutine spawningCoroutine;
    private bool isSpawning = false;

    void Start()
    {
        if (autoStartSpawning)
        {
            StartSpawning();
        }
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            spawningCoroutine = StartCoroutine(SpawnTilesContinuously());
        }
    }

    public void StopSpawning()
    {
        if (isSpawning)
        {
            isSpawning = false;
            if (spawningCoroutine != null)
            {
                StopCoroutine(spawningCoroutine);
            }
        }
    }

    IEnumerator SpawnTilesContinuously()
    {
        // Initialize spawn position at start line
        float nextSpawnZ = startLine.position.z;
        
        while (isSpawning)
        {
            SpawnTileRow();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnTileRow()
    {
        for (int i = 0; i < tilesPerRow; i++)
        {
            float xPos = i * tileLength - tileLength * (tilesPerRow - 1) / 2f;
            Vector3 spawnPos = new Vector3(xPos, 0, startLine.position.z);
            
            GameObject tile = TileFactory.Instance.GetGroundTile(GroundType.grn_1);
            tile.transform.position = spawnPos;
            tile.GetComponent<GroundController>().SetMoving(true);
        }
    }


    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (startLine != null && endLine != null)
        {
            // Calculate the three lane positions
            float leftLane = -tileLength;   // Left tile position (-2 units)
            float centerLane = 0f;          // Center tile position
            float rightLane = tileLength;    // Right tile position (+2 units)

            // Draw three parallel guide lines from start to end
            DrawLaneGuide(startLine.position.z, endLine.position.z, leftLane, Color.cyan);
            DrawLaneGuide(startLine.position.z, endLine.position.z, centerLane, Color.magenta);
            DrawLaneGuide(startLine.position.z, endLine.position.z, rightLane, Color.cyan);

            // Draw start/end markers
            DrawBoundaryMarkers(startLine.position.z, "START", Color.green);
            DrawBoundaryMarkers(endLine.position.z, "END", Color.red);
        }
    }

    void DrawLaneGuide(float startZ, float endZ, float xPos, Color color)
    {
        Gizmos.color = color;
        Vector3 startPos = new Vector3(xPos, 0, startZ);
        Vector3 endPos = new Vector3(xPos, 0, endZ);
        
        // Main guide line
        Gizmos.DrawLine(startPos, endPos);
        
        // Add arrow indicators every 2 units
        for (float z = startZ; z < endZ; z += 2f)
        {
            Vector3 arrowPos = new Vector3(xPos, 0, z);
            Gizmos.DrawLine(arrowPos, arrowPos + new Vector3(0.2f, 0, 0.2f));
            Gizmos.DrawLine(arrowPos, arrowPos + new Vector3(-0.2f, 0, 0.2f));
        }
    }

    void DrawBoundaryMarkers(float zPos, string label, Color color)
    {
        float halfWidth = tileLength * 1.5f; // 3 tiles wide (1.5 each side)
        
        Gizmos.color = color;
        Gizmos.DrawLine(
            new Vector3(-halfWidth, 0, zPos),
            new Vector3(halfWidth, 0, zPos)
        );
        
        // Label
        UnityEditor.Handles.Label(
            new Vector3(-halfWidth - 1f, 0, zPos), 
            label, 
            new GUIStyle() { normal = new GUIStyleState() { textColor = color } }
        );
        
        // Boundary indicators
        Gizmos.DrawCube(new Vector3(-halfWidth, 0, zPos), Vector3.one * 0.3f);
        Gizmos.DrawCube(new Vector3(halfWidth, 0, zPos), Vector3.one * 0.3f);
    }
    #endif

}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(GroundSpawner))]
public class GroundSpawnerEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Test Spawn Row"))
        {
            ((GroundSpawner)target).SpawnTileRow();
        }
    }
}
#endif