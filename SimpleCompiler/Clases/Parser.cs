using System;
using System.Collections.Generic;

public class ASTNode
{
    public string Value { get; set; }
    public List<ASTNode> Children { get; set; }

    public ASTNode(string value)
    {
        Value = value;
        Children = new List<ASTNode>();
    }
}

public class Parser
{
    private List<Token> _tokens;
    private int _position;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
        _position = 0;
    }

    public ASTNode Parse()
    {
        Console.WriteLine("Parsing started");
        return ParseStatement();
    }

    private ASTNode ParseStatement()
    {
        Console.WriteLine($"Parsing Statement at position {_position}");
        if (_position >= _tokens.Count)
        {
            throw new Exception("Unexpected end of input while parsing statement.");
        }

        ASTNode node = new ASTNode("Statement");

        if (_tokens[_position].Type == TokenType.Identifier)
        {
            ASTNode assignmentNode = new ASTNode("Assignment");
            assignmentNode.Children.Add(new ASTNode(_tokens[_position].Value));
            Console.WriteLine($"Identifier: {_tokens[_position].Value}");
            _position++;

            if (Match(TokenType.Operator, "="))
            {
                assignmentNode.Children.Add(new ASTNode("="));
                assignmentNode.Children.Add(ParseExpression());
/*
                if (Match(TokenType.Separator, ";"))
                {
                    node.Children.Add(assignmentNode);
                }
                else
                {
                    throw new Exception("Expected ';' at the end of the statement.");
                }*/
            }
            else
            {
                throw new Exception("Expected '=' after identifier.");
            }
        }
        else
        {
            throw new Exception("Expected an identifier at the beginning of the statement.");
        }

        return node;
    }

    private ASTNode ParseExpression()
    {
        Console.WriteLine($"Parsing Expression at position {_position}");
        ASTNode node = ParseTerm();

        while (_position < _tokens.Count && _tokens[_position].Type == TokenType.Operator && _tokens[_position].Value == "+")
        {
            Console.WriteLine($"Operator: {_tokens[_position].Value}");
            ASTNode operatorNode = new ASTNode(_tokens[_position].Value);
            _position++;
            operatorNode.Children.Add(node);
            operatorNode.Children.Add(ParseTerm());
            node = operatorNode;
        }

        return node;
    }

    private ASTNode ParseTerm()
    {
        Console.WriteLine($"Parsing Term at position {_position}");
        ASTNode node = ParseFactor();

        while (_position < _tokens.Count && _tokens[_position].Type == TokenType.Operator && _tokens[_position].Value == "*")
        {
            Console.WriteLine($"Operator: {_tokens[_position].Value}");
            ASTNode operatorNode = new ASTNode(_tokens[_position].Value);
            _position++;
            operatorNode.Children.Add(node);
            operatorNode.Children.Add(ParseFactor());
            node = operatorNode;
        }

        return node;
    }

    private ASTNode ParseFactor()
    {
        Console.WriteLine($"Parsing Factor at position {_position}");
        if (_position >= _tokens.Count)
        {
            throw new Exception("Unexpected end of input while parsing factor.");
        }

        Token token = _tokens[_position];
        ASTNode node;

        if (token.Type == TokenType.Number || token.Type == TokenType.Identifier)
        {
            Console.WriteLine($"Factor: {token.Value}");
            node = new ASTNode(token.Value);
            _position++;
        }
        else
        {
            throw new Exception("Unexpected token: " + token.Value);
        }

        return node;
    }

    private bool Match(TokenType type, string value = null)
    {
        if (_position < _tokens.Count && _tokens[_position].Type == type && (value == null || _tokens[_position].Value == value))
        {
            _position++;
            return true;
        }

        return false;
    }
}
