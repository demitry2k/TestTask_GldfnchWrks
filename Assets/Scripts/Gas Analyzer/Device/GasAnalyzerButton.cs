using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasAnalyzerButton : MonoBehaviour
{
    [SerializeField] private GasAnalyzerState _gasAnalyzerState;
    [SerializeField] private GasAnalyzerDisplay _gasAnalyzerDisplay;
    [SerializeField] private Renderer _renderer;
    private bool _alreadyPressed = false;
    private void OnTriggerStay(Collider other)
    {
        ContactFinger contactFinger = null;
        if (other.tag == "ContactFinger" && other.TryGetComponent<ContactFinger>(out contactFinger))
        {
            if (contactFinger.IsPressed)
            {
                if (!_alreadyPressed)
                {
                    _renderer.enabled = true;
                    OnLongPressStart();
                }
            }
            else
            {
                _renderer.enabled = false;
                OnLongPressEnd();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ContactFinger contactFinger = null;
        if (other.tag == "ContactFinger" && other.TryGetComponent<ContactFinger>(out contactFinger))
        {
            _renderer.enabled = false;
            OnLongPressEnd();
        }
    }


    private void OnLongPressStart()
    {
        _gasAnalyzerDisplay.ActivateLongPressIndicator();
        _alreadyPressed = true;
        StartCoroutine(LongPressCoroutine());
    }

    private void OnLongPressEnd()
    {
        _gasAnalyzerDisplay.DeativateLongPressIndicator();
        _alreadyPressed = false;
        StopAllCoroutines();
    }

    private IEnumerator LongPressCoroutine()
    {
        yield return new WaitForSeconds(3f);
        _gasAnalyzerState.SwitchState();
        _gasAnalyzerDisplay.DeativateLongPressIndicator();
    }
}
