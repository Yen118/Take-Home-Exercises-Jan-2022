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

//Create a Daily Sales per Store request for a specified month. 
//Order stores by city by location. For Sales, show order date, number of orders, 
//total sales without GST tax and total GST tax.


from place in Stores
orderby place.City, place.Location
select new
{
   City = place.City,
   Location = place.Location,
   Sales = from sale in place.Orders
           where sale.OrderDate >= new DateTime(2017, 12, 1)
		      && sale.OrderDate <= new DateTime(2017, 12, 31)
		   group sale by sale.OrderDate into dailySales
		   select new 
		   { 
		       Date = dailySales.Key,
			   NumberOfOrders = dailySales.Count(),
			   ProductSales = dailySales.Sum(s => s.SubTotal),
			   GST = dailySales.Sum(s => s.GST)
		   }
}