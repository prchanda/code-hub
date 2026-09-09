DP usually becomes easier when we think backward:

"What is the best answer I already know before reaching i?"

When defining dp[i], ask:

"If I stop at position i, what complete question has dp[i] already answered?"

And that's why the transition works in house robber problem:

dp[i] = max(
    dp[i-1],                      // don't rob i
    dp[i-2] + nums[i]      // rob i
)

Because both dp[i-1] and dp[i-2] are already solved subproblems.

dp[i] = the maximum money we can rob from houses 0 through i, without robbing two adjacent houses.

That's our state definition.

######################################################################################################################################

### 🔥 Golden rule for DP direction

Don't memorize "Game DP goes backwards."

Instead ask:

> **What states does my current state depend on?**

If:

```
dp[i] → dp[i-1], dp[i-2]
```

➡️ calculate **forward**.

If:

```
dp[i] → dp[i+1], dp[i+2]
```

➡️ calculate **backward**.

That's the real rule.


### **Lessons**

1. In two-player optimal games, instead of tracking both players' scores, often track the score difference from the perspective of whoever's turn it is. This is a very important game-DP pattern
2. Bottom-up approach logic is same as recursive version, except return statements in recursive version should be replaced with `continue` statement in bottom-up approach as execution is moved forward skipping rest of the code, meeting some boundary condition. Recursive function calls should be replaced by saving the states in bottom-up approach. 

