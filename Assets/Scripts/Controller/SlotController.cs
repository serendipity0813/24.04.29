using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    private TextMeshProUGUI _numberText;
    private Image[] _image;
    int _line = 0;
    int _column = 0;
    int _number = 0;
    string _objectName = "";

    private void Awake()
    {
        _numberText = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponentsInChildren<Image>();
        _objectName = this.gameObject.name;
        _line = Int32.Parse(_objectName) / 4;
        _column = Int32.Parse(_objectName) % 4;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _number = GameManager.Instance.Numbers[_line, _column];               
             ChangeNumber();
             ChangeColor();
                     
        }
    }

    private void ChangeColor()
    {
        switch(_number)
        {
            case 1:
                _image[1].color = new Color(0, 0, 0, 0);
                    break;
            case 2:
                _image[1].color = new Color(210, 201, 192, 255);
                break;
            case 4:
                _image[1].color = new Color(229, 217, 194, 255);
                break;
            case 8:
                _image[1].color = new Color(228, 165, 113, 225);
                break;
            case 16:
                _image[1].color = new Color(238, 143, 96, 225);
                break;
            case 32:
                _image[1].color = new Color(234, 119, 91, 225);
                break;
            case 64:
                _image[1].color = new Color(238, 90, 59, 225);
                break;
            case 128:
                _image[1].color = new Color(227, 198, 108, 225);
                break;
            case 256:
                _image[1].color = new Color(232, 99, 96, 225);
                break;
            case 512:
                _image[1].color = new Color(229, 94, 77, 225);
                break;
            case 1024:
                _image[1].color = new Color(235, 193, 66, 255);
                break;
            case 2048:
                _image[1].color = new Color(230, 191, 61, 225);
                break;
            default:
                _image[1].color = new Color(255, 255, 255, 255);
                break;
        }
    }

    private void ChangeNumber()
    {
        if (_number == 1)
            _numberText.text = "";
        else
            _numberText.text = _number.ToString();
    }
}
