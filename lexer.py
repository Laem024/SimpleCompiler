# # lexer.py
# import ply.lex as lex

# tokens = (
#     'NUMBER',
#     'PLUS',
#     'MINUS',
#     'TIMES',
#     'DIVIDE',
#     'LPAREN',
#     'RPAREN',
#     'ID',
#     'ASSIGN',
# )

# t_PLUS = r'\+'
# t_MINUS = r'-'
# t_TIMES = r'\*'
# t_DIVIDE = r'/'
# t_LPAREN = r'\('
# t_RPAREN = r'\)'
# t_ASSIGN = r'='

# def t_NUMBER(t):
#     r'\d+'
#     t.value = int(t.value)
#     return t

# def t_ID(t):
#     r'[a-zA-Z_][a-zA-Z0-9_]*'
#     return t

# t_ignore = ' \t'

# def t_newline(t):
#     r'\n+'
#     t.lexer.lineno += len(t.value)

# def t_error(t):
#     print(f"Illegal character '{t.value[0]}'")
#     t.lexer.skip(1)

# lexer = lex.lex()




# lexer.py
import ply.lex as lex

tokens = (
    'NUMBER',
    'PLUS',
    'MINUS',
    'TIMES',
    'DIVIDE',
    'LPAREN',
    'RPAREN',
    'ID',
    'ASSIGN',
    'SEMICOLON',
)

t_PLUS = r'\+'
t_MINUS = r'-'
t_TIMES = r'\*'
t_DIVIDE = r'/'
t_LPAREN = r'\('
t_RPAREN = r'\)'
t_ASSIGN = r'='
t_SEMICOLON = r';'

def t_NUMBER(t):
    r'\d+'
    t.value = int(t.value)
    return t

def t_ID(t):
    r'[a-zA-Z_][a-zA-Z0-9_]*'
    return t

t_ignore = ' \t'

def t_newline(t):
    r'\n+'
    t.lexer.lineno += len(t.value)

def t_error(t):
    print(f"Illegal character '{t.value[0]}'")
    t.lexer.skip(1)

lexer = lex.lex()
