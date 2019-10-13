#! /usr/bin/env python2

from pwn import *

while True:
    try:
        p = process("./times-up")
        p.recvuntil('Challenge: ')
        solve = p.recvuntil('\n')
        solution = eval(solve)
        print(solution)
        p.sendline(str(solution))
        print(p.recvuntil('}'))
        p.close()
    except EOFError:
        p.close()