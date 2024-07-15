# # parser.py
# import ply.yacc as yacc
# from lexer import tokens
# from symbol_table import symbol_table

# def p_statement_assign(p):
#     'statement : ID ASSIGN expression SEMICOLON'
#     p[0] = ('assign', p[1], p[3])
#     symbol_table.add(p[1], None)  # Añadimos la variable a la tabla de símbolos

# def p_statement_expr(p):
#     'statement : expression SEMICOLON'
#     p[0] = p[1]

# def p_expression_binop(p):
#     '''expression : expression PLUS expression
#                   | expression MINUS expression
#                   | expression TIMES expression
#                   | expression DIVIDE expression'''
#     p[0] = (p[2], p[1], p[3])

# def p_expression_group(p):
#     'expression : LPAREN expression RPAREN'
#     p[0] = p[2]

# def p_expression_number(p):
#     'expression : NUMBER'
#     p[0] = ('number', p[1])

# def p_expression_id(p):
#     'expression : ID'
#     p[0] = ('id', p[1])

# def p_error(p):
#     if p:
#         print(f"Syntax error at '{p.value}'")
#     else:
#         print("Syntax error at EOF")

# parser = yacc.yacc()




# parser.py
import ply.yacc as yacc
from lexer import tokens
from symbol_table import symbol_table

def p_statement_assign(p):
    'statement : ID ASSIGN expression SEMICOLON'
    p[0] = ('assign', p[1], p[3])
    symbol_table.add(p[1], None)  # Añadimos la variable a la tabla de símbolos

def p_statement_expr(p):
    'statement : expression SEMICOLON'
    p[0] = p[1]

def p_expression_binop(p):
    '''expression : expression PLUS expression
                  | expression MINUS expression
                  | expression TIMES expression
                  | expression DIVIDE expression'''
    p[0] = (p[2], p[1], p[3])

def p_expression_group(p):
    'expression : LPAREN expression RPAREN'
    p[0] = p[2]

def p_expression_number(p):
    'expression : NUMBER'
    p[0] = ('number', p[1])

def p_expression_id(p):
    'expression : ID'
    p[0] = ('id', p[1])

def p_error(p):
    if p:
        raise SyntaxError(f"Error de sintaxis en '{p.value}' en la línea {p.lineno}")
    else:
        raise SyntaxError("Error de sintaxis al final del archivo")

parser = yacc.yacc()
