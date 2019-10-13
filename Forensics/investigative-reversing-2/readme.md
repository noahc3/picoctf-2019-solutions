# Investigative Reversing 2 - 350 Points

This challenge has the flag encoded into the image file using "least significant bit encoding". This encoding sets only the least significant bit in a byte of the image file to a bit of a text string. This causes effectively no noticable effect to the original image.

The solution takes the least significant bits from the image starting at the encoded offset (found using Ghidra on the challenge binary) and converts it back to text to get the flag.