# shark on wire 2 - 300 Points

We found [this](https://2019shell1.picoctf.com/static/dcd259894e0efe9d6e91da2af47e6369/capture.pcap) packet capture. Recover the flag that was pilfered from the network.

This challenge is not as simple as most packet capture analysis challenges, and requires a bit of creative thinking.

First things first is to filter only TCP and UDP streams to see if we can find anything interesting in the data. Theres a lot of garbage here, including some "fake" flags in the UDP streams.

Importantly, there are two packets with "start" and "end" in the data, in which the packets between them have strange port numbers. Specifically packets coming from 10.0.0.66.
![](https://i.imgur.com/UWOXT6j.png) ![](https://imgur.com/6lGbk1u.png)

Ignoring the first digit, the port numbers are all printable ASCII characters
![](https://i.imgur.com/ieP4USb.png)

Converting those to ASCII gives you the flag: ![](https://imgur.com/lCAh07A.png)

<b>Flag: picoCTF{p1LLf3r3d_data_v1a_st3g0}</b>
