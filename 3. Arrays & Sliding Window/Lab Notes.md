### Array-specific questions

**A. Is this asking about a contiguous range?**

Words to notice:

- subarray
- substring
- consecutive
- contiguous
- window
- range

If YES → immediately think:

> **Sliding Window / Prefix Sum / Monotonic Queue**

---

**B. Do I need to find a pair/triplet?**

Think:

> **HashSet / HashMap / Two Pointers / Sorting**

---

**C. Is the question asking for maximum/minimum sum over a contiguous range?**

Think:

> **Kadane / Sliding Window**

---

**D. Is there a "next greater/smaller" relationship?**

Think:

> **Monotonic Stack**

---

**E. Are intervals involved?**

Think:

> **Sort + Merge / Sweep Line**


# The BIGGEST Sliding Window recognition trick

This is the sentence I want you to install:

> **"I need something about a contiguous range, and I can maintain some property while moving left/right."**

That's Sliding Window.

## Pattern A — Variable-size window

Example:

> Longest substring without repeating characters

You don't know the window size.

You expand `right` until the window becomes invalid.

Then move `left` until valid again.

```
valid → valid → valid → INVALID
                      ↑
                     right

then

          left →
```

Typical structure:

```
for (int right = 0; right < n; right++)
{
    // add right

    while (window is invalid)
    {
        // remove left
        left++;
    }

    // update answer
}
```

### Trigger words

Look for:

- longest
- shortest
- maximum length
- minimum length
- at most K
- at least K
- no duplicates
- contains all required characters

---

# 4. Pattern B — Fixed-size window

Example:

> Maximum sum of subarray of size K

Window is always:

```
K
```

So:

```
[1 2 3] 4 5
    ↓
1 [2 3 4] 5
```

Instead of recalculating:

```
sum = arr[i] + arr[i+1] + arr[i+2]
```

every time, do:

```
newSum = oldSum
         - outgoing
         + incoming
```

This is the essence of sliding window.


```                 ARRAY
                   │
       ┌───────────┴───────────┐
       │                       │
   CONTIGUOUS?              MULTIPLE ELEMENTS?
       │                       │
       ├── Longest/Shortest    ├── Pair/Triplet
       │       ↓               │       ↓
       │   Sliding Window      │   Two Pointers
       │                       │
       ├── Fixed window        ├── Before + After
       │       ↓               │       ↓
       │   Monotonic Deque     │   Prefix/Suffix
       │
       ├── Exact Sum
       │       ↓
       │   Prefix Sum + Map
       │
       └── Maximum Sum
               ↓
             Kadane

Intervals → Sort + Greedy
```



| LC      | Problem                             | Pattern                                     |
| ------- | ----------------------------------- | ------------------------------------------- |
| **3**   | Longest Substring Without Repeating | **Variable Sliding Window + HashSet**       |
| **76**  | Minimum Window Substring            | **Variable Sliding Window + Frequency Map** |
| **560** | Subarray Sum Equals K               | **Prefix Sum + HashMap**                    |
| **239** | c                                   | **Fixed Sliding Window + Monotonic Deque**  |
| **53**  | Maximum Subarray                    | **Kadane's Algorithm**                      |
| **15**  | 3Sum                                | **Sort + Two Pointers**                     |
| **238** | Product Except Self                 | **Prefix/Suffix**                           |
| **56**  | Merge Intervals                     | **Sort + Greedy Scan**                      |