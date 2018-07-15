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
db.Account.createIndex({username:1},{unique:true,name:"UNIQUE USERNAME"});
db.Account.createIndex({email:1},{unique:true,name:"UNIQUE EMAIL"});
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
		ToyName:"Rubik 3x3",
		ToyType:rubikID,
		Producer:"Xiao Xi",
		SizeX:3,
		SizeY:3,
		SizeZ:3,
		Price:15.99,
		Quantity:50,
		YearOfManufacture: 2018,
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
		ToyName:"Rubik 4x4",
		ToyType:rubikID,
		Producer:"Xi Meng",
		SizeX:4,
		SizeY:4,
		SizeZ:4,
		Price:22.99,
		Quantity:50,
		YearOfManufacture: 2018,
		PhotoURL:"",
		Description:""
	},
	{
		ToyName:"Rubik 4x3",
		ToyType:rubikID,
		Producer:"Xi Xong",
		SizeX:4,
		SizeY:3,
		SizeZ:3,
		Price:20.50,
		Quantity:60,
		YearOfManufacture: 2018,
		PhotoURL:"",
		Description:""
	},
	{
		ToyName:"1000 pieces puzzle",
		ToyType:puzzleID,
		Producer:"ABC INC",
		SizeX:50,
		SizeY:20,
		Price:30.10,
		Quantity:30,
		YearOfManufacture: 2018,
		PhotoURL:"",
		Description:""
	},
	{
		ToyName:"2000 pieces puzzle",
		ToyType:puzzleID,
		Producer:"ABC INC",
		SizeX:80,
		SizeY:25,
		Price:39.99,
		Quantity:10,
		YearOfManufacture: 2018,
		PhotoURL:"",
		Description:""
	}
	]);
