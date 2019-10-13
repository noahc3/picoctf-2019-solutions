# Time's Up Again - 450 Points

This is nearly identical to Time's Up, however you have to solve the challenge in under 200 microseconds. Python is unable to solve this fast enough on the server.

Our solution is a .NET Core application which uses Jace.NET to evaluate the expression. C# is fast enough to solve the challenge.

A similar issue occurrs with this solution as in Time's Up. Jace.NET returns solutions as doubles, which trade off precision in favor of preventing overflowing/underflowing. This solution can take up to 20 seconds to get a lucky challenge that doesnt overflow/underflow. 