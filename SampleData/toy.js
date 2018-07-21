con = new Mongo();
db = con.getDB("PuzzleShopDB");

//insert toy
db.Toy.insertMany(
    [
    {
    	_id: "T01",
        ToyName:"Rubik 3x3",
        ToyType:"Rubik",
        Producer:"Xiao Xi",
        SizeX:3,
        SizeY:3,
        SizeZ:3,
        Price:15.99,
        Quantity:50,
        YearOfManufacture: 2018,
        Description:"",
        PhotoURL:"",
        Review:[
        {
            Name:"ABC",
            Email: "guest@gmail.com",
            Title:"Good",
            Content: "This thing is great, my kids love it!",
            Star: 5,
            Date:"1-1-2018",
        },
        {
            Name:"DEF",
            Email: "anotherguest@gmail.com",
            Title:"Fine",
            Content: "Great product",
            Star: 4,
            Date:"5-1-2018",
        }]
    },
    {
    	_id: "T02",
        ToyName:"Rubik 4x4",
        ToyType:"Rubik",
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
    	_id: "T03",
        ToyName:"Rubik 4x3",
        ToyType:"Rubik",
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
    	_id: "T04",
        ToyName:"1000 pieces puzzle",
        ToyType:"Puzzle",
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
    	_id: "T05",
        ToyName:"2000 pieces puzzle",
        ToyType:"Puzzle",
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

db.Toy.insertMany(
    [
    {
    	_id: "T06",
        ToyName: "RUBIK’S TOWER",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 2,
        SizeY: 2,
        SizeZ: 4,
        Price: 14.49,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "The Rubik’s Tower (or 2x2x4 Rubik’s Cube) is an interesting twist on the original Rubik’s Cube. Imagine two 2x2 Rubik’s Cubes that rotate around the central axis allowing this puzzle to shape-shift. That’s right - it makes it very difficult to solve! This puzzle is sold in classic Hungarian packaging; similar in design to what the original Rubik’s Cube was retailed in when it first appeared. It is packaged in Hungary at Erno Rubik’s (the inventor of the Rubik’s Cube) very own studio and acts as a collector’s item as well as a fantastic toy. Be sure the rows are correctly aligned before turning the Rubik’s Tower and never use excessive force.",
        PhotoURL: "img/Products/tower_1__enlarged.png"
    }, 
    {
    	_id: "T07",
        ToyName: "RUBIK’S TWIST",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 1,
        SizeY: 1,
        SizeZ: 24,
        Price: 14.49,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "The Rubik’s Twist is a twisting puzzle challenge that takes the form of thousands of shapes. Solve one shape and move onto another - or devise your own creation to defy your friends. Rubik’s Snake - it’ll charm you! The Rubik’s Snake (also known as the Rubik’s Twist) is one of the puzzles invented by Erno Rubik (inventor of the Rubik’s Cube). Rather than a single solution, the Rubik’s Snake can be used to create a variety of wonderful shapes, including a snake, ball, cat, dog and many more? How many can you find and create? The Rubik’s Snake is created from 24 triangular prisms attached face to face and able to rotate 360 degrees letting you transform it into almost any shape. So let your imagination run wild! You can even attach multiple Rubik’s Snakes to create new outlandish shapes – what can you create?",
        PhotoURL: "img/Products/twist_1___enlarged.png"
    }, 
    {
    	_id: "T08",
        ToyName: "RUBIK’S SNAKE",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 1,
        SizeY: 1,
        SizeZ: 24,
        Price: 14.49,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "The Rubik’s Snake is a twisting puzzle challenge that takes the form of thousands of shapes. Solve one shape and move onto another - or devise your own creation to defy your friends. Rubik’s Snake - it’ll charm you! The Rubik’s Snake (also known as the Rubik’s Twist) is one of the puzzles invented by Erno Rubik (inventor of the Rubik’s Cube). Rather than a single solution, the Rubik’s Snake can be used to create a variety of wonderful shapes, including a snake, ball, cat, dog and many more? How many can you find and create? The Rubik’s Snake is created from 24 triangular prisms attached face to face and able to rotate 360 degrees letting you transform it into almost any shape. So let your imagination run wild! You can even attach multiple Rubik’s Snakes to create new outlandish shapes – what can you create? This purchase is for 1 Rubik’s Snake only",
        PhotoURL: "img/Products/snake_3__enlarged.png"
    }, 
    {
    	_id: "T09",
        ToyName: "RUBIK’S VOID",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 3,
        SizeY: 3,
        SizeZ: 3,
        Price: 16.49,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "Rubik’s, the makers of the world’s best-selling puzzle, bring you: The New Void Cube. The classic Void Cube now in Rubik’s colours! (Red, Orange, Yellow, Green, Blue & White). Void is a HOLE new puzzle, with a HOLE new challenge. This evolution of the original 3x3 Rubik’s Cube was designed by Katsuhiko Okamoto. The Void has missing centre cubes that make this puzzle harder than an original 3x3 Rubik’s cube to solve. This cube is truly amazing to behold, leaving your brain void of answers to the question: “how can that Rubik’s Cube have a hole in the middle and still work? The Void Cube is another incredibly addictive, multi-dimensional challenge that will fascinate puzzle fans as much as the Original Rubik’s Cube has done for over three decades. With so many possible colour combinations and only one solution, everyone who has ever played with the Rubik’s Cube will want to play with The Void. Twist and turn The Void to return the six coloured rings to their complete state and you will find this cube puzzle really is amazing to see, to touch and to play with. Get sucked into the fun and enjoyment of The Rubik’s Void Cube.",
        PhotoURL: "img/Products/void_1__enlarged.png"
    }, 
    {
    	_id: "T10",
        ToyName: "RUBIK’S 2X2 CUBE",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 2,
        SizeY: 2,
        SizeZ: 2,
        Price: 8.99,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "This is the new Rubik’s 2x2 with tough tiles. The traditional stickers have been replaced with plastic; which mean no fading, peeling or cheating! It also has a brand new mechanism that results in a smoother, faster and more reliable Rubik’s Cube. It might look easy but don’t be fooled – it is still a challenge. The 2x2 Rubik’s Cube (also known as the pocket or mini cube) consists of 8 corner cubies and operates in much the same way as its bigger brother – the Rubik’s Cube. As it is smaller than the traditional Rubik’s cube it can be more easily slipped into a pocket or bag, making it the perfect item to take on a bus, train or aeroplane. It also makes a great present for younger puzzle enthusiasts who might not be ready for a fully-fledged 3x3 Rubik’s Cube. The Rubik’s 2x2 Cube has 3,674,160 permutations and only one solution! Due to the new smoother movement, the 2x2 cube cannot be taken apart and hence we cannot replace any cubes that are broken as a result of attempted dis-assembly. No Hint Booklet or Stand included.",
        PhotoURL: "img/Products/2x2_4__enlarged.png"
    }, 
    {
    	_id: "T11",
        ToyName: "RUBIK’S JUNIOR KITTEN",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 1,
        SizeY: 2,
        SizeZ: 3,
        Price: 9.99,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "The Rubik’s Junior Kitten is the ideal puzzle for little problem solvers. The cute twistable character is so easy to grip and turn. Twist the blocks to create a crazy mixed-up animal, but with relatively few combinations. It is easy to solve whist keeping your child entertained. With 4 animals to collect… Bunny, Bear, Puppy & Kitten! AGES 3-9",
        PhotoURL: "img/Products/kitten__enlarged.png"
    }, 
    {
    	_id: "T12",
        ToyName: "MY FIRST CUBE",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 2,
        SizeY: 2,
        SizeZ: 2,
        Price: 6.99,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "This soft, brain-building toy turns like a real Rubik’s Cube–little ones develop motor skills and color recognition as they play! With no pieces to lose and a compact design, this mind-bender is ideal for on-the-go play. Kids can hardly put it down!",
        PhotoURL: "img/Products/my_first_cube__enlarged.png"
    }, 
    {
    	_id: "T13",
        ToyName: "BLANK CUBE",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 3,
        SizeY: 3,
        SizeZ: 3,
        Price: 9.99,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "Exactly what it says on the tin!! It’s a blank 3x3 cube – in case you want to buy your stickers separately and apply them or you want to create a custom cube. With this blank cube you can make amazing personalised gifts, customise the colours of your Rubik’s Cube, or even create joke or unsolvable cubes.",
        PhotoURL: "img/Products/blank_cube__enlarged.png"
    }, 
    {
    	_id: "T14",
        ToyName: "RUBIK’S 3X3 KEYCHAIN",
        ToyType: "Rubik",
        Producer: "Rubiks",
        SizeX: 3,
        SizeY: 3,
        SizeZ: 3,
        Price: 7.99,
        Quantity: 50,
        YearOfManufacture: 2018,
        Description: "Rubik’s 3X3 Cube Keychain is the exact same and incredibly addictive, multi-dimensional challenge that has fascinated puzzle fans around the world since 1980… but much smaller. The Rubik’s Cube keychain is small enough to fit on your keys, so you really can take it anywhere! The Rubik’s Cube is the classic colour-matching puzzle that’s a great mental challenge at home or on the move. Turn and twist the sides of the cube so that each of the six faces only has one colour. Over “43 Quintillion” (that’s 43 with 18 zeros to you and me) moves are possible with this original 3x3 Cube, but there is only one solution! With lots of practice you can solve it in under 10 seconds! Rubik’s Cube is the incredibly addictive, and has fascinated fans since it arrived in 1980. A must for puzzle lovers, the aim is to twist and turn the Rubik’s Cube to return it to its original state, with every side having one solid colour. For those who struggle to master this challenge - or simply lack the patience - we have provided a guide with the simplest ever Rubik’s Cube solution. With this retro puzzle hours of challenging fun lie ahead.",
        PhotoURL: "img/Products/3x3_key_1__enlarged.png"
    }
    ]
)

//show inserted result
print("Toy Collection");
result = db.Toy.find().toArray();
printjson(result);