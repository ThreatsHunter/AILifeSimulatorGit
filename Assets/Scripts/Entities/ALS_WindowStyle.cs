using UnityEngine;

public static class ALS_WindowStyle
{
    public static GUIStyle GetButtonStyle(GUIStyle _guiStyle, int _fontSize, Color _textColor, Color _normalColor)
    {
        GUIStyle _style = new GUIStyle(_guiStyle);
        _style.fontSize = _fontSize;
        _style.normal.textColor = _textColor;
        _style.hover.textColor = Color.green;
        _style.normal.background = GetTextureColor(_normalColor);
        _style.fontStyle = FontStyle.Bold;
        return _style;
    }
    public static GUIStyle GetLabelStyle(int _size, Color _color)
    {
        GUIStyle _style = new GUIStyle(GUI.skin.label);
        _style.fontSize = _size;
        _style.hover.textColor = _color;
        _style.fontStyle = FontStyle.Italic;
        return _style;
    }
    public static Texture2D GetTextureColor(Color _color)
    {
        Texture2D _t2d = new Texture2D(1, 1);
        _t2d.SetPixel(1, 1, _color);
        _t2d.Apply();
        return _t2d;
    }
}