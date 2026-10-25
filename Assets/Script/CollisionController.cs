using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Debug-only logging: stripped from release builds and no longer spams the console every physics step.
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    private static void Log(Collision2D collision, string message)
    {
        if (collision.gameObject.name == "box")
            Debug.Log(message);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Log(collision, "enter");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Log(collision, "exit");
    }
}
