using Terminal.Gui;
using System.Collections.Generic;
using System.Linq;
using coinshop.core;

namespace coinshop.ui
{
	internal static class Program
	{
		private static void Main()
		{
			Application.Init();

			var forSale = new List<Item>
			{
				new ("Coin", 3),
				new ("Expensive Coin", 10)
			};
			
			var cart = new Cart(new DiscountRepository(
				new Dictionary<string, decimal>
				{
					{ "seth", .9M }
				}
			));

			var top = Application.Top;

			var shop = SetUpUserInterface(forSale, cart);
			top.Add(shop);
			Application.Run();
		}
		
		private static Window SetUpUserInterface(IEnumerable<Item> items, Cart cart)
		{
			var coinShop = new Window ("Seth's Coin Shop"){
				X = 1,
				Y = 1,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};					

			var discountLabel = new Label("Discount: ")
			{
				X = 1,
				Y = 2,
				Width = 12,
				Height = 1
			};
			var discountField = new TextField("")
			{
				X = Pos.Right(discountLabel),
				Y = 2,
				Width = 12,
				Height = 1
			};
			
			var startAt = Pos.Bottom(discountField);
			
			var forSale = new FrameView ("For Sale") {
				X = 0,
				Y = startAt,
				Width = Dim.Percent (30),
				Height = 10
			};
			
			var cartView = new FrameView ("Cart") {
				X = Pos.Right(forSale),
				Y = startAt,
				Width = Dim.Percent (70),
				Height = 10
			};
			
			discountField.Changed += (_, _) =>
			{
				cart.ApplyDiscount(discountField.Text.ToString());
				UpdateCart(cartView, cart);
			};

			var i = 0;
			foreach (var item in items)
			{
				var button = new Button($"{item.Price} - {item.Name}")
				{
					Y = i,
				};
				i++; // otherwise we end up drawing over
				button.Clicked += () =>
				{
					cart.AddItem(item, 1);
					UpdateCart(cartView, cart);
				};
				forSale.Add(button);
			}
			
			coinShop.Add (
				discountLabel,
				discountField,
				forSale,
				cartView
			);
			
			return coinShop;
		}
		private static void UpdateCart(View cartView, Cart cart)
		{
			cartView.RemoveAll(); // I'm sure there must be a _right_ way to do this
			var list = new List<string>(cart.Items()
				.Select(i => $"{i.Value}x {i.Key.Name} = {i.Value * i.Key.Price}").ToList())
			{
				"----",
				$"SubTotal: {cart.SubTotal()}", 
				$"Total: {cart.Total()}"
			};
			cartView.Add(new ListView(list));
			cartView.Redraw(cartView.Bounds);
		}
	}
}
