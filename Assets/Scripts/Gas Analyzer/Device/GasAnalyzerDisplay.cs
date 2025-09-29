using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasAnalyzerDisplay : MonoBehaviour
{
    [SerializeField] private GasAnalyzerState _state;
    [SerializeField] private GameObject _displayCanvas;
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private Image _longPressIndicator;
    private float _longPressTargetState = 0;

    private void Awake()
    {
        _state.OnStateEnableEvent.AddListener(() => SetDisplayState(true));
        _state.OnStateDisableEvent.AddListener(() => SetDisplayState(false));
    }
    private void Update()
    {
        _longPressIndicator.fillAmount += _longPressTargetState / 3 * Time.deltaTime;
    }
    public void SetDisplayState(bool state)
    {
        _displayCanvas.SetActive(state);
    }

    public void UpdateCounterText(float value)
    {
        counterText.text = MathF.Round(value, 2).ToString();
    }

    public void ActivateLongPressIndicator()
    {
        _longPressIndicator.fillAmount = 0;
        _longPressTargetState = 1f;
    }
    public void DeativateLongPressIndicator()
    {
        _longPressIndicator.fillAmount = 0;
        _longPressTargetState = 0;
    }
}
