# intermediate_code.py
from symbol_table import symbol_table

temp_counter = 0

def new_temp():
    global temp_counter
    temp_counter += 1
    return f'temp{temp_counter}'

def generate_code(tree):
    code = []
    if tree[0] == 'assign':
        _, name, expr = tree
        expr_code, result = generate_code(expr)
        symbol_table.add(name, result)
        code.extend(expr_code)
        code.append(f'{name} = {result}')
    elif tree[0] in ('+', '-', '*', '/'):
        op, left, right = tree
        left_code, left_result = generate_code(left)
        right_code, right_result = generate_code(right)
        result = new_temp()
        code.extend(left_code)
        code.extend(right_code)
        code.append(f'{result} = {left_result} {op} {right_result}')
    elif tree[0] == 'number':
        result = str(tree[1])
    elif tree[0] == 'id':
        result = tree[1]

    return code, result

def print_code(intermediate_code):
    for line in intermediate_code:
        print(line)
