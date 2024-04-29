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
        if (Input.GetMouseButtonUp(0))
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
                _image[1].color = new Color(210f/255f, 201 / 255f, 192 / 255f, 255);
                break;
            case 4:
                _image[1].color = new Color(229f/ 255f, 217f / 255f, 194f / 255f, 255);
                break;
            case 8:
                _image[1].color = new Color(228f/255f, 165f / 255f, 113f / 255f, 225);
                break;
            case 16:
                _image[1].color = new Color(238f / 255f, 143f / 255f, 96f / 255f, 225);
                break;
            case 32:
                _image[1].color = new Color(234f / 255f, 119f / 255f, 91f / 255f, 225);
                break;
            case 64:
                _image[1].color = new Color(238f / 255f, 90f / 255f, 59f / 255f, 225);
                break;
            case 128:
                _image[1].color = new Color(227f / 255f, 198f / 255f, 108f / 255f, 225);
                break;
            case 256:
                _image[1].color = new Color(232f / 255f, 99f / 255f, 96f / 255f, 225);
                break;
            case 512:
                _image[1].color = new Color(229f / 255f, 94f / 255f, 77f / 255f, 225);
                break;
            case 1024:
                _image[1].color = new Color(235f / 255f, 193f / 255f, 66f / 255f, 255);
                break;
            case 2048:
                _image[1].color = new Color(230f / 255f, 191f / 255f, 61f / 255f, 225);
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
