
### There are two valid binary-search styles

This is probably where the confusion comes from.

**Style 1 — closed interval `[left, right]`:**

```
while (left <= right)
{
    if (valid(mid))
        right = mid - 1;
    else
        left = mid + 1;
}

return left;
```

Here, `right = mid - 1` **is correct**.

**Style 2 — shrinking interval with `left < right`:**

```
while (left < right)
{
    if (valid(mid))
        right = mid;
    else
        left = mid + 1;
}

return left;
```

Here, `right = mid` is correct.


> **If `mid` could still be the answer, keep it.**

If you've already determined that `mid` cannot be the answer, remove it with `mid - 1`.