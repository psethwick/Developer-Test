# Seth's Coin Shop
## Approach

Went for a really basic (but SOLID) simple C# class-based approach for the core `Cart` functionality.

An `Item` has a name and a price.

`Cart` is responsible for holding any number of items and calculating totals.

A `Cart` also has a `DiscountRepository` which just holds available code/discount pairs.

The UI is built with [Terminal.Gui](https://github.com/migueldeicaza/gui.cs), which I had been meaning to try out since I read about it on Scott Hanselman's excellent [blog](https://www.hanselman.com/blog/its-2020-and-it-is-time-for-text-mode-with-guics).

## With More Time

### coinshop.core

Definitely would need some kind of `Inventory` next, it should not be a concern of `coinshop.ui`.

Add some (not in-memory) storage mechanism for the `Cart` items. `DiscountRepository` and `Inventory` should also have some storage.

Some dependency injection, I didn't already do it because it would have felt like over-engineering with only in-memory storage. Should be a relatively straightforward drop-in with how it's already composed.

### coinshop.ui

I'm not that happy with the overall layout/alignment, so I would spend some time re-designing it and wrangling `Terminal.Gui`

Would be nice to get some user interface tests in!