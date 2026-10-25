using UnityEngine;

public class checkpointscript : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider2D checkPointCollider;

    void Awake()
    {
        checkPointCollider = GetComponent<BoxCollider2D>();
        GameObject respawnObject = GameObject.FindGameObjectWithTag("Respawn");
        if (respawnObject != null)
            respawn = respawnObject.GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (respawn != null && other.CompareTag("Player"))
        {
            respawn.respawnPoint = gameObject;
            checkPointCollider.enabled = false;
        }
    }
}
