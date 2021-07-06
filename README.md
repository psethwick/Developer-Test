# Seth's Coin Shop
## Approach

Went for a really basic (but SOLID) simple C# class-based approach for the core `Cart` functionality.

An `Item` has a name and a price.

`Cart` is responsible for holding any number of items and calculating totals.

A `Cart` also has a `DiscountRepository` which just holds available code/discount pairs.

The UI is built with [Terminal.Gui](https://github.com/migueldeicaza/gui.cs), which I had been meaning to try out since I read about it on Scott Hanselman's excellent [blog](https://www.hanselman.com/blog/its-2020-and-it-is-time-for-text-mode-with-guics).

## With More Time

Some CI with GitHub actions. I've used them before, but not tried it out with C#.

### coinshop.core

`Item` should have some kind of unique `Id` instead of treating `Name` as if it were one. The `IEquality<T>` methods would use `Id` instead as well.

Definitely would need some kind of `Inventory`, it should not be a concern of `coinshop.ui`.

Add some (not in-memory) storage mechanism for the `Cart` items. `DiscountRepository` and `Inventory` should also have some storage.

Some dependency injection, I didn't already do it because it would have felt like over-engineering with only in-memory storage. Should be a relatively straightforward drop-in with how it's already composed.

Validation! Currently it's possible to have a negative quantity of an item, which I'm not sure makes sense, for example.

### coinshop.ui

I'm not that happy with the overall layout/alignment, so I would spend some time re-designing it and wrangling `Terminal.Gui`

It's currently not possible to remove items from the `Cart` and it probably should be.

I feel like there must be a better way to do binding/refresh in `Terminal.Gui`, would be nice to tidy that up.

Would be nice to get some user interface tests in!