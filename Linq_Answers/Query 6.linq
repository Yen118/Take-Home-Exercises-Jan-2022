<Query Kind="Expression">
  <Connection>
    <ID>740a2c4c-47ea-4921-b17c-463463430886</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-VGOS6SS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//List all the products a customer (use Customer #1) has purchased and the number of times the product was purchased.
//Order by number of times purchased then description.

from person in Customers
where person.CustomerID == 1
select new 
{
   Customer = person.LastName + ", " + person.FirstName,
   OrderCount = person.Orders.Count,
   Items = from sale in person.Orders
           from item in sale.OrderLists
		   group item by item.Product into solditems
		   orderby solditems.Count() descending, solditems.Key.Description
		   select new
		   {
		       Description = solditems.Key.Description,
			   TimesBought = solditems.Count()
		   }
}