Task 2.1 — Research: IReadOnlyDictionary & SortedDictionary
### IReadOnlyDictionary<TKey, TValue>

الـ`IReadOnlyDictionary<TKey, TValue>` ده **interface** أصلاً، وبيمثل a generic read-only collection of key-value pairs.

يعني مثلاً أنا عايز أتعامل مع collection على إنها Dictionary، لكن من خلال الـinterface ده المستخدم يقدر يقرأ منها فقط، زي إنه يجيب الـ`Key` والـ`Value`، يعرف الـ`Count`، أو يعمل `ContainsKey` و`TryGetValue`، لكن مش يقدر يعمل `Add` أو `Remove`.

الـ`IReadOnlyDictionary` نفسه بيحدد الـcontract، لكن مش بيحدد الـimplementation بتاع الـmethods دي. أي class يعمل implementation للـinterface لازم يوفر الـmembers الموجودة فيه.

الـ`Dictionary<TKey,TValue>` بيـimplement الـ`IDictionary<TKey,TValue>` وفي نفس الوقت بيـimplement الـ`IReadOnlyDictionary<TKey,TValue>`، والـ`SortedDictionary<TKey,TValue>` برضه بيـimplement الاتنين.

فالفرق إن لما أتعامل مع object من نوع `Dictionary` أو `SortedDictionary` مباشرة، أقدر أستخدم الـmethods والـproperties الخاصة بالـclass والـmethods بتاعت الـ`IDictionary` اللي تسمحلي بالتعديل. لكن لو الـpublic method بترجع `IReadOnlyDictionary`، فهي بتقول للـcaller: "أنا هديك Dictionary تقدر تقرأ منه، لكن مش المفروض تعدل عليه من خلال الـreference ده."

وده بيخلي الـpublic method أقل ارتباطًا بـimplementation معينة؛ لأنها بتقول إنها محتاجة dictionary للقراءة فقط، ومش محتاجة الـcaller يعرف هل الـobject الحقيقي `Dictionary` ولا `SortedDictionary` أو implementation تانية.

---

### SortedDictionary<TKey, TValue>

الـ`SortedDictionary<TKey, TValue>` عبارة عن **concrete class** used to store data على هيئة key-value pairs، زي الـ`Dictionary` بالضبط.

لكن الفرق الأساسي إن الـ`SortedDictionary` بيحافظ على الـelements **sorted based on the key**، باستخدام comparer للـkeys.

يعني لو عندي keys:

`30, 10, 20`

فالـ`SortedDictionary` لما أعمل enumeration عليه هلاقيهم بالترتيب:

`10, 20, 30`.

أما الـ`Dictionary` فمش بستخدمه لما أكون محتاج إن الـkeys تكون مرتبة.

كمان فيه فرق في الـlookup speed. الـ`Dictionary` بيعتمد على hashing، ولذلك الـlookup فيه عادةً بيكون **O(1)**.

أما الـ`SortedDictionary` فبيعتمد على structure بتحافظ على ترتيب الـkeys، والـlookup فيه **O(log n)**.

فأنا أستخدم `Dictionary` لما يكون أهم حاجة عندي سرعة الـlookup ومش محتاج ترتيب للـkeys.

وأستخدم `SortedDictionary` لما أكون محتاج إن الـdata تفضل مرتبة حسب الـkey، ومحتاج أتعامل مع الـkeys وهي مرتبة، حتى لو ده معناه إن الـlookup هيكون أبطأ من الـ`Dictionary`.

### In short

* `IReadOnlyDictionary` → **interface** بيحدد read-only contract للـkey-value collection.
* `Dictionary` → **concrete class** بيستخدم hashing وبيوفر عادةً O(1) lookup.
* `SortedDictionary` → **concrete class** بيحافظ على ترتيب الـkeys، والـlookup فيه O(log n).
* `IReadOnlyDictionary` مش معناه إن الـobject نفسه immutable، هو بس بيحدد إن الـreference ده يسمح بالقراءة فقط.
============================================
Task 2.2 — Pick the Collection
Dictionary
→ key → value lookup

HashSet
→ unique values

List
→ ordered sequence + duplicates + index access

IReadOnlyDictionary
→ dictionary-shaped data exposed for reading

SortedDictionary
→ key → value + keys stay sorted

IEnumerable
→ sequence that can be iterated
