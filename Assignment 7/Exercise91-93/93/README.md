## Exercise 9.3

The problem with the implementation was that the queue effectively became a sliding window over a continuously growing linked list. `put()` moved the window forward at `tail`, and `get()` moved it forward at `head`, but the nodes behind the window were never collected.
The reason for that was that `dummy` kept a reference to the original sentinel node, and since every node's `next` points to the following node, every node ever inserted was still reachable through `dummy`.

The threads in `runThreads` had a reference to the `SentinelLockQueue`, which in turn had a reference to `dummy`, so none of them could be garbage collected. Memory use therefore grew proportionally with total number of `put()` calls rather than with the current size of the queue.
The fix was then to remove the field and create the sentinel in the constructor instead, so only `head` refers to it.
The result is that the original sentinel becomes eligible for garbage collection at the first `get()`, and likewise every following `get()` makes the previous sentinel unreachable, so the list behind `head` no longer survives.

Note:
I had a hard time replicating the issue as described the first time around and increasing the amount of iterations made it take ages.
I instead opted to limit the ram available to the JVM by running tests with `java -Xmx256m QueueWithMistake`, which clearly indicated if the issue was fixed or not, in a much shorter timeframe. 