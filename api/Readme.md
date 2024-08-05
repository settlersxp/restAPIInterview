# Database migration - up
1. Add-Migration initial
2. Check the migration file
3. Update-Database

or:
dotnet tool install --global dotnet-ef

1. dotnet ef migrations add initial
2. dotnet ef database update


# TODOs:
1. Remove the id from the saving DTO - (done)
2. Fix Patch method - (done)
3. Use a service or repository instead of directly accessing the database in the controller - (done)
4. Add authentication - (done)
5. Add model validation - (done)
6. Add unit tests
