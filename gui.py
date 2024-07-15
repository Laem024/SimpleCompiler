# gui.py
import tkinter as tk
from tkinter import scrolledtext
from main import run_compiler

def run_and_display_results():
    code = code_text.get("1.0", tk.END)
    outputs = run_compiler(code)
    
    tokens_output.delete("1.0", tk.END)
    tokens_output.insert(tk.END, outputs["tokens"])
    
    parse_tree_output.delete("1.0", tk.END)
    parse_tree_output.insert(tk.END, outputs["parse_tree"])
    
    intermediate_code_output.delete("1.0", tk.END)
    intermediate_code_output.insert(tk.END, outputs["intermediate_code"])
    
    symbol_table_output.delete("1.0", tk.END)
    symbol_table_output.insert(tk.END, outputs["symbol_table"])

root = tk.Tk()
root.title("Simple Compiler")

# Frame for code input
code_frame = tk.Frame(root)
code_frame.pack(side=tk.TOP, fill=tk.BOTH, expand=True)
tk.Label(code_frame, text="Source Code").pack()
code_text = scrolledtext.ScrolledText(code_frame, height=10)
code_text.pack(fill=tk.BOTH, expand=True)

# Run button
run_button = tk.Button(root, text="Run Compiler", command=run_and_display_results)
run_button.pack()

# Frame for outputs
output_frame = tk.Frame(root)
output_frame.pack(side=tk.BOTTOM, fill=tk.BOTH, expand=True)

# Token output
tk.Label(output_frame, text="Tokens").grid(row=0, column=0)
tokens_output = scrolledtext.ScrolledText(output_frame, height=10, width=30)
tokens_output.grid(row=1, column=0)

# Parse tree output
tk.Label(output_frame, text="Parse Tree").grid(row=0, column=1)
parse_tree_output = scrolledtext.ScrolledText(output_frame, height=10, width=30)
parse_tree_output.grid(row=1, column=1)

# Intermediate code output
tk.Label(output_frame, text="Intermediate Code").grid(row=0, column=2)
intermediate_code_output = scrolledtext.ScrolledText(output_frame, height=10, width=30)
intermediate_code_output.grid(row=1, column=2)

# Symbol table output
tk.Label(output_frame, text="Symbol Table").grid(row=0, column=3)
symbol_table_output = scrolledtext.ScrolledText(output_frame, height=10, width=30)
symbol_table_output.grid(row=1, column=3)

root.mainloop()
