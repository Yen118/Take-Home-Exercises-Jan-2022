<Query Kind="Expression">
  <Connection>
    <ID>e7c1ce88-7056-48e6-b7da-53c5a62ce380</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-VGOS6SS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>GroceryList</Database>
  </Connection>
</Query>

// Create a product list which indicates what products are purchased by our customers and how many times 
//that product was purchased. Order the list by most popular product then by alphabetic description.

from item in Products
orderby item.OrderLists.Count descending, item.Description
select new
{ 
    Product = item.Description,
	TimePurchased = item.OrderLists.Count
}