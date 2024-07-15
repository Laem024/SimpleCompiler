# # main.py
# from lexer import lexer
# from parser import parser
# from symbol_table import symbol_table
# from intermediate_code import generate_code

# def run_compiler(data):
#     lexer.input(data)
    
#     tokens_output = []
#     while True:
#         tok = lexer.token()
#         if not tok:
#             break
#         tokens_output.append(str(tok))
    
#     try:
#         result = parser.parse(data)
#         intermediate_code, _ = generate_code(result)
#         intermediate_code_output = "\n".join(intermediate_code)
#         symbol_table_output = str(symbol_table)
#         parse_tree_output = str(result)
#         syntax_errors = ""
#     except Exception as e:
#         intermediate_code_output = ""
#         symbol_table_output = ""
#         parse_tree_output = ""
#         syntax_errors = str(e)
    
#     return {
#         "tokens": "\n".join(tokens_output),
#         "parse_tree": parse_tree_output,
#         "intermediate_code": intermediate_code_output,
#         "symbol_table": symbol_table_output,
#         "syntax_errors": syntax_errors
#     }

# if __name__ == "__main__":
#     with open('examples/example_code.txt', 'r') as file:
#         data = file.read()
#     outputs = run_compiler(data)
#     for key, value in outputs.items():
#         print(f"{key}:\n{value}\n")



# main.py
from lexer import lexer
from parser import parser
from symbol_table import symbol_table
from intermediate_code import generate_code

def run_compiler(data):
    lexer.input(data)
    
    tokens_output = []
    while True:
        tok = lexer.token()
        if not tok:
            break
        tokens_output.append(str(tok))
    
    try:
        result = parser.parse(data)
        intermediate_code, _ = generate_code(result)
        intermediate_code_output = "\n".join(intermediate_code)
        symbol_table_output = str(symbol_table)
        parse_tree_output = str(result)
        syntax_errors = ""
    except SyntaxError as e:
        intermediate_code_output = ""
        symbol_table_output = ""
        parse_tree_output = ""
        syntax_errors = str(e)
    
    return {
        "tokens": "\n".join(tokens_output),
        "parse_tree": parse_tree_output,
        "intermediate_code": intermediate_code_output,
        "symbol_table": symbol_table_output,
        "syntax_errors": syntax_errors
    }

if __name__ == "__main__":
    with open('examples/example_code.txt', 'r') as file:
        data = file.read()
    outputs = run_compiler(data)
    for key, value in outputs.items():
        print(f"{key}:\n{value}\n")
