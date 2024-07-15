using System;
using System.Collections.Generic;

public enum TokenType
{
    Identifier,
    Number,
    Operator,
    Separator
}

public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}

public class Lexer
{
    private string _input;
    private int _position;
    private List<Token> _tokens;

    public Lexer(string input)
    {
        _input = input;
        _tokens = new List<Token>();
    }

    public List<Token> Tokenize()
    {
        while (_position < _input.Length)
        {
            if (char.IsWhiteSpace(_input[_position]))
            {
                _position++;
            }
            else if (char.IsLetter(_input[_position]))
            {
                TokenizeIdentifier();
            }
            else if (char.IsDigit(_input[_position]))
            {
                TokenizeNumber();
            }
            else if ("=+*;".Contains(_input[_position]))
            {
                TokenizeOperator();
            }
            else
            {
                throw new Exception($"Unexpected character: {_input[_position]}");
            }
        }

        // Depuración
        foreach (var token in _tokens)
        {
            Console.WriteLine($"Token: {token.Type} - {token.Value}");
        }

        return _tokens;
    }

    private void TokenizeIdentifier()
    {
        int start = _position;
        while (_position < _input.Length && char.IsLetterOrDigit(_input[_position]))
        {
            _position++;
        }
        string identifier = _input.Substring(start, _position - start);
        _tokens.Add(new Token(TokenType.Identifier, identifier));
        Console.WriteLine($"Tokenized Identifier: {identifier}");
    }

    private void TokenizeNumber()
    {
        int start = _position;
        while (_position < _input.Length && char.IsDigit(_input[_position]))
        {
            _position++;
        }
        string number = _input.Substring(start, _position - start);
        _tokens.Add(new Token(TokenType.Number, number));
        Console.WriteLine($"Tokenized Number: {number}");
    }

    private void TokenizeOperator()
    {
        char op = _input[_position];
        _tokens.Add(new Token(TokenType.Operator, op.ToString()));
        _position++;
        Console.WriteLine($"Tokenized Operator: {op}");
    }
}
