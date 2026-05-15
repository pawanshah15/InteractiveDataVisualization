using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicker : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;

    [SerializeField]
    private float interactDistance = 3f;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Ray ray = new Ray(
                m_Camera.transform.position,
                m_Camera.transform.forward
            );

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                Debug.Log(
                    "Interacted with: " +
                    hit.collider.gameObject.name
                );

                GOInteraction aGOI =
                    hit.collider.gameObject
                    .GetComponent<GOInteraction>();

                if (aGOI)
                {
                    aGOI.Interaction = true;
                }
            }
        }
    }
}