
So **memoization and bottom-up have the same asymptotic complexity** here.

The big conceptual difference is:

- **Top-down:** start with the final problem and recursively discover the subproblems you need. **Top-down** avoids computing subproblems you do not need, but it carries recursive call stack overhead. 
- **Bottom-up:** explicitly solve the smaller states first and build toward the final answer. **Bottom-up** avoids stack overflow errors and is often faster in practice, but it forces you to solve all subproblems from the ground up.

