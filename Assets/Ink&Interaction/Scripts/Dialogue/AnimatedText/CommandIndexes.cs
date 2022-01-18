using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandIndexes
{
    private string tag;
    public string Tag => tag;
    private ITextEffect textEffectClass;
    public ITextEffect TextEffectClass => textEffectClass;

    public int firstIndex;
    public int lastIndex;
    public CommandIndexes(string _tag, ITextEffect _textEffectClass)
    {
        tag = _tag;
        textEffectClass = _textEffectClass;
    }
}
