using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{

    public TextMeshProUGUI tiptext;
    public RectTransform window;

    public static Action<String, Vector2> OnMouseHover;
    public static Action OnMouseLeave;


    #region Unity_funcs
    // Start is called before the first frame update
    void Start()
    {
        HideTip();
    }
    #endregion

    #region Enablement
    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLeave += HideTip;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseLeave -= HideTip;
    }
    #endregion

    #region Tool_tip
    private void ShowTip(String tip, Vector2 loc)
    {
        tiptext.text = tip;
        window.sizeDelta = new Vector2(tiptext.preferredWidth> 200? 200: tiptext.preferredWidth, tiptext.preferredHeight);
        window.gameObject.SetActive(true);
        window.transform.position = new Vector2(loc.x + window.sizeDelta.x * 2, loc.y);
    }

    private void HideTip()
    {
        tiptext.text = default;
        window.gameObject.SetActive(false);
    }
    #endregion

}
