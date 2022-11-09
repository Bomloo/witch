using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    public string tipToShow;
    private float timeToWait = .5f;


    #region Pointer_funcs
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        ToolTipManager.OnMouseLeave();
    }
    
    public void ShowMessage()
    {
        ToolTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);

        ShowMessage();
    }

    #endregion
}
