using ICT2ConAppDemoCS;

Product product = new Product();
product.Name = "Computer";
product.ProductID = 1;
product.Rate = 50000;
product.Qty = 10;
product.MinRequiredQty = 5;
product.MaxCapatity = 20;
product.Stock_Low += new StockHandler(ProductManager.LowInventoryEvent);

Console.WriteLine(product);

product.Sell = 6;

Console.WriteLine("==================================");
Console.WriteLine(product);

product.Buy = 17;

Console.WriteLine("==================================");
Console.WriteLine(product);


