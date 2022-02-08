<Query Kind="Statements">
  <Connection>
    <ID>740a2c4c-47ea-4921-b17c-463463430886</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-VGOS6SS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//Print out all product items on a requested order (use Order #33). Group by Category and order by Product Description. 
//You do not need to format money as this would be done at the presentation level. 
//Use the QtyPicked in your calculations. 
//Hint: You will need to using type casting (decimal). Use of the ternary operator will help.


var orderId = 33;
var result = from item in OrderLists
           where item.OrderID == orderId
		   group item by item.Product.Category into cate
		   orderby cate.Key.Description
		   select new 
		   {
		      Category = cate.Key.Description,
			  OrderProducts = from x in cate
			                  orderby x.Product.Description
							  select new 
							  {
							     Product = x.Product.Description,
								 Price = x.Price,
								 PickedQty = x.QtyPicked,
								 Discount = x.Discount,
								 SubTotal = (decimal)x.QtyPicked * x.Price - x.Discount,
								 Tax = x.Product.Taxable? ((decimal)x.QtyPicked * x.Price - x.Discount) * 0.05m : 0.00m,
								 ExtendedPrice = ( (decimal)x.QtyPicked * x.Price - x.Discount) + (x.Product.Taxable? ((decimal)x.QtyPicked * x.Price - x.Discount) * 0.05m : 0.00m)
							  }
		   };
result.Dump();