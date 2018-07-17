//create connection
con = new Mongo();
//find database, if not exist, create
db = con.getDB("PuzzleShopDB");
//insert into Account collection, if not exist, create
//list of Account insert[]
db.User.insertMany(
	[
	{
	Username:"admin",
	PasswordHash:"21232f297a57a5a743894a0e4a801fc3",
	FirstName:"admin",
	LastName:"admin",
	Email:"admin@puzzleshop.com",
	Role:0,
	},
	{
	Username:"nmt",
	PasswordHash:"202cb962ac59075b964b07152d234b70",
	FirstName:"Tu",
	LastName:"Nguyen",
	Email:"tunguyen@gmail.com",
	Role:1,
	},
	{
	Username:"ttn",
	PasswordHash:"250cf8b51c773f3f8dc8b4be867a9a02",
	FirstName:"Nhan",
	LastName:"Tran",
	Email:"nhantran@gmail.com",
	Role:1,
	}
	]
	)
db.User.createIndex({username:1},{unique:true,name:"UNIQUE USERNAME"});
db.User.createIndex({email:1},{unique:true,name:"UNIQUE EMAIL"});
//Show inserted result
print("User Collection");
result = db.User.find().toArray();
printjson(result);
