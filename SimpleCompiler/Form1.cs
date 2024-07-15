using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtSourceCode.Text;

                Lexer lexer = new Lexer(input);
                List<Token> tokens = lexer.Tokenize();

                txtTokens.Text = string.Join(Environment.NewLine, tokens.ConvertAll(token => $"{token.Type}: {token.Value}"));

                // Depuración
                Console.WriteLine("Tokens generados:");
                foreach (var token in tokens)
                {
                    Console.WriteLine($"{token.Type}: {token.Value}");
                }

                Parser parser = new Parser(tokens);
                ASTNode ast = parser.Parse();

                SymbolTable symbolTable = new SymbolTable();
                foreach (var token in tokens)
                {
                    if (token.Type == TokenType.Identifier)
                    {
                        symbolTable.AddSymbol(token.Value, "Variable");
                    }
                }

                txtSymbolTable.Text = symbolTable.ToString();

                IntermediateCodeGenerator codeGenerator = new IntermediateCodeGenerator();
                string code = codeGenerator.GenerateCode(ast);

                txtIntermediateCode.Text = code;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
