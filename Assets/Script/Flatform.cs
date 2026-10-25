using UnityEngine;

public class Flatform : MonoBehaviour
{
    private const float ArriveThresholdSqr = .1f * .1f;

    public Transform posA, posB;
    public int Speed;
    Vector2 targetPos;

    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        Vector2 position = transform.position;
        if (((Vector2)posA.position - position).sqrMagnitude < ArriveThresholdSqr) targetPos = posB.position;
        else if (((Vector2)posB.position - position).sqrMagnitude < ArriveThresholdSqr) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(position, targetPos, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        if (posA == null || posB == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
