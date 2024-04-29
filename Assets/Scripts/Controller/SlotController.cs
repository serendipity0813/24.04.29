using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    private TextMeshProUGUI _numberText;
    int _line = 0;
    int _column = 0;
    string _objectName = "";

    private void Awake()
    {
        _numberText = GetComponentInChildren<TextMeshProUGUI>();
        _objectName = this.gameObject.name;
        _line = Int32.Parse(_objectName) / 4;
        _column = Int32.Parse(_objectName) % 4;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeNumber();
        }
    }

    private void ChangeNumber()
    {
        _numberText.text = GameManager.Instance.Numbers[_line, _column].ToString();
    }
}
