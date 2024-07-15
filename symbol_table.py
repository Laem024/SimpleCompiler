# symbol_table.py
class SymbolTable:
    def __init__(self):
        self.symbols = {}

    def add(self, name, value):
        self.symbols[name] = value

    def get(self, name):
        return self.symbols.get(name)

    def __str__(self):
        return str(self.symbols)

symbol_table = SymbolTable()
