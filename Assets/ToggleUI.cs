using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public CanvasGroup uiCanvasGroup;

    public void ToggleVisibility()
    {
        uiCanvasGroup.alpha = (uiCanvasGroup.alpha == 0) ? 1 : 0;
        uiCanvasGroup.interactable = !uiCanvasGroup.interactable;
        uiCanvasGroup.blocksRaycasts = !uiCanvasGroup.blocksRaycasts;
    }
}
