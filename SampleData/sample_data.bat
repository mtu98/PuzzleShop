@echo off

where mongo

if errorlevel 1 (
	echo "Can't find mongo.exe, please add %MONGO_HOME%\bin to PATH"
	EXIT /B 1)

mongo PuzzleShopDB --eval "db.dropDatabase()"

mongo PuzzleShopDB.js
mongo Toy.js
mongo Orders.js

pause