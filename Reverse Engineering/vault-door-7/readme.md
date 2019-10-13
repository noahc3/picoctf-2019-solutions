# vault-door-7 - 400 Points

This solution replicates the Java functionality in C# and brute-forces the solution.

The solution brute-forces 4 bytes at a time since the output checks against 8 32bit ints. This can take several minutes to brute force.

It's possible to write smarter solution that brute-forces one byte at a time and limits the possible inputs to valid characters that can be typed into the website, but I was lazy.