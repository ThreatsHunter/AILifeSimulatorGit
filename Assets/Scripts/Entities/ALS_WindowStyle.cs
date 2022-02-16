using UnityEngine;

public static class ALS_WindowStyle
{
    public static GUIStyle GetButtonStyle(GUIStyle _button, int _fontSize, Color _textColor, Color _normalColor, FontStyle _style = FontStyle.Normal)
    {
        GUIStyle _guiStyle = new GUIStyle(_button);
        _guiStyle.fontSize = _fontSize;
        _guiStyle.normal.textColor = _textColor;
        _guiStyle.hover.textColor = Color.green;
        _guiStyle.normal.background = GetTextureColor(_normalColor);
        _guiStyle.fontStyle = _style;
        return _guiStyle;
    }
    public static GUIStyle GetLabelStyle(int _size, Color _color, FontStyle _style = FontStyle.Normal)
    {
        GUIStyle _guiStyle = new GUIStyle(GUI.skin.label);
        _guiStyle.fontSize = _size;
        _guiStyle.hover.textColor = _color;
        _guiStyle.fontStyle = _style;
        return _guiStyle;
    }
    public static Texture2D GetTextureColor(Color _color)
    {
        Texture2D _t2d = new Texture2D(1, 1);
        _t2d.SetPixel(1, 1, _color);
        _t2d.Apply();
        return _t2d;
    }
}