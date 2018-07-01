//create connection
con = new Mongo();
//find database, if not exist, create
db = con.getDB("PuzzleShopDB");
//insert into Account collection, if not exist, create
//list of Account insert[]
db.Account.insertMany(
	[
	{
	username:"admin",
	passwordHash:"21232f297a57a5a743894a0e4a801fc3",
	firstName:"admin",
	lastName:"admin",
	email:"admin@puzzleshop.com",
	role:0,
	},
	{
	username:"nmt",
	passwordHash:"202cb962ac59075b964b07152d234b70",
	firstName:"Tu",
	lastName:"Nguyen",
	email:"tunguyen@gmail.com",
	role:1,
	},
	{
	username:"ttn",
	passwordHash:"250cf8b51c773f3f8dc8b4be867a9a02",
	firstName:"Nhan",
	lastName:"Tran",
	email:"nhantran@gmail.com",
	role:1,
	}
	]
	)
//Show inserted result
print("Account Collection");
result = db.Account.find().toArray();
printjson(result);
//insert toy type
//hold a objectID value
var rubikID = db.ToyType.insertOne(
{
	ToyType:"Rubik"
}
	).insertedId;

var puzzleID = db.ToyType.insertOne(
{
	ToyType:"Puzzle"
}).insertedId
//show inserted result
print("ToyType Collection");
result = db.ToyType.find().toArray();
printjson(result);

//insert toy
db.Toy.insertMany(
	[
	{
		ToyName:"3x3 Rubik",
		ToyType:rubikID,
		Producer:"Xiao Xi",
		Size:"3x3",
		Price:80000,
		Quantity:50,
		Description:"",
		PhotoURL:"",
		Comment:[
		{
			username:"nmt",
			Content:"Good",
			Date:"1-1-2018",
		},
		{
			username:"ttn",
			Content:"Not bad",
			Date:"10-2-2018",
		}]
	},
	{
		ToyName:"4x4 Rubik",
		ToyType:rubikID,
		Producer:"Xi Meng",
		Size:"4x4",
		Price:120000,
		Quantity:50,
		Description:""
	},
	{
		ToyName:"3x4 Rubik",
		ToyType:rubikID,
		Producer:"Xi Xong",
		Size:"3x4",
		Price:110000,
		Quantity:60,
		Description:""
	},
	{
		ToyName:"100 pieces puzzle",
		ToyType:puzzleID,
		Producer:"ABC INC",
		Size:"100 pirces",
		Price:60000,
		Quantity:30,
		Description:""
	},
	{
		ToyName:"200 pieces puzzle",
		ToyType:puzzleID,
		Producer:"ABC INC",
		Size:"200 pirces",
		Price:100000,
		Quantity:10,
		Description:""
	}
	]);

//show inserted result
print("Toy Collection");
result = db.Toy.find().toArray();
printjson(result);

