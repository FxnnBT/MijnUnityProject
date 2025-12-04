using UnityEngine;
using UnityEngine.InputSystem;

public class click : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use the new Input System
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("click");
            var cam = Camera.main;
            if (cam != null)
            {
                Vector2 mouseScreen = Mouse.current.position.ReadValue();
                Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(mouseScreen.x, mouseScreen.y, cam.nearClipPlane));
                Vector2 origin = mouseWorld;

                RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log($"Clicked 2D object: {hit.collider.gameObject.name}");
                    // Optionally: interact with the hit object here
                }
            }
        }
    }
}
