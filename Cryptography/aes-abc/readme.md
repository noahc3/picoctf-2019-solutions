# AES-ABC - 400 Points

This challenge takes an input PPM image file, encrypts it with AES-ECB, then "encrypts" it with a custom-rolled "AES" called "AES-ABC".

A quick check on Wikipedia regarding AES shows that AES-ECB is fairly insecure and is typically prone to leaking plaintext data when the dataset is large enough:

![](https://puu.sh/ErVUb/dc52a11d46.png)

The solution is simple, reverse the ABC cipher applied to the image to get it in ECB form, the just open the image. The flag will be visible enough to solve the challenge.