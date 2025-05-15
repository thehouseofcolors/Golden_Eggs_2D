using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GroundTile groundTile;
    public float moveSpeed = 2f;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    public void SetMoving(bool state) => isMoving = state;

    // Called when the tile needs to be recycled
    public void Recycle()
    {
        TileFactory.Instance.ReleaseGroundTile(groundTile.groundType, gameObject);
    }
}