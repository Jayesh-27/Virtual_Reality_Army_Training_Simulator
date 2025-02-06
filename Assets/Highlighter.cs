using UnityEngine;

public class Highlighter : MonoBehaviour
{
    private Canvas canvas;
    private Material originalMaterial;
    public Material highlightMaterial; // Set this material in the inspector

    private void Start()
    {
        canvas = GetComponent<Canvas>();

        // Assuming the Canvas has a GraphicRaycaster component
        if (canvas != null)
        {
            originalMaterial = canvas.GetComponent<CanvasRenderer>().GetMaterial();
        }
        else
        {
            Debug.LogError("Canvas component not found!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the VR controller or player's hand
        if (other.CompareTag("VRController"))
        {
            // Highlight the canvas when hovered
            HighlightCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the VR controller or player's hand
        if (other.CompareTag("VRController"))
        {
            // Remove the highlight when not hovered
            HighlightCanvas(false);
        }
    }

    private void HighlightCanvas(bool highlight)
    {
        if (canvas != null)
        {
            // Change the material to highlight or original based on the boolean value
            canvas.GetComponent<CanvasRenderer>().SetMaterial(highlight ? highlightMaterial : originalMaterial, 0);
        }
    }
}
