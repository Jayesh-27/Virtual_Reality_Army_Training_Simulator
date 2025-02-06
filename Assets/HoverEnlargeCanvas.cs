using UnityEngine;

public class HoverEnlargeCanvas : MonoBehaviour
{
    // Set the target canvas and parameters
    public Canvas targetCanvas;
    public float enlargeSpeed = 0.02f;
    public Vector3 maxScale = new Vector3(1.5f, 1.5f, 1.5f);

    private Vector3 originalScale;
    private bool isHovering = false;

    void Start()
    {
        // Store the original scale of the canvas
        originalScale = targetCanvas.transform.localScale;
    }

    void Update()
    {
        // Check if hovering and gradually enlarge the canvas
        if (isHovering && targetCanvas.transform.localScale.x < maxScale.x)
        {
            EnlargeCanvas();
        }
    }

    // Called when the VR controller hovers over the canvas
    public void OnHoverEnter()
    {
        isHovering = true;
    }

    // Called when the VR controller stops hovering over the canvas
    public void OnHoverExit()
    {
        isHovering = false;
        // Reset the canvas scale when not hovering
        targetCanvas.transform.localScale = originalScale;
    }

    // Enlarge the canvas gradually
    void EnlargeCanvas()
    {
        Vector3 newScale = targetCanvas.transform.localScale + new Vector3(enlargeSpeed, enlargeSpeed, enlargeSpeed) * Time.deltaTime;
        // Clamp the scale to the maximum specified
        newScale = Vector3.Min(newScale, maxScale);
        targetCanvas.transform.localScale = newScale;
    }
}
