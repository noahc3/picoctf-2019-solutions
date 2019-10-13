# Forky - 500 Points

This is a simple challenge that basically tests if you can Google how to use gdb.

The challenge splits the running process four times, creating a number of child processes. All you have to do is follow down the chain and view the doNothing parameter of the last child.

Solution:

```
gdb ./vuln
set follow-fork-mode child
break doNothing
r
info reg
```

The flag is the signed integer representation of the EAX register.

It's a mystery why this was worth 500 points... ¯\\\_(ツ)\_/¯