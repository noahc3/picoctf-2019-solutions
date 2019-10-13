# asm1 - 200 Points

The best way to solve the asm challenges is not actually to call functions with assembly, but instead with C.

GCC allows C code to seamlessly call assembly functions as if they were written in C. Just make sure they are tagged as global at the top of the assembly source files.

This solution puts the asm code provided by the challenge into chal.S and calls the function from main in solve.c.

You can build these solutions on an Ubuntu machine with the `build-essential` package by running the `make` command in the directory with the Makefile.