using System;
using System.Collections.Generic;

public class SymbolTable
{
    private Dictionary<string, string> _symbols;

    public SymbolTable()
    {
        _symbols = new Dictionary<string, string>();
    }

    public void AddSymbol(string name, string type)
    {
        if (!_symbols.ContainsKey(name))
        {
            _symbols[name] = type;
        }
    }

    public bool Contains(string name)
    {
        return _symbols.ContainsKey(name);
    }

    public string? GetSymbolType(string name)
    {
        return _symbols.ContainsKey(name) ? _symbols[name] : null;
    }

    public override string ToString()
    {
        string result = "";
        foreach (var symbol in _symbols)
        {
            result += $"{symbol.Key}: {symbol.Value}\n";
        }
        return result;
    }
}
