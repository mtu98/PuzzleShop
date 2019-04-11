//create connection
con = new Mongo();
//find database, if not exist, create
db = con.getDB("PuzzleShopDB");
//Insert Sample into Orders
var rubik3x3 = db.Toy.findOne({Name: "Rubik 3x3"})._id;

var rubik4x4 = db.Toy.findOne({Name: "Rubik 4x4"})._id;
db.Orders.insertMany(
	[
	{
		OrderDate: "10-7-2018",
		Username: "nmt",
		OrderItems:
		[
		{
			ToyID: rubik3x3,
			Quantity: 2
		}],
		Total: 31.98,
		Status:1
	},
	{
		OrderDate: "8-6-2018",
		Username: "ttn",
		OrderItems:
		[
		{
			ToyID: rubik4x4,
			Quantity: 2
		}],
		Total: 45.98,
		Status:1
	}]

	)
//show inserted result
print("Orders Collection");
result = db.Orders.find().toArray();
printjson(result);