<Query Kind="Statements">
  <Connection>
    <ID>c374505e-cbbe-4834-b171-2bc918e30907</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-VGOS6SS</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//Generate a report on store orders and sales.
//Group this report by store. Show the total orders, the average order size (number of items per order) and average pre-tax revenue.


var result = from item in Stores
             select new 
			 {
			     Location = item.Location,
				 Orders = from or in Orders
				          select new 
						  {
						    
						  }
			 }
           