# Part 03 — answers

---

## BlockedUsers

- Time complexity before: O(n · m), where n = requestIds (5,000) and m = blockedIds (50,000). `List.Contains` is a linear scan, performed once per request.
- Time (ms) before: time=55 ms
- What did you change? Copied blockedIds into a `HashSet<int>` once, then used `Contains` on the set for each request.
- Time complexity after: O(n + m). Building the set is O(m), and each lookup is O(1) on average.
- Time (ms) after:  time=1 ms

---

## Students

- What was the problem? `GetAllStudents` built a `List<Student>` with all 1,000,000 students (and their name strings) before returning, even though the caller only reads 3 and breaks.
- What did you change? Changed the return type to `IEnumerable<Student>` and replaced the list with `yield return`. Students are now created lazily, one at a time, as the `foreach` asks for them, so stopping after 3 creates only 3.