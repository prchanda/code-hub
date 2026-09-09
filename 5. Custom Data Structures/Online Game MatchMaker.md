### Problem

You are given a `Player` class and a `GameServer` class:

```csharp
public class Player
{
    public int GetRating();
}

public class GameServer
{
    public void StartGame(Player player1, Player player2);
}
```

Implement a `MatchMaker` class that maintains a pool of players waiting to start a game.

```csharp
public class MatchMaker
{
    public MatchMaker(int maxDifference, GameServer gameServer);

    public void AddPlayer(Player player);
}
```

### Requirements

When a new player joins:

1. Check whether there is already a waiting player whose skill rating differs from the new player's rating by **at most `maxDifference`**.
    
2. If one or more valid players exist, immediately match the new player with the **closest-rated waiting player**.
    
3. Call:
    

```csharp
gameServer.StartGame(player1, player2);
```

4. Remove both matched players from the waiting pool.
    
5. If there is no valid opponent, add the new player to the waiting pool.
    
6. Players with the same rating are allowed.
    
7. The match should happen immediately; **do not wait for a globally optimal future match**.
    

### Example

Suppose:

```text
maxDifference = 10
```

Waiting players:

```text
Rating: 80, 95, 105, 120
```

A new player with rating:

```text
100
```

joins.

Valid opponents are:

```text
95  → difference = 5
105 → difference = 5
```

Therefore, either `95` or `105` can be selected (depending on the tie-breaking rule).

If the waiting players were:

```text
80, 96, 110, 120
```

then:

```text
|100 - 96|  = 4
|100 - 110| = 10
```

So the player with rating **96** must be selected.

### Follow-up

Design the data structure so that finding the closest waiting player is efficient.

**Hint:** For a new rating `R`, the closest waiting player must be either:

- `Floor(R)` — the largest rating ≤ `R`
    
- `Ceiling(R)` — the smallest rating ≥ `R`
    

Compare the distance to these two candidates and select the closer one.

### Expected complexity

With a balanced ordered tree supporting `Floor`, `Ceiling`, insertion, and deletion:

```text
AddPlayer: O(log N)
Space:     O(N)
```

where `N` is the number of players currently waiting.

### Interview discussion

Clarify with the interviewer:

> "Should I match with any player within the allowed rating difference, or must I always select the closest-rated player?"

If **any valid player** is acceptable, a simpler ordered-set/range approach works.

If **closest match is required**, use predecessor + successor.



```cs
// --- Mocking the provided classes for context ---
public class Player
{
    private readonly int rating;
    public Player(int rating) => this.rating = rating;
    public int GetRating() => rating;
}

// ------------------------------------------------

public class GameServer
{
    public void StartGame(Player player1, Player player2)
    {
        // Logic to transition players to a live game server
        Console.WriteLine($"Game started between {player1.GetRating()} and {player2.GetRating()}");
    }
}
// ------------------------------------------------

public class QueueEntry : IComparable<QueueEntry>
{
    public Player Player { get; set; }
    public int Rating { get; set; }
    public long Id { get; set; }

    public int CompareTo(QueueEntry other)
    {
        int cmp = Rating.CompareTo(other.Rating);
        
        // If ratings are identical, sort by arrival order (Id) to maintain uniqueness
        if (cmp == 0) 
		    return Id.CompareTo(other.Id);
        
        return cmp;
    }
}

// ------------------------------------------------

public class MatchMaker
{
    private readonly int maxDifference;
    private readonly GameServer gameServer;
    private readonly SortedSet<QueueEntry> waitingPool;
    private long nextId;

    public MatchMaker(int maxDifference, GameServer gameServer)
    {
        this.maxDifference = maxDifference;
        this.gameServer = gameServer;
        this.waitingPool = new SortedSet<QueueEntry>();
        this.nextId = 0;
    }

    public void AddPlayer(Player player)
    {
        int rating = player.GetRating();

        // Define the acceptable inclusive rating range
        var minBound = new QueueEntry { Rating = rating - maxDifference, Id = long.MinValue };
        var maxBound = new QueueEntry { Rating = rating + maxDifference, Id = long.MaxValue };

        // Get all currently waiting players within the valid skill range
        var validMatches = waitingPool.GetViewBetween(minBound, maxBound);

        if (validMatches.Count > 0)
        {
            // A valid match exists. We greedily pick the first available one.
            QueueEntry opponent = validMatches.Min;
            
            waitingPool.Remove(opponent);
            gameServer.StartGame(player, opponent.Player);
        }
        else
        {
            // No valid match found, add to the waiting pool
            waitingPool.Add(new QueueEntry 
            { 
                Player = player, 
                Rating = rating, 
                Id = nextId++ 
            });
        }
    }
}		
	

```