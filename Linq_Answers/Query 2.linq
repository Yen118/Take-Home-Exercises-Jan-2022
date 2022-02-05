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

//We want a mailing list for a Valued Customers flyer that is being sent out. List the customer addresses for customers who have shopped at each store. 
//List by the store. Include the store location as well as the customer's address.
//Do NOT include the customer name in the results.


from place in Stores.AsEnumerable()
orderby place.Location
select new 
{
   Location = place.Location,
   Clients = ( from sale in place.Orders
               select new 
			   {
			      Address = sale.Customer.Address,
				  City = sale.Customer.City,
				  Province = sale.Customer.Province
			   }).Distinct()
}