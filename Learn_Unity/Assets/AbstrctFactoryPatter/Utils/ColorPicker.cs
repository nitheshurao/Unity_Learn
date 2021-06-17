using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : SingletonBase<ColorPicker>
{
    [SerializeField] private List<ColorData> _colorDatas;
    private Dictionary<ColorCode, Color> _colorMapper;

    private void Awake()
    {
        _colorMapper = new Dictionary<ColorCode, Color>();

        for (int i = 0; i < _colorDatas.Count; i++)
        {
            _colorMapper.Add(_colorDatas[i].ColorCode, _colorDatas[i].Color);
        }
    }

    public Color GetColor(ColorCode colorCode)
    {
        return _colorMapper[colorCode];
    }
}

[System.Serializable]
public class ColorData
{
    public ColorCode ColorCode;
    public Color Color;
}

public enum ColorCode
{
    Blue,
    Green,
    Orange,
    Red,
    Black,
    White,
    Magenta,
    Grey01,Grey02,Grey03,
    Black01
};

