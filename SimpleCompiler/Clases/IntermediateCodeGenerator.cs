using System;
using System.Collections.Generic;
using System.Text;

public class IntermediateCodeGenerator
{
    public string GenerateCode(ASTNode node)
    {
        StringBuilder code = new StringBuilder();
        GenerateCode(node, code);
        Console.WriteLine("Generated Intermediate Code:\n" + code.ToString());
        return code.ToString();
    }

    private void GenerateCode(ASTNode node, StringBuilder code)
    {
        if (node == null)
            return;

        switch (node.Value)
        {
            case "Assignment":
                GenerateAssignmentCode(node, code);
                break;
            default:
                code.Append(node.Value);
                break;
        }

        foreach (var child in node.Children)
        {
            GenerateCode(child, code);
        }
    }

    private void GenerateAssignmentCode(ASTNode node, StringBuilder code)
    {
        if (node.Children.Count != 3)
            throw new Exception("Invalid assignment node structure.");

        code.Append(node.Children[0].Value);
        code.Append(" = ");
        GenerateCode(node.Children[2], code);
        code.Append(";\n");
    }
}
