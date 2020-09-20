using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStageText : MonoBehaviour
{
    public Text uiText;

    private void FixedUpdate()
    {
        uiText.text = $"{StageManager.Instance.CurrentStage}";
    }
}
